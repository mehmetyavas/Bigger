using System.Threading;
using System.Threading.Tasks;
using Business.BusinessAspects;
using Business.Constants;
using Business.Handlers.Authorizations.ValidationRules;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Authorizations.Commands
{
    public class RegisterUserCommand : IRequest<IResult>
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }


        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, IResult>
        {
            private readonly IUserRepository _userRepository;

            private readonly IUserGroupRepository _userGroupRepository;
            private readonly IGroupRepository _groupRepository;

            public RegisterUserCommandHandler(IUserRepository userRepository, IUserGroupRepository userGroupRepository,
                IGroupRepository groupRepository)
            {
                _userRepository = userRepository;
                _userGroupRepository = userGroupRepository;
                _groupRepository = groupRepository;
            }


            [ValidationAspect(typeof(RegisterUserValidator), Priority = 2)]
            [CacheRemoveAspect()]
            [LogAspect(typeof(PostgreSqlLogger))]
            public async Task<IResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                var isThereAnyUser = await _userRepository.GetAsync(u => u.Email == request.Email);

                if (isThereAnyUser != null)
                {
                    return new ErrorResult(Messages.NameAlreadyExist);
                }

                var group = await _groupRepository.GetAsync(x => x.GroupName == "user");
                if (group is null)
                {
                    _groupRepository.Add(new Group { GroupName = "user" });
                    await _groupRepository.SaveChangesAsync();

                    group = await _groupRepository.GetAsync(x => x.GroupName == "user");
                }

                HashingHelper.CreatePasswordHash(request.Password, out var passwordSalt, out var passwordHash);
                var user = new User
                {
                    Email = request.Email,
                    Username = request.Username,
                    FullName = request.FullName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                };

                _userRepository.Add(user);
                await _userRepository.SaveChangesAsync();


                var getUser = await _userRepository.GetAsync(x => x.Email == request.Email);


                _userGroupRepository.Add(new UserGroup
                {
                    GroupId = group.Id,
                    UserId = getUser.UserId
                });
                await _userGroupRepository.SaveChangesAsync();

                return new SuccessResult(Messages.Added);
            }
        }
    }
}