using System;
using PlutoRover.Interfaces;
using PlutoRover.Models;
using PlutoRover.Models.Enums;

namespace PlutoRover.Core.Commands
{
    public class CommandF : ICommandExecute
    {
        public Position ExecuteCommand(Rover rover)
        {
            if (rover == null)
            {
                throw new NullReferenceException("Rover cannot be null");
            }

            return LoadPosition(rover.Position);
        }

        private Position LoadPosition(Position position)
        {
            switch (position.Direction)
            {
                case Direction.N:
                    position.Y = position.Y + 1;
                    break;
                case Direction.S:
                    position.Y = position.Y - 1;
                    break;
                case Direction.E:
                    position.X = position.X + 1;
                    break;
                case Direction.W:
                    position.X = position.X - 1;
                    break;
            }

            return position;
        }
    }
}