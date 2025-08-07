using BMGeneratorTest.Models.Entities;
using BMGeneratorTest.Models.Interfaces;
using BMGeneratorTest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMGeneratorTest.Services;
public class GraphicConfigService : IGraphicConfigService
{
    private readonly IGraficConfigRepository _graphicConfigRepository;
    public GraphicConfigService(IGraficConfigRepository graficConfigRepository)
    {
        this._graphicConfigRepository = graficConfigRepository;
    }
    public GraphicConfigModel LoadObject()
    {
        return this._graphicConfigRepository.LoadObject();
    }

    public void SaveConfig(GraphicConfigModel graphicConfig)
    {
        this._graphicConfigRepository.Insert(graphicConfig);
    }
}
