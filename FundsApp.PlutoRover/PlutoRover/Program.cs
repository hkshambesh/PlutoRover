using System;
using Ninject;
using PlutoRover.Interfaces;
using PlutoRover.IoC;
using PlutoRover.Models;
using PlutoRover.Models.Enums;

namespace PlutoRover
{
    public class Program
    {
        static void Main(string[] args)
        {
            var programController = DependencyResolver.Kernel.Get<IProgramController>();

            while (true)
            {
                Console.WriteLine("enter commands: ");

                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    Position newPosition = programController.ExecuteCommands(new Position
                    {
                        X = 0, Y = 0, Direction = Direction.N // Set default position 0, 0, N
                    }, input);

                    Console.WriteLine(newPosition.X + "," + newPosition.Y + "," + newPosition.Direction);
                }
            }
        }
    }
}
