using BMGeneratorTest.Models.Interfaces;
using BMGeneratorTest.Services;
using BMGeneratorTest.ViewModels;
using Microsoft.Maui.Controls.Shapes;
using System.Windows.Markup;

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

        this.Loaded += (s, e) =>
        {
            PrecoInicial.Focus();
        };

        ChartView.SizeChanged += (s, e) =>
        {
            ChartView.Clip = new RoundRectangleGeometry
            {
                CornerRadius = new CornerRadius(10),
                Rect = new Rect(0, 0, ChartView.Width, ChartView.Height)
            };
        };

        viewModel.PropertyChanged += (s, e) =>
        {
            if(e.PropertyName == nameof(viewModel.Values))
            {
                if(viewModel.Values.Count > 1)
                {
                    _chartDrawable.Values = viewModel.Values;
                    ChartView.MaximumWidthRequest = Math.Max(viewModel.Values.Count * 20, 300);                    
                    ChartView.Invalidate();                                        
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

   

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        if (width < 600)
        { 
            GridContent.SetRow(FormContainer, 0);
            GridContent.SetColumn(FormContainer, 0);
            GridContent.SetColumnSpan(FormContainer, 2);

            GridContent.SetRow(GraphicContainer, 1);
            GridContent.SetColumn(GraphicContainer, 0);
            GridContent.SetColumnSpan(GraphicContainer, 2);

            GridContent.SetRow(ColorsConfig, 2);
            GridContent.SetColumn(ColorsConfig, 0);
            GridContent.SetColumnSpan(ColorsConfig, 2);

            ChartView.WidthRequest = 1000;
           
        }
        else
        {  
            GridContent.SetRow(GraphicContainer, 0);
            GridContent.SetColumn(GraphicContainer, 0);
            GridContent.SetColumnSpan(GraphicContainer, 1);

            GridContent.SetRow(FormContainer, 0);
            GridContent.SetColumn(FormContainer, 1);
            GridContent.SetColumnSpan(FormContainer, 1);


            GridContent.SetRow(ColorsConfig, 1);
            GridContent.SetColumn(ColorsConfig, 0);
            GridContent.SetColumnSpan(ColorsConfig, 1);

            ChartView.ClearValue(GraphicsView.WidthRequestProperty);
           
        }
    }
}