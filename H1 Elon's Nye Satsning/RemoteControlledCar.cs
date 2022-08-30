using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Elon_s_Nye_Satsning
{
    public enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }
    internal class RemoteControlledCar
    {
        private byte maxBatteryCapacity;
        /// <summary>
        /// Maximum capacity of the battery.
        /// </summary>
        private byte MaxBatteryCapacity
        {
            get { return maxBatteryCapacity; }
            set { maxBatteryCapacity = value; }
        }

        private int metresPerBatteryPercentage;
        /// <summary>
        /// The number of metres a car can drive before it depletes 1% of battery.                                     
        /// </summary>
        private int MetresPerBatteryPercentage
        {
            get { return metresPerBatteryPercentage; }
            set { metresPerBatteryPercentage = value; }
        }

        private byte currentBattery = 0;
        /// <summary>
        /// The cars current battery level.
        /// </summary>
        public byte CurrentBattery
        {
            get { return currentBattery; }
            private set { currentBattery = value; }
        }

        private int drivenMetres = 0;
        /// <summary>
        /// The number of metres driven since the last charge.
        /// </summary>
        public int DrivenMetres
        {
            get { return drivenMetres; }
            private set { drivenMetres = value; }
        }

        private string color;
        /// <summary>
        /// Color of the car.
        /// </summary>
        public string Color
        {
            get { return color; }
            private set { color = value; }
        }

        private int xPos;
        /// <summary>
        /// The position of the car on the x axis.
        /// </summary>
        public int XPos
        {
            get { return xPos; }
            private set { xPos = value; }
        }

        private int yPos;
        /// <summary>
        /// The position of the car on the y axis
        /// </summary>
        public int YPos
        {
            get { return yPos; }
            private set { yPos = value; }
        }

        public RemoteControlledCar(string color = "Red", int xPos = 0, int yPos = 0)
        {
            MaxBatteryCapacity = 100;
            MetresPerBatteryPercentage = 20;
            CurrentBattery = 100;
            DrivenMetres = 0;
            Color = color;
            XPos = xPos;
            YPos = yPos;
        }

        /// <summary>
        /// Simulates the car driving 1 meter in the specified direction.
        /// </summary>
        public void Drive(Direction direction)
        {
            int maxX = 60;
            int maxY = 40;

            if (CurrentBattery > 0)
            {
                switch(direction)
                {
                    case Direction.NORTH:
                        if (YPos > 0)
                            YPos--;
                        break;
                    case Direction.EAST:
                        if (XPos < maxX)
                            XPos++;
                        break;
                    case Direction.SOUTH:
                        if (YPos < maxY)
                            YPos++;
                        break;
                    case Direction.WEST:
                        if (XPos > 0)
                            XPos--;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Attempted to drive in non-existing direction.");
                }

                // If car isn't stuck on the edge of the map, it has driven one additional meter.
                if ((direction == Direction.NORTH && YPos != 0) ||
                    (direction == Direction.SOUTH && YPos != maxY) ||
                    (direction == Direction.EAST && XPos != maxX) ||
                    (direction == Direction.WEST && XPos != 0))
                {
                    DrivenMetres++;
                }

                // Deplete battery every time the car has driven as many metres as defined in MetresPerBatteryPercentage
                if (DrivenMetres > 0 &&
                    DrivenMetres % MetresPerBatteryPercentage == 0)
                { 
                    DepleteBattery(); 
                }
            }
        }

        /// <summary>
        /// Return car battery to full charge.
        /// </summary>
        public void Charge()
        {
            CurrentBattery = MaxBatteryCapacity;
            DrivenMetres = 0;
        }

        /// <summary>
        /// Remove 1% from the cars current battery charge.
        /// </summary>
        public void DepleteBattery()
        {
            CurrentBattery--;
        }
    }
}
