namespace MauiApp2.Views;
using MauiApp2.Helper;
using MauiApp2.Service;

public partial class SignIn : ContentPage
{
    private DBMokup _db;
    private string _userName;
    private string _password;
    public string UserName
    {
        get { return _userName; }
        set
        {

            _userName = value;
            OnPropertyChanged();
        }

    }
    public string UserPassword
    {
        get { return _password; }
        set
        {
            _password = value;
            OnPropertyChanged();
        }

    }
    public bool IsSignInButtonEnabled
    {

        get => !(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserPassword));

    }
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
