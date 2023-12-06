using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    // Определение делегата
    delegate Task<int[]> GetEvenSubsetDelegate(int size);

    static async Task Main()
    {
        // Создание экземпляра делегата с использованием лямбда-выражения
        GetEvenSubsetDelegate getEvenSubset = async (size) =>
        {
            // Генерация массива случайных чисел
            int[] randomNumbers = GenerateRandomNumbers(size);

            // Мониторинг процесса выполнения
            Console.WriteLine("Выполняется обработка...");

            // Задержка для имитации длительного вычисления
            await Task.Delay(2000);

            // Получение подмножества четных чисел
            int[] evenSubset = GetEvenNumbers(randomNumbers);

            // Возврат результата
            return evenSubset;
        };

        // Добавлен тайм-аут в 5 секунд
        var timeoutTask = Task.Delay(5000);
        var resultTask = getEvenSubset(10);

        // Ожидание завершения задачи или тайм-аута
        var completedTask = await Task.WhenAny(resultTask, timeoutTask);

        // Вывод информации о ходе решения
        if (completedTask == resultTask)
        {
            Console.WriteLine("Задача выполнена успешно:");
            // Получение результата
            int[] result = await resultTask;

            Console.WriteLine("Подмножество четных чисел:");
            foreach (var num in result)
            {
                Console.Write(num + " ");
            }
        }
        else
        {
            Console.WriteLine("Время ожидания истекло. Задача прервана.");
        }
    }

    // Генерация массива случайных чисел
    static int[] GenerateRandomNumbers(int size)
    {
        Random random = new Random();
        int[] resultArray = new int[size];

        for (int i = 0; i < size; i++)
        {
            resultArray[i] = random.Next(1, 100);
        }

        return resultArray;
    }

    // Получение подмножества четных чисел из массива
    static int[] GetEvenNumbers(int[] numbers)
    {
        int count = 0;

        foreach (var num in numbers)
        {
            if (num % 2 == 0)
            {
                count++;
            }
        }

        int[] evenNumbers = new int[count];
        int index = 0;

        foreach (var num in numbers)
        {
            if (num % 2 == 0)
            {
                evenNumbers[index] = num;
                index++;
            }
        }

        return evenNumbers;
    }
}
