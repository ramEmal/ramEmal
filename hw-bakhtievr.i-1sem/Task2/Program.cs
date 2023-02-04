using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

var accepts = new[] { "y", "yes", "yeah", "да" };
var declines = new[] { "n", "no", "not", "нет" };

bool isValid = false;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Здравствуйте, вы подаетесь на вакансию DevOps инженера в компании Рога и Копыта.");
Console.WriteLine("Нам нужно будет уточнить некоторую информацию");

PrintDelimiter();

Console.Write("Вы согласны с нашей политикой конфиденциальности? (Y/n): ");
var consentResult = Console.ReadLine()?.ToLower();
if (consentResult is null || !accepts.Contains(consentResult))
    UnsatisfiedRequirement("вы не приняли нашу политику конфиденциальности");

PrintDelimiter();

Console.WriteLine("Для начала как вас зовут?"); 
var name = Console.ReadLine();
if (string.IsNullOrWhiteSpace(name))
    ValidationErrorExit("имя","не указанно имя");


Console.Write("Ваш возраст: ");
isValid = int.TryParse(Console.ReadLine(), out var age);

if(!isValid || age < 0)
    ValidationErrorExit("возраст", "неверное число");
if(age < 18)
    UnsatisfiedRequirement("для оформления договора вы должны быть старше 18 лет");


Console.Write("Ваш стаж работы: ");
isValid = int.TryParse(Console.ReadLine(), out var workExperience);

if(!isValid || workExperience < 0 || age - workExperience - 16 <= 0)
    ValidationErrorExit("стаж", "неверное число");
if(workExperience < 1)
    UnsatisfiedRequirement("ваш стаж еще слишком мал");


Console.WriteLine("Перичислите технологии с которыми вы работали. (Пустая строка завершит ввод)");
var techStack = new List<string>();
string techName;
while (!string.IsNullOrEmpty(techName = Console.ReadLine()))
{
    techStack.Add(techName);
}
if(techStack.Count < 3)
    UnsatisfiedRequirement("вы знаете слишком мало технологий");


Console.WriteLine("Укажите ваш уровень знания английского языка. (по CEFR, например B2)"); 
var englishLevel = Console.ReadLine()?.ToUpper();
if (string.IsNullOrWhiteSpace(englishLevel) || englishLevel.Length != 2 || !(englishLevel[0] is (>='A') and (<='C') && englishLevel[1] is '1' or '2' ) )
    ValidationErrorExit("уровень языка","указан неверно");
if(englishLevel[0] < 'B')
    UnsatisfiedRequirement("нам требуется персонал с высоким уровнем знания английского");


Console.Write("Вы готовы работать сверхурочно? (Y/n): ");
var overtimeConsent = Console.ReadLine()?.ToLower();
if (overtimeConsent is null || !accepts.Contains(overtimeConsent))
    UnsatisfiedRequirement("нам нужны трудолюбивые сотрудники");


Console.Write("Желаемая зарплата: ");
isValid = int.TryParse(Console.ReadLine(), out var salary);
if(!isValid || salary < 0)
    ValidationErrorExit("зарплата", "неверное число");
if(salary > 200000)
    UnsatisfiedRequirement("мы не можем платить столько");


Console.Write("Вы готовы управлять кластером из 100 машин на bare-metal? (Y/n): ");
var bareMetalConsent = Console.ReadLine()?.ToLower();
if (bareMetalConsent is null || !accepts.Contains(bareMetalConsent))
    UnsatisfiedRequirement("к сожалению, вы не справитесь с нашей инфраструктурой");


Console.Write("Простой вопрос, какой командой управляют сетевым экраном linux?: ");
var iptablesAnswer = Console.ReadLine()?.ToLower();
if (iptablesAnswer is null or not "iptables")
    UnsatisfiedRequirement("такие вещи знать надо");


Console.Write("Простой вопрос, какой командой управляют кластером k8s?: ");
var kubectlAnswer = Console.ReadLine()?.ToLower();
if (kubectlAnswer is null or not "kubectl")
    UnsatisfiedRequirement("такие вещи знать надо");

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
    Console.WriteLine($"\n{new string('-',10)}\n");
}

void UnsatisfiedRequirement(string message)
{
    PrintDelimiter();
    Console.WriteLine("К сожалению вы нам не подходите\n" +
                      $"Причина: {message} ");
    Halt();
}

void ValidationErrorExit(string paramName,string message)
{
    PrintDelimiter();
    Console.WriteLine("К сожалению вы не осилили правильно заполнить форму\n" +
                      $"У вас ошибка в поле {paramName}: {message} ");
    Halt();
}

void Halt()
{
    Console.WriteLine("Анкетирование завершено. Нажмите любую клавишу для выхода...");
    Console.ReadKey();
    System.Environment.Exit(0);
}
