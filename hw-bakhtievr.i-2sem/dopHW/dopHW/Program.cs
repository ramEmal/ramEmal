using System.IO;
using System.Linq;
using System.Text;

namespace dopHW
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("C:/Users/Ramil/OneDrive/Рабочий стол/1.txt",Encoding.Default);
            
            StreamWriter str = new StreamWriter("C:/Users/Ramil/OneDrive/Рабочий стол/2.txt",false,Encoding.Default);

            string file = sr.ReadToEnd();
            sr.Close();

            string file1 = str.ToString();
            string newString =
                string.Concat(file1.ToLower().AsEnumerable().Select((c, i) => i % 2 == 0 ? c : char.ToUpper(c)));
                
            
            StringBuilder sb = new StringBuilder(file.Length);
            bool uppercase = false;
            foreach (char c in file)
            {
                if (uppercase)
                    sb.Append(char.ToUpper(c));
                else
                    sb.Append(char.ToLower(c));
                
                uppercase = !uppercase;
            }
            str.Write(sb.ToString());
            str.Close();
        }
    }
}