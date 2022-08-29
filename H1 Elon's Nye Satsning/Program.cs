using System;
using System.Collections.Generic;

namespace H1_Elon_s_Nye_Satsning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;

            RemoteControlledCar car1 = new RemoteControlledCar(xPos: 0, yPos: 0);
            RemoteControlledCar car2 = new RemoteControlledCar("Green", 30, 30);

            List<RemoteControlledCar> cars = new List<RemoteControlledCar>();
            cars.Add(car1);
            cars.Add(car2);

            while (isRunning)
            {
                // Draw cars and HUD on console
                DrawCars(cars);
                DrawCarHUD(cars);
                
                // Read and respond to input
                ConsoleKey input = Console.ReadKey(true).Key;

                switch (input)
                {
                    // Car1 controls
                    case ConsoleKey.W:
                        EraseTrack(car1);
                        car1.Drive(Direction.NORTH);
                        break;
                    case ConsoleKey.A:
                        EraseTrack(car1);
                        car1.Drive(Direction.WEST);
                        break;
                    case ConsoleKey.S:
                        EraseTrack(car1);
                        car1.Drive(Direction.SOUTH);
                        break;
                    case ConsoleKey.D:
                        EraseTrack(car1);
                        car1.Drive(Direction.EAST);
                        break;
                    case ConsoleKey.Enter:
                        car1.Charge();

                    // Car2 controls
                    case ConsoleKey.UpArrow:
                        EraseTrack(car2);
                        car2.Drive(Direction.NORTH);
                        break;
                    case ConsoleKey.LeftArrow:
                        EraseTrack(car2);
                        car2.Drive(Direction.WEST);
                        break;
                    case ConsoleKey.DownArrow:
                        EraseTrack(car2);
                        car2.Drive(Direction.SOUTH);
                        break;
                    case ConsoleKey.RightArrow:
                        EraseTrack(car2);
                        car2.Drive(Direction.EAST);
                        break;

                    // Break driving loop
                    case ConsoleKey.Escape:
                        isRunning = false;
                        break;

                    // Charge car1
                        car2.Charge();
                        break;

                    // All other keys just continue running the loop.
                    default:
                        break;
                }
            }


            Console.ReadKey();
        }

        /// <summary>
        /// Erases the car from its current position before moving it to the new position
        /// </summary>
        static void EraseTrack(RemoteControlledCar c)
        {
            Console.SetCursorPosition(c.XPos, c.YPos);
            Console.Write(' ');
            Console.ResetColor();
        }

        /// <summary>
        /// Move the cars around on the console.
        /// </summary>
        /// <param name="cars"></param>
        static void DrawCars(List<RemoteControlledCar> cars)
        {
            foreach (RemoteControlledCar c in cars)
            {
                // Draw car at the cars current position
                Console.SetCursorPosition(c.XPos, c.YPos);

                // Convert object string with color value to System.ConsoleColor
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), c.Color);

                // Write an H representing the car.
                Console.Write('H');

                // Reset console color to default.
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Write current battery charge and metres driven since last charge to console.
        /// </summary>
        /// <param name="cars"></param>
        static void DrawCarHUD(List<RemoteControlledCar> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                // Convert object string with color value to System.ConsoleColor
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), cars[i].Color);

                // Set cursor position to write details about the cars battery and currently driven distance in the side.
                Console.SetCursorPosition(70, 10 * i);

                // Write details to console.
                Console.Write("Car " + i + " | Battery: " + cars[i].CurrentBattery + " | Metres since last charge: " + cars[i].DrivenMetres + "   ");
            }
        }
    }
}
