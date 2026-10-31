namespace MauiApp2.Views;
using MauiApp2.Helper;
public partial class SignIn : ContentPage
{
    public SignIn()
    {
        InitializeComponent();
    }

    private void TogglePassordButton_Clicked(object sender, EventArgs e)
    {
        var visBtn = sender as Button;
        PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
        if (PasswordEntry.IsPassword)
            visBtn!.Text = FontHelper.CLOSED_EYE_ICON;
        else
            visBtn!.Text = FontHelper.OPEN_EYE_ICON;

    }
}
