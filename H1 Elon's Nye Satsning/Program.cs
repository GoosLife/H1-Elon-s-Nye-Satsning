using System;
using System.Collections.Generic;

namespace H1_Elon_s_Nye_Satsning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // The game loop runs on this bool
            bool isRunning = true;

            // Create cars
            RemoteControlledCar car1 = new RemoteControlledCar(xPos: 0, yPos: 0);
            RemoteControlledCar car2 = new RemoteControlledCar("Green", 30, 30);

            // Add to list of cars
            List<RemoteControlledCar> cars = new List<RemoteControlledCar>();
            cars.Add(car1);
            cars.Add(car2);

            // "Game" loop
            while (isRunning)
            {
                // Draw cars and HUD to console
                DrawGraphics(cars);
                
                // Input handler
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
                    case ConsoleKey.Tab: // Charge the car
                        car1.Charge();
                        break;

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
                    case ConsoleKey.Enter: // Charge the car
                        car2.Charge();
                        break;

                    // Break driving loop
                    case ConsoleKey.Escape:
                        isRunning = false;
                        break;

                    // All other keys just continue running the loop.
                    default:
                        break;
                }
            }

            // Press a key before the console window closes
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
        /// Draws graphics to console, i.e. the cars at their positions and the hud indicating their battery level and metres driven since last charge.
        /// </summary>
        /// <param name="cars"></param>
        static void DrawGraphics(List<RemoteControlledCar> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                // Convert object string with the cars color value to System.ConsoleColor
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), cars[i].Color);

                DrawCar(cars[i]);

                DrawCarHUD(cars[i], i);

                // Reset console color to default.
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Draw a car at the cars x,y coordinate in the console.
        /// </summary>
        /// <param name="car"></param>
        static void DrawCar(RemoteControlledCar c)
        {
            // Draw car at the cars current position
            Console.SetCursorPosition(c.XPos, c.YPos);

            // Write an H representing the car.
            Console.Write('H');
        }

        /// <summary>
        /// Write current battery charge and metres driven since last charge to console.
        /// </summary>
        /// <param name="cars"></param>
        static void DrawCarHUD(RemoteControlledCar c, int i)
        {
                // Set cursor position to write details about the cars battery and currently driven distance in the side.
                Console.SetCursorPosition(70, 10 * i);

                // Write details to console.
                Console.Write("Car " + i + " | Battery: " + c.CurrentBattery + " | Metres since last charge: " + c.DrivenMetres + "   ");
        }
    }
}
