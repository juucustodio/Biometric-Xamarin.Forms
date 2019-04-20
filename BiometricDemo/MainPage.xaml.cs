using System;
using System.ComponentModel;
using Plugin.Fingerprint;
using Xamarin.Forms;

namespace BiometricDemo
{
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Autenticar(object sender, EventArgs e)
        {
            var result = await CrossFingerprint.Current.IsAvailableAsync(true);

            if (result)
            {
                var auth = await CrossFingerprint.Current.AuthenticateAsync("Toque no sensor");
                if (auth.Authenticated)
                {
                    Resultado.Text = "Autenticado com sucesso! :)";
                }
                else
                {
                    Resultado.Text = "Impressão digital não reconhecida";
                }
            }
            else
            {
                await DisplayAlert("Ops","Dispositivo não suportado","OK");
            }
        }

    }
}
