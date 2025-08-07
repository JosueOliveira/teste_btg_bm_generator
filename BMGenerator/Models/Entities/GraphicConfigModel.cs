using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMGeneratorTest.Models.Entities;
public class GraphicConfigModel
{
    public static readonly string tableName = "graphicConfig.json";
    public string LineColor { get;  set; }
    public string BackgroundColor { get; set; }
}
