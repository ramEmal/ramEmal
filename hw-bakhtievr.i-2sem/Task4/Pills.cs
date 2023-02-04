using System;

namespace task4
{
    internal class Pills : Medicine
    {
        public int BlocksAmount { get; set; }
        public int PillsInBlock { get; set; }
        private int FullAmount { get; set; }
        private int RecomendedAmount { get; }
        private ShapeOfPill ShapeOfThisPill { get; }



        public Pills(string name, int shelfLife, decimal cost, MethodsOfUse methodOfUse,
            int blocksAmount, int pillsInBlock, bool haveReceipt,
            ShapeOfPill shape, Illnesses illnessOfThisMedicine, int recomendedAmount) :
            base(name, shelfLife, cost, haveReceipt, illnessOfThisMedicine, methodOfUse)
        {
            BlocksAmount = blocksAmount;
            PillsInBlock = pillsInBlock;
            RecomendedAmount = recomendedAmount;
            ShapeOfThisPill = shape;
            FullAmount = BlocksAmount * PillsInBlock;
        }

        public override void InstructionOfUse()
        {
            Console.WriteLine(
                $"This pills help to recover from {IlnessOfThisMedicine}.The recomended norm is {RecomendedAmount}." +
                $" There are {FullAmount} pills in the pack. Pills' form is {ShapeOfThisPill}");
        }

        public override void Use()
        {
            InstructionOfUse();
            TakeAPill();
        }

        protected int TakeAPill()
        {
            if (FullAmount < RecomendedAmount)
                throw new NotEnoughMedicineException("pills are not enough");
            FullAmount -= RecomendedAmount;
            return FullAmount;
        }
    }
}