using Microsoft.EntityFrameworkCore;
using PaulBot.Discord.Subjects.Models;
using PaulBot.Discord.Verification.Models;

namespace PaulBot.Data;

public class PaulBotDbContext : DbContext
{
    public PaulBotDbContext(DbContextOptions<PaulBotDbContext> options) : base(options)
    {
    }

    public virtual DbSet<MemberVerification> Verifications { get; set; } = null!;
    
    public virtual DbSet<Subject> Subjects { get; set; } = null!;
}