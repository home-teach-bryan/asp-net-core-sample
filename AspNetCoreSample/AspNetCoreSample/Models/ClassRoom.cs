namespace AspNetCoreSample.Models;

public class ClassRoom
{
    public Guid Id { get; private set; }
    
    public string Name { get; private set; }

    public ClassRoom()
    {
        
    }
    
    public ClassRoom(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public void SetName(string name)
    {
        this.Name = name;
    }
}