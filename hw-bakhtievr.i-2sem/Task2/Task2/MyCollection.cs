using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Task2
{
    public class MyCollection:IEnumerable,IEnumerator
    {
        public Element[] ElementArray = null;

        public MyCollection()
        {
            ElementArray = new Element[4];
            ElementArray[0] = new Element("Artem", 18, 170);
            ElementArray[1] = new Element("Barry", 22, 210);
            ElementArray[2] = new Element("Cad", 30, 160);
            ElementArray[3] = new Element("Daniil", 45, 188);
        }

        private int position = -1;

        public bool MoveNext()
        {
            if (position < ElementArray.Length - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get { return ElementArray[position]; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this as IEnumerator;
        }
    }
}