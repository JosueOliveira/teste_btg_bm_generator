using BMGeneratorTest.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMGenerate_Test;
public class BMGeneratorServiceTests
{
    private readonly BMGeneratorService bMGeneratorService;

    public BMGeneratorServiceTests()
    {
        bMGeneratorService = new BMGeneratorService();
    }

    [Fact]
    public void GenerateBrowniaMotionTest()
    {
        var values = bMGeneratorService.GenerateBrowniaMotion(sigma:10, mean:20, initialPrice:100, numDays: 150);

        Assert.Equal(150, values.Count);
    }
}
