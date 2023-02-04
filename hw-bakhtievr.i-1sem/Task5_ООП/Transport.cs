using System;
namespace Task9
{
    public abstract class Transport
    {
        public string Company { get; set; }
        public string Model { get; set; }
        public double MaxSpeed { get;  protected set; }
        public int Cost { get; set; }
        public int NumberOfWheels { get; set; }
        public int MassTranspot { get; set; }

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
            Console.WriteLine($"Transport mass is {MassTranspot} kg");
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