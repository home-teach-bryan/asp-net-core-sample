﻿using AspNetCoreSample.Models;
using AspNetCoreSample.Models.Request;
using AspNetCoreSample.Models.Response;
using AspNetCoreSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSample.Controllers;

/// <summary>
/// 學校相關API
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SchoolController : ControllerBase
{
    private readonly ISchoolService _schoolService;

    /// <summary>
    /// 學校控制器
    /// </summary>
    /// <param name="schoolService"></param>
    public SchoolController(ISchoolService schoolService)
    {
        _schoolService = schoolService;
    }

    /// <summary>
    /// 新增學校
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddSchool([FromBody] AddSchoolRequest request)
    {
        var result = await _schoolService.AddSchoolAsync(Guid.NewGuid(), request.Name);
        return Ok(new
        {
            Status = result
        });
    }

    /// <summary>
    /// 更新學校
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateSchool([FromRoute] Guid id, [FromBody] UpdateSchoolRequest request)
    {
        var result = await _schoolService.UpdateSchoolAsync(id, request.Name);
        return Ok(new
        {
            Status = result
        });
    }
    
    /// <summary>
    /// 刪除學校
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteSchool([FromRoute] Guid id)
    {
        var result = await _schoolService.DeleteSchoolAsync(id);
        return Ok(new
        {
            Status = result
        });
    }

    /// <summary>
    /// 取得學校清單
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetSchools()
    {
        var schools = await _schoolService.GetSchoolsAsync();
        var result = schools.Select(item => new GetSchoolResponse
        {
            Id = item.Id,
            Name = item.Name
        });
        return Ok(new
        {
            Status = true,
            Data = result,
        });
    }
    
    /// <summary>
    /// 取得學校
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetSchool([FromRoute] Guid id)
    {
        var school = await _schoolService.GetSchoolAsync(id);
        if (school == null)
        {
            return NotFound();
        }
        return Ok(new
        {
            Status = true,
            Data = new GetSchoolResponse{ Id = school.Id, Name = school.Name }
        });
    }
}