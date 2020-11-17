using System.Collections.Generic;
using CommanderAPI.Models;

namespace CommanderAPI.Data
{
  public class MockCommanderRepo : ICommanderAPIRepo
  {
    
    public void CreateCommand(Command cmd)
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<Command> GetAllCommands()
    {
      var commands = new List<Command>
      {
        new Command { ID = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" },
        new Command { ID = 0, HowTo = "Cut bread", Line = "Get a Knife", Platform = "Knife & chopping board" },
        new Command { ID = 0, HowTo = "Make a cup of tea", Line = "Place Teabag", Platform = "kettle & Cup" }
      };

      return commands;
    }


    public Command GetCommandByID(int id)
    {
      return new Command { ID = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" };

    }

    public bool SaveChanges()
    {
      throw new System.NotImplementedException();
    }

    public void UpdateCommand(Command cmd)
    {
      throw new System.NotImplementedException();
    }
  }
}
