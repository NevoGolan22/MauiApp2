namespace MauiApp2.Views;

using MauiApp2.Helper;
using MauiApp2.Service;

public partial class SignIn : ContentPage
{
    private string _userName;
    private string _password;
    private bool _entryAsPassword;
    private bool _IsMessageLabelVisible;
    private string _messageText;
    private Color _MessageTextColor;
    private bool _iDebugMode => true;
    private DBMokup _dbMokup;

    public bool IsSignedInButtonEnabled
    {
        get => !string.IsNullOrEmpty(UserName)
            && !string.IsNullOrEmpty(UserPassword);
    }

    public bool IsMessageLabelVisible
    {
        get => _IsMessageLabelVisible;
        set
        {
            if (_IsMessageLabelVisible != value)
            {
                _IsMessageLabelVisible = value;
                OnPropertyChanged(nameof(IsMessageLabelVisible));
            }
        }
    }

    public string UserName
    {
        get => _userName;
        set
        {
            _userName = value;
            OnPropertyChanged(nameof(UserName));
            OnPropertyChanged(nameof(IsSignedInButtonEnabled));
        }
    }

    public string UserPassword
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged(nameof(UserPassword));
            OnPropertyChanged(nameof(IsSignedInButtonEnabled));
        }
    }

    public bool EntryAsPassword
    {
        get => _entryAsPassword;
        set
        {
            _entryAsPassword = value;
            OnPropertyChanged(nameof(EntryAsPassword));
        }
    }

    public string MessageText
    {
        get => _messageText;
        set
        {
            _messageText = value;
            OnPropertyChanged(nameof(MessageText));
        }
    }

    public Color MessageTextColor
    {
        get => _MessageTextColor;
        set
        {
            _MessageTextColor = value;
            OnPropertyChanged(nameof(MessageTextColor));
        }
    }

    public SignIn()
    {
        InitializeComponent();

        BindingContext = this;

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