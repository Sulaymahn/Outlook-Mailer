using OutlookMailer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OutlookMailer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var m = new Mailer(userEmail.Text, userEmailPassword.Text);
            await m.SendEmailAsync(userName.Text, receiverName.Text, receiverEmail.Text, messageSubject.Text, messageBody.Text);

            await DisplayAlert("SENT", "EMAIL SENT", "OKAY");
        }
    }
}
