using AspNetCoreSample.Models;

namespace AspNetCoreSample.Services;

public class SchoolService : ISchoolService
{
    private List<School> _schools = new List<School>();

    public Task<bool> AddSchoolAsync(School school)
    {
        if (_schools.Any(item => item.Id == school.Id))
        {
            _schools.Add(school);
            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }
}