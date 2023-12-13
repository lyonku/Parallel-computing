using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    public static void Main()
    {
        int ArraySize = 25; // Размер массива
        int Divisor = 3; // Делитель

        var obj = new MyThread(ArraySize, Divisor);
        var th = new Thread(obj.ThreadMain);
        th.Start();
    }
}

public class MyThread
{
    private int Divisor;
    private int[] array;

    public MyThread(int ArraySize, int Divisor)
    {
        this.Divisor = Divisor;

        // Инициализация массива случайными числами
        Random rand = new Random();
        array = new int[ArraySize];
        for (int i = 0; i < ArraySize; i++)
        {
            array[i] = rand.Next(1, 1000);
        }
    }

    public void ThreadMain()
    {
        Console.WriteLine("Массив:");
        PrintArray(array);

        Console.WriteLine("Элементы, делящиеся на {0}:", Divisor);
        foreach (var element in array)
        {
            if (element % Divisor == 0)
            {
                Console.Write(element + " ");
            }
        }
        Console.WriteLine();
    }

    private void PrintArray(int[] arr)
    {
        foreach (var element in arr)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }

}
