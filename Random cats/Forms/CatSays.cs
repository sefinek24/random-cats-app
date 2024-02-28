using System;
using System.Windows.Forms;

namespace RandomCats.Forms
{
	public sealed partial class CatSays : Form
	{
		public CatSays()
		{
			InitializeComponent();

			DoubleBuffered = true;
		}

		public string TextData => textBox1.Text;

		public string TextSize => textBox2.Text;
		public string TextColor => textBox3.Text;

		private void OkButton_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBox1.Text))
			{
				DialogResult = DialogResult.OK;
				Close();
			}
			else
			{
				MessageBox.Show(@"Please fill in all text fields.");
			}
		}
	}
}
