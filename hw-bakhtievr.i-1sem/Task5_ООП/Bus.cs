﻿using System;
namespace Task9
{
    public class Bus:Transport
    {
        public int LoadCapacity { get; set; }
        public double HumanMass { get; set; }
        public int places;
        /// <summary>
        /// Здесть указывается максимальная вместимость автобуса
        /// </summary>
        /// <exception cref="MyException"></exception>
        public int Places
        {
            get { return places; }
            set
            {
                if (value > 45)
                    throw new MyException("В автобусе не осталось мест", value);
                else
                    places = value;
            } 
        }
        public Bus(string name, int wheels, double maxSpeed,int places)
        {
            Places = places;
            Model = name;
            NumberOfWheels = wheels;
            MaxSpeed = maxSpeed;
        }
        
        public double CalculatLoad(int loadCapacity, double humanMass,int places)
        {
            Places = places;
            LoadCapacity = loadCapacity;
            HumanMass = humanMass;
            return loadCapacity/(humanMass*places) ;
        }
        public void InfoBus()
        {
            Console.WriteLine($"This vehicle{Model} is designed to carry passengers and has a capacity of {Places} + passengers," +
                              $"the maximum speed of the bus is {MaxSpeed} km/h, but unlike others it has {NumberOfWheels} wheels");
        } 
    }
}