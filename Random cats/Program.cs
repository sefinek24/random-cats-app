using System;
using System.Net.Http;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Random_cats.Forms;

namespace Random_cats
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Konfiguracja kontenera wstrzykiwania zależności
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);

            // Tworzenie dostawcy usług
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                // Pobieranie instancji klasy Main z wstrzykniętym CatApiService
                Main mainForm = serviceProvider.GetRequiredService<Main>();

                // Uruchomienie aplikacji
                Application.Run(mainForm);
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Rejestracja klas wstrzykiwanych
            services.AddTransient<HttpClient>(); // Jeśli korzystasz z .NET Core 2.1+, możesz użyć AddHttpClient zamiast używać HttpClient bezpośrednio
            services.AddSingleton<CatApiService>();
            services.AddTransient<Main>();
        }
    }
}
