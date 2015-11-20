using NUnit.Framework;
using PlutoRover.Core.Commands;
using PlutoRover.Models;
using PlutoRover.Models.Enums;

namespace PlutoRover.Tests
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void When_command_is_right_rotate_90_degrees_test()
        {
            // act
            var commandR = new CommandR();
            var rover = new Rover
            {
                Command = Command.R,
                Position = new Position
                {
                    Direction = Direction.N,
                    X = 0,
                    Y = 0
                }
            };

            // actual and Assert
            rover.Position = commandR.ExecuteCommand(rover);
            Assert.AreEqual(Direction.E, rover.Position.Direction);

            rover.Position = commandR.ExecuteCommand(rover);
            Assert.AreEqual(Direction.S, rover.Position.Direction);

            rover.Position = commandR.ExecuteCommand(rover);
            Assert.AreEqual(Direction.W, rover.Position.Direction);

            rover.Position = commandR.ExecuteCommand(rover);
            Assert.AreEqual(Direction.N, rover.Position.Direction);
        }

        [Test]
        public void When_command_is_left_rotate_90_degrees_test()
        {
            // act
            var commandR = new CommandL();
            var rover = new Rover
            {
                Command = Command.L,
                Position = new Position
                {
                    Direction = Direction.N,
                    X = 0,
                    Y = 0
                }
            };

            // actual and Assert
            rover.Position = commandR.ExecuteCommand(rover);
            Assert.AreEqual(Direction.W, rover.Position.Direction);

            rover.Position = commandR.ExecuteCommand(rover);
            Assert.AreEqual(Direction.S, rover.Position.Direction);

            rover.Position = commandR.ExecuteCommand(rover);
            Assert.AreEqual(Direction.E, rover.Position.Direction);

            rover.Position = commandR.ExecuteCommand(rover);
            Assert.AreEqual(Direction.N, rover.Position.Direction);
        }

        [Test]
        public void When_command_is_forward_and_direction_north_increase_by_one_test()
        {
            // act
            var commandR = new CommandF();
            var rover = new Rover
            {
                Command = Command.F,
                Position = new Position
                {
                    Direction = Direction.N,
                    X = 0,
                    Y = 0
                }
            };

            // actual and Assert
            rover.Position = commandR.ExecuteCommand(rover);
            Assert.AreEqual(1, rover.Position.Y);

            rover.Position = commandR.ExecuteCommand(rover);
            Assert.AreEqual(2, rover.Position.Y);
        }

        [Test]
        public void When_command_is_forward_and_direction_east_increase_by_one_test()
        {
            // act
            var commandR = new CommandF();
            var rover = new Rover
            {
                Command = Command.F,
                Position = new Position
                {
                    Direction = Direction.E,
                    X = 0,
                    Y = 0
                }
            };

            // actual
            rover.Position = commandR.ExecuteCommand(rover);

            // assert
            Assert.AreEqual(1, rover.Position.X);
        }

        [Test]
        public void When_command_is_forward_and_direction_south_decrease_by_one_test()
        {
            // act
            var commandR = new CommandF();
            var rover = new Rover
            {
                Command = Command.F,
                Position = new Position
                {
                    Direction = Direction.S,
                    X = 0,
                    Y = 0
                }
            };

            // actual
            rover.Position = commandR.ExecuteCommand(rover);

            // assert
            Assert.AreEqual(-1, rover.Position.Y);
        }

        [Test]
        public void When_command_is_forward_and_direction_west_decrease_by_one_test()
        {
            // act
            var commandR = new CommandF();
            var rover = new Rover
            {
                Command = Command.F,
                Position = new Position
                {
                    Direction = Direction.W,
                    X = 0,
                    Y = 0
                }
            };

            // actual
            rover.Position = commandR.ExecuteCommand(rover);

            // assert
            Assert.AreEqual(-1, rover.Position.X);
        }

        [Test]
        public void When_command_is_backward_and_direction_north_decrease_by_one_test()
        {
            // act
            var commandR = new CommandB();
            var rover = new Rover
            {
                Command = Command.B,
                Position = new Position
                {
                    Direction = Direction.N,
                    X = 0,
                    Y = 0
                }
            };

            // actual and Assert
            rover.Position = commandR.ExecuteCommand(rover);
            Assert.AreEqual(-1, rover.Position.Y);

            rover.Position = commandR.ExecuteCommand(rover);
            Assert.AreEqual(-2, rover.Position.Y);
        }

        [Test]
        public void When_command_is_backward_and_direction_east_increase_by_one_test()
        {
            // act
            var commandR = new CommandB();
            var rover = new Rover
            {
                Command = Command.B,
                Position = new Position
                {
                    Direction = Direction.E,
                    X = 0,
                    Y = 0
                }
            };

            // actual
            rover.Position = commandR.ExecuteCommand(rover);

            // assert
            Assert.AreEqual(-1, rover.Position.X);
        }

        [Test]
        public void When_command_is_backward_and_direction_south_decrease_by_one_test()
        {
            // act
            var commandR = new CommandB();
            var rover = new Rover
            {
                Command = Command.B,
                Position = new Position
                {
                    Direction = Direction.S,
                    X = 0,
                    Y = 0
                }
            };

            // actual
            rover.Position = commandR.ExecuteCommand(rover);

            // assert
            Assert.AreEqual(1, rover.Position.Y);
        }

        [Test]
        public void When_command_is_backward_and_direction_west_decrease_by_one_test()
        {
            // act
            var commandR = new CommandB();
            var rover = new Rover
            {
                Command = Command.B,
                Position = new Position
                {
                    Direction = Direction.W,
                    X = 0,
                    Y = 0
                }
            };

            // actual
            rover.Position = commandR.ExecuteCommand(rover);

            // assert
            Assert.AreEqual(1, rover.Position.X);
        }
    }
}