using ScopeMed.Core.Models;
using System.Threading.Tasks;

namespace ScopeMed.Application.Interface
{
    public interface ISignUpService
    {
        Task<bool> RegisterUserAsync(User user, string password);
    }
}
