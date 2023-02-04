using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

var accepts = new[] {"y", "yes", "yeah", "да"};
var declines = new[] {"n", "no", "not", "нет"};

var requirementErrors = new List<string>();

bool isValid = false;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Здравствуйте, вы подаетесь на вакансию DevOps инженера в компании Рога и Копыта.");
Console.WriteLine("Нам нужно будет уточнить некоторую информацию");

PrintDelimiter();

Console.Write("Вы согласны с нашей политикой конфиденциальности? (Y/n): ");
var consentResult = Console.ReadLine()?.ToLower();
if (consentResult is null || !accepts.Contains(consentResult))
    ShowUnsatisfiedRequirement("вы не приняли нашу политику конфиденциальности");

PrintDelimiter();

Console.WriteLine("Для начала как вас зовут?");
var name = ReadAndValidate(text => text, input =>
    string.IsNullOrWhiteSpace(input) ? "Неправильно введено имя" : null);


Console.Write("Ваш возраст: ");

var age = ReadAndValidate(text => int.TryParse(text, out int result) ? result : -1,
    age => age < 0 ? "неверное число" : null);

if (age < 18)
    ShowUnsatisfiedRequirement("для оформления договора вы должны быть старше 18 лет");


Console.Write("Ваш стаж работы: ");
var workExperience = ReadAndValidate(text => int.TryParse(text, out int result) ? result : -1,
    exp => exp < 0 || age - exp - 16 <= 0 ? "неверное число" : null);

if (workExperience < 1)
    ShowUnsatisfiedRequirement("ваш стаж еще слишком мал");


Console.WriteLine("Перичислите технологии с которыми вы работали. (Пустая строка завершит ввод)");
var techStack = new List<string>();
string techName;
while (!string.IsNullOrEmpty(techName = Console.ReadLine()))
{
    techStack.Add(techName);
}

if (techStack.Count < 3)
    ShowUnsatisfiedRequirement("вы знаете слишком мало технологий");


Console.WriteLine("Укажите ваш уровень знания английского языка. (по CEFR, например B2)");
var englishLevel = ReadAndValidate(text => text?.ToUpper(),
    input => string.IsNullOrWhiteSpace(input) || input.Length != 2 ||
             !(input[0] is (>='A') and (<='C') && input[1] is '1' or '2')
        ? "неправильно введен уровень языка" : null);

if (englishLevel[0] < 'B')
    ShowUnsatisfiedRequirement("нам требуется персонал с высоким уровнем знания английского");


Console.Write("Вы готовы работать сверхурочно? (Y/n): ");
var overtimeConsent = Console.ReadLine()?.ToLower();
if (overtimeConsent is null || !accepts.Contains(overtimeConsent))
    ShowUnsatisfiedRequirement("нам нужны трудолюбивые сотрудники");


Console.Write("Желаемая зарплата: ");
var salary = ReadAndValidate(text => int.TryParse(text, out int result) ? result : -1,
    age => age < 0 ? "неверное число" : null);

if (salary > 200000)
    ShowUnsatisfiedRequirement("мы не можем платить столько");


Console.Write("Вы готовы управлять кластером из 100 машин на bare-metal? (Y/n): ");
var bareMetalConsent = Console.ReadLine()?.ToLower();
if (bareMetalConsent is null || !accepts.Contains(bareMetalConsent))
    ShowUnsatisfiedRequirement("к сожалению, вы не справитесь с нашей инфраструктурой");


Console.Write("Простой вопрос, какой командой управляют сетевым экраном linux?: ");
var iptablesAnswer = Console.ReadLine()?.ToLower();
if (iptablesAnswer is null or not "iptables")
    ShowUnsatisfiedRequirement("такие вещи знать надо");


Console.Write("Простой вопрос, какой командой управляют кластером k8s?: "); 
var kubectlAnswer = Console.ReadLine()?.ToLower();
if (kubectlAnswer is null or not "kubectl")
    ShowUnsatisfiedRequirement("такие вещи знать надо");

PrintDelimiter();

Console.WriteLine($"Имя: {name}");
Console.WriteLine($"Возраст: {age}");
Console.WriteLine($"Стаж: {workExperience}");
Console.WriteLine($"Стак: {string.Join(" / ", techStack)}");
Console.WriteLine($"Уровень английского: {englishLevel}");
Console.WriteLine($"Желаемая зарплата: ≈{salary}₽");
Console.WriteLine(@"Готовность к сверхурочной работе: ✅");
Console.WriteLine(@"Готовность к поддержке кластера: ✅");
Console.WriteLine(@"Тест по Linux: ✅");
Console.WriteLine(@"Тест по k8s: ✅");
Console.WriteLine(@"Согласие на обработку данных: ✅");

Console.WriteLine("Вы нам подходите!");

PrintDelimiter();

Console.WriteLine("Спасибо, мы сохранили вашу заявку.");
Halt();

void PrintDelimiter()
{
    Console.WriteLine($"\n{new string('-', 10)}\n");
}


//Прошу прощения за генерики, но это лучший метод который я придумал.

T ReadAndValidate<T>(Func<string, T?> transformer, Func<T?, string?> validator)
{
    T obj;
    while (true)
    {
        var input = Console.ReadLine() ?? "";
        obj = transformer(input);

        var validationError = validator(obj);
        if (validationError is null)
            break;

        ShowValidationError(validationError);
    }

    return obj;
}

void ShowUnsatisfiedRequirement(string message)
{
    PrintDelimiter();
    Console.WriteLine("К сожалению вы нам не подходите\n" +
                      $"Причина: {message} ");
    Halt();
}

void ShowValidationError(string message)
{
    PrintDelimiter();
    Console.WriteLine($"У вас ошибка в поле: {message}, повторите ввод ");
}

void Halt()
{
    Console.WriteLine("Анкетирование завершено. Нажмите любую клавишу для выхода...");
    Console.ReadKey();
    System.Environment.Exit(0);
}

