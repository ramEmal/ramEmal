using System;
using System.Collections.Generic;
using System.Linq;
using static task4.Illnesses;
using static task4.MethodsOfUse;
using static task4.ShapeOfPill;

namespace task4
{
    public class Pharmacy
    {
        public string Name { get; }
        private TimeSpan OpeningHour { get; }
        private TimeSpan ClosingHour { get; }
        private Dictionary<Pills, int> PillsInStock { get; set; }
        private Dictionary<Cream, int> CreamsInStock { get; set; }
        private Dictionary<Spray, int> SpraysInStock { get; set; }
        private string WantedPills { get; }
        private string WantedCream { get; }
        private string WantedSpray { get; }

        private int Profit { get; set; }

        internal Pharmacy(string name, string wantedPill, string wantedSpray,
            string wantedCream)
        {
            WantedCream = wantedCream;
            WantedPills = wantedPill;
            WantedSpray = wantedSpray;
            Name = name;
            OpeningHour = new TimeSpan(9, 0, 0);
            ClosingHour = new TimeSpan(22, 0, 0);
            PillsInStock = new Dictionary<Pills, int>
            {
                {
                    new Pills("num1", 2023, 450, Oral,
                        4, 8, true, Round,
                        Cold, 2),
                    9
                },

                {
                    new Pills("num2", 2201, 250, Intravenously,
                        4, 8, false, Square,
                        Headache, 3),
                    6
                },

                {
                    new Pills("num3", 2019, 300, Oral,
                        4, 9, true, Cylindrical,
                        StomachAche, 4),
                    8
                }
            };
            CreamsInStock = new Dictionary<Cream, int>
            {
                {
                    new Cream("1", 2018, 150, true, Pimples,
                        External),
                    10
                },

                {
                    new Cream("2", 2023, 200, false, Cold,
                        External),
                    5
                },

                {
                    new Cream("3", 2024, 300, false, Pimples,
                        External),
                    2
                }
            };
            SpraysInStock = new Dictionary<Spray, int>
            {
                {
                    new Spray("1", 2020, 429, false, StomachAche,
                        External, 200, 0.02),
                    5
                },
                {
                    new Spray("2", 2023, 867, false, Cold,
                        Nosal, 169, 0.05),
                    10
                },
                {
                    new Spray("3", 2024, 578, false, Cold,
                        Oral, 400, 0.1),
                    6
                }
            };
        }

        private bool IsNormalShelfLife(int year, WantedMedicine wantedMedicine)
        {
            bool flag = false;
            switch (wantedMedicine)
            {
                case WantedMedicine.Pills:

                    flag = FilterForMedicine(WantedPills, PillsInStock, year);
                    break;
                
                case WantedMedicine.Spray:
                    flag =FilterForMedicine(WantedSpray, SpraysInStock, year);
                    break;
                
                case WantedMedicine.Cream:
                    flag = FilterForMedicine(WantedCream, CreamsInStock, year);
                    break;
            }

            return flag;
        }

        public void Sell(int year)
        {
            decimal sum = 0;
            
            if (IsNormalShelfLife(year, WantedMedicine.Pills))
                foreach (var p in PillsInStock.Where(p => p.Key.Name == WantedPills))
                {
                    sum += p.Key.Cost;
                    Console.WriteLine($"the cost of {WantedPills} is {p.Key.Cost}");
                }
            else
                Console.WriteLine("Unfortunately we can't sell this spray");


            if (IsNormalShelfLife(year, WantedMedicine.Spray))
                foreach (var s in SpraysInStock.Where(s => s.Key.Name == WantedSpray))
                {
                    sum += s.Key.Cost;
                    Console.WriteLine($"the cost of {WantedSpray} is {s.Key.Cost}");
                }
            else
                Console.WriteLine("Unfortunately we can't sell this spray");

            if (IsNormalShelfLife(year, WantedMedicine.Cream))
                foreach (var c in CreamsInStock.Where(c => c.Key.Name == WantedCream))
                {
                    sum += c.Key.Cost;
                    Console.WriteLine($"the cost of {WantedCream} is {c.Key.Cost}"); 
                }
            else 
                Console.WriteLine("Unfortunately we can't sell this spray");

            
            Console.WriteLine($"your medicines will cost {sum}");
        }

        private bool FilterForMedicine<T>(string wantedMedicine, Dictionary<T, int> medicineDict, int year)
            where T: Medicine

        {
            bool flag1 = false;
            foreach (var m in medicineDict.Where(c => c.Key.Name == wantedMedicine)
                .Select(c => c.Key.ShelfLife >= year))
                flag1 = m;
            return flag1;
        }
    }
}
