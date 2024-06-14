using System.Threading.Tasks;

namespace ScopeMed.Core.Interfaces
{
    public interface ILoginService
    {
        Task<bool> ValidateCredentialsAsync(string email, string password);
    }
}
