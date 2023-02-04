using System;
namespace Task9
{
    public class Bicycle:Transport
    {
        protected bool IsWorking { get; }
        public Bicycle(string model, int wheels,bool isWorking)
        {
            IsWorking=isWorking;
            Model=model;
            NumberOfWheels=wheels;
        }
        public void CheckIsWorking()
        {
            if (IsWorking)
            {
                Console.Write($"Сheck the chain it may have come off");
            }
            else
            {
                Console.Write($"All right, keep moving, be careful on the turns");
            }
        }
        public  void CheckInfoOfBicycle()
        {
            Console.Write($"this transport {Model} is designed for both children and adults, ");CheckIsWorking();
            Console.Write($"and has {NumberOfWheels} wheels");
        }      
    }
}