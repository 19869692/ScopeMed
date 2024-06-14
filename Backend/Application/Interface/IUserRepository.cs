using ScopeMed.Core.Models;
using System.Threading.Tasks;

namespace ScopeMed.Interface.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<bool> AddUserAsync(User user);
    }
}
