using BMGeneratorTest.Models;
using BMGeneratorTest.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMGeneratorTest.Services;
public class ColorService : IColorService
{
    public List<ColorItem> GetColors()
    {
        return new List<ColorItem>
        {
            new ColorItem { Name = "Vermelho", Color = Colors.Red },
            new ColorItem { Name = "Verde", Color = Colors.Green },
            new ColorItem { Name = "Azul", Color = Colors.Blue },
            new ColorItem { Name = "Amarelo", Color = Colors.Yellow },
            new ColorItem { Name = "Preto", Color = Colors.Black },
            new ColorItem { Name = "Cinza", Color = Color.FromArgb("#756A6A")}
        };
    }
}
