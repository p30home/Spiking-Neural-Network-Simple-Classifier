using SNNClassifier.Graphic;
using SNNClassifier.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNNClassifier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Network network = null;

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void ShowResult()
        {
            var res = network.GetResults();
            PicClassifier1.Image = res[0];
            PicClassifier2.Image = res[1];
        }

        private void ButtonTrain_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog op = new FolderBrowserDialog();
            lbl0.Visible = lbl1.Visible = false;
            if (op.ShowDialog() == DialogResult.OK)
            {
                Random rand = new Random((int)DateTime.Now.Ticks);
                var files = System.IO.Directory
                    .GetFiles(op.SelectedPath, "*.jpg", System.IO.SearchOption.AllDirectories)
                    .OrderBy(a => rand.Next()).ToArray();
                var paramFile = System.IO.Path.Combine(op.SelectedPath, "params.json");
                Parameters parameters = null;
                if (System.IO.File.Exists(paramFile))
                {
                    parameters = Newtonsoft.Json.JsonConvert.DeserializeObject<Parameters>(System.IO.File.ReadAllText(paramFile));
                }
                else
                {
                    parameters = new Parameters();
                }
                ParamsSet frm = new ParamsSet(parameters);
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(parameters);
                System.IO.File.WriteAllText(System.IO.Path.Combine(op.SelectedPath, "params.json"), json);

                network = new Network(Threshold: parameters.Threshold, TimeStep: parameters.TimeStep,
                    InitWeight: parameters.InitialWeight, Vartiation: parameters.Variation, PA: parameters.PA,
                    NA: parameters.NA);

                List<Bitmap> images = new List<Bitmap>(10000);
                foreach (var f in files)
                {
                    var img = (Bitmap)Bitmap.FromFile(f);
                    {
                        var imgs = img.Variation(0);
                        images.AddRange(imgs);
                    }
                }

                if (files.Length < 10)
                {
                    ImageVariationForm frmVariation = new ImageVariationForm(images);
                    if (frmVariation.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                var Gabors = new GaborFilter[images.Count];



                Task.Run(() =>
                {
                    try
                    {
                        this.InvokeIfRequired(f =>
                {
                    f.Text = "Little Zhenik - making gabor filters";
                });
                        this.InvokeIfRequired(f =>
                        {
                            ButtonTrain.Enabled = false;
                            progressBar1.Visible = true;
                        });
                        Parallel.For(0, images.Count, i =>
                        {
                            Gabors[i] = new GaborFilter();
                            Gabors[i].CreateFromBitmap(images[i]);
                        });
                        this.InvokeIfRequired(f =>
                        {
                            f.Text = "Little Zhenik";
                        });
                    }
                    catch (Exception ex)
                    {
                        this.InvokeIfRequired(f => MessageBox.Show(ex.Message));
                    }
                }).ContinueWith(g =>
                {

                    {
                        var epochs = parameters.Epoch;
                        this.InvokeIfRequired(f => { progressBar1.Maximum = epochs * 2 / 3 * epochs * 1 / 3 * Gabors.Length; });

                        try
                        {

                            int p = 0;
                            for (int i = 0; i < epochs * 2 / 3; i++)
                            {
                                for (int j = 0; j < Gabors.Length; j++)
                                {
                                    for (int c = 0; c < epochs / 3; c++)
                                    {
                                        var t = network.Train(Gabors[j]);
                                        if (t == null)
                                            this.InvokeIfRequired(f =>
                                            {
                                            //MessageBox.Show(f,"threshold error");
                                            this.Text = "Little Zhenik - Threshold";
                                                i = epochs;
                                                j = Gabors.Length;
                                                c = epochs / 3;
                                            });
                                        if (p % 20 == 0)
                                        {
                                            this.InvokeIfRequired(f =>
                                            {
                                                try
                                                {
                                                    f.ShowResult();
                                                    progressBar1.Value = p;
                                                }
                                                catch
                                                {
                                                    this.Text = "Little Zhenik - Threshold";
                                                }
                                            });
                                            Task.Delay(5).Wait();
                                        }
                                        p++;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            this.InvokeIfRequired(f => MessageBox.Show(ex.Message));
                        }
                        this.InvokeIfRequired(f =>
                        {
                            progressBar1.Visible = false;
                            ButtonTest.Enabled = true;
                            ButtonTrain.Enabled = true;
                        });
                    }
                });



                
            }
        }

        private void ButtonTest_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                var gabor = new GaborFilter();
                gabor.CreateFromFile(op.FileName);
                pictureBox1.Image = GaborFilter.CreateFromArray(gabor.Result[GaborAngel._0]);
                pictureBox2.Image = GaborFilter.CreateFromArray(gabor.Result[GaborAngel._45]);
                pictureBox3.Image = GaborFilter.CreateFromArray(gabor.Result[GaborAngel._90]);
                pictureBox4.Image = GaborFilter.CreateFromArray(gabor.Result[GaborAngel._135]);
                PicInput.Image = Bitmap.FromFile(op.FileName);
                var c = network?.Classify(gabor);
                if (c == null)
                    MessageBox.Show("cannot classify");
                else
                {
                    if (c.Index == 0)
                    {
                        lbl0.Visible = true;
                        lbl1.Visible = false;
                    }
                    else
                    {
                        lbl0.Visible = false;
                        lbl1.Visible = true;
                    }
                }
                this.Width = 1089;
            }
        }

        private void lbl1_Click(object sender, EventArgs e)
        {
        }
    }
}