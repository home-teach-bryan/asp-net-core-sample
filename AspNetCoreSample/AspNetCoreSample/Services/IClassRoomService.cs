using AspNetCoreSample.Models;

namespace AspNetCoreSample.Services;

public interface IClassRoomService
{
    Task<List<ClassRoom>> GetClassRoomsAsync(Guid schoolId);

    Task<bool> AddClassRoomAsync(Guid id, string name, Guid schoolId);

    Task<bool> UpdateClassRoomAsync(Guid id, string name, Guid schoolId);

    Task<bool> DeleteClassRoomAsync(Guid id, Guid schoolId);
    Task<ClassRoom?> GetClassRoomAsync(Guid id, Guid schoolId);
}