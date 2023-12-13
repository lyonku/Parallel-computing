class Program
{
    static void Main()
    {
        int a = 5;
        int b = 7;

        int result = SquareOfNumbers(a, b);

        Console.WriteLine($"Квадрат произведения {a} и {b} равен: {result}");
    }

    static int SquareOfNumbers(int x, int y)
    {
        int multiplication = x * y;
        int square = multiplication * multiplication;

        return square;
    }
}
