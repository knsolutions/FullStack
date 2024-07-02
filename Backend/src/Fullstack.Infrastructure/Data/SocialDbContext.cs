using Fullstack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fullstack.Infrastructure.Data;

public class SocialDbContext : DbContext
{
    public SocialDbContext(DbContextOptions<SocialDbContext> options) : base(options)
    {
        
    }

    public DbSet<Post> Posts { get; set; }


}
