using System;
namespace task4
{
    class Spray : Medicine
    {
        private int VolumeMl { get; set; }
        private int ZilchVolume { get; } //объем на пшик
        private int AmountOfZilch { get; set; } // количество пшиков
        private double AmountOfActiveSubstance { get; } //в одном пшике
        private double DailyNorm { get; }
        public DateTime TimeOfLastUse { get; set; }
        
        public Spray(string name, int shelfLife, decimal cost, bool haveReceipt,
            Illnesses ilnessOfThisMedicine, MethodsOfUse methodOfUse, int volumeMl,
            double amountOfActiveSubstance)
            : base(name, shelfLife, cost, haveReceipt, ilnessOfThisMedicine, methodOfUse)
        {
            VolumeMl = volumeMl;
            ZilchVolume = 1;
            AmountOfZilch = VolumeMl / ZilchVolume;
            AmountOfActiveSubstance= amountOfActiveSubstance;
            DailyNorm = AmountOfActiveSubstance * 5;
        }

        public override void InstructionOfUse()
        {
            Console.WriteLine($"Spray helps to recover from {IlnessOfThisMedicine}. Daily norm is" +
                              $"{DailyNorm}. One zilch takes {ZilchVolume}");
        }

        public override void Use()
        {
            Console.WriteLine("Zilch!");
            MakeAZilch();
            TimeOfLastUse = DateTime.Now;
        }
        
        private void MakeAZilch()
        {
            if (VolumeMl < ZilchVolume)
                throw new NotEnoughMedicineException("amount of zilches is not enough");
            AmountOfZilch -= 1;
            VolumeMl -= ZilchVolume;
        }
    }
}