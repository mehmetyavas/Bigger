using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;

namespace Business.Handlers.Profiles.Commands;

public class UpdateUserProfileCommand : IRequest<IResult>
{
    public required int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MobilPhone { get; set; }
    public string Email { get; set; }
}

public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, IResult>
{
    private IUserRepository _userRepository;

    public UpdateUserProfileCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IResult> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {
        var userToUpdate = await _userRepository.GetAsync(x => x.UserId == request.UserId);
        if (userToUpdate is null)
            return new ErrorResult(Messages.UserNotFound);

        userToUpdate.FullName = $"{request.FirstName} {request.LastName}";
        userToUpdate.Email = request.Email;
        userToUpdate.MobilePhones = request.MobilPhone;

        _userRepository.Update(userToUpdate);
        await _userRepository.SaveChangesAsync();

        return new SuccessResult();
    }
}