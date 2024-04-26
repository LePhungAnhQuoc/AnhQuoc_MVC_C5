using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AnhQuoc_MVC_C5
{
    public class DatabaseFirst
    {
        #region SingleTonPattern
        private static readonly object _InstanceLock = new object();

        private static DatabaseFirst _Instance;
        public static DatabaseFirst Instance
        {
            get
            {
                lock (_InstanceLock)
                {
                    if (_Instance == null)
                    {
                        if (IsConnectValid)
                        {
                            _Instance = new DatabaseFirst();
                        }
                    }
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        public QuanLyHangHoaEntities dbSource;
        public static string ConnStr;
        public static bool IsConnectValid = false;

        private DatabaseFirst()
        {
            dbSource = new QuanLyHangHoaEntities();
            dbSource.Configuration.LazyLoadingEnabled = false;
        }
    }
}
