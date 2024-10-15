class Program
{
    static void Main(string[] args)
    {
        IUniversity university = new University();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Загрузить студентов и преподавателей из файлов");
            Console.WriteLine("2. Показать всех студентов");
            Console.WriteLine("3. Добавить студента");
            Console.WriteLine("4. Удалить студента");
            Console.WriteLine("5. Показать всех преподавателей");
            Console.WriteLine("6. Добавить преподавателя");
            Console.WriteLine("7. Удалить преподавателя");
            Console.WriteLine("8. Найти по фамилии");
            Console.WriteLine("9. Выдать всех студентов, чей средний балл выше заданного. Отсортировать их по среднему баллу");
            Console.WriteLine("0. Выход");

            Console.Write("\nВыберите опцию: ");
            string choice = Console.ReadLine() ?? string.Empty;

            switch (choice)
            {
                case "1":
                    LoadData(university);
                    break;
                case "2":
                    ShowStudents(university);
                    break;
                case "3":
                    AddStudent(university);
                    break;
                case "4":
                    DeleteStudent(university);
                    break;
                case "5":
                    ShowTeachers(university);
                    break;
                case "6":
                    AddTeacher(university);
                    break;
                case "7":
                    DeleteTeacher(university);
                    break;
                case "8":
                    FindByLastName(university);
                    break;
                case "9":
                    FindByAvrPoint(university);
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Неправильный выбор, попробуйте еще раз.");
                    break;
            }
        }
    }

    // Метод загрузки данных студентов и преподавателей из файлов
    static void LoadData(IUniversity university)
    {
        string studentFilePath = "data/students.txt";
        string teacherFilePath = "data/teachers.txt";

        // Загрузка студентов
        if (File.Exists(studentFilePath))
        {
            foreach (var line in File.ReadLines(studentFilePath))
            {
                try
                {
                    var student = Student.CreateFromString(line);  // Парсинг строки в объект студента
                    university.Add(student);  // Добавление студента в университет
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка при разборе строки студента: {e.Message}");
                }
            }
        }
        else
        {
            Console.WriteLine($"Файл студентов '{studentFilePath}' не найден.");
        }

        // Загрузка преподавателей
        if (File.Exists(teacherFilePath))
        {
            foreach (var line in File.ReadLines(teacherFilePath))
            {
                try
                {
                    var teacher = Teacher.CreateFromString(line);  // Парсинг строки в объект преподавателя
                    university.Add(teacher);  // Добавление преподавателя в университет
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка при разборе строки преподавателя: {e.Message}");
                }
            }
        }
        else
        {
            Console.WriteLine($"Файл преподавателей '{teacherFilePath}' не найден.");
        }

        Console.WriteLine("Данные загружены.");
    }

    // Метод для показа всех студентов
    static void ShowStudents(IUniversity university)
    {
        Console.WriteLine("\nСтуденты:");
        foreach (var student in university.Students)
        {
            Console.WriteLine(student);  // Печать каждого студента
        }
    }

    // Метод для добавления нового студента
    static void AddStudent(IUniversity university)
    {
        Console.Write("\nВведите данные студента (например: Иван; Иванович; Иванов; 1 Сен 2000; 1; A1; 4,5): ");
        string data = Console.ReadLine();
        try
        {
            var student = Student.CreateFromString(data);  // Парсинг строки в объект студента
            university.Add(student);  // Добавление студента в университет
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при добавлении студента: {e.Message}");
        }
    }

    static void DeleteStudent(IUniversity university)
    {
        Console.Write("\nВведите фамилию студента для удаления: ");
        string lastName = Console.ReadLine();
        var students = university.FindByLastName(lastName).OfType<Student>().ToList();  // Поиск студентов по фамилии

        if (students.Count > 0)
        {
            Console.WriteLine("Найдены следующие студенты:");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. " + students[i].ToString());
            }

            Console.Write("Введите номер студента для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= students.Count)
            {
                university.Remove(students[index - 1]);
                Console.WriteLine("Студент успешно удалён.");
            }
            else
            {
                Console.WriteLine("Некорректный номер.");
            }
        }
        else
        {
            Console.WriteLine("Студенты с такой фамилией не найдены.");
        }
    }


    // Метод для показа всех преподавателей
    static void ShowTeachers(IUniversity university)
    {
        Console.WriteLine("\nПреподаватели:");
        foreach (var teacher in university.Teachers)
        {
            Console.WriteLine(teacher);  // Печать каждого преподавателя
        }
    }

    // Метод для добавления нового преподавателя
    static void AddTeacher(IUniversity university)
    {
        Console.Write("\nВведите данные преподавателя (например: Джон; Майкл; Смит; 15 Мар 1980; Математика; 10; Профессор): ");
        string data = Console.ReadLine();
        try
        {
            var teacher = Teacher.CreateFromString(data);  // Парсинг строки в объект преподавателя
            university.Add(teacher);  // Добавление преподавателя в университет
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при добавлении преподавателя: {e.Message}");
        }
    }

    // Метод для удаления преподавателя по фамилии
    static void DeleteTeacher(IUniversity university)
    {
        Console.Write("\nВведите фамилию преподавателя для удаления: ");
        string lastName = Console.ReadLine();
        var teachers = university.FindByLastName(lastName).OfType<Teacher>().ToList();

        if (teachers.Count > 0)
        {
            Console.WriteLine("Найдены следующие преподаватели:");
            for (int i = 0; i < teachers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. " + teachers[i].ToString());
            }

            Console.Write("Введите номер преподавателя для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= teachers.Count)
            {
                university.Remove(teachers[index - 1]);
                Console.WriteLine("Преподаватель успешно удалён.");
            }
            else
            {
                Console.WriteLine("Некорректный номер.");
            }
        }
        else
        {
            Console.WriteLine("Преподаватели с такой фамилией не найдены.");
        }
    }


    // Метод для поиска людей по фамилии
    static void FindByLastName(IUniversity university)
    {
        Console.Write("\nВведите фамилию для поиска: ");
        string lastName = Console.ReadLine();
        var persons = university.FindByLastName(lastName);  // Поиск по фамилии

        if (persons.Any())
        {
            foreach (var person in persons)
            {
                Console.WriteLine(person);  // Печать найденных людей
            }
        }
        else
        {
            Console.WriteLine("Персоны с такой фамилией не найдены.");
        }
    }


    static void FindByAvrPoint(IUniversity university)
    {
        Console.Write("Введите средний балл: ");

        // Читаем строку и пытаемся преобразовать в float
        if (float.TryParse(Console.ReadLine(), out float averageScore))
        {
            var students = university.FindByAvrPoint(averageScore);
            if (students.Any())
            {
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }
            else
            {
                Console.WriteLine("Студенты с указанным средним баллом не найдены.");
            }
        }
        else
        {
            Console.WriteLine("Некорректный ввод среднего балла.");
        }
    }
}
