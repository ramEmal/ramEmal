using System;
namespace Task9
{
    public interface IMovement
    {
        public int Distanse { get; set; }
        public static int MaxSpeed { get; set; }
        public static int MinSpeed { get; set; }
        public int MinTime { get; set; }
        /// <summary>
        /// Расчитывает за какое минимальное время проедет сулчайное расстояние при случайной полученной скорости
        /// </summary>
        /// <param name="distanse"></param>
        /// <param name="maxSpeed"></param>
        /// <param name="minSpeed"></param>
        public void CheckTime(int distanse, int maxSpeed,int minSpeed)
        {
            Distanse = distanse;
            MaxSpeed = maxSpeed;
            MinSpeed = minSpeed;
            var rnd = new Random();
            MinTime = rnd.Next(Distanse/ MaxSpeed, Distanse / MinSpeed);
            Console.WriteLine($"Transport  can travel this distance in {MinTime} of the time");
        }
    }
}