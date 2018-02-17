using SNNClassifier.Graphic;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SNNClassifier.Models
{
    public class Network
    {
        public Bitmap[] GetResults()
        {
            Bitmap[] results = new Bitmap[Classifiers.Length];
            for (int i = 0; i < Classifiers.Length; i++)
            {
                results[i] = new Bitmap(Size, Size);
                for (int x = 0; x < Size; x++)
                {
                    for (int y = 0; y < Size; y++)
                    {
                        var val = 0;
                        for (int l = 0; l < 4; l++)
                        {
                            val += (int)(Layer[l, x, y].Weight[i] * 255);
                        }
                        val = val / 3;
                        val = 255 - (val > 255 ? 255 : val < 0 ? 0 : val);
                        results[i].SetPixel(x, y, Color.FromArgb(val, val, val));
                    }
                }
            }

            return results;
        }

        private int Time { get; set; }
        public double Threshold { get; }
        public int TimeStep { get; }
        public double PA { get; }
        public double NA { get; }
        public Neuron[,,] Layer { get; set; }

        public Classifier[] Classifiers { get; set; }

        public List<Neuron> Spikes { get; set; }
        public int Size { get; }

        public Network(double Threshold, int TimeStep, double InitWeight, double Vartiation,double PA , double NA, int Size = 100)
        {
            this.Threshold = Threshold;
            this.TimeStep = TimeStep;
            this.PA = PA;
            this.NA = NA;
            this.Layer = new Neuron[4, Size, Size];
            this.Spikes = new List<Neuron>(Size * Size);
            this.Size = Size;
            this.Classifiers = new Classifier[]
            {
                new Classifier{Index = 0 },
                new Classifier{Index = 1 }
            };
            Random rand = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    for (int k = 0; k < Size; k++)
                    {
                        Layer[i, j, k] = new Neuron();
                        for (int x = 0; x < this.Classifiers.Length; x++)
                        {
                            Layer[i, j, k].Weight[x] = InitWeight + (rand.NextDouble() * Vartiation * (rand.Next(0, 1) == 0 ? 1 : -1));
                        }
                    }
                }
            }
        }

        private void ResetPotential()
        {
            this.Classifiers[0].Potential = this.Classifiers[1].Potential = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int x = 0; x < Size; x++)
                {
                    for (int y = 0; y < Size; y++)
                    {
                        Layer[i, x, y].Potential = 0;
                        Layer[i, x, y].Spike = 0;
                    }
                }
            }
        }

        private void ApplySTDP(Classifier classifier)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    for (int k = 0; k < Size; k++)
                    {
                        UpdateWeight(Layer[i, j, k], classifier);
                    }
                }
            }
        }

        private void UpdateWeight(Neuron preSynaptic, Neuron postSynaptic)
        {
            var delta = preSynaptic.Spike > postSynaptic.Spike || preSynaptic.Spike == 0 ? NA : PA;
            preSynaptic.Weight[(postSynaptic as Classifier).Index] += delta;
            if (preSynaptic.Weight[(postSynaptic as Classifier).Index] > 1)
                preSynaptic.Weight[(postSynaptic as Classifier).Index] = 1;
        }

        public Classifier Classify(GaborFilter gaborFilter, bool train = false)
        {
            ResetPotential();
            var list = SpikeTurns(gaborFilter);
            Classifier winner = null;
            for (int t = 1; t < TimeStep + 1; t++)
            {
                foreach (var n in list[TimeStep - t])
                {
                    n.Spike = t;
                    for (int i = 0; winner == null && i < this.Classifiers.Length; i++)
                    {
                        this.Classifiers[i].Potential += n.Weight[i];
                    }
                }
                if (winner == null && list[TimeStep - t].Count > 0)
                {
                    for (int i = 0; i < this.Classifiers.Length; i++)
                    {
                        if (this.Classifiers[i].Potential >= this.Threshold)
                        {
                            this.Classifiers[i].Spike = t;
                            winner = winner == null ? this.Classifiers[i] : winner.Potential > this.Classifiers[i].Potential ? winner : this.Classifiers[i];
                        }
                    }
                }
            }

            if (!train)
                winner = winner ?? (Classifiers[0].Potential > Classifiers[1].Potential ? Classifiers[0] : Classifiers[1]);

            return winner;
        }

        public Classifier Train(GaborFilter gaborFilter)
        {
            var c = Classify(gaborFilter, true);
            if (c != null)
            {
                ApplySTDP(c);
            }
            return c;
        }

        private List<Neuron>[] SpikeTurns(GaborFilter GaborFilter)
        {
            List<Neuron>[] list = new List<Neuron>[TimeStep];
            var t = GaborFilter.Max / TimeStep;
            int[] steps = new int[TimeStep];
            for (int i = 1; i < TimeStep; i++)
            {
                list[i - 1] = new List<Neuron>(500);
                steps[i - 1] = t * i;
            }

            steps[TimeStep - 1] = 256;
            list[TimeStep - 1] = new List<Neuron>(500);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    for (int k = 0; k < Size; k++)
                    {
                        var val = (GaborFilter.Result[(GaborAngel)i][j, k]);
                        val = (val < 0 ? 0 : val > 255 ? 255 : val);
                        var n = Layer[i, j, k];
                        if (val == 0)
                            continue;
                        for (int x = 1; x < TimeStep; x++)
                        {
                            if (val < steps[x - 1] && ((x > 1 && val >= steps[x - 2]) || x == 1))
                            {
                                list[x].Add(n);
                                n.Potential = val;
                                break;
                            }
                        }
                    }
                }
            }

            return list;
        }
    }
}