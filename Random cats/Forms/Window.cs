using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;

namespace Random_cats.Forms
{
    public partial class Main : Form
    {
        private readonly CatApiService _catApiService;

        public Main(CatApiService catApiService)
        {
            _catApiService = catApiService;
            InitializeComponent();
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            await InitializeWebView();
        }

        private async Task InitializeWebView()
        {
            string cacheFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Sefinek");

            CoreWebView2Environment coreWeb = await CoreWebView2Environment.CreateAsync(null, cacheFolder, new CoreWebView2EnvironmentOptions());
            await webView21.EnsureCoreWebView2Async(coreWeb);
        }

        private async void GetRandomCat_Click(object sender, EventArgs e)
        {
            try
            {
                string imageUrl = await _catApiService.GetRandomCatImageUrl();
                if (!string.IsNullOrEmpty(imageUrl))
                    webView21.CoreWebView2.Navigate(imageUrl);
                else
                    MessageBox.Show("Nie udało się pobrać adresu URL obrazka z API.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}");
            }
        }
    }

    public class CatApiService
    {
        private readonly HttpClient httpClient;

        public CatApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> GetRandomCatImageUrl()
        {
            HttpResponseMessage response = await httpClient.GetAsync("https://api.sefinek.net/api/v2/random/animal/cat");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();

                ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                if (apiResponse.Success) return apiResponse.Message;
            }
            else
            {
                MessageBox.Show($"Wystąpił błąd podczas pobierania danych z API. Kod odpowiedzi: {response.StatusCode}");
            }

            return null;
        }
    }

    public class ApiResponse
    {
        public bool Success { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
