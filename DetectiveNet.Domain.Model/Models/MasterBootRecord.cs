namespace DetectiveNet.Domain.Model.Models;

public record MasterBootRecord
{
    public bool IsBootable { get; init; }
    public int StartHead { get; init; }
    public int StartSector { get; init; }
    public int StartCylinder { get; set; }
    public string? SystemId { get; init; }
    public string Hex { get; set; }
}