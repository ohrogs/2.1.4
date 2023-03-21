namespace App.MAUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            //App.Current.MainPage = new NavigationPage(new Login());
            
        }

        private async void SignupBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Signup());
        }
    }
}