public class University : IUniversity
{
    private List<IPerson> persons = new List<IPerson>();

    // Свойства, реализующие интерфейс IUniversity
    public IEnumerable<IPerson> Persons
    {
        get
        {
            // Сортировка по дате рождения для всех людей
            return persons.OrderBy(p => p.Date);
        }
    }

    public IEnumerable<Student> Students
    {
        get
        {
            // Сортировка по дате рождения для студентов
            return persons.OfType<Student>().OrderBy(s => s.Date);
        }
    }

    public IEnumerable<Teacher> Teachers
    {
        get
        {
            // Сортировка по дате рождения для преподавателей
            return persons.OfType<Teacher>().OrderBy(t => t.Date);
        }
    }

    // Метод для добавления нового человека
    public void Add(IPerson person)
    {
        persons.Add(person);
    }

    // Метод для удаления человека
    public void Remove(IPerson person)
    {
        persons.Remove(person);
    }

    // Метод для поиска людей по фамилии
    public IEnumerable<IPerson> FindByLastName(string lastName)
    {
        return persons.Where(p => p.Lastname.Equals(lastName, StringComparison.OrdinalIgnoreCase));
    }

    // Метод для поиска преподавателей по кафедре
    public IEnumerable<Teacher> FindByDepartment(string text)
    {
        // Сортировка преподавателей по должности и фильтрация по кафедре
        return persons.OfType<Teacher>()
                      .Where(t => t.Department.Contains(text, StringComparison.OrdinalIgnoreCase))
                      .OrderBy(t => t.JobPosition);
    }
}
