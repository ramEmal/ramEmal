namespace Task2
{
    public class Element
    {
        public string name;
        public int areaFirst;
        public int areaNext;

        public Element(string n, int a, int b)
        {
            name = n;
            areaFirst = a;
            areaNext = b;
        }

        public int AreaFirst
        {
            get { return areaFirst;}
            set { areaFirst = value; }
        }

        public int AreaNext
        {
            get { return areaNext; }
            set { areaNext = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}