using AspNetCoreSample.Models;

namespace AspNetCoreSample.Services;

public class ClassRoomService : IClassRoomService
{
    private readonly ISchoolService _schoolService;

    public ClassRoomService(ISchoolService schoolService)
    {
        _schoolService = schoolService;
    }
    public async Task<List<ClassRoom>> GetClassRoomsAsync(Guid schoolId)
    {
        var school = await _schoolService.GetSchoolAsync(schoolId);
        if (school == null)
        {
            return new List<ClassRoom>();
        }
        return school.GetClassRooms(); 
    }

    public async Task<bool> AddClassRoomAsync(Guid id, string name, Guid schoolId)
    {
        var school = await _schoolService.GetSchoolAsync(schoolId);
        if (school == null)
        {
            return false;
        }
        var isSuccess = school.AddClassRoom(new ClassRoom(id, name));
        return isSuccess;
    }

    public async Task<bool> UpdateClassRoomAsync(Guid id, string name, Guid schoolId)
    {
         var school = await _schoolService.GetSchoolAsync(schoolId);
         if (school == null)
         {
             return false;
         }
         var classRoom = school.GetClassRoom(id);
         if (classRoom == null)
         {
             return false;
         }
         classRoom.SetName(name);
         return true;
    }

    public async Task<bool> DeleteClassRoomAsync(Guid id, Guid schoolId)
    {
         var school = await _schoolService.GetSchoolAsync(schoolId);
         if (school == null)
         {
             return false;
         }
         var classRoom = school.GetClassRoom(id);
         if (classRoom == null)
         {
             return false;
         }
         school.RemoveClassRoom(classRoom);
         return true;
    }

    public async Task<ClassRoom?> GetClassRoomAsync(Guid id, Guid schoolId)
    {
        var school = await _schoolService.GetSchoolAsync(schoolId);
        if (school != null)
        {
            return school.GetClassRoom(id);
        }
        return new ClassRoom();
    }
}