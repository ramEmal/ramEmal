using System;
using System.Collections;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCollection userCollection = new MyCollection();

            foreach (Element element in userCollection)
            {
                Console.WriteLine("Name: {0} areaFirst: {1} areaNext: {2}", element.name, element.areaFirst, element.areaNext);
            }
            Console.Write(new string('-',29)+"\n");
            foreach (Element element in userCollection)
            {
                Console.WriteLine("Name:{0},areaFirst:{1},areaNext{2}",element.name,element.areaFirst,element.areaNext);
            }
            Console.Write(new string('-',29)+"\n");
            MyCollection MyElementCollection = new MyCollection();
            IEnumerable enumerable=MyElementCollection as IEnumerable;
            IEnumerator enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Element element=enumerator.Current as Element;
                Console.WriteLine("Name:{0},areaFirst:{1},areaNext{2}",element.name,element.areaFirst,element.areaNext);
            }
            enumerator.Reset();

            Console.ReadKey();
        }
    }
}