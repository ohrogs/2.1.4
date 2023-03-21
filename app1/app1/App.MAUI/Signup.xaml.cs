using System.Text;

namespace App.MAUI;

public partial class Signup : ContentPage
{
    public Signup()
    {
        InitializeComponent();
    }

    private StringBuilder Check()
    {
        StringBuilder stringBuilder = new StringBuilder();
        if (String.IsNullOrEmpty(EntryNick.Text))
        {
            stringBuilder.AppendLine("No user provided");
        }
        if (String.IsNullOrEmpty(EntryPassword.Text))
        {
            stringBuilder.AppendLine("No password provided");
        }
        if (String.IsNullOrEmpty(EntryName.Text))
        {
            stringBuilder.AppendLine("No name provided");
        }
        if (String.IsNullOrEmpty(EntrySurname.Text))
        {
            stringBuilder.AppendLine("No surname provided");
        }
        if (String.IsNullOrEmpty(EntryCF.Text))
        {
            stringBuilder.AppendLine("No fiscal provided");
        }
        return stringBuilder;
    }

    private void btnSignUp_Clicked(object sender, EventArgs e)
    {
        var check = Check();
        if (check.Length > 0)
        {
            DisplayAlert("sei un ase", check.ToString(), "fr");
            return;
        }
        using (var client = new HttpClient())
        {
            var uri = "http:";
            var httpMessage = new HttpRequestMessage(HttpMethod.Post, uri);
        }

    }
}