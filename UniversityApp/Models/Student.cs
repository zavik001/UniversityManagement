public class Student : IPerson
{
    // Реализация свойств из интерфейса IPerson
    public string Name { get; private set; }
    public string Patronomic { get; private set; }
    public string Lastname { get; private set; }
    public DateTime Date { get; private set; }
    public int Age
    {
        get
        {
            var today = DateTime.Today;
            var age = today.Year - Date.Year;
            if (Date > today.AddYears(-age)) age--;
            return age;
        }
    }

    // Дополнительные свойства для класса Student
    public int Course { get; private set; }
    public string Group { get; private set; }
    public float AverageScore { get; private set; }

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
        var parts = data.Split(';');

        var name = parts[0].Trim();
        var patronomic = parts[1].Trim();
        var lastname = parts[2].Trim();
        var date = DateTime.Parse(parts[3].Trim());
        int course = int.Parse(parts[4].Trim());
        var group = parts[5].Trim();
        float averageScore = float.Parse(parts[6].Trim());

        return new Student(name, patronomic, lastname, date, course, group, averageScore);
    }

    // Переопределение функции ToString
    public override string ToString()
    {
        return $"{Lastname} {Name} {Patronomic}, Date of Birth: {Date:dd MMM yyyy}, Age: {Age}, Course: {Course}, Group: {Group}, Average Score: {AverageScore:F2}";
    }
}
