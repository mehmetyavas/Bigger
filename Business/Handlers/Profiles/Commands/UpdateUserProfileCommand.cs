using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Business.Constants;
using Business.Services.Image;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using Microsoft.AspNetCore.Http;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Handlers.Profiles.Commands;

public class UpdateUserProfileCommand : IRequest<IResult>
{
    public required int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MobilPhone { get; set; }
    public string Email { get; set; }
    public IFormFile Avatar { get; set; }
}

public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, IResult>
{
    private IUserRepository _userRepository;
    private IImageService _imageService;

    public UpdateUserProfileCommandHandler(IUserRepository userRepository, IImageService imageService)
    {
        _userRepository = userRepository;
        _imageService = imageService;
    }

    public async Task<IResult> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {
        var userToUpdate = await _userRepository.GetAsync(x => x.UserId == request.UserId);
        if (userToUpdate is null)
            return new ErrorResult(Messages.UserNotFound);


        var url = userToUpdate.AvatarUrl;
        userToUpdate.FullName = $"{request.FirstName} {request.LastName}";
        userToUpdate.Email = request.Email;
        userToUpdate.MobilePhones = request.MobilPhone;

        _imageService.PathDir = "user";
        userToUpdate.AvatarUrl = await _imageService.UpdateImageAsync(request.Avatar, url);

        _userRepository.Update(userToUpdate);
        await _userRepository.SaveChangesAsync();

        return new SuccessResult();
    }
}