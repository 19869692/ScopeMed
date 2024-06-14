using ScopeMed.Core.Interfaces;
using ScopeMed.Infrastructure.Repositories;
using ScopeMed.Infrastructure.Services;
using ScopeMed.Interface.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScopeMed
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddSingleton<ILoginService, LoginService>();
            builder.Services.AddSingleton<ISignUpService, SignUpService>();
            builder.Services.AddSingleton<IUserRepository, UserRepository>();

        }
    }
}
