using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ScopeMed.Core.Models;
using ScopeMed.Application.Interface;
using System.Text.Json;

namespace ScopeMed.Functions
{
    public class SignUpFunction
    {
        private readonly ILogger<SignUpFunction> _logger;
        private readonly ISignUpService _signUpService;


        public SignUpFunction(ILogger<SignUpFunction> logger, ISignUpService signUpService)
        {
            _logger = logger;
            _signUpService = signUpService;
        }

        [Function("SignUpFunction")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get","post")] HttpRequest req)
        {
            _logger.LogInformation("Processing signup request.");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonSerializer.Deserialize<UserSignUpData>(requestBody);
            if (data == null || string.IsNullOrWhiteSpace(data.Email) || string.IsNullOrWhiteSpace(data.Password))
            {
                return new BadRequestObjectResult("Invalid input");
            }
            var user = new User { Email = data.Email };
            bool isSignUpSuccessful = await _signUpService.RegisterUserAsync(user, data.Password);
            if (isSignUpSuccessful)
            {
                return new OkObjectResult("Signup successful!");
            }
            else
            {
                return new BadRequestObjectResult("Invalid credentials.");
            }
            
        }
        private class UserSignUpData
        {
            public required string Email { get; set; }          //Email must be required
            public required string Password { get; set; }       //Password must be required
            public required string FirstName { get; set; }      
            public required string LastName { get; set; }
        }
    }
}
