using System;
using System.Threading;

class Program
{
    public static void Main()
    {
        // Задаем размер матрицы (например, 3x3)
        int rows = 5;
        int cols = 5;

        var obj = new MyThread(rows, cols);
        var th = new Thread(obj.ThreadMain);
        th.Start();
    }
}

public class MyThread
{
    private int rows;
    private int cols;
    private int[,] array;

    public MyThread(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;

        array = new int[rows, cols];
        Random rnd = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                array[i, j] = rnd.Next(1000);
            }
        }
    }

    public void ThreadMain()
    {
        // Вывод матрицы
        Console.WriteLine("Матрица:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }

        // Находим и выводим сумму элементов матрицы
        int sum = CalculateMatrixSum();
        Console.WriteLine("Сумма элементов матрицы: {0}", sum);
    }

    private int CalculateMatrixSum()
    {
        int sum = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                sum += array[i, j];
            }
        }

        return sum;
    }
}
