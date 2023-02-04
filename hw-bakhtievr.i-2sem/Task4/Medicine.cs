namespace task4
{
    abstract class Medicine : IUsable  
    {
        public string Name { get; set; }
        public int ShelfLife { get; set; }
        public decimal Cost { get; set; }
        
        public bool HaveReceipt { get; }
        public Illnesses IlnessOfThisMedicine { get; }
        
        public MethodsOfUse MethodOfUse { get; }
        public Medicine(string name, int shelfLife, decimal cost, bool haveReceipt, 
            Illnesses ilnessOfThisMedicine, MethodsOfUse methodOfUse)
        {
            Name = name;
            ShelfLife = shelfLife;
            Cost = cost;
            HaveReceipt = haveReceipt;
            IlnessOfThisMedicine = ilnessOfThisMedicine;
            MethodOfUse = methodOfUse;
        }

        public abstract void InstructionOfUse();
        public abstract void Use();

    }
}