namespace DetectiveNet.Sdk;

public abstract class IDiskReader<T>
{
    public abstract T Read(string pathToImage);
}