using AspNetCoreSample.Models;

namespace AspNetCoreSample.Services;

public interface ISchoolService
{
    Task<bool> AddSchoolAsync(School school);
}