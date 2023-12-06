using System;

class Program
{
    static void Main()
    {
        // Пример использования функции
        int a = 5;
        int b = 7;

        int result = SquareOfNumbers(a, b);

        Console.WriteLine($"Квадрат произведения {a} и {b} равен: {result}");
    }

    static int SquareOfNumbers(int x, int y)
    {
        // Вычисляем произведение
        int multiplication = x * y;

        // Возводим результат в квадрат
        int square = multiplication * multiplication;

        return square;
    }
}
