using System;

namespace task4
{
    internal class NotEnoughMedicineException : Exception
    {
        public NotEnoughMedicineException(string message) : base(message)
        {
        }
    }
}