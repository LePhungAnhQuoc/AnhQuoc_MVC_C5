using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AnhQuoc_MVC_C5
{
    public static class Constants
    {
        #region Directory-Images
        public static string rememberDirectoryOpenFile = @"C:\";
        public static string StartUrlImage = "\\Assets\\Images\\";
        public static string HumanUrlImage = "\\Assets\\Images\\Others\\human.png";

        public static string fServerNames = "Data/ServerNames.xml";
        public static string childServerName = "ServerName";

        public static string fDatabaseNames = "Data/DatabaseNames.xml";
        public static string childDatabaseName = "DatabaseName";

        #endregion
        public const int nPerPage = 6;

        public static DateTime dateEmptyValue = DateTime.MinValue;
        public static DateTime dateMinValue = DateTime.Parse("01/01/1900");
        public static Func<DateTime> dateMaxValue = () => DateTime.Now;

        #region txt-Length
        public static int textBoxMaxLength = 500;
        public static int textIdentifyLength = 12;
        public static int textPhoneLength = 10;
        public static int textAreaMaxLength = 1000;
        #endregion

        public const string formatDateString = "dd/MM/yyyy";

        public const int MaxAnsiCode = 127;
        public static List<char> allowCharacterInText = new List<char> { ',', '.' };
        
        public static string Culture = "vi-VN";
        public static string DatabaseNameConfig = nameof(QuanLyHangHoaEntities);

        #region Prefix
        public static string prefixDatabaseName = "DB";
        public static string prefixServerName = "SV";
        public static string prefixProduct = string.Empty;
        public static string prefixUser = string.Empty;
        public static string prefixOrder = string.Empty;
        public static string prefixOrderDetail = string.Empty;
        public static string prefixCategory = string.Empty;

        #endregion

        #region CheckProperties
        public static string[] checkPropBookISBN = new string[] { "IdBookTitle", "IdAuthor", "OriginLanguage" };
        public static string[] checkPropBookTitle = new string[] { "Name", "IdCategory" };
        public static string[] checkPropFunction = new string[] { "Name", "IdParent" };
        public static string[] checkPropRole = new string[] { "Name" };
        public static string[] checkPropReader = new string[] { "LName", "FName", "boF", "ReaderType" };
        public static string[] checkPropChild = new string[] { "IdAdult" };
        public static string[] checkPropUser = new string[] { "Username" };
        public static string[] checkPropAuthor = new string[] { "Name" };
        public static string[] checkPropAdult = new string[] { "Identify" };
        public static string[] checkPropCategory = new string[] { "Name" };
        public static string[] checkPropPublisher = new string[] { "Name" };
        public static string[] checkPropTranslator = new string[] { "Name" };
        public static string[] checkPropProvince = new string[] { "Name" };
        public static string[] checkPropPenaltyReason = new string[] { "Name" };
        public static string[] checkPropParameter = new string[] { "Name" };
        public static string[] checkPropBook = new string[] { };
        public static string[] checkPropBookStatus = new string[] { "Name" };
        #endregion
        
        #region Style-String
        public static string styleBtnRestore = "btnRestore";
        public static string styleBtnDelete = "btnDelete";
        public static string styleBtnConfirm = "btnConfirm";
        public static string styleBtnCancel = "btnCancel";
        public static string styleWDGeneral = "wdStyleGeneral";
        public static string styleStkWrapButton = "stkWrapButton";
        public static string stylelblNote = "lblNote";
        #endregion

        public static int maxWDHeight = 700;
        public static int maxWDWidth = 1250;
        public static double FormMaxWidth = 800;
        public static double borderDistance = 10;

        public static double maxHeightTextArea = 200;

        public static Func<string> ShortConnStr = () => $"data source={"ADMIN"};initial catalog={"QuanLyHangHoa"};integrated security={true.ToString()}";
    }
}
