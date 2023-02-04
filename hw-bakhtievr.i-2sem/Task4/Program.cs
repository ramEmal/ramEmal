namespace task4
{
    class Program
    {
        static void Main()
        {
            var k = new Pharmacy("abc", "num1","1","3");
            k.Sell(2022);
            var pill = new Pills("sd", 2023, 550, MethodsOfUse.Oral,
                1, 5, false, ShapeOfPill.Round,
                Illnesses.Cold, 2);
            pill.Use();
            pill.Use();
        }
    }
}