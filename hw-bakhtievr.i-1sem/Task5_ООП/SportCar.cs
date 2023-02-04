using System;
namespace Task9
{
    public class SportCar:Transport,IMovement
    {
        public bool HasTurboEngin { get; set; }
        public SportCar(string model, int cost,bool hasTurboEngin)
        {
            Model = model;
            Cost = cost;
            HasTurboEngin = hasTurboEngin;
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
            Console.WriteLine($"The model of this car {Model}, the price of this car {Cost}" +
                              $"Does it have a turbocharged engine? {HasTurboEngin} of course. $");
        }
        public int Distanse { get; set; }
        public int MinTime { get; set; }
    }
}