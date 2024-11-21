using System;

class Program
{
    static int Sum(params int[] numbers)
    {
        int sum = 0;
        foreach (int i in numbers)
        {
            sum += i;
        }

        return sum;
    }

    enum Vorch
    {
        ОченьВорчливый,
        Ворчливый,
        НеВорчливый
    }
    struct GrandFather
    {
        public string Name;
        public Vorch Vorch;
        public string[] Curses;
        public int Sinyak;

        public GrandFather(string name, Vorch vorch, params string[] curses)
        {
            Name = name;
            Vorch = vorch;
            Curses = curses;
            Sinyak = 0;
        }

        public static int Sinyaki(GrandFather ded, params string[] curses)
        {
            foreach (string cur in ded.Curses)
            {
                if (curses.Contains(cur))
                {
                    ded.Sinyak++;
                }
            }
            return ded.Sinyak;
        }
    }

    static void Multiply(ref int result, params int[] numbers)
    {
        foreach (int i in numbers)
        {
            result *= i;
        }
    }

    static void SrArith(out double result, params int[] numbers)
    {
        result = Sum(numbers)/(double)numbers.Length;
        Console.WriteLine(result);
    }
    
    
    static void Ex1()
    {
        int[] array = new int[20];
        Random random = new Random();
        
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(1, 101); 
        }
        
        Console.WriteLine("Массив до замены:");
        Console.WriteLine(string.Join(", ", array));
        Console.WriteLine("\nВведите первое число из массива для замены:");
        if (!int.TryParse(Console.ReadLine(), out int firstNumber))
        {
            Console.WriteLine("Ошибка ввода");
            return;
        }
        Console.WriteLine("Введите второе число из массива для замены:");
        if (!int.TryParse(Console.ReadLine(), out int secondNumber))
        {
            Console.WriteLine("Ошибка ввода");
            return;
        }
        
        int index1 = Array.IndexOf(array, firstNumber);
        int index2 = Array.IndexOf(array, secondNumber);
        
        if (index1 == -1 || index2 == -1)
        {
            Console.WriteLine("Этих чисел нет в массиве");
            return;
        }
        
        (array[index1], array[index2]) = (array[index2], array[index1]);
        
        Console.WriteLine("\nМассив после замены:");
        Console.WriteLine(string.Join(", ", array));
    }

    static void Ex2()
    {
        int[] ar1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        Console.WriteLine(Sum(ar1));
        int result = 1;
        Multiply(ref result, ar1);
        Console.WriteLine(result);
        double avg;
        SrArith(out avg, ar1);
    }

    static void Ex4()
    {
        GrandFather[] deds = new GrandFather[]
        {
            new GrandFather("Игорь", Vorch.ОченьВорчливый, "Проститутки!", "Стыдобище!"),
            new GrandFather("Евгений", Vorch.НеВорчливый, "Боже!", "Бог тебе судья!"),
            new GrandFather("Андрей", Vorch.Ворчливый, "Понаехали!", "Гады!"),
            new GrandFather("Алексей", Vorch.Ворчливый, "Наркоманы!", "Что за поколение!"),
            new GrandFather("Владимир", Vorch.ОченьВорчливый, "Идиоты!", "Хулиганы!", "Понаехали!"),
        };
        string[] curses = {"Проститутки!", "Понаехали!", "Гады!", "Идиоты!", "Туниядцы"};
        foreach (GrandFather d in deds)
        {
            Console.WriteLine($"Количество синяков у деда по имени {d.Name} : {GrandFather.Sinyaki(d, curses)} ");
        }
    }
    static void Main(string[] args)
    {
        // Вывести на экран массив из 20 случайных чисел. Ввести два числа из этого массива,
        // которые нужно поменять местами. Вывести на экран получившийся массив.
        Console.WriteLine("Упражнение 1");
        Ex1();

        // Написать метод, где в качества аргумента будет передан массив (ключевое слово
        // params). Вывести сумму элементов массива (вернуть). Вывести (ref) произведение
        // массива. Вывести (out) среднее арифметическое в массиве.
        Console.WriteLine("Упражнение 2");
        Ex2();
        
        // Пользователь вводит числа. Если числа от 0 до 9, то необходимо в консоли нарисовать
        // изображение цифры в виде символа #.Если число больше 9 или меньше 0, то консоль
        // должна окраситься в красный цвет на 3 секунды и вывести сообщение об ошибке. Если
        // пользователь ввёл не цифру, то программа должна выпасть в исключение. Программа
        // завершает работу, если пользователь введёт слово: exit или закрыть (оба варианта
        // должны сработать) - консоль закроется.
        
        // Создать структуру Дед. У деда есть имя, уровень ворчливости (перечисление), массив
        // фраз для ворчания (прим.: “Проститутки!”, “Гады!”), количество синяков от ударов
        // бабки = 0 по умолчанию. Создать 5 дедов. У каждого деда - разное количество фраз для
        // ворчания. Напишите метод (внутри структуры), который на вход принимает деда,
        // список матерных слов (params). Если дед содержит в своей лексике матерные слова из
        // списка, то бабка ставит фингал за каждое слово. Вернуть количество фингалов.
        Console.WriteLine("Упражнение 4");
        Ex4();

    }
}