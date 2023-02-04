using System;
namespace Task9
{
    /// <summary>
    /// выбрасывает ошибку если пользователь укажет число большее вместимости автобуса
    /// </summary>
    public class MyException:Exception 
    { 
        public int Value { get; }
        public MyException(string message, int val) : base(message)
        {
            Value = val; 
        } 
    }
}