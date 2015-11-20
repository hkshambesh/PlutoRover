using System;
using PlutoRover.Interfaces;
using PlutoRover.Models;
using PlutoRover.Models.Enums;

namespace PlutoRover.Core.Commands
{
    public class CommandR : ICommandExecute
    {
        public Position ExecuteCommand(Rover rover)
        {
            if (rover == null)
            {
                throw new NullReferenceException("Rover cannot be null");
            }

            return new Position
            {
                X = rover.Position.X,
                Y = rover.Position.Y,
                Direction = GetDirection(rover.Position.Direction)
            };
        }

        private Direction GetDirection(Direction currentDirection)
        {
            Direction direction = Direction.Unknown;

            switch (currentDirection)
            {
                case Direction.N:
                    direction = Direction.E;
                    break;
                case Direction.E:
                    direction = Direction.S;
                    break;
                case Direction.S:
                    direction = Direction.W;
                    break;
                case Direction.W:
                    direction = Direction.N;
                    break;
            }

            return direction;
        }
    }
}