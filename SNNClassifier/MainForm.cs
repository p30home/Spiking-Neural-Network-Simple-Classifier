using SNNClassifier.Graphic;
using SNNClassifier.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNNClassifier
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Network network = new Network(Threshold: 400, TimeStep: 100, InitWeight: 0.5, Vartiation: 0.03, Size: 100);
        private GaborFilter[] Gabors = null;

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
            ShowResult();
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
            if (op.ShowDialog() == DialogResult.OK)
            {
                var files = System.IO.Directory.GetFiles(op.SelectedPath);

                List<Bitmap> images = new List<Bitmap>(10000);
                foreach (var f in files)
                {
                    using (var img = (Bitmap)Bitmap.FromFile(f))
                    {
                        var imgs = img.Variation(0);
                        images.AddRange(imgs);
                    }
                }

                ImageVariationForm frm = new ImageVariationForm(images);
                if(frm.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                Gabors = new GaborFilter[images.Count];

                Parallel.For(0, images.Count, i =>
                {
                    Gabors[i] = new GaborFilter();
                    Gabors[i].CreateFromBitmap(images[i]);
                });
                Random rand = new Random();
                var epochs = 70;
                progressBar1.Maximum = epochs * Gabors.Length;
                ButtonTrain.Enabled = false;
                progressBar1.Visible = true;
                Task.Run(() =>
                {
                    for (int i = 0; i < epochs; i++)
                    {
                        for (int j = 0; j < Gabors.Length; j++)
                        {
                            var t= network.Train(Gabors[j]);
                            if (t == null)
                                this.InvokeIfRequired(f =>
                                {
                                    MessageBox.Show(f,"threshold error");
                                });
                            this.InvokeIfRequired(f =>
                            {
                                f.ShowResult();
                                progressBar1.Value = (i) * (Gabors.Length) + (j);
                            });
                            Task.Delay(5).Wait();
                        }
                    }
                    this.InvokeIfRequired(f =>
                    {
                        progressBar1.Visible = false;
                        ButtonTest.Enabled = true;
                    });
                }
                );


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
                var c = network.Classify(gabor);
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
    }
}