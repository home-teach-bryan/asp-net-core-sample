using AspNetCoreSample.Models;
using AspNetCoreSample.Models.Request;
using AspNetCoreSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSample.Controllers;

/// <summary>
/// 學校相關API
/// </summary>
[ApiController]
[Route("[controller]")]
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
    [Route("")]
    [HttpPost]
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
    [Route("{id}")]
    [HttpPut]
    
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
    [Route("{id}")]
    [HttpDelete]
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
    [Route("")]
    [HttpGet]
    public async Task<IActionResult> GetSchools()
    {
        var schools = await _schoolService.GetSchoolsAsync();
        return Ok(new
        {
            Status = true,
            Data = schools
        });
    }
    
    /// <summary>
    /// 取得學校
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Route("{id}")]
    [HttpGet]
    public async Task<IActionResult> GetSchool([FromRoute] Guid id)
    {
        var school = await _schoolService.GetSchoolAsync(id);
        return Ok(new
        {
            Status = true,
            Data = school
        });
    }
}