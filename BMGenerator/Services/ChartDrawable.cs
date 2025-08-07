using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMGeneratorTest.Services;
public class ChartDrawable : IDrawable
{    
    public List<float> Values { get; set; } = new List<float> 
    {
        0,0
    };

    
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        if (Values == null || Values.Count < 2)
            return;

        if (Values == null || Values.Count < 2)
            return;

        canvas.FillColor = Color.FromArgb("#756A6A");
        canvas.FillRectangle(dirtyRect);

        float width = dirtyRect.Width;
        float height = dirtyRect.Height;
         
        float minValue = Values.Min();
        float maxValue = Values.Max();
        float range = Math.Max(1f, maxValue - minValue);

        float stepX = width / (Values.Count - 1);

        var points = new List<PointF>();

        for (int i = 0; i < Values.Count; i++)
        {
            float x = i * stepX;
            float normalized = (Values[i] - minValue) / range;
            float y = height - (normalized * height);
            points.Add(new PointF(x, y));
        }
         
        canvas.StrokeColor = Color.FromArgb("#662978");
        canvas.StrokeSize = 2;

        for (int i = 0; i < points.Count - 1; i++)
        {
            canvas.DrawLine(points[i], points[i + 1]);
        }
         
        canvas.FillColor = Colors.Green;
        canvas.FillCircle(points[0].X, points[0].Y, 5);
         
        canvas.FillColor = Colors.Red;
        canvas.FillCircle(points[^1].X, points[^1].Y, 5);
    }

}
