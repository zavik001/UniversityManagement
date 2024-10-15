public interface IUniversity
{
    IEnumerable<IPerson> Persons { get; }
    IEnumerable<Student> Students { get; }
    IEnumerable<Teacher> Teachers { get; }
    void Add(IPerson person);
    void Remove(IPerson person);
    IEnumerable<IPerson> FindByLastName(string lastName);
    IEnumerable<Student> FindByAvrPoint(float avrPoint);
}
