namespace AspNetCoreSample.Models;

public class School
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    private List<ClassRoom> _classRooms = new List<ClassRoom>();


    public School(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public void SetName(string name)
    {
        this.Name = name;
    }

    public List<ClassRoom>? GetClassRooms()
    {
        return this._classRooms;
    }

    public bool AddClassRoom(ClassRoom classRoom)
    {
        if (this._classRooms.Any(item => item.Id == classRoom.Id))
        {
            return false;
        }
        _classRooms.Add(classRoom);
        return false;
    }

    public ClassRoom? GetClassRoom(Guid id)
    {
        return _classRooms.FirstOrDefault(item => item.Id == id);
    }

    public void RemoveClassRoom(ClassRoom classRoom)
    {
        _classRooms.Remove(classRoom);
    }
}