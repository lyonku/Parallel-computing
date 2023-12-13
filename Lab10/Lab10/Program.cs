using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    public static void Main()
    {
        int rows = 5;
        int cols = 5;

        var matrixMaxFinder = new TaskMatrixMaxFinder(rows, cols);
        Task task = Task.Factory.StartNew(matrixMaxFinder.FindMax);
        task.Wait();
    }
}

public class TaskMatrixMaxFinder
{
    private int rows;
    private int cols;
    private int[,] array;

    public TaskMatrixMaxFinder(int rows, int cols)
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

    public void FindMax()
    {
        int max = int.MinValue;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (array[i, j] > max)
                {
                    max = array[i, j];
                }
            }
        }

        Console.WriteLine("Максимальный элемент в матрице: {0}", max);
    }
}