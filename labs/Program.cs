using System;

class Program
{
    static int Max(int a, int b)
    {
        return a > b ? a : b;
    }

    static void Change(ref int a, ref int b)
    {
        (a, b) = (b, a);
    }

    static bool Factorial(int number, out long result)
    {
        result = 1;
        try
        {
            checked
            {
                for (int i = 1; i <= number; i++)
                {
                    result *= i;
                }
            }
            return true;
        }
        catch (OverflowException)
        {
            result = 0;
            return false;
        }
    }
    
    static int SecondFactorial(int number)
    {
        if (number == 0 || number == 1) 
            return 1;
        return number * SecondFactorial(number - 1);
    }
    
    static int Fibonacci(int n)
    {
        if (n == 1 || n == 2) 
            return 1;

        return Fibonacci(n - 1) + Fibonacci(n - 2); 
    }

    
    static int NOD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b; 
            a = temp;  
        }
        return a;
    }
    static int NOD(int a, int b, int c)
    {
        return NOD(NOD(a, b), c);
    }


    static void Ex1()
    {
        Console.WriteLine("Введите первое число:");
        int num1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите второе число:");
        int num2 = int.Parse(Console.ReadLine());
        int maxNum = Max(num1, num2);
        Console.WriteLine($"Наибольшее число: {maxNum}");
    }

    static void Ex2()
    {
        Console.WriteLine("Введите первое число:");
        int number1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите второе число:");
        int number2 = int.Parse(Console.ReadLine());
        Console.WriteLine($"\nДо обмена: {number1}, {number2}");
        Change(ref number1, ref number2);
        Console.WriteLine($"После обмена: {number1}, {number2}");
    }

    static void Ex3()
    {
        Console.WriteLine("Введите число для вычисления факториала:");
        int number = int.Parse(Console.ReadLine());
        if (number < 0)
        {
            Console.WriteLine("Факториал определён только для неотрицательных чисел.");
            return;
        }
        if (Factorial(number, out long factorial))
        {
            Console.WriteLine($"Факториал числа {number} равен {factorial}");
        }
        else
        {
            Console.WriteLine($"Ошибка: При вычислении факториала числа {number} произошло переполнение.");
        }
    }
    static void Ex4()
    {
        Console.WriteLine("Введите число для вычисления факториала:");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            if (number < 0)
            {
                Console.WriteLine("Ошибка: Факториал определён только для неотрицательных чисел.");
                return;
            }

            long result = SecondFactorial(number); 
            Console.WriteLine($"Факториал числа {number} равен {result}");
        }
        else
        {
            Console.WriteLine("Ошибка ввода");
        }
    }

    static void Ex5()
    {
        Console.WriteLine("Введите два числа для вычисления НОД:");

        if (!int.TryParse(Console.ReadLine(), out int num1) || !int.TryParse(Console.ReadLine(), out int num2))
        {
            Console.WriteLine("Ошибка ввода");
            return;
        }

        Console.WriteLine($"НОД чисел {num1} и {num2} равен {NOD(num1, num2)}");

        // Ввод трёх чисел с проверкой на корректность
        Console.WriteLine("Введите третье число для вычисления НОД:");

        if (!int.TryParse(Console.ReadLine(), out int num3))
        {
            Console.WriteLine("Ошибка ввода");
            return;
        }

        Console.WriteLine($"НОД чисел {num1}, {num2} и {num3} равен {NOD(num1, num2, num3)}");
    }

    static void Ex6()
    {
        Console.WriteLine("Введите номер числа Фибоначчи:");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
        {
            int result = Fibonacci(n);
            Console.WriteLine($"Число Фибоначчи с номером {n}: {result}");
        }
        else
        {
            Console.WriteLine("Ошибка ввода");
        }
    }

    
    public static void Main(string[] args)
    {
        // Написать метод, возвращающий наибольшее из двух чисел. Входные
        // параметры метода – два целых числа. Протестировать метод.
        Console.WriteLine("Упражнение 4.1");
        Ex1();
        
        // Написать метод, который меняет местами значения двух передаваемых
        // параметров. Параметры передавать по ссылке. Протестировать метод.
        Console.WriteLine("\nУпражнение 4.2");
        Ex2();
        
        // Написать метод вычисления факториала числа, результат вычислений
        // передавать в выходном параметре. Если метод отработал успешно, то вернуть значение true;
        // если в процессе вычисления возникло переполнение, то вернуть значение false. Для
        // отслеживания переполнения значения использовать блок checked.
        Console.WriteLine("\nУпражнение 4.3");
        Ex3();
        
        // Написать рекурсивный метод вычисления факториала числа.
        Console.WriteLine("\nУпражнение 4.4");
        Ex4();
        
        // Написать метод, который вычисляет НОД двух натуральных чисел
        // (алгоритм Евклида). Написать метод с тем же именем, который вычисляет НОД трех
        // натуральных чисел.
        Console.WriteLine("\nДомашнее задание 5.1");
        Ex5();
        // Написать рекурсивный метод, вычисляющий значение n-го числа
        // ряда Фибоначчи. Ряд Фибоначчи – последовательность натуральных чисел 1, 1, 2, 3, 5, 8,
        // 13... Для таких чисел верно соотношение Fk = Fk-1 + Fk-2 .
        Console.WriteLine("\nДомашнее задание 5.2");
        Ex6();
        
    }
}