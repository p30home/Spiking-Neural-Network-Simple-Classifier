using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNNClassifier.Models
{
    public class Neuron
    {
        public int Spike { get; set; }

        public double[] Weight { get; set; } = new double[2];

        public double Potential { get; set; }
    }

    public class Classifier : Neuron
    {
        public int Index { get; set; }
    }
}
