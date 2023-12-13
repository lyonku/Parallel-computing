using System;

class Program
{
    static void Main()
    {
        Func<Action<bool>, float, float> myFuncDelegate = SomeMethod;
        Action<bool> myActionDelegate = IsExamPass;

        float result = myFuncDelegate(myActionDelegate, 4.9f);
        Console.WriteLine("Средняя оценка: " + result);
    }

    static float SomeMethod(Action<bool> action, float param)
    {
        Console.WriteLine("Аттестация: Пилипенко Евгений");
        action(true);  // Пример вызова Action<bool>
        return param;
    }

    static void IsExamPass(bool param)
    {
        Console.WriteLine("Экзамен сдан: " + (param ? "Да" : "Нет"));
    }
}
