namespace AspNetCoreSample.Models;

public class School
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public School(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public void SetName(string name)
    {
        this.Name = name;
    }
}