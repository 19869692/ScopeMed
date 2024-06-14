using ScopeMed.Application.Interface;
using ScopeMed.Core.Models;
using System.Threading.Tasks;

namespace ScopeMed.Application.Services
{
    public class SignUpService : ISignUpService
    {
        private readonly IUserRepository _userRepository;

        public SignUpService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> RegisterUserAsync(User user, string password)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
            return await _userRepository.AddUserAsync(user);
        }
    }
}
