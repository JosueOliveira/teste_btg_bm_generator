using BMGeneratorTest.Models.Entities;
using BMGeneratorTest.Models.Interfaces;
using BMGeneratorTest.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMGenerate_Test;
public class GraficConfigServiceTests
{
    private readonly Mock<IGraficConfigRepository> repository;
    private readonly GraphicConfigService service;

    public GraficConfigServiceTests()
    {
        repository = new Mock<IGraficConfigRepository>();
        service = new GraphicConfigService(repository.Object);
    }

    [Fact]
    public void LoadObjectTest()
    {
        GraphicConfigModel graphicConfig = new GraphicConfigModel();
        repository.Setup(x => x.LoadObject()).Returns(graphicConfig);

        Assert.NotNull(graphicConfig);        
    }

    [Fact]
    public void SaveConfigTest()
    {
        GraphicConfigModel graphicConfig = new GraphicConfigModel { BackgroundColor = "#FF0000", LineColor = "#0000FF" };
        service.SaveConfig(graphicConfig);

        repository.Verify(x => x.Insert(graphicConfig), Times.Once());  
    }
}
