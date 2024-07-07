using System.ComponentModel.DataAnnotations;

namespace AspNetCoreSample.Models.Request;

public class AddClassRoomRequest
{
    /// <summary>
    /// 課程名稱
    /// </summary>
    [Required(AllowEmptyStrings = false)]
    [MaxLength(10, ErrorMessage = "課程最長為15個字元")]
    public string Name { get; set; }
}