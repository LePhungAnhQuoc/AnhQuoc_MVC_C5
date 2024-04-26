﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AnhQuoc_MVC_C5
{
    public class ServerName : IModelBase
    {
        public string Id { get; set; }

        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }

        private bool _Status;
        public bool Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
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


        #region Constructors
        public ServerName()
        {
            Name = string.Empty;
        }

        public ServerName(string id)
        {
            Id = id;
            Name = string.Empty;
        }

        public ServerName(string id, string name)
        {
            Id = id;
            Name = name;
        }
        #endregion

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
