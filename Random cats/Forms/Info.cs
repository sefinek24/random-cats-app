using System;
using System.Windows.Forms;

namespace RandomCats.Forms
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            string format = string.Format(label4.Text, $"v{Application.ProductVersion}");
            label4.Text = format;
        }
    }
}
