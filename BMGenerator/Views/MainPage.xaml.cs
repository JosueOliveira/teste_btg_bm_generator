using BMGeneratorTest.Models.Interfaces;
using BMGeneratorTest.Services;
using BMGeneratorTest.ViewModels;

namespace BMGeneratorTest.Views;

public partial class MainPage : ContentPage
{
	private ChartDrawable _chartDrawable;
    private MainViewModel _mainViewModel;
	public MainPage(MainViewModel viewModel, ChartDrawable chartDrawable)
	{
		InitializeComponent();
		BindingContext = _mainViewModel= viewModel;

        _chartDrawable = chartDrawable;
		ChartView.Drawable = _chartDrawable;

        viewModel.PropertyChanged += (s, e) =>
        {
            if(e.PropertyName == nameof(viewModel.Values))
            {
                if(viewModel.Values.Count > 1)
                {
                    ChartView.MaximumWidthRequest = Math.Max(viewModel.Values.Count * 20, 300);
                    ChartView.Invalidate();
                    _chartDrawable.Values = viewModel.Values;
                }              
            }

            if (e.PropertyName == nameof(viewModel.ColorGraphicSelected))
            {

                chartDrawable.UpdateBackgroundColor(viewModel.ColorGraphicSelected.Color);
                ChartView.Invalidate();
            }

            if (e.PropertyName == nameof(viewModel.ColorGraphicLineSelected))
            {

                chartDrawable.UpdateGraphicLineColor(viewModel.ColorGraphicLineSelected.Color);
                ChartView.Invalidate();
            }
        };
	} 
}