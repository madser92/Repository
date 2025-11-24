using System;

class Program
{
    // Метод для безопасного ввода положительного целого числа
    static int ReadPositiveInt(string prompt)
    {
        int value;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out value) && value > 0)
            {
                return value;
            }
            Console.WriteLine("Ошибка: введите целое число больше 0.");
        }
    }

    // Метод для ввода массива строк заданной длины
    static string[] ReadStringArray(int count, string itemPrompt)
    {
        string[] array = new string[count];
        for (int i = 0; i < count; i++)
        {
            Console.Write($"{itemPrompt} {i + 1}: ");
            array[i] = Console.ReadLine();
        }
        return array;
    }

    // Метод для заполнения данных о пользователе
    static (string name, string surname, int age, bool hasPet, string[] petNames, string[] favColors) ReadUser()
    {
        Console.Write("Введите имя: ");
        string name = Console.ReadLine();

        Console.Write("Введите фамилию: ");
        string surname = Console.ReadLine();

        int age = ReadPositiveInt("Введите возраст: ");

        Console.Write("Есть ли у вас питомец? (да/нет): ");
        string petAnswer = Console.ReadLine().Trim().ToLower();
        bool hasPet = petAnswer == "да" || petAnswer == "д" || petAnswer == "yes" || petAnswer == "y";

        string[] petNames = new string[0];
        if (hasPet)
        {
            int petCount = ReadPositiveInt("Введите количество питомцев: ");
            petNames = ReadStringArray(petCount, "Кличка питомца");
        }

        int colorCount = ReadPositiveInt("Введите количество любимых цветов: ");
        string[] favColors = ReadStringArray(colorCount, "Любимый цвет");

        return (name, surname, age, hasPet, petNames, favColors);
    }

    // Метод для отображения данных пользователя
    static void ShowUser((string name, string surname, int age, bool hasPet, string[] petNames, string[] favColors) user)
    {
        Console.WriteLine("\n--- Данные пользователя ---");
        Console.WriteLine($"Имя: {user.name}");
        Console.WriteLine($"Фамилия: {user.surname}");
        Console.WriteLine($"Возраст: {user.age}");

        if (user.hasPet)
        {
            Console.WriteLine($"Количество питомцев: {user.petNames.Length}");
            Console.WriteLine("Клички питомцев: " + string.Join(", ", user.petNames));
        }
        else
        {
            Console.WriteLine("Питомцев нет.");
        }

        Console.WriteLine($"Любимые цвета: {string.Join(", ", user.favColors)}");
    }

    // Точка входа
    static void Main()
    {
        var userData = ReadUser();
        ShowUser(userData);
    }
}