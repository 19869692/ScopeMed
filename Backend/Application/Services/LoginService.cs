using System.Threading.Tasks;
using BCrypt.Net;
using ScopeMed.Interface;
using ScopeMed.Application.Interface;

namespace ScopeMed.Application.Services
{
    public class LoginService : ILoginService   //LoginService class implements ILoginService interface
    {
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> ValidateCredentialsAsync(string email, string password)         //method from ILoginService interface
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            return user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        }
    }
}
