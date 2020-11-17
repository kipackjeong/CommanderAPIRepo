using System;
using System.Collections.Generic;
using System.Linq;
using CommanderAPI.Models;

namespace CommanderAPI.Data
{
  public class SqlCommanderRepo : ICommanderAPIRepo
  {
    private readonly CommanderContext _context;

    public SqlCommanderRepo(CommanderContext context)
    {
        _context = context;

    }

    public IEnumerable<Command> GetAllCommands()
    {
                        // DbSet
        return _context.Commands.ToList();
    }

    public Command GetCommandByID(int id)
    {
        return _context.Commands.FirstOrDefault(p => p.ID == id);
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }



    public void CreateCommand(Command cmd)
    {
      if(cmd == null)
        throw new ArgumentNullException(nameof(cmd));
      
                //DbSet
      _context.Commands.Add(cmd);
    }

    public void UpdateCommand(Command cmd)
    {
      // Nothing
    }
  }
}