using AspNetCoreSample.Models.Request;
using AspNetCoreSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassRoomController : ControllerBase
{
    /// <summary>
    /// 班級服務
    /// </summary>
    private IClassRoomService _classRoomService;

    /// <summary>
    /// 班級控制器
    /// </summary>
    /// <param name="classRoomService"></param>
    public ClassRoomController(IClassRoomService classRoomService)
    {
        _classRoomService = classRoomService;
    }

    /// <summary>
    /// 新增班級
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Route("")]
    [HttpPost]
    public async Task<IActionResult> AddClassRoom([FromBody] AddClassRoomRequest request)
    {
        var result = await _classRoomService.AddClassRoomAsync(request.Id, request.Name, request.SchoolId);
        return Ok(new
        {
            Status = result
        });
    }
    
    /// <summary>
    /// 更新班級
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [Route("{id}")]
    [HttpPut]
    public async Task<IActionResult> UpdateClassRoom([FromRoute] Guid id,[FromBody] UpdateClassRoomRequest request)
    {
        var result = await _classRoomService.UpdateClassRoomAsync(id, request.Name);
        return Ok(new
        {
            Status = result
        });
    }
    
    /// <summary>
    /// 刪除班級
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Route("{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteClassRoom([FromRoute] Guid id)
    {
        var result = await _classRoomService.DeleteClassRoomAsync(id);
        return Ok(new
        {
            Status = result
        });
    }
    
    /// <summary>
    /// 取得班級
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Route("{id}")]
    [HttpGet]
    public async Task<IActionResult> GetClassRoom([FromRoute] Guid id)
    {
        var result = await _classRoomService.GetClassRoomAsync(id);
        return Ok(new
        {
            Status = result
        });
    }
    
    /// <summary>
    /// 班級清單
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetClassRooms()
    {
        var result = await _classRoomService.GetClassRoomsAsync();
        return Ok(new
        {
            Status = result
        });
    }
}