using System.Collections;

namespace DetectiveNet.Sdk;

public abstract class DiskReaderBase<T> : IDiskReader<T>
{
    protected byte[] ReadBytes(Stream stream, int start, int length)
    {
        using BinaryReader reader = new(stream);
        reader.BaseStream.Seek(start, SeekOrigin.Begin);
        byte[] bytes = new byte[length];
        int bytesRead = reader.Read(bytes, 0, length);
        return bytes;
    }
    
    protected byte[] GetSectionBytes(byte[] bytes, int offset, int length)
    {
        byte[] sectionBytes = new byte[length];
        
        for (int index = 0; index < length; index++)
        {
            sectionBytes[index] = bytes[index + offset];
        }

        return sectionBytes;
    }
    
    protected int ConvertBitsToInteger(byte[] sectionBytes)
    {
        BitArray bits = new BitArray(sectionBytes);
        int[] integers = new int[1];
        bits.CopyTo(integers, 0);
        return integers[0];
    }
}