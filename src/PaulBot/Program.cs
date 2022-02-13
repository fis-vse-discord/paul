var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, configuration) =>
    {
        configuration.AddEnvironmentVariables();
        
        if (context.HostingEnvironment.IsDevelopment())
        {
            configuration.AddUserSecrets<Program>(optional: true);
        }
    })
    .ConfigureServices(services =>
    {
        
    })
    .Build();

await host.RunAsync();