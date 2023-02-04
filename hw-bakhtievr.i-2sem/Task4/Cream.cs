using System;

namespace task4
{
    class Cream : Medicine 
    {
        private int VolumeMg { get; set; }
        private double KeepingTemperature { get;}
        private int RecomendedVolume { get; }

        public Cream(string name, int shelfLife, decimal cost, bool haveReceipt,
            Illnesses ilnessOfThisMedicine, MethodsOfUse methodOfUse):
            base(name,shelfLife,cost,haveReceipt,ilnessOfThisMedicine, methodOfUse)
        {
            VolumeMg = 250;
            KeepingTemperature = 20;
            RecomendedVolume = 2;
        }

        private void ToSpread()
        {
            if (VolumeMg < RecomendedVolume)
                throw new NotEnoughMedicineException("cream is not enough");
            VolumeMg -= RecomendedVolume ;
        }

        public override void Use()
        {
            Console.WriteLine($"Cream {Name} is spread on ur soft skin. ");
            ToSpread();
        }

        public override void InstructionOfUse()
        {
            Console.WriteLine($"Help yourself,recomended volume is {RecomendedVolume}," +
                              $" keeping temp is {KeepingTemperature} gradusov");
        }
    }
}