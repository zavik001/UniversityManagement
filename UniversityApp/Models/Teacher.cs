public class Teacher : IPerson
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

    // Дополнительные свойства для класса Teacher
    public string Department { get; private set; }
    public int Experience { get; private set; }
    public Position JobPosition { get; private set; }

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
        var parts = data.Split(';');

        var name = parts[0].Trim();
        var patronomic = parts[1].Trim();
        var lastname = parts[2].Trim();
        var date = DateTime.Parse(parts[3].Trim());
        var department = parts[4].Trim();
        var experience = int.Parse(parts[5].Trim());
        var jobPosition = (Position)Enum.Parse(typeof(Position), parts[6].Trim());

        return new Teacher(name, patronomic, lastname, date, department, experience, jobPosition);
    }

    // Переопределение функции ToString
    public override string ToString()
    {
        return $"{Lastname} {Name} {Patronomic}; Position: {JobPosition}; Department: {Department}; Experience: {Experience} years; Date of Birth: {Date:dd MMM yyyy}; Age: {Age}";
    }
}
