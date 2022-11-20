using DetectiveNet.Domain.Model.Models;

namespace DetectiveNet.Sdk.Tests;

public class MasterBootRecordTests
{
    // Place a test image in this directory. Not included in source as files are too large.
    private readonly string _pathToImage = 
        $"{Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}.."))}{Path.DirectorySeparatorChar}TestImages{Path.DirectorySeparatorChar}disk.dd";

    [Fact]
    public void GetBootIndicatorFromImageSuccessful()
    {
        // Arrange
        MasterBootRecordReader mbrReader = new();

        // Act 
        MasterBootRecord? mbr = mbrReader.Read(_pathToImage);
        
        // Assert
        Assert.NotNull(mbr);
        Assert.True(mbr.IsBootable);
    }
    
    [Fact]
    public void GetStartingHeadFromImageSuccessful()
    {
        // Arrange
        MasterBootRecordReader mbrReader = new();
        
        // Act 
        MasterBootRecord? mbr = mbrReader.Read(_pathToImage);
        
        // Assert
        Assert.NotNull(mbr);
        Assert.Equal(1, mbr.StartHead);
    }

    [Fact]
    public void GetStartingSectorFromImageSuccessful()
    {
        // Arrange
        MasterBootRecordReader mbrReader = new();
        
        // Act 
        MasterBootRecord? mbr = mbrReader.Read(_pathToImage);
        
        // Assert
        Assert.NotNull(mbr);
        Assert.Equal(1, mbr.StartHead);
    }
}