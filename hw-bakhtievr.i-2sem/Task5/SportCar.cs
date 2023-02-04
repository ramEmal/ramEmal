using System;
namespace Task9
{
    public class SportCar:Transport,IMovement
    {
        public bool HasTurboEngin { get; set; }
        /*public SportCar( string model,int cost,bool hasTurboEngin)
        {
            Model = model;
            InformationDictionary[Information.Cost] = cost;
            HasTurboEngin = hasTurboEngin;
        }*/

        public SportCar( string model, int dataCost,bool hasTurboEngin)
        {
            InformationDictionary[Information.Cost] = dataCost;
            HasTurboEngin = hasTurboEngin;
            Model = model;
        }

        public int Door { get; set; }
        public override void Display()
        {
            NumberOfWheels = 4;
            Door = 2;
            Console.WriteLine($"Sport Car have {NumberOfWheels} wheels,and have {Door} door");
        }
        public void  IformationSportCar()
        {
            InformationDictionary[Information.NumberOfDoors] = 2;
            InformationDictionary[Information.MaxSpead] = 270;
            InformationDictionary[Information.Cost] = 200000;
            InformationDictionary[Information.MassTransport] = 2000;

            Console.WriteLine($"The model of this car {Model}, the price of this car {Information.Cost}" +
                              $"Does it have a turbocharged engine? {HasTurboEngin} of course" +
                              $"the price of this car{Information.Cost}$,the car is sporty," +
                              $" has only {Information.NumberOfDoors} doors, " +
                              $"and its maximum speed{Information.MaxSpead}$");
        }
        public int Distanse { get; set; }
        public int MinTime { get; set; }
    }
}