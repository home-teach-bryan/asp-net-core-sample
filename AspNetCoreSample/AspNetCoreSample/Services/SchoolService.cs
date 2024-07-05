﻿using AspNetCoreSample.Models;
using AspNetCoreSample.Models.Response;

namespace AspNetCoreSample.Services;

public class SchoolService : ISchoolService
{
    private List<School> _schools = new List<School>();

    /// <summary>
    /// 新增學校
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public Task<bool> AddSchoolAsync(Guid id, string name)
    {
        if (_schools.Any(item => item.Id == id || item.Name == name))
        {
            return Task.FromResult(false);
        }
        _schools.Add(new School(id, name));
        return Task.FromResult(false);
    }

    /// <summary>
    /// 取得學校
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public Task<bool> UpdateSchoolAsync(Guid id, string name)
    {
        var school = _schools.FirstOrDefault(item => item.Id == id);
        if (school != null)
        {
            school.SetName(name);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    /// <summary>
    /// 學校清單
    /// </summary>
    /// <returns></returns>
    public Task<List<GetSchoolResponse>> GetSchoolsAsync()
    {
        var result = _schools.Select(item => new GetSchoolResponse
        {
            Id = item.Id,
            Name = item.Name
        }).ToList();
        return Task.FromResult(result);
    }

    /// <summary>
    /// 刪除學校
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<bool> DeleteSchoolAsync(Guid id)
    {
        var school = _schools.FirstOrDefault(item => item.Id == id);
        if (school != null)
        {
            _schools.Remove(school);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    /// <summary>
    /// 取得學校
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<GetSchoolResponse> GetSchoolAsync(Guid id)
    {
        var school = _schools.FirstOrDefault(item => item.Id == id);
        if (school != null)
        {
            return Task.FromResult(new GetSchoolResponse
            {
                Id = school.Id,
                Name = school.Name
            });
        }
        return Task.FromResult<GetSchoolResponse>(null);
    }
}