using BMGeneratorTest.Services;
using BMGeneratorTest.ViewModels;

namespace BMGeneratorTest.Views;

public partial class MainPage : ContentPage
{
	private ChartDrawable _chartDrawable;
    private MainViewModel _mainViewModel;
	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _mainViewModel= viewModel;
		_chartDrawable = new ChartDrawable();
		ChartView.Drawable = _chartDrawable;

        viewModel.PropertyChanged += (s, e) =>
        {
            if(e.PropertyName == nameof(viewModel.Values))
            {
                if(viewModel.Values.Count > 0)
                {
                    ChartView.MaximumWidthRequest = Math.Max(viewModel.Values.Count * 20, 300);
                    ChartView.Invalidate();
                    _chartDrawable.Values = viewModel.Values;
                } 
            }
        };
	} 
}