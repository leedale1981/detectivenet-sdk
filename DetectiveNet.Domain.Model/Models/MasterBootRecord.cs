namespace DetectiveNet.Domain.Model.Models;

public record MasterBootRecord
{
    public bool IsBootable { get; init; }
    public int StartHead { get; init; }
    public int EndHead { get; init; }
    public int StartSector { get; init; }
    public int EndSector { get; init; }
    public int StartCylinder { get; set; }
    public int EndCylinder { get; set; }
    public int RelativeSectors { get; set; }
    public int TotalSectors { get; set; }
    public string? SystemId { get; init; }
    public string Hex { get; init; }
}