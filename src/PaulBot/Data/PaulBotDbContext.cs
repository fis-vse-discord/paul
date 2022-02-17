using Microsoft.EntityFrameworkCore;
using PaulBot.Discord.Roles.Models;
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

    public virtual DbSet<SelfAssignableRole> SelfRoles { get; set; } = null!;
    
    public virtual DbSet<SelfAssignableRolesMenu> SelfRoleMenus { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder model)
    {
        base.OnModelCreating(model);

        model.Entity<SelfAssignableRolesMenu>()
            .HasMany(m => m.Roles)
            .WithOne(r => r.Menu)
            .HasForeignKey(r => r.RoleMenuId);
    }
}