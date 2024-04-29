using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Xml;


namespace CalcConsole
{
    class Sum {
        public static double SumNumbers(List<double> Numbers){
            double Output = 0;
            for (ushort i = 0; i < Numbers.Count; i++) {
                Output += Numbers[i];
            }
            return Output;
        }
    }
    class Sub {
        public static double SubNumbers(List<double> Numbers)
        {
            double Output = 0;
            for (ushort i = 0; i < Numbers.Count; i++)
            {
                Output -= Numbers[i];
            }
            return Output;
        }
    }
    class Multiply {
        public static double MultiplyNumbers(List<double> Numbers) {
            double Output = 1;
            for (ushort i = 0; i < Numbers.Count; i++)
            {
                Output *= Numbers[i];
            }
            return Output;
        }
    }
    class Div {
        public static bool IsNumbersValid(List<double> Numbers) {
            for (ushort i = 0; i < Numbers.Count; i++)
            {
                if (Numbers[i] == 0)
                    return false;
            }
            return true;
        }
        public static double DivNumbers(List<double> Numbers)
        {
            double Output = Numbers[0];
            for (ushort i = 1; i < Numbers.Count; i++)
            {
                Output /= Numbers[i];
            }
            return Output;
        }
    }
    class GetInput {
        static bool TryReadNumber(string num) {
            float parsed_num = 0;
            return float.TryParse(num, out parsed_num);
        }
        public static ushort GetShort(ushort Max) {
            string pattern = "^[0-9]";
            string num = Console.ReadLine();
            Regex rg = new Regex(pattern);
            if (rg.IsMatch(num) && UInt64.Parse(num) < Max)
                return UInt16.Parse(num);
            else
                Console.WriteLine("Неправильно.");
            return GetShort(Max);
        }
        public static double GetNum() {
            string num = Console.ReadLine();
            if (TryReadNumber(num))
                return double.Parse(num);
            else
                return GetNum();
        }
        public static List<double> GetNumList(ushort NumbersCount) {
            List<double> Numbers = new List<double>();
            for (ushort i = 0; i < NumbersCount; i++)
            {
                Console.Write("Введите число " + i.ToString() + ": ");
                Numbers.Add(GetInput.GetNum());
            }
            return Numbers;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            const ushort MaxAction = 4;
            Console.WriteLine("Выберите действие: ");
            Console.WriteLine("0. Сложение");
            Console.WriteLine("1. Вычитание"); 
            Console.WriteLine("2. Умножение");
            Console.WriteLine("3. Деление");
            Console.WriteLine("4. Возведение в степень");
            ushort CurrentVariant = GetInput.GetShort(MaxAction);
            ushort NumbersCount = 1;
            switch (CurrentVariant) {
                case 0:
                    Console.Write("Введите количество слагаемых (1 по умолчанию): ");
                    NumbersCount = GetInput.GetShort(255);
                    double sum = Sum.SumNumbers(GetInput.GetNumList(NumbersCount));
                    Console.Write("Результат сложения: " + sum.ToString());
                    break;
                case 1:
                    Console.Write("Введите количество операндов (1 по умолчанию): ");
                    NumbersCount = GetInput.GetShort(255);
                    double sub = Sum.SumNumbers(GetInput.GetNumList(NumbersCount));
                    Console.Write("Результат вычитания: " + sub.ToString());
                    break;
                case 2:
                    Console.Write("Введите количество множителей (1 по умолчанию): ");
                    NumbersCount = GetInput.GetShort(255);
                    double multiply = Multiply.MultiplyNumbers(GetInput.GetNumList(NumbersCount));
                    Console.Write("Результат умножения: " + multiply.ToString());
                    break;
                case 3:
                    Console.Write("Введите количество делителей (1 по умолчанию): ");
                    NumbersCount = GetInput.GetShort(255);
                    List<double> Numbers = GetInput.GetNumList(NumbersCount);
                    if (!Div.IsNumbersValid(Numbers)) {
                        Console.WriteLine("На ноль делить нельзя.");
                    }
                    else{
                        double div = Div.DivNumbers(Numbers);
                        Console.Write("Результат деления: " + div);
                    }
                    break;
            }
            Console.WriteLine("\n Готово. Для выхода нажть любую клавившу");
            Console.ReadKey();
        }
    }
}