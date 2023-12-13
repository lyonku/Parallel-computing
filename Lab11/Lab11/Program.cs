using System;
using System.Threading.Tasks;

class Program
{
    public static void Main()
    {
        int size = 15;
        TaskArrayProcessor arrayProcessor = new TaskArrayProcessor(size);

        Task tBase = new Task(() =>
        {
            Console.WriteLine("Первая задача. Начало");
            arrayProcessor.FindMinOdd();
            Console.WriteLine("Первая задача. Окончание");
        });

        Task tContinue = tBase.ContinueWith(base_task =>
        {
            Console.WriteLine("Вторая задача. Начало");
            arrayProcessor.CountDivisibleBy7();
            Console.WriteLine("Вторая задача. Окончание");
        });

        tBase.Start();
        Console.ReadKey();
    }
}

public class TaskArrayProcessor
{
    private int[] array;

    public TaskArrayProcessor(int size)
    {
        array = new int[size];
        Random rnd = new Random();

        for (int i = 0; i < size; i++)
        {
            array[i] = rnd.Next(1000);
        }
    }

    public void FindMinOdd()
    {
        int minOdd = int.MaxValue;

        foreach (var num in array)
        {
            if (num % 2 != 0 && num < minOdd)
            {
                minOdd = num;
            }
        }

        Console.WriteLine("Минимальный нечетный элемент: {0}", minOdd);
    }

    public void CountDivisibleBy7()
    {
        int count = 0;

        foreach (var num in array)
        {
            if (num % 7 == 0)
            {
                count++;
            }
        }

        Console.WriteLine("Количество элементов, делящихся на 7: {0}", count);
    }
}