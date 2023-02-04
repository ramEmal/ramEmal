using System;
namespace Task9
{
    public class CargoTransport:Transport
    {
        public CargoTransport(string model,string company)
        {
            Company = company;
            Model = model;
        }
        /// <summary>
        /// Сокрытый метод
        /// </summary>
        public void GetInforamationTransport(Transport car,Program.ToStart toStart)
        {
            toStart(car);
            Console.WriteLine($"Power of Car {car.Power} and car have {car.NumberOfWheels} Wheels");        
        }
    }
}