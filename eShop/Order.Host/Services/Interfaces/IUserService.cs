using Order.Host.Models;

namespace Order.Host.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserInfoDto> GetUserInfoAsync(string userId);
    }
}
