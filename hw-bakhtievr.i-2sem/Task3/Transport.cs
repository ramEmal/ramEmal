using System;
using System.Collections.Generic;

namespace Task9
{
    public abstract class Transport
    {
        public Dictionary<Information, int> InformationDictionary = new();
        public enum Information
        {
            NumberOfDoors,
            MassTransport,
            MaxSpead,
            Cost
        }
        public string Company { get; set; }
        public string Model { get; set; }
        public int NumberOfWheels { get; set; }

        /// <summary>
        /// метод Display переопределен в классе SportCar
        /// </summary>
        public virtual void Display()
        {
            NumberOfWheels = 8;
            Console.WriteLine($"Transport have {NumberOfWheels} Wheels");
        }
        public void GetInforamationTransportMass()
        {
            InformationDictionary[Information.MassTransport] = 5000;
            Console.WriteLine($"Transport mass is {Information.MassTransport} kg");
        }
        /// <summary>
        /// неаобязательный метод 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="mileage"></param>
        /// <param name="mark"></param>
        public void ShowTransport(string model, int mileage = 3000, string mark = "Panamera gts turbo")
        {
            Console.WriteLine($"Model:{model} mileage:{mileage} mark:{mark} ");
        }
        public int Power { get; set; }
        public void GetPower()
        {
            Console.WriteLine($"Power is Transport{Power}");
        }
    }
}