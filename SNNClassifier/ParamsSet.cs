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
    public partial class ParamsSet : Form
    {
        public ParamsSet(Parameters parameters)
        {
            InitializeComponent();
            this.txtEpoch.Text = parameters.Epoch.ToString();
            this.txtInitWeight.Text = parameters.InitialWeight.ToString();
            this.txtNA.Text = parameters.NA.ToString();
            this.txtPA.Text = parameters.PA.ToString();
            this.txtThreshold.Text = parameters.Threshold.ToString();
            this.txtTimeStep.Text = parameters.TimeStep.ToString();
            this.txtVariation.Text = parameters.Variation.ToString();
            this.P = parameters;
        }

        public Parameters P { get; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            P.Epoch = int.Parse(txtEpoch.Text);
            P.InitialWeight = double.Parse(txtInitWeight.Text);
            P.NA = double.Parse(txtNA.Text);
            P.PA = double.Parse(txtPA.Text);
            P.Threshold = int.Parse(txtThreshold.Text);
            P.TimeStep = int.Parse(txtTimeStep.Text);
            P.Variation = double.Parse(txtVariation.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
