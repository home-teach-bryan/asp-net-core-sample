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

    public SchoolController(ISchoolService schoolService)
    {
        _schoolService = schoolService;
    }

    /// <summary>
    /// 新增學校
    /// </summary>
    /// <param name="request"></param>
    /// <returns>操作回傳狀態</returns>
    /// <response code="200">成功</response>
    /// <response code="400">參數錯誤</response>
    [Route("")]
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType<object>(StatusCodes.Status200OK)]
    [ProducesResponseType<object>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddSchool([FromBody] AddSchoolRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _schoolService.AddSchoolAsync(new School(Guid.NewGuid(), request.Name));
        return Ok(new
        {
            Status = result
        });
    }
}