using CommanderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderAPI.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {
            
        }


        public DbSet<Command> Commands {get;set;}


    }
}