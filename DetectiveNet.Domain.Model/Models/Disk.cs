namespace DetectiveNet.Domain.Model.Models;

public record Disk
{
    public MasterBootRecord MasterBootRecord { get; set; }
}