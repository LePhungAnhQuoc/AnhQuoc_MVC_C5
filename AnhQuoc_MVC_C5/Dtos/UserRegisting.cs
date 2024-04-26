using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace AnhQuoc_MVC_C5
{
    public class UserRegisting : IDtoBase
    {
        private string _Username;
        public string Username
        {
            get { return _Username; }
            set
            {
                _Username = value;
                OnPropertyChanged();
            }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                OnPropertyChanged();
            }
        }

        private string _PasswordRetype;

        public string PasswordRetype
        {
            get { return _PasswordRetype; }
            set
            {
                _PasswordRetype = value;
                OnPropertyChanged();
            }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }


        private string _Email;

        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                OnPropertyChanged();
            }
        }

        private DateTime _DOB;
        public DateTime DOB
        {
            get { return _DOB; }
            set
            {
                _DOB = value;
                OnPropertyChanged();
            }
        }



        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}