﻿using AspNetCoreSample.Models.Request;
using AspNetCoreSample.Models.Response;
using AspNetCoreSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSample.Controllers;

[ApiController]
[Route("api/School/{schoolId}/ClassRoom")]
public class ClassRoomController : ControllerBase
{
    private readonly IClassRoomService _classRoomService;

    public ClassRoomController(IClassRoomService classRoomService)
    {
        _classRoomService = classRoomService;
    }
    
    /// <summary>
    /// 加入班級
    /// </summary>
    /// <param name="schoolId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddClassRoom([FromRoute] Guid schoolId, [FromBody] AddClassRoomRequest request)
    {
        var result = await _classRoomService.AddClassRoomAsync(Guid.NewGuid(), request.Name, schoolId);
        return Ok(new
        {
            Status = result
        });
    }
    
    /// <summary>
    /// 更新班級
    /// </summary>
    /// <param name="schoolId"></param>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateClassRoom([FromRoute] Guid schoolId, [FromRoute] Guid id, [FromBody] UpdateClassRoomRequest request)
    {
        var result = await _classRoomService.UpdateClassRoomAsync(id, request.Name, schoolId);
        return Ok(new
        {
            Status = result
        });
    }
    
    /// <summary>
    /// 刪除班級
    /// </summary>
    /// <param name="schoolId"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteClassRoom([FromRoute] Guid schoolId, [FromRoute] Guid id)
    {
        var result = await _classRoomService.DeleteClassRoomAsync(id, schoolId);
        return Ok(new
        {
            Status = result
        });
    }
    
    /// <summary>
    /// 取得學校中全部班級
    /// </summary>
    /// <param name="schoolId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetClassRooms([FromRoute] Guid schoolId)
    {
        var classRooms = await _classRoomService.GetClassRoomsAsync(schoolId);
        return Ok(new
        {
            Status = true,
            Data = classRooms.Select(item => new GetClassRoomResponse
            {
                Id = item.Id,
                Name = item.Name
            })
        });
    }
    
    /// <summary>
    /// 取得班級
    /// </summary>
    /// <param name="schoolId"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetClassRoom([FromRoute] Guid schoolId, [FromRoute] Guid id)
    {
        var classRoom = await _classRoomService.GetClassRoomAsync(id, schoolId);
        if (classRoom == null)
        {
            return NotFound();
        }
        return Ok(new
        {
            Status = true,
            Data = new GetClassRoomResponse { Id = classRoom.Id, Name = classRoom.Name }
        });
    }
    
    
}