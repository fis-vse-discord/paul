using Microsoft.EntityFrameworkCore;
using PaulBot.Discord.Verification.Models;

namespace PaulBot.Data;

public class PaulBotDbContext : DbContext
{
    public PaulBotDbContext(DbContextOptions<PaulBotDbContext> options) : base(options)
    {
    }

    public DbSet<MemberVerification> Verifications { get; set; } = null!;
}