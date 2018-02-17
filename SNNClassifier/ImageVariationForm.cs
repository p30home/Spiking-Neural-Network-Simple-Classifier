using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNNClassifier
{
    public partial class ImageVariationForm : Form
    {
        List<Bitmap> images;
        public ImageVariationForm(List<Bitmap> Images)
        {
            InitializeComponent();
            images = Images;
        }

        private void ImageVariationForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < images.Count; i++)
            {
                PictureBox p = new PictureBox();
                p.Name = "pic" + i;
                p.BorderStyle = BorderStyle.FixedSingle;
                p.Image = images[i];
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                p.Width = 50;
                p.Height = 50;
                flowLayoutPanel1.Controls.Add(p);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
