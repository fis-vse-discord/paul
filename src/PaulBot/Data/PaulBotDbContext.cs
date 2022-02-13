using Microsoft.EntityFrameworkCore;

namespace PaulBot.Data;

public class PaulBotDbContext : DbContext
{
    public PaulBotDbContext(DbContextOptions<PaulBotDbContext> options) : base(options)
    {
    }
}