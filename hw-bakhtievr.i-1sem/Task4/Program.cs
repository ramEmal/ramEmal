using System;
using System.Collections.Generic;
using System.Linq;

Console.WriteLine("Введите массив чисел разделяя пробелами пробел");

ReadArrayInt(out var input);

while (true)
{
    PrintMenu();
    var isValidCommand = int.TryParse(Console.ReadLine(), out var command);
    if (!isValidCommand)
    {
        Console.WriteLine("Неверная комманда, повторите ввод");
        continue;
    }

    try
    {
        switch (command)
        {
            case 0:
                Environment.Exit(0); 
                break;
            case 1:
                PrintSameSignElements(input);
                break;
            case 2:
                PrintBiggerElements(input);
                break;
            case 3:
                var result = "";
                GetReversedArray(input, ref result);
                Console.WriteLine(result);
                break;
            case 4:
                Console.WriteLine(PrintSorted());
                break;
            case 5:
                Console.WriteLine(GetDivisibleArrays(input).even);
                break;
            case 6:
                Console.WriteLine(GetDivisibleArrays(input).odd);
                break;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"Ошибка при выполнении комманды: {e.Message}"); 
    }
}

void PrintSameSignElements(int[] array)
{
    if (array.Length < 3)
        throw new ArgumentException("В массиве слишком мало элементов для этой комманды", nameof(array));
    var wasElementFound = false;
    for (var index = 1; index < array.Length - 1; index++)
    {
        if (Math.Sign(array[index - 1]) == Math.Sign(array[index])
            && Math.Sign(array[index + 1]) == Math.Sign(array[index]))
        {
            wasElementFound = true;
            Console.Write(array[index]+" ");
        }
            
    }
    Console.WriteLine(wasElementFound ? "" : "Ни одного элемента не найденно");
}

void PrintBiggerElements(int[] array)
{
    if (array.Length < 3)
        throw new ArgumentException("В массиве слишком мало элементов для этой комманды", nameof(array));
    var wasElementFound = false;
    
    for (var index = 1; index < array.Length - 1; index++)
    {
        if (array[index - 1] > array[index]
            && array[index + 1] > array[index])
        {
            wasElementFound = true;
            Console.Write(array[index]+" ");
        }
            
    }
    Console.WriteLine(wasElementFound ? "" : "Ни одного элемента не найденно");
}

void GetReversedArray(int[] array, ref string result)
{
    result = string.Join(" ", array.Reverse());
}

string PrintSorted()
{
    return string.Join(" ", input);
}

(string even, string odd) GetDivisibleArrays(int[] array)
{
    var even = string.Join(" ",array.Where(x => x % 2 == 0));
    var odd = string.Join(" ",array.Where(x => x % 2 != 0));
    return (even, odd);
}

void ReadArrayInt(out int[] array)
{
    while (true)
    {
        try
        {
            array = Console.ReadLine()?.Split(" ").Select(int.Parse).ToArray();

            if (array == null || array.Length < 1)
                throw new ApplicationException();

            break;
        }
        catch (Exception e)
        {
            Console.WriteLine("Произошла ошибка, повторите ввод");
        }
    }
}

void PrintMenu()
{
    Console.WriteLine("Список комманд:");
    Console.WriteLine("1. Вывести элементы имеющие соседей с одиновыми знаками");
    Console.WriteLine("2. Вывести элементы имеющие соседей больше самого элемента");
    Console.WriteLine("3. Вывести перевернутый массив");
    Console.WriteLine("4. Вывести отсортированный массив");
    Console.WriteLine("5. Вывести четные значения");
    Console.WriteLine("6. Вывести нечетные значения");
    Console.WriteLine("0. Выход из программы");
    Console.WriteLine("----------------------");
    Console.Write("Выбор: ");
}
