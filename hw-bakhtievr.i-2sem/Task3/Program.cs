using System;
using System.IO;
using System.Threading.Channels;

namespace Task9
{
    public class Program
    {
        public delegate void ToStart(Transport car);

        static void Main(string[] args)
        {
            ToStart toStart = GetInforamationTransportMass;

            SportCar koenigsegg = new SportCar("Koengseg Agera R",1650000,  true);
            koenigsegg.IformationSportCar();
            koenigsegg.Display();
            koenigsegg.GetInforamationTransportMass();
            koenigsegg.ShowTransport("Porshe");
            Console.WriteLine($"______________________________________________");

            IMovement imMovement = new SportCar( "Lamdorghini Urus",2000000,true);
            imMovement.CheckTime((2000), 305, 120);
            Console.WriteLine("_______________________________________________");

            Bus gaz = new Bus("Gaz", 6, 40);
            gaz.InfoBus();
            gaz.GetInforamationTransportMass();
            Console.Write("maximum capacity ");
            try
            {
                Console.WriteLine((int) gaz.CalculatLoad(7000, 60.5, 45));
            }
            catch (MyException e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
                Console.WriteLine($"Некорректное значение: {e.Value}");
                throw;
            }

            Console.WriteLine($"______________________________________________");

            Bicycle BMX = new Bicycle("BMX", 2, true);
            BMX.CheckInfoOfBicycle();
            BMX.GetInforamationTransportMass();
            Console.WriteLine($"______________________________________________");

            CargoTransport truck = new CargoTransport("M&HCV Construck", "TATA Motors");
            truck.Display();
            truck.GetInforamationTransport(truck,toStart);

            using (var myAvto = new StreamReader("C:/Users/Ramil/Work/homework2/hw-bakhtievr.i/Task5/Avto.txt"))
            {
                var characteristicModel = myAvto.ReadLine();
                string dataModel = characteristicModel;

                var characteristicCost = myAvto.ReadLine();
                int dataCost = int.Parse(characteristicCost);

                var characteristicTurboEngine = myAvto.ReadLine();
                bool dataTurboEngine = bool.Parse(characteristicTurboEngine);

                SportCar sportCar = new SportCar(dataModel,dataCost,dataTurboEngine);
                Console.WriteLine($"The model of this car {characteristicModel}, " +
                                  $"the price of this car {characteristicCost} " +
                                  $"Does it have a turbocharged engine? {characteristicTurboEngine} of course.");
                Console.WriteLine(sportCar);
            }
        }


        public static void GetInforamationTransportMass(Transport car)
        {
            Console.WriteLine($"The company that produces trucks {car.Company}" +
                              $" and the model of one of these trucks {car.Model}");
            Console.WriteLine($"Power of Car {car.Power} and car have {car.NumberOfWheels} Wheels");
        }
    }
}

