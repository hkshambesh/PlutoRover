using Moq;
using NUnit;
using NUnit.Framework;
using PlutoRover.Core;
using PlutoRover.Interfaces;
using PlutoRover.Models;
using PlutoRover.Models.Enums;

namespace PlutoRover.Tests
{
    [TestFixture]
    public class RoverMockTests
    {
        private Mock<IRoverManager> _mockIRoverManager;

        [OneTimeSetUp]
        public void Setup()
        {
            _mockIRoverManager = new Mock<IRoverManager>();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            _mockIRoverManager = null;
        }

        [TestCase(0, 0, Direction.N, Command.F, 0, 1, Direction.N)]
        [TestCase(0, 1, Direction.N, Command.F, 0, 2, Direction.N)]
        [TestCase(0, 2, Direction.E, Command.R, 0, 2, Direction.E)]
        [TestCase(0, 2, Direction.E, Command.F, 1, 2, Direction.E)]
        [TestCase(1, 2, Direction.E, Command.F, 2, 2, Direction.E)]
        public void When_rover_is_set_to_move_to_single_direction_test(int x, int y, Direction direction, Command command,
                int expectedX, int expectedY, Direction expectedDirection)
        {
            // act
            var currentPosition = new Position
            {
                X = x,
                Y = y,
                Direction = direction
            };

            var rover = new Rover
            {
                Position = currentPosition,
                Command = command
            };

            _mockIRoverManager.Setup(m => m.Move(rover)).Returns(new Position
            {
                X = expectedX,
                Y = expectedY,
                Direction = expectedDirection
            });

            // actual 
            var actual = _mockIRoverManager.Object.Move(rover);

            // assert
            Assert.AreEqual(expectedX, actual.X);
            Assert.AreEqual(expectedY, actual.Y);
            Assert.AreEqual(expectedDirection, actual.Direction);
        }

        [TestCase(0,0,Direction.N, "FFRFF")]
        public void When_rover_is_set_to_move_with_multiple_commands_test(int x, int y, Direction direction, string commands)
        {
            // act
            var currentPosition = new Position
            {
                X = x,
                Y = y,
                Direction = direction
            };

            var roverF0 = GenerateRoverObj(0, 0, Direction.N, Command.F);
            var roverF1 = GenerateRoverObj(0, 1, Direction.N, Command.F);
            var roverF2 = GenerateRoverObj(0, 2, Direction.N, Command.F);
            var roverR3 = GenerateRoverObj(0, 1, Direction.N, Command.R);
            var roverF4 = GenerateRoverObj(1, 1, Direction.N, Command.F);
            var roverF5 = GenerateRoverObj(2, 2, Direction.N, Command.F);

            _mockIRoverManager.Setup(m => m.Move(roverF0)).Returns(roverF0.Position);
            _mockIRoverManager.Setup(m => m.Move(roverF1)).Returns(roverF1.Position);
            _mockIRoverManager.Setup(m => m.Move(roverF2)).Returns(roverF2.Position);
            _mockIRoverManager.Setup(m => m.Move(roverR3)).Returns(roverR3.Position);
            _mockIRoverManager.Setup(m => m.Move(roverF4)).Returns(roverF4.Position);
            _mockIRoverManager.Setup(m => m.Move(roverF5)).Returns(roverF5.Position);

            var programController = new ProgramController(_mockIRoverManager.Object);

            // actual
            var actual = programController.ExecuteCommands(currentPosition, commands);

            // assert
            Assert.AreEqual(2, actual.X);
            Assert.AreEqual(2, actual.Y);
            Assert.AreEqual(Direction.E, actual.Direction);
        }

        private Rover GenerateRoverObj(int x, int y, Direction direction, Command command)
        {
            return new Rover
            {
                Position = new Position
                {
                    X = x,
                    Y = y,
                    Direction = direction
                },
                Command = command
            };
        }
    }
}