using DetectiveNet.Domain.Model.Models;

namespace DetectiveNet.Sdk;

public class DiskReader : DiskReaderBase<Disk>
{
    private IDiskReader<MasterBootRecord> _mbrReader;

    public DiskReader(IDiskReader<MasterBootRecord> mbrReader)
    {
        _mbrReader = mbrReader;
    }
    
    /// <summary>
    /// Reads entire disk image and returns a Disk object.
    /// </summary>
    /// <param name="pathToImage"></param>
    /// <returns>Disk object</returns>
    public override Disk Read(string pathToImage)
    {
        Disk disk = new()
        {
            MasterBootRecord = _mbrReader.Read(pathToImage),
        };
        
        return disk;
    }
}