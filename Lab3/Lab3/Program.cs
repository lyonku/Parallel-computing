using System;

class Program
{
    static void Main()
    {
        // Пример использования делегата
        Func<Action<bool>, float, float> myFuncDelegate = SomeMethod;
        Action<bool> myActionDelegate = IsNewStudent;

        float result = myFuncDelegate(myActionDelegate, 4.5f);
        Console.WriteLine("Средняя оценка: " + result);
    }

    static float SomeMethod(Action<bool> action, float param)
    {
        action(true);  // Пример вызова Action<bool>
        return param;
    }

    static void IsNewStudent(bool param)
    {
        Console.WriteLine("Новый студент? " + param);
    }
}
