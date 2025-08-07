using BMGeneratorTest.Models;
using BMGeneratorTest.Models.Entities;
using BMGeneratorTest.Models.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMGeneratorTest.ViewModels;
public partial class MainViewModel : ObservableObject
{
    #region Properties
    private readonly IBMGenerator _bmGenerator; 
    private readonly IGraphicConfigService _graphicConfigService;
    private readonly IColorService _colorService;
    private GraphicConfigModel graphicConfig;
    [ObservableProperty]
    private float precoInicial;
    [ObservableProperty]
    private float volatilidadeMedia;
    [ObservableProperty]
    private float retornoMedio;
    [ObservableProperty]
    private int tempoDias;
    [ObservableProperty]
    private List<float> values;
    [ObservableProperty]
    private List<ColorItem> colorItems;
    [ObservableProperty]
    private ColorItem colorGraphicSelected;
    [ObservableProperty]
    private ColorItem colorGraphicLineSelected;
    #endregion

    #region Builders
    public MainViewModel(
        IBMGenerator bMGenerator, 
        IGraphicConfigService graphicConfigService, 
        IColorService colorService)
    {
        _bmGenerator = bMGenerator;
        _graphicConfigService = graphicConfigService;
        _colorService = colorService;
        Initializer();
    }
    #endregion

    #region Commands
    [RelayCommand]
    public async Task GenerateGraphicCommand()
    {
        await GetBrowniaAnalises();
    }
    #endregion

    #region Métodos Auxiliares
    public async Task GetBrowniaAnalises()
    {
        try
        {
            Values = _bmGenerator.GenerateBrowniaMotion(sigma:VolatilidadeMedia , mean: RetornoMedio, initialPrice: PrecoInicial, numDays: TempoDias);            
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    private void Initializer()
    { 
        graphicConfig = _graphicConfigService.LoadObject();       
        ColorItems = _colorService.GetColors();
        if(graphicConfig != null)
        {
            ColorGraphicSelected = ColorItems.FirstOrDefault(x => x.Color.ToArgbHex() == graphicConfig.BackgroundColor);
            ColorGraphicLineSelected = ColorItems.FirstOrDefault(x => x.Color.ToArgbHex() == graphicConfig.LineColor);
        }       
    }

    #endregion 
}
