using System.Globalization;

public class Teacher : IPerson
{
    // Реализация свойств из интерфейса IPerson
    public string Name { get; }
    public string Patronomic { get; }
    public string Lastname { get; }
    public DateTime Date { get; }
    public int Age => DateTime.Today.Year - Date.Year - (DateTime.Today.DayOfYear < Date.DayOfYear ? 1 : 0);

    // Дополнительные свойства для класса Teacher
    public string Department { get; }
    public int Experience { get; }
    public Position JobPosition { get; }

    public static int CalculateAge(DateTime birthDate)
    {
        int age = DateTime.Today.Year - birthDate.Year;

        if (DateTime.Today.DayOfYear < birthDate.DayOfYear)
        {
            age--;
        }

        return age;
    }

    // Конструктор, принимающий значения всех свойств
    public Teacher(string name, string patronomic, string lastname, DateTime date, string department, int experience, Position jobPosition)
    {
        Name = name;
        Patronomic = patronomic;
        Lastname = lastname;
        Date = date;
        Department = department;
        Experience = experience;
        JobPosition = jobPosition;
    }

    // Статическая функция создания преподавателя из строки
    public static Teacher CreateFromString(string data)
    {
        var parts = data.Split(';').Select(p => p.Trim()).ToArray();
        var name = parts[0];
        var patronomic = parts[1];
        var lastname = parts[2];
        var date = DateTime.Parse(parts[3]);
        var department = parts[4];
        int experience = int.Parse(parts[5]);

        Position jobPosition;
        if (!Enum.TryParse(parts[6], true, out jobPosition))
        {
            throw new ArgumentException($"Некорректное значение для позиции: {parts[6]}");
        }

        return new Teacher(name, patronomic, lastname, date, department, experience, jobPosition);
    }

    // Переопределение функции ToString
    public override string ToString()
    {
        return $"{Lastname} {Name} {Patronomic}, Кафедра: {Department}, Должность: {JobPosition}, Стаж: {Experience} лет, Дата рождения: {Date:dd MMM yyyy}, Возраст: {Age}";
    }
}
