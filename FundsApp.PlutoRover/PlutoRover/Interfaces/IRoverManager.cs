using PlutoRover.Models;

namespace PlutoRover.Interfaces
{
    public interface IRoverManager
    {
        Position Move(Rover rover);
    }
}