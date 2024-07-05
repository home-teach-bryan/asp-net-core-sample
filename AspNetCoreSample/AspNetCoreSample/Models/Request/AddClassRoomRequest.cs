namespace AspNetCoreSample.Models.Request;

public class AddClassRoomRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid SchoolId { get; set; }
}