using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp2.Helper;
using MauiApp2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp2.ViewModels
{
    public class SignInViewModel : ViewModelBase /*ObservableObject*/
    {
        private string? _userName;
        private string? _password;
        private bool _entryAsPassword;
        private bool _IsMessageLabelVisible;
        private string? _messageText;
        private Color? _MessageTextColor;
        private string? _TogglePasswordButtonText;

        private bool _iDebugMode => true;
        private DBMokup? _dbMokup;

        public string TogglePasswordButtonText
        {
            get => _TogglePasswordButtonText!;
            set
            {
                _TogglePasswordButtonText = value;
                OnPropertyChanged(nameof(TogglePasswordButtonText));
            }
        }
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

        public ICommand ShowPasswordCommand { get; }
        public ICommand SignInCommand { get; }
        public SignInViewModel()
        {
            ShowPasswordCommand = new Command(() =>
            {
                if (EntryAsPassword)
                {
                    TogglePasswordButtonText = FontHelper.CLOSED_EYE_ICON;
                }
                else
                {
                    TogglePasswordButtonText = FontHelper.OPEN_EYE_ICON;
                }
                EntryAsPassword = !EntryAsPassword;
            });
            SignInCommand = new Command(OnSignInButtonClicked);

            TogglePasswordButtonText = FontHelper.CLOSED_EYE_ICON;
            
            EntryAsPassword = true;
            _dbMokup = new DBMokup();
            if (_iDebugMode)
            {
                UserName = "admin@mail.com";
                UserPassword = "admin";
            }
        }
        void OnTugglePasswordButtonClicked()
        {

            //var visBtn = Sender as Button;
            //if (EntryAsPassword)
            //{
            //    TogglePasswordButtonText = FontHelper.CLOSED_EYE_ICON;
            //}
            //else
            //{
            //    TogglePasswordButtonText = FontHelper.OPEN_EYE_ICON;
            //}
            //EntryAsPassword = !EntryAsPassword;
        }

        void OnSignInButtonClicked()
        {
            if (_dbMokup!.IsExist(UserName,UserPassword)) 
            {
                MessageText = MesseagesHelper.SignInSuccessMessage;
                MessageTextColor = Colors.Green;
            }
            else
            {
                MessageText = MesseagesHelper.SignInErrorMessage;
                MessageTextColor = Colors.Red;
            }
            //if (_dbMokup.isExist(UserName, UserPassword))
            //{
            //    MessageText = MesseagesHelper.SignInSuccessMessage;
            //    MessageTextColor = Colors.Green;
            //}
            //else
            //{
            //    MessageText = MesseagesHelper.SignInErrorMessage;
            //    MessageTextColor = Colors.Red;
            //}

            //IsMessageLabelVisible = true;
        }
    }
}
