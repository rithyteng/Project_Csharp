using Microsoft.EntityFrameworkCore;

namespace game.Models
{
    public class MyContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get;set;}
        public DbSet <Characters> Characters{get;set;}
        // public DbSet<Act> Activities{get;set;}

        // public DbSet<Response> Responses{get;set;}
    }
}
