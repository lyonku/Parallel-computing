class Program
{
    static void Main()
    {
        Action method = CalculateMatrixAverage;
        Thread[] tmas = new Thread[20];

        for (int i = 0; i < tmas.Length; i++)
        {
            tmas[i] = new Thread(CalculateMatrixAverage);
            tmas[i].Start();
        }

        Console.ReadKey();
    }

    static void CalculateMatrixAverage()
    {
        int threadId = Thread.CurrentThread.ManagedThreadId;
        int rows = 8;
        int cols = 8;

        int[,] array = new int[rows, cols];
        Random rnd = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                array[i, j] = rnd.Next(1000);
            }
        }

        // Вычисляем среднее арифметическое
        int sum = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                sum += array[i, j];
            }
        }

        double average = sum / (rows * cols);


        Console.WriteLine("Поток " + threadId + ". Среднее арифметическое в матрице = " + average);
    }
}