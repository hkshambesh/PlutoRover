using System;
using PlutoRover.Interfaces;
using PlutoRover.Models;
using PlutoRover.Models.Enums;

namespace PlutoRover.Core
{
    public class ProgramController : IProgramController
    {
        private readonly IRoverManager _roverManager;

        public ProgramController(IRoverManager roverManager)
        {
            _roverManager = roverManager;
        }

        public Position ExecuteCommands(Position position, string commands)
        {
            try
            {
                char[] cmds = commands.ToCharArray();

                foreach (char command in cmds)
                {
                    var rover = new Rover
                    {
                        Position = position,
                        Command = (Command)Enum.Parse(typeof(Command), command.ToString().ToUpper())
                    };

                    position = _roverManager.Move(rover);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("failed to execute command: " + commands, ex);
            }

            return position;
        }
    }
}