using BMGeneratorTest.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BMGeneratorTest.Services;
public class BMGeneratorService : IBMGenerator
{
    public List<float> GenerateBrowniaMotion(float sigma, float mean, float initialPrice, int numDays)
    {
        Random rand = new();
        List<float> prices = new() { initialPrice }; 

        for (int i = 1; i < numDays; i++)
        {
            double u1 = 1.0 - rand.NextDouble();
            double u2 = 1.0 - rand.NextDouble();
            double z = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);

            double retornoDiario = mean + sigma * z;

            prices.Add((float)retornoDiario);  
        }

        return prices;
    }
}
