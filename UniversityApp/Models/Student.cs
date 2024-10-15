using System.Globalization;

public class Student : IPerson
{
    // Реализация свойств из интерфейса IPerson
    public string Name { get; }
    public string Patronomic { get; }
    public string Lastname { get; }
    public DateTime Date { get; }

    public int Age => CalculateAge(Date);

    // Дополнительные свойства для класса Student
    public int Course { get; }
    public string Group { get; }
    public float AverageScore { get; }

    // Статическая функция вычисления возраста
    public static int CalculateAge(DateTime birthDate)
    {
        var today = DateTime.Today;
        int age = today.Year - birthDate.Year;

        if (today.DayOfYear < birthDate.DayOfYear)
        {
            age--;
        }

        return age;
    }

    // Конструктор, принимающий значения всех свойств
    public Student(string name, string patronomic, string lastname, DateTime date, int course, string group, float averageScore)
    {
        Name = name;
        Patronomic = patronomic;
        Lastname = lastname;
        Date = date;
        Course = course;
        Group = group;
        AverageScore = averageScore;
    }

    // Статическая функция создания студента из строки
    public static Student CreateFromString(string data)
    {
        var parts = data.Split(';').Select(p => p.Trim()).ToArray();

        var name = parts[0];
        var patronomic = parts[1];
        var lastname = parts[2];
        var date = DateTime.Parse(parts[3]);
        int course = int.Parse(parts[4]);
        var group = parts[5];
        float averageScore = float.Parse(parts[6]);

        return new Student(name, patronomic, lastname, date, course, group, averageScore);
    }

    // Переопределение функции ToString
    public override string ToString()
    {
        return $"{Lastname} {Name} {Patronomic}, Дата рождения: {Date:dd MMM yyyy}, Возраст: {Age}, Курс: {Course}, Группа: {Group}, Средний балл: {AverageScore:F2}";
    }
}
