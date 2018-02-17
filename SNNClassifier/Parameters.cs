using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNNClassifier
{
    public class Parameters
    {
        public int Epoch { get; set; } = 20;
        public double PA { get; set; } = 0.001;
        public double NA { get; set; } = -0.0004;
        public double InitialWeight { get; set; } = 0.5;
        public double Variation { get; set; } = 0.03;

        public int Threshold { get; set; } = 400;

        public int TimeStep { get; set; } = 40;
    }
}
