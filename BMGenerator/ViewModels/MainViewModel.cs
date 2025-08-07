using BMGeneratorTest.Models.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMGeneratorTest.ViewModels;
public partial class MainViewModel : ObservableObject
{
    #region Properties
    private readonly IBMGenerator _bmGenerator;
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
    #endregion

    #region Builders
    public MainViewModel(IBMGenerator bMGenerator)
    {
        _bmGenerator = bMGenerator;
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
    #endregion
}
