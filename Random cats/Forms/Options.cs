using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RandomCats.Forms
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            bool isAppInAutoStart = IsApplicationInAutoStart(MainForm.AutoStartTitle, MainForm.AppPath);
            button3.Text = isAppInAutoStart ? "Remove from autostart" : "Add to autostart";
        }

        private bool IsApplicationInAutoStart(string publisherName, string appPath)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            string value = key?.GetValue(publisherName) as string;
            key?.Close();

            return string.Equals(value, appPath, StringComparison.OrdinalIgnoreCase);
        }

        private void AddToAutoStart_Click(object sender, EventArgs e)
        {
            bool isAppInAutoStart = IsApplicationInAutoStart(MainForm.AutoStartTitle, MainForm.AppPath);

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (isAppInAutoStart)
            {
                key?.DeleteValue(MainForm.AutoStartTitle, false);
                button3.Text = @"Add to AutoStart";
            }
            else
            {
                key?.SetValue(MainForm.AutoStartTitle, MainForm.AppPath);
                button3.Text = @"Remove from AutoStart";
            }

            key?.Close();
        }

        private async void DeleteCache_Click(object sender, EventArgs e)
        {
            Hide();

            await Task.Delay(100);

            string webView2Folder = Path.Combine(Program.AppData, "EBWebView");

            try
            {
                long totalSavedSpace = 0;
                int filesDeleted = 0;

                if (Directory.Exists(webView2Folder))
                {
                    string[] files = Directory.GetFiles(webView2Folder, "*", SearchOption.AllDirectories);

                    foreach (string file in files)
                        try
                        {
                            FileInfo fileInfo = new FileInfo(file);

                            totalSavedSpace += fileInfo.Length;

                            File.Delete(file);

                            filesDeleted++;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(@"An error occurred while deleting the file: " + ex.Message);
                        }

                    if (filesDeleted > 0)
                    {
                        // Files were deleted, inform the user about the memory saved
                        double savedSpaceInMb = (double)totalSavedSpace / (1024 * 1024);
                        MessageBox.Show($"Deleted {filesDeleted} files.\nSaved {savedSpaceInMb:0.##} MB of memory.");
                    }
                    else
                    {
                        MessageBox.Show(@"No files to delete.");
                    }
                }
                else
                {
                    MessageBox.Show(@"WebView2 folder not found. No files to delete.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"An error occurred while deleting cache files: " + ex.Message);
            }

            Show();
        }
    }
}
