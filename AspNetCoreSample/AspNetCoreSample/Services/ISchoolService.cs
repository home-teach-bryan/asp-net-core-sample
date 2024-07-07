using AspNetCoreSample.Models;
using AspNetCoreSample.Models.Response;

namespace AspNetCoreSample.Services;

public interface ISchoolService
{
    /// <summary>
    /// 新增學校
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<bool> AddSchoolAsync(Guid id, string name);

    /// <summary>
    /// 更新學校
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<bool> UpdateSchoolAsync(Guid id, string name);
    
    /// <summary>
    /// 學校清單
    /// </summary>
    /// <returns></returns>
    Task<List<School>> GetSchoolsAsync();
    
    /// <summary>
    /// 刪除學校
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteSchoolAsync(Guid id);

    /// <summary>
    /// 取得學校
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<School?> GetSchoolAsync(Guid id);
}