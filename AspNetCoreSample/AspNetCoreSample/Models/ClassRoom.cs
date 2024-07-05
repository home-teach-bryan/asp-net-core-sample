namespace AspNetCoreSample.Models;

public class ClassRoom
{
    public Guid Id { get; private set; }
    
    public string Name { get; private set; }
    
    public Guid SchoolId { get; private set; }

    public ClassRoom(Guid id, string name, Guid schoolId)
    {
        Id = id;
        Name = name;
        SchoolId = schoolId;
    }

    public void SetName(string name)
    {
        this.Name = name;
    }
}