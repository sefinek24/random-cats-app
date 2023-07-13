using System;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using Microsoft.Extensions.DependencyInjection;
using RandomCats.Forms;
using RandomCats.Properties;

namespace RandomCats
{
    internal static class Program
    {
        public static readonly string AppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Sefinek");
        private static readonly string AppDataRandomCats = Path.Combine(AppData, "Random cats");
        private static readonly string ConfigFilePath = Path.Combine(AppDataRandomCats, "config.ini");

        [DllImport("user32.dll")]
        private static extern bool SetProcessDpiAwarenessContext(IntPtr dpiContext);

        private static bool IsFirstRun()
        {
            if (!Directory.Exists(AppDataRandomCats)) Directory.CreateDirectory(AppDataRandomCats);

            FileIniDataParser parser = new FileIniDataParser();
            IniData configData;

            bool isFirstRun;
            if (!File.Exists(ConfigFilePath))
            {
                configData = new IniData
                {
                    ["General"] =
                    {
                        ["FirstRun"] = "true"
                    }
                };
                parser.WriteFile(ConfigFilePath, configData);
                isFirstRun = true;
            }
            else
            {
                configData = parser.ReadFile(ConfigFilePath);
                isFirstRun = Convert.ToBoolean(configData["General"]["FirstRun"]);
            }

            if (!isFirstRun) return false;
            configData["General"]["FirstRun"] = "false";
            parser.WriteFile(ConfigFilePath, configData);

            return true;
        }


        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SetProcessDpiAwarenessContext(new IntPtr(-4));


            if (IsFirstRun())
                MessageBox.Show("Hey! It seems like this is your first run of the application!" +
                                "\n\nPlease be informed that the images obtained from the API are 100% free, and you can freely download them." +
                                "\n\nHave a great day or evening!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Dependency injection container configuration
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);

            // Creating the service provider
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                // Getting an instance of the Main class with the CatApiService injected
                MainForm mainForm = serviceProvider.GetRequiredService<MainForm>();

                // Set icon
                mainForm.Icon = Resources.icon;

                // Running the application
                Application.Run(mainForm);
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Registering injected classes
            services.AddTransient<HttpClient>();
            services.AddSingleton<CatApiService>();
            services.AddTransient<MainForm>();
        }
    }
}
