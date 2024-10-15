public class University : IUniversity
{
    // Список для хранения всех людей (как студентов, так и преподавателей)
    private List<IPerson> persons = new List<IPerson>();

    // Свойство возвращает всех людей (студентов и преподавателей), отсортированных по дате рождения
    public IEnumerable<IPerson> Persons => persons.OrderBy(p => p.Date);

    // Свойство возвращает всех студентов, отсортированных по дате рождения
    public IEnumerable<Student> Students => persons.OfType<Student>().OrderBy(s => s.Date);

    // Свойство возвращает всех преподавателей, отсортированных по дате рождения
    public IEnumerable<Teacher> Teachers => persons.OfType<Teacher>().OrderBy(t => t.Date);

    // Метод добавления нового человека (студента или преподавателя)
    public void Add(IPerson person)
    {
        persons.Add(person);
    }

    // Метод удаление существующего человека (студента или преподавателя)
    public void Remove(IPerson person)
    {
        persons.Remove(person);
    }

    // Поиск людей по фамилии (без учета регистра)
    public IEnumerable<IPerson> FindByLastName(string lastName)
    {
        return persons.Where(p => p.Lastname.Equals(lastName, StringComparison.OrdinalIgnoreCase));
    }

    // Для четных вариантов. Поиск студентов, у которых средний балл выше указанного
    // и сортировка их по среднему баллу
    public IEnumerable<Student> FindByAvrPoint(float avrPoint)
    {
        return persons.OfType<Student>().Where(s => s.AverageScore > avrPoint).OrderBy(s => s.AverageScore);
    }
}
