using Ninject;
using NUnit.Framework;
using PlutoRover.Interfaces;
using PlutoRover.IoC;
using PlutoRover.Models;
using PlutoRover.Models.Enums;

namespace PlutoRover.Tests
{
    [TestFixture]
    public class RoverTests
    {
        private Rover _rover;

        [OneTimeSetUp]
        public void Setup()
        {
            _rover = new Rover
            {
                Position = new Position
                {
                    X = 0, Y = 0, Direction = Direction.N
                }
            };
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            _rover = null;
        }

        [TestCase("FFRFF", 2, 2, Direction.E)]
        public void When_multiple_commands_executed_test(string commands, int expectedX, int expectedY, Direction expectedDirection)
        {
            // act
            var programController = DependencyResolver.Kernel.Get<IProgramController>();

            // actual
            var actual = programController.ExecuteCommands(_rover.Position, commands);

            // assert
            Assert.AreEqual(expectedX, actual.X);
            Assert.AreEqual(expectedY, actual.Y);
            Assert.AreEqual(expectedDirection, actual.Direction);
        }
    }
}