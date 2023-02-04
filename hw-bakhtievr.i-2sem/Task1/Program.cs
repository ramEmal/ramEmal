using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Account<string> account1 = new Account<string>("3s4ds53fg4");
            Account<int> account2 = new Account<int>(3456357);
            
            account1.ChangePassword("345sg3gd4df5");
            Console.WriteLine(account1.Password);
            
            ObjAccount objAccount1 = new ObjAccount("3s4ds53fg4");
            ObjAccount objAccount2 = new ObjAccount(85435657);
            ObjAccount objAccount3 = new ObjAccount("7s5634564");
            
            objAccount1.ChangePassword("werqqyxvbxrq444");
            Console.WriteLine(objAccount1.Password);
            
            objAccount2.ChangePassword("78924928374");
            Console.WriteLine(objAccount2.Password);
        }
    }
}
