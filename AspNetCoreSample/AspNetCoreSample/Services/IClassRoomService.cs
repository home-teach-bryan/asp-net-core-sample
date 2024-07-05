using AspNetCoreSample.Models;

namespace AspNetCoreSample.Services;

public interface IClassRoomService
{
    Task<List<ClassRoom>> GetClassRoomsAsync();
    Task<ClassRoom> GetClassRoomAsync(Guid id);
    Task<bool> AddClassRoomAsync(Guid id, string name, Guid schoolId);
    Task<bool> DeleteClassRoomAsync(Guid id);
    
    Task<bool> UpdateClassRoomAsync(Guid id, string name);
}