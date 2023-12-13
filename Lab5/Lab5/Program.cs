using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    // Определение делегата
    delegate int[] GetEvenSubsetDelegate();

    static void Main()
    {
        MyTask myTask = new MyTask();

        GetEvenSubsetDelegate getEvenSubset = () =>
        {
            // Генерация массива случайных чисел
            myTask.GenerateRandomNumbers(10);

            // Получение подмножества четных чисел
            int[] evenSubset = myTask.GetEvenNumbers();

            return evenSubset;
        };
        CancellationTokenSource cancellationToken = new CancellationTokenSource();

        Task<int[]> task = Task.Run(() => getEvenSubset());


        bool waitCheck = task.Wait(TimeSpan.FromSeconds(2));
        if (waitCheck)
        {
            Console.WriteLine("\nПрограмма выполнилась вовремя");
        }
        else
        {
            cancellationToken.Cancel();
            throw new TimeoutException("\nПрограмма не успела завершится ");
        }
    }
}

class MyTask
{
    private int[] array;

    // Генерация массива случайных чисел
    public void GenerateRandomNumbers(int size)
    {
        Random random = new Random();
        int[] resultArray = new int[size];

        for (int i = 0; i < size; i++)
        {
            resultArray[i] = random.Next(100);
        }

        array = resultArray;
    }

    // Получение подмножества четных чисел из массива
    public int[] GetEvenNumbers()
    {
        List<int> evenNumbers = new List<int>();
        Thread.Sleep(3000);
        foreach (var num in array)
        {
            if (num % 2 == 0)
            {
                evenNumbers.Add(num);
            }
        }

        Console.WriteLine("Подмножество четных чисел:");
        foreach (var num in evenNumbers)
        {
            Console.Write(num + " ");
        }

        return evenNumbers.ToArray();
    }

}