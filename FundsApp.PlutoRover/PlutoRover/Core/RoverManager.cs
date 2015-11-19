using PlutoRover.Interfaces;
using PlutoRover.Models;

namespace PlutoRover.Core
{
    public class RoverManager : IRoverManager
    {
        private readonly ICommandFactory _commandFactory;
        private ICommandExecute _commandExecute;

        public RoverManager(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public Position Move(Rover rover)
        {
            _commandExecute = _commandFactory.GetCommandHandler(rover.Command.ToString());

            return _commandExecute.ExecuteCommand(rover);
        }
    }
}