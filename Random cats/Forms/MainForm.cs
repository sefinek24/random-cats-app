using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using RandomCats.Properties;
using RandomCats.Scripts;

namespace RandomCats.Forms
{
	public sealed partial class MainForm : Form
	{
		private static readonly string TheCatApi = "https://api.thecatapi.com/v1/breeds";
		public static readonly string AutoStartTitle = "Random cat images UwU";

		// Paths
		public static readonly string AppPath = AppDomain.CurrentDomain.BaseDirectory;
		private readonly CatApiService _catApiService;
		private readonly string _factsHtml = Path.Combine(AppPath, "www", "facts.html");
		private readonly string _loadedHtml = Path.Combine(AppPath, "www", "loaded.html");
		private Breeds _breedsForm;

		public MainForm(CatApiService catApiService)
		{
			InitializeComponent();

			DoubleBuffered = true;
			_catApiService = catApiService;
		}

		private async void MainForm_Load(object sender, EventArgs e)
		{
			comboBox1.Items.Add("Loading...");
			comboBox1.SelectedIndex = comboBox1.Items.Count - 1;

			await InitializeWebView();

			Random random = new Random();
			int randomIndex = random.Next(comboBox2.Items.Count);
			comboBox2.SelectedIndex = randomIndex;

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
					MessageBox.Show(@"Something went wrong.", Program.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			int index = comboBox1.FindStringExact("ragd");
			if (index != -1) comboBox1.SelectedIndex = index;
		}

		private async Task InitializeWebView()
		{
			CoreWebView2EnvironmentOptions options = new CoreWebView2EnvironmentOptions();
			CoreWebView2Environment coreWeb = await CoreWebView2Environment.CreateAsync(null, Program.AppData, options);
			await webView21.EnsureCoreWebView2Async(coreWeb);


			string html = File.ReadAllText(_loadedHtml);
			webView21.NavigateToString(html);
		}

		private void Information_Click(object sender, EventArgs e)
		{
			new Info { Icon = Resources.icon }.ShowDialog();
		}

		private void Options_Click(object sender, EventArgs e)
		{
			new Options { Icon = Resources.icon }.ShowDialog();
		}

		private async void GetRandomCatFacts_Click(object sender, EventArgs e)
		{
			try
			{
				string fact = await GetCatFact();

				string htmlTemplate = File.ReadAllText(_factsHtml);
				string updatedHtml = htmlTemplate.Replace("{{CatFact}}", fact);
				webView21.NavigateToString(updatedHtml);
			}
			catch (Exception ex)
			{
				MessageBox.Show(@"An error occurred while retrieving cat facts: " + ex.Message, Program.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private static async Task<string> GetCatFact()
		{
			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage response = await client.GetAsync("https://catfact.ninja/fact");
				if (!response.IsSuccessStatusCode) throw new Exception("An error occurred while retrieving cat facts. HTTP response code: " + response.StatusCode);

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

		private void Pinterest_Click(object sender, EventArgs e)
		{
			string[] links =
			{
				"https://pinterest.com/search/pins/?q=cute%20cat&rs=typed",
				"https://pinterest.com/search/pins/?q=pretty%20cat&rs=typed",
				"https://pinterest.com/search/pins/?q=ragdoll%20kitten&rs=guide&add_refine=Kitten%7Cguide%7Cword%7C2",
				"https://pinterest.com/search/pins/?q=cute%20siamese%20cats&rs=typed"
			};

			Random random = new Random();
			int randomIndex = random.Next(links.Length);
			string randomLink = links[randomIndex];


			webView21.CoreWebView2.Navigate(randomLink);
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
			CatSays form2 = new CatSays { Icon = Resources.icon };

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

			string url = $"https://cataas.com/cat/gif/says/{text}?filter=mono&color={color}&size={size}&type=medium";
			webView21.CoreWebView2.Navigate(url);
		}

		private void GetRandomHTTPCat_Click(object sender, EventArgs e)
		{
			string selectedValue = comboBox2.SelectedItem.ToString();
			string firstThreeDigits = selectedValue.Substring(0, 3);
			webView21.CoreWebView2.Navigate($"https://http.cat/{firstThreeDigits}");

			Random random = new Random();
			int randomIndex = random.Next(comboBox2.Items.Count);
			comboBox2.SelectedIndex = randomIndex;
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

				MessageBox.Show($"Something went wrong.\n\nResponse code: {apiResponse.Status}\nMessage: {apiResponse.Message}", Program.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				MessageBox.Show($"An error occurred while retrieving data from the API.\n\nResponse: {response.StatusCode}", Program.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return null;
		}
	}
}
