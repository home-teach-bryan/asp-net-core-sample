using AspNetCoreSample.Models;

namespace AspNetCoreSample.Services;

public class ClassRoomService : IClassRoomService
{
    private List<ClassRoom> _classRooms = new List<ClassRoom>();

    public Task<List<ClassRoom>> GetClassRoomsAsync()
    {
        return Task.FromResult(_classRooms);
    }

    public Task<bool> AddClassRoomAsync(Guid id, string name, Guid schoolId)
    {
        if (_classRooms.Any(item => item.Id == id || item.Name == name))
        {
            return Task.FromResult(false);
        }

        _classRooms.Add(new ClassRoom(id, name, schoolId));
        return Task.FromResult(true);
    }

    public Task<bool> UpdateClassRoomAsync(Guid id, string name)
    {
        var classRoom = _classRooms.FirstOrDefault(item => item.Id == id || item.Name == name);
        if (classRoom == null) 
        {
            return Task.FromResult(false);
        }

        classRoom.SetName(name);
        return Task.FromResult(true);
    }

    public Task<bool> DeleteClassRoomAsync(Guid id)
    {
        var classRoom = _classRooms.FirstOrDefault(item => item.Id == id);
        if (classRoom == null)
        {
            return Task.FromResult(false);
        }

        _classRooms.Remove(classRoom);
        return Task.FromResult(true);
    }

    public Task<ClassRoom> GetClassRoomAsync(Guid id)
    {
        var classRoom = _classRooms.FirstOrDefault(item => item.Id == id);
        if (classRoom == null)
        {
            return Task.FromResult<ClassRoom>(classRoom);
        }
        return Task.FromResult<ClassRoom>(classRoom);
    }
}