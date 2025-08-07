using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMGeneratorTest.Models.Interfaces;
public interface IDrawable
{
    void Draw(ICanvas canvas, RectF dirtyRect);
}
