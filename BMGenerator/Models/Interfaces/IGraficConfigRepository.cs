using BMGeneratorTest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMGeneratorTest.Models.Interfaces;
public interface IGraficConfigRepository
{
    void Insert (GraphicConfigModel graficConfig);
    void Update (GraphicConfigModel graficConfig);
    GraphicConfigModel LoadObject();
}
