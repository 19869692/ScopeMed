using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ScopeMed.Interface.Interfaces;
using ScopeMed.Core.Interfaces;

namespace ScopeMed.Functions
{
    public class LoginFunction
    {
        private readonly ILogger<LoginFunction> _logger;
        private readonly ILoginService _loginService;

        public LoginFunction(ILogger<LoginFunction> logger, ILoginService loginService)
        {
            _logger = logger;
            _loginService = loginService;
        }

        [Function("LoginFunction")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            UserLoginData data = JsonSerializer.Deserialize<UserLoginData>(requestBody);

            bool isLoginSuccessful = await _loginService.ValidateCredentialsAsync(data.Email, data.Password);

            if (isLoginSuccessful)
            {
                return new OkObjectResult("Login successful!");
            }
            else
            {
                return new UnauthorizedObjectResult("Invalid credentials.");
            }
        }

        private class UserLoginData
        {
            public required string Email { get; set; }          //Email must be required
            public required string Password { get; set; }       //Password must be required
        }
    }
}
