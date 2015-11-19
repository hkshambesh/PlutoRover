using PlutoRover.Models;

namespace PlutoRover.Interfaces
{
    public interface ICommandExecute
    {
        Position ExecuteCommand(Rover rover);
    }
}