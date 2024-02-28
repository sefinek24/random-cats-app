using System;
using System.Windows.Forms;

namespace RandomCats.Forms
{
	public sealed partial class Info : Form
	{
		public Info()
		{
			InitializeComponent();

			DoubleBuffered = true;
		}

		private void Options_Load(object sender, EventArgs e)
		{
			string format = string.Format(label4.Text, $"v{Application.ProductVersion}");
			label4.Text = format;
		}
	}
}
