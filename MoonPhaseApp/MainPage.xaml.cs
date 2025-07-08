using System.Net.Http.Json;
using System.Text.Json;

namespace MoonPhaseApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            OnAppStart();
        }

        private async void OnAppStart()
        {
            var moonPhase = await GetFirstMoonPhaseAsync();
            MainImage.Source = moonPhase?.moon_image;
            DateLabel.Text = DateTime.Now.ToString("MMM dd");
            PhaseLabel.Text = moonPhase?.phase;
            IllumLabel.Text = moonPhase?.illumination;
            AgeLabel.Text = TrimAge(moonPhase?.moon_age);
            DistLabel.Text = MoonDistanceTranslate(moonPhase?.moon_distance);
        }

        private string TrimAge(string? s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return "";
            }

            string[] parts = s.Split('.');

            if (int.Parse(parts[0]) <= 15)
            {
                return (15 - int.Parse(parts[0])).ToString();
            }
            else
            {
                return ((27 + 15) - int.Parse(parts[0])).ToString();
            }
        }

        private string MoonDistanceTranslate(string? s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return "";
            }

            int min = 363300;
            int max = 435500;
            int finalPercentage;

            string justDigits = s.Replace(" km", "");

            double distance = double.Parse(justDigits);

            int onePercent = (max - min) / 100;

            if ((distance - min) > 0)
            {
                finalPercentage = 100 - (int)((distance - min) / onePercent);
            }
            else
            {
                finalPercentage = 1;
            }

            return (finalPercentage.ToString()) + "%";
        }

        private static readonly HttpClient client = new HttpClient();

        public async Task<PostData> GetFirstMoonPhaseAsync()
        {
            string url = "https://api.viewbits.com/v1/moonphase";

            var response = await client.GetStringAsync(url);
            var moonPhases = JsonSerializer.Deserialize<PostData[]>(response);

            if (moonPhases is not null)
            {
                return moonPhases[3];
            }
            else
            {
                Console.WriteLine("API call failed");
                return new PostData();
            }
        }
    }

}
