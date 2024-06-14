using System.Threading.Tasks;

namespace ScopeMed.Application.Interface
{
    public interface ILoginService
    {
        Task<bool> ValidateCredentialsAsync(string email, string password);
    }
}
