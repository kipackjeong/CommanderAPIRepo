using System.Collections.Generic;
using CommanderAPI.Models;

namespace CommanderAPI.Data
{
    public interface ICommanderAPIRepo
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands(); //Gets all the commands from user
        Command GetCommandByID(int id); // Get single command from user by ID
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
 
    }
}