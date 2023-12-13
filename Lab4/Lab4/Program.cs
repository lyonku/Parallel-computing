using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    // Определение делегата
    delegate int[] GetEvenSubsetDelegate(int size);

    static void Main()
    {
        MyTask myTask = new MyTask();

        GetEvenSubsetDelegate getEvenSubset = (size) =>
        {
            // Генерация массива случайных чисел
            myTask.GenerateRandomNumbers(size);

            // Получение подмножества четных чисел
            int[] evenSubset = myTask.GetEvenNumbers();

            return evenSubset;
        };

        Task<int[]> task = Task.Run(() => getEvenSubset(10));

        Console.ReadKey();
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