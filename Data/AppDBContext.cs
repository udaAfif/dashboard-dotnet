using Microsoft.EntityFrameworkCore;
using dotNetDashboard.Models;

namespace dotNetDashboard.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
