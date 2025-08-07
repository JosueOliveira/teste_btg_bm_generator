using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMGeneratorTest.Models.Interfaces;
public interface IBMGenerator
{
    List<float> GenerateBrowniaMotion(float sigma, float mean, float initialPrice, int numDays);
}
