using DetectiveNet.Domain.Model.Models;

namespace DetectiveNet.Sdk;

public class MasterBootRecordReader : DiskReaderBase<MasterBootRecord>
{
    public override MasterBootRecord? Read(string pathToImage)
    {
        byte[] bytes;
        if (File.Exists(pathToImage))
        {
            FileStream imageFileStream = File.OpenRead(pathToImage);
            bytes = ReadBytes(imageFileStream, 0, 512);
        }
        else
        {
            throw new ArgumentException("The specified image file does not exist");
        }

        if (bytes.Length == 512 && IsMbr(bytes))
        {
            return new MasterBootRecord()
            {
                Hex = BitConverter.ToString(bytes),
                IsBootable = GetIsBootable(bytes),
                StartHead = int.Parse(BitConverter.ToString(GetSectionBytes(bytes, 447, 1))),
                StartSector = int.Parse(BitConverter.ToString(GetSectionBytes(bytes, 448, 1))),
                StartCylinder = int.Parse(BitConverter.ToString(GetSectionBytes(bytes, 449, 1))),
                SystemId = GetPartitionType(BitConverter.ToString(GetSectionBytes(bytes, 450, 1)))
            };
        }

        return null;
    }

    private bool IsMbr(byte[] bytes)
    {
        
    }

    private bool GetIsBootable(byte[] bytes)
    {
        byte[] bootableBytes = GetSectionBytes(bytes, 446, 1);
        return BitConverter.ToString(bootableBytes) == "80";
    }

    private string GetPartitionType(string hex)
    {
        return hex switch
        {
            "01" => "FAT32 < 32MB",
            "04" => "FAT16 < 32MB",
            "05" => "MS Extended Partition using CHS",
            "06" => "FAT16B",
            "07" => "NTFS, HPFS, exFAT",
            "0B" => "FAT32 CHS",
            "0C" => "FAT32 LBA",
            "0E" => "FAT16 LBA",
            "0F" => "MS Extended Parition LBA",
            "42" => "Windows Dynamic Volume",
            "82" => "Linux Swap",
            "83" => "Linux",
            "84" => "Windows hibernation parition",
            "85" => "Linux extended",
            "AB" => "Max OS X boot",
            "AF" => "HFS, HFS+",
            "EE" => "MS GPT",
            "EF" => "Intel EFI",
            _ => hex
        };
    }
}