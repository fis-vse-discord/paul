using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using PaulBot.Configuration;
using PaulBot.Data;
using PaulBot.Discord.Verification.Configuration;
using PaulBot.Discord.Verification.Contracts;
using PaulBot.Discord.Verification.Services;
using PaulBot.Extensions;

var builder = WebApplication.CreateBuilder();

builder.Host.ConfigureAppConfiguration((context, configuration) =>
{
    configuration.AddEnvironmentVariables();

    if (context.HostingEnvironment.IsDevelopment())
    {
        configuration.AddUserSecrets<Program>(optional: true);
    }
});

builder.Host.ConfigureServices((context, services) =>
{
    var configuration = context.Configuration;

    services.Configure<DiscordConfiguration>(configuration.GetRequiredSection(DiscordConfiguration.Section));
    services.Configure<VerificationConfiguration>(
        configuration.GetRequiredSection(VerificationConfiguration.Section));

    services.AddDiscordBot();
    services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
        .AddMicrosoftIdentityWebApp(configuration.GetRequiredSection("Azure"));
    services.AddControllersWithViews(options =>
    {
        var policy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();

        options.Filters.Add(new AuthorizeFilter(policy));
    });
    services.AddTransient<IMemberVerificationService, MemberMemberVerificationService>();
    services.AddDbContext<PaulBotDbContext>(options =>
            options
                .UseNpgsql(configuration.GetConnectionString("Default"))
                .UseSnakeCaseNamingConvention(),
        ServiceLifetime.Transient,
        ServiceLifetime.Transient
    );
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();
