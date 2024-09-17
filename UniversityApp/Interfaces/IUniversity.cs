interface IUniversity
{
    IEnumerable<IPerson> Persons { get; }
    IEnumerable<Student> Students { get; }
    IEnumerable<Teacher> Teachers { get; }
    void Add(IPerson person);
    void Remove(IPerson person);
    IEnumerable<IPerson> FindByLastName(string lastName);
    IEnumerable<Teacher> FindByDepartment(string text);
}
