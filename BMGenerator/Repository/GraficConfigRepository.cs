using BMGeneratorTest.Models.Entities;
using BMGeneratorTest.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMGeneratorTest.Repository;
public class GraficConfigRepository : IGraficConfigRepository
{
    private readonly IDataStore<GraphicConfigModel> _dataStore;
    private readonly GraphicConfigModel _graphicConfig;

    public GraficConfigRepository(IDataStore<GraphicConfigModel> dataStore)
    {
        this._dataStore = dataStore;
        _graphicConfig = _dataStore.LoadData().FirstOrDefault() ?? new GraphicConfigModel { BackgroundColor = "#000000", LineColor = "#FFFF00" };
    }

    public void Insert(GraphicConfigModel graficConfig)
    {
        this._dataStore.SaveData(new List<GraphicConfigModel> { graficConfig });
    }

    public void Update(GraphicConfigModel graficConfig)
    {
        throw new NotImplementedException();
    }

    public GraphicConfigModel LoadObject()
    {
        return this._graphicConfig;
    }
}
