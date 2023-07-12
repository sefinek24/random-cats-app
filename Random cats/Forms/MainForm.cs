using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Win32;
using Newtonsoft.Json;
using RandomCats.Properties;
using RandomCats.Scripts;

namespace RandomCats.Forms
{
    public partial class MainForm : Form
    {
        private const string TheCatApi = "https://api.thecatapi.com/v1/breeds";
        private readonly CatApiService _catApiService;
        private readonly string AppPath = Application.ExecutablePath;
        private readonly string AutoStartTitle = "Random cat images UwU";
        private Breeds _breedsForm;

        public MainForm(CatApiService catApiService)
        {
            _catApiService = catApiService;
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Loading...");
            comboBox1.SelectedIndex = comboBox1.Items.Count - 1;


            await InitializeWebView();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(TheCatApi);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Models.Breed[] breeds = JsonConvert.DeserializeObject<Models.Breed[]>(json);
                    comboBox1.Items.Clear();

                    foreach (Models.Breed breed in breeds) comboBox1.Items.Add(breed.Id);
                }
                else
                {
                    MessageBox.Show(@"Something went wrong.");
                }
            }

            int index = comboBox1.FindStringExact("ragd");
            if (index != -1) comboBox1.SelectedIndex = index;

            bool isAppInAutoStart = IsApplicationInAutoStart(AutoStartTitle, AppPath);
            button3.Text = isAppInAutoStart ? "Remove from autostart" : "Add to autostart";
        }

        private async Task InitializeWebView()
        {
            CoreWebView2EnvironmentOptions options = new CoreWebView2EnvironmentOptions();
            CoreWebView2Environment coreWeb = await CoreWebView2Environment.CreateAsync(null, Program.AppData, options);
            await webView21.EnsureCoreWebView2Async(coreWeb);
        }

        private void AddToAutoStart_Click(object sender, EventArgs e)
        {
            bool isAppInAutoStart = IsApplicationInAutoStart(AutoStartTitle, AppPath);

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (isAppInAutoStart)
            {
                key?.DeleteValue(AutoStartTitle, false);
                button3.Text = @"Add to AutoStart";
            }
            else
            {
                key?.SetValue(AutoStartTitle, AppPath);
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
                        MessageBox.Show($"Deleted {filesDeleted} files.\nSaved {savedSpaceInMb.ToString("0.##")} MB of memory.");
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


        private bool IsApplicationInAutoStart(string publisherName, string appPath)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            string value = key?.GetValue(publisherName) as string;
            key?.Close();

            return string.Equals(value, appPath, StringComparison.OrdinalIgnoreCase);
        }

        private async void GetRandomCatFacts_Click(object sender, EventArgs e)
        {
            try
            {
                string fact = await GetCatFact();

                string filePath = Path.Combine("website", "facts.html");
                string htmlTemplate = File.ReadAllText(filePath);

                string updatedHtml = htmlTemplate.Replace("{{CatFact}}", fact);

                webView21.NavigateToString(updatedHtml);
            }
            catch (Exception ex)
            {
                // Obsługa błędów
                MessageBox.Show(@"Wystąpił błąd podczas pobierania faktów o kotach: " + ex.Message);
            }
        }

        private async Task<string> GetCatFact()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://catfact.ninja/fact");
                if (!response.IsSuccessStatusCode) throw new Exception("Wystąpił błąd podczas pobierania faktów o kotach. Kod odpowiedzi HTTP: " + response.StatusCode);

                string json = await response.Content.ReadAsStringAsync();
                dynamic factData = JsonConvert.DeserializeObject(json);
                string fact = factData?.fact;
                return fact;
            }
        }

        private async void GetRandomFox_Click(object sender, EventArgs e)
        {
            try
            {
                string imageUrl = await _catApiService.GetRandomCatImageUrl("https://api.sefinek.net/api/v2/random/animal/fox");
                if (!string.IsNullOrEmpty(imageUrl)) webView21.CoreWebView2.Navigate(imageUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred:\n\n{ex}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void GetRandomCat1_Click(object sender, EventArgs e)
        {
            try
            {
                string imageUrl = await _catApiService.GetRandomCatImageUrl("https://api.sefinek.net/api/v2/random/animal/cat");
                if (!string.IsNullOrEmpty(imageUrl)) webView21.CoreWebView2.Navigate(imageUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred:\n\n{ex}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetRandomCat2_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.Navigate("https://cataas.com/cat");
        }

        private void GetRandomCatGif_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.Navigate("https://cataas.com/cat/gif");
        }

        private void GetRandomCuteCat_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.Navigate("https://cataas.com/cat/cute");
        }

        private void GetRandomSadCat_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.Navigate("https://cataas.com/cat/sad");
        }

        private void CatSays_Click(object sender, EventArgs e)
        {
            CatSays form2 = new CatSays();

            DialogResult result = form2.ShowDialog();
            if (result != DialogResult.OK) return;

            string text = form2.TextData;
            string size = form2.TextSize;
            string color = form2.TextColor;

            string url = $"https://cataas.com/cat/says/{text}?size={size}&color={color}";
            webView21.CoreWebView2.Navigate(url);
        }

        private void CatSaysGif_Click(object sender, EventArgs e)
        {
            CatSays form2 = new CatSays();

            DialogResult result = form2.ShowDialog();
            if (result != DialogResult.OK) return;

            string text = form2.TextData;
            string size = form2.TextSize;
            string color = form2.TextColor;

            string url = $"https://cataas.com/cat/gif/says/{text}?filter=sepia&color={color}&size={size}&type=or";
            webView21.CoreWebView2.Navigate(url);
        }

        private async void JustGetCatPic_Click(object sender, EventArgs e)
        {
            string breedId = comboBox1.SelectedItem.ToString();
            if (breedId == "Loading...")
            {
                MessageBox.Show(@"This feature is not ready. Please wait a few seconds and try again.");
                return;
            }

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage breedResponse = await client.GetAsync($"https://api.thecatapi.com/v1/images/search?breed_ids={breedId}");
                if (breedResponse.IsSuccessStatusCode)
                {
                    string breedResponseBody = await breedResponse.Content.ReadAsStringAsync();
                    Models.TheCatApi[] apiResponse = JsonConvert.DeserializeObject<Models.TheCatApi[]>(breedResponseBody);
                    if (apiResponse.Length > 0)
                    {
                        Models.TheCatApi breed = apiResponse[0];
                        webView21.CoreWebView2.Navigate(breed.Url);

                        if (_breedsForm != null && !_breedsForm.IsDisposed)
                        {
                            _breedsForm.UpdateBreedInfo(breedId);
                        }
                        else
                        {
                            _breedsForm = new Breeds(breedId) { Icon = Resources.icon };
                            _breedsForm.Show();
                        }
                    }
                    else
                    {
                        Console.WriteLine(@"No data available for the selected breed.");
                    }
                }
                else
                {
                    Console.WriteLine(@"Something went wrong. Error code: " + breedResponse.StatusCode);
                }
            }
        }
    }

    public class CatApiService
    {
        private readonly HttpClient _httpClient;

        public CatApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", $"Mozilla/5.0 (compatible; RandomCats/{Application.ProductVersion}; +https://sefinek.net)");
        }

        public async Task<string> GetRandomCatImageUrl(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                Models.ApiResponse apiResponse = JsonConvert.DeserializeObject<Models.ApiResponse>(jsonResponse);

                if (apiResponse.Success) return apiResponse.Message;

                MessageBox.Show($"Something went wrong.\n\nResponse code: {apiResponse.Status}\nMessage: {apiResponse.Message}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"An error occurred while retrieving data from the API.\n\nResponse: {response.StatusCode}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }
    }
}
