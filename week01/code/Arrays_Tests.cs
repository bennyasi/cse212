using System.Collections.Generic;
using Xunit;

public class Arrays_Tests
{
    [Fact]
    public void MultiplesOf_ReturnsCorrectArray()
    {
        var result = Arrays.MultiplesOf(3, 5);
        Assert.Equal(new double[] { 3, 6, 9, 12, 15 }, result);
    }

    [Fact]
    public void RotateListRight_Amount3_ReturnsCorrectList()
    {
        var input = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Arrays.RotateListRight(input, 3); // No assignment
        Assert.Equal(new List<int> { 7, 8, 9, 1, 2, 3, 4, 5, 6 }, input);
    }

    [Fact]
    public void RotateListRight_Amount5_ReturnsCorrectList()
    {
        var input = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Arrays.RotateListRight(input, 5); // No assignment
        Assert.Equal(new List<int> { 5, 6, 7, 8, 9, 1, 2, 3, 4 }, input);
    }
}
