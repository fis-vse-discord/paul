using Microsoft.EntityFrameworkCore;
using PaulBot.Configuration;
using PaulBot.Data;
using PaulBot.Discord.Verification.Configuration;
using PaulBot.Discord.Verification.Contracts;
using PaulBot.Discord.Verification.Services;
using PaulBot.Extensions;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, configuration) =>
    {
        configuration.AddEnvironmentVariables();
        
        if (context.HostingEnvironment.IsDevelopment())
        {
            configuration.AddUserSecrets<Program>(optional: true);
        }
    })
    .ConfigureServices((context, services) =>
    {
        var configuration = context.Configuration; 
        
        services.Configure<DiscordConfiguration>(configuration.GetRequiredSection(DiscordConfiguration.Section));
        services.Configure<VerificationConfiguration>(configuration.GetRequiredSection(VerificationConfiguration.Section));
        
        services.AddDiscordBot();
        services.AddTransient<IMemberVerificationService, MemberMemberVerificationService>();
        services.AddDbContext<PaulBotDbContext>(options => 
            options
                .UseNpgsql(configuration.GetConnectionString("Default"))
                .UseSnakeCaseNamingConvention()
        );
    })
    .Build();

await host.RunAsync();