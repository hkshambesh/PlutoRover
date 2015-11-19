using PlutoRover.Models;

namespace PlutoRover.Interfaces
{
    public interface IProgramController
    {
        Position ExecuteCommands(Position currentPosition, string commands);
    }
}