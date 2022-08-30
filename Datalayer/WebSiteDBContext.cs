namespace Datalayer;
using Microsoft.EntityFrameworkCore;

public class WebSiteDBContext : DbContext
{
    public WebSiteDBContext(): base() {}
    public WebSiteDBContext(DbContextOptions options) : base(options) {}

    public DbSet<User> Users {get; set;}

    public DbSet<Pokemon> Pokemon{get;set;}

    public DbSet<Match> Matches{get;set;}
}