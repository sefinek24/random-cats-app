using System;
using System.Diagnostics;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;
using RandomCats.Scripts;

namespace RandomCats.Forms
{
    public partial class Breeds : Form
    {
        private string _breedId;
        private string _wikipedia;

        public Breeds(string breedId)
        {
            InitializeComponent();
            _breedId = breedId;
        }

        private async void LoadBreedInfo()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://api.thecatapi.com/v1/breeds/{_breedId}";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Models.Breed apiResponse = JsonConvert.DeserializeObject<Models.Breed>(json);

                    label3.Text = apiResponse.Id;
                    label2.Text = apiResponse.Name;
                    label8.Text = apiResponse.Alt_names;
                    richTextBox1.Text = apiResponse.Description;
                    label7.Text = apiResponse.Origin;

                    label10.Text = apiResponse.Life_span;
                    label12.Text = apiResponse.Adaptability.ToString();
                    label14.Text = apiResponse.Affection_level.ToString();
                    label16.Text = apiResponse.Child_friendly.ToString();

                    label18.Text = apiResponse.Dog_friendly.ToString();
                    label20.Text = apiResponse.Energy_level.ToString();
                    label22.Text = apiResponse.Grooming.ToString();
                    label24.Text = apiResponse.Health_issues.ToString();

                    label26.Text = apiResponse.Intelligence.ToString();
                    label28.Text = apiResponse.Shedding_level.ToString();
                    label30.Text = apiResponse.Social_needs.ToString();
                    label32.Text = apiResponse.Vocalisation.ToString();

                    label34.Text = apiResponse.Experimental.ToString();
                    label36.Text = apiResponse.Hairless.ToString();
                    label38.Text = apiResponse.Natural.ToString();
                    label40.Text = apiResponse.Rare.ToString();

                    label42.Text = apiResponse.Rex.ToString();
                    label44.Text = apiResponse.Suppressed_tail.ToString();
                    label46.Text = apiResponse.Short_legs.ToString();

                    _wikipedia = apiResponse.Wikipedia_url;
                }
                else
                {
                    MessageBox.Show(@"An error occurred while fetching data from the API.", Program.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void UpdateBreedInfo(string breedId)
        {
            _breedId = breedId;
            LoadBreedInfo();
        }

        private void Breeds_Load(object sender, EventArgs e)
        {
            LoadBreedInfo();
        }

        private void OpenWiki_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(_wikipedia);
        }
    }
}
