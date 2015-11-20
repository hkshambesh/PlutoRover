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
    }
}