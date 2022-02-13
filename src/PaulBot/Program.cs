using PaulBot.Configuration;
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
        
        services.AddDiscordBot();
    })
    .Build();

await host.RunAsync();