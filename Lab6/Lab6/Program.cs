using System;
using System.Linq;
using System.Threading.Tasks;

// Делегат для обратного вызова
delegate void CallbackDelegate(int[] result);

class Program
{
    static async Task Main(string[] args)
    {
        int arraySize = 10;

        // Использование делегата для обратного вызова
        CallbackDelegate callback = result =>
        {
            Console.WriteLine("Результат:");
            foreach (var item in result)
            {
                Console.Write($"{item} ");
            }
        };

        await ProcessArrayAsync(arraySize, callback);
    }

    // Асинхронный метод с использованием делегата для обратного вызова
    static async Task ProcessArrayAsync(int size, CallbackDelegate callback)
    {
        int[] array = GenerateRandomArray(size);

        await Task.Run(() =>
        {
            var result = array.Where(x => x % 3 == 0).ToArray();
            // Вызываем делегат (обратный асинхронный метод)
            callback(result);
        });
    }

    static int[] GenerateRandomArray(int size)
    {
        Random random = new Random();
        int[] resultArray = new int[size];

        for (int i = 0; i < size; i++)
        {
            resultArray[i] = random.Next(1, 100);
        }

        return resultArray;
    }
}
