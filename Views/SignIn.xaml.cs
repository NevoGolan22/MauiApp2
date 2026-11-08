namespace MauiApp2.Views;

using MauiApp2.Helper;
using MauiApp2.Service;
using MauiApp2.ViewModels;

public partial class SignIn : ContentPage
{
    

    public SignIn()
    {
        InitializeComponent();


        BindingContext = new SignInViewModel();

        EntryAsPassword = true;

        _dbMokup = new DBMokup();

        if (_iDebugMode)
        {
            UserName = "admin@mail.com";
            UserPassword = "admin";
        }
    }

    void OnTugglePasswordButtonClicked(object sender, EventArgs e)
    {
        EntryAsPassword = !EntryAsPassword;
    }

    private void OnSignInButtonClicked(object sender, EventArgs e)
    {
        if (_dbMokup.isExist(UserName, UserPassword))
        {
            MessageText = MesseagesHelper.SignInSuccessMessage;
            MessageTextColor = Colors.Green;
        }
        else
        {
            MessageText = MesseagesHelper.SignInErrorMessage;
            MessageTextColor = Colors.Red;
        }

        IsMessageLabelVisible = true;
    }
}