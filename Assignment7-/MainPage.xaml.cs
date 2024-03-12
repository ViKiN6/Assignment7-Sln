using Newtonsoft.Json;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Assignment7_
{
    public partial class MainPage : ContentPage
    {
        private string file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "json.file");



        private Profile _profile;

        public Profile Profile { get { return _profile; } set { _profile = value; OnPropertyChanged(); } }

        public MainPage()
        {
            InitializeComponent();
            LoadProfile();
            BindingContext = this;

        }
        

            private async void LoadProfile()
            {
            try
            {
             //   var file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "json.file");

                if (File.Exists(file))
                {
                    string json = File.ReadAllText(file);
                    Profile = JsonConvert.DeserializeObject<Profile>(json);
                }

                else
                {
                    Profile = new Profile();
                }

            }
                    
                catch (Exception ex)
                {
                    
                }
            }

            public async Task SaveProfileAsync(Profile profile)

            {
             var json = JsonConvert.SerializeObject(profile);
            // var filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "json.file");
             await File.WriteAllTextAsync(file, json);

            TextBox.Text = json;

            }



        private async void OnSaveClicked(object sender, EventArgs e)
        {
           
            Message.Text = "Saved";
            SaveProfileAsync(Profile);
        }




        private async void OnLoadClicked(object sender, EventArgs e)
        {
            if (Profile != null)
            {
              //  await LoadProfileAsync(Profile);
            }

        }
    }
}