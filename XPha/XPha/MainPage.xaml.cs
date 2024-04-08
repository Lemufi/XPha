using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XPha
{
    public partial class MainPage : ContentPage
    {
        IEnumerable<Locale> locales;
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            TextToSpeechMethod();
        }

        private void Button1_Pressed(object sender, EventArgs e)
        {
            var button = (Button)sender;

            button.BackgroundColor = Color.Blue;
        }

        private void Button1_Released(object sender, EventArgs e)
        {
            var button = (Button)sender;

            button.BackgroundColor = Color.DarkCyan;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            locales = await TextToSpeech.GetLocalesAsync();

            foreach (var l in locales)
                Languages.Items.Add(l.Name);
        }

        private async void TextToSpeechMethod()
        {
            //locales = await TextToSpeech.GetLocalesAsync(); // Obtenir la langue de l'appareil pour le synthétiseur vocal.
            //var locale = locales.Single(l => l.Name == "fr"); // Grab the first locale.

            if (Languages.SelectedIndex > 0)
            {
                var settings = new SpeechOptions()
                {
                    Volume = .75f,
                    Pitch = 1.0f,
                    Locale = locales.Single(l => l.Name == Languages.SelectedItem.ToString()) // sélectionne la langue choisi par l'utilisateur dans le Picker.
                    //Locale = locales.Single(l => l.Name == "French (France)") // Definit la langue voulue dans la liste des Locales présentes.
                };

                    if (EntryText.Text == "")
                    {
                        EntryText.Text = "";
                    }

                    else
                    {
                        await TextToSpeech.SpeakAsync(EntryText.Text, settings);
                    }
            }
        }
    }
}
