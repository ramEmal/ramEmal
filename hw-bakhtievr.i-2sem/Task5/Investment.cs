using System;
namespace Task9
{
    public class Investment
    {
        private static int addSportCar = 2;
        public static int AddSportCar
        {
            get { return addSportCar; }
            set
            {
                if (value > 1) addSportCar = value;
            }
        }
        /// <summary>
        /// рассчитывает стоимость транспорта спустя время 
        /// </summary>
        /// <param name="addsportCar"></param>
        /// <param name="cost"></param>
        /// <param name="riseInPrice"></param>
        /// <returns></returns>
        public static decimal GetCost(int addsportCar, int cost, int riseInPrice)
        {
            decimal result = cost; 
            for (int i = 1; i < addSportCar; i++)
                result = result + addSportCar * riseInPrice;
            return result;
        }
    }
}