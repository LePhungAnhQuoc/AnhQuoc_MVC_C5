using Microsoft.Win32;
using System.Globalization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using System.Drawing;
using System.Web.Mvc;
using System.Web.UI;
using System.Web;

namespace AnhQuoc_MVC_C5
{
    public class Utilities
    {
        #region Notify
        public static string NotifyBookStatus()
        {
            return string.Format("This book is already borrow!");
        }

        public static string NotifyNotHaveRole()
        {
            return string.Format("This user doesn't have role!");
        }

        public static string NotifyRoleLock()
        {
            return string.Format("This role for this user is currently locked. Contact admin for help!");
        }

        public static string NotifyNotHaveFunctions(string item)
        {
            return string.Format("This {0} doesn't have any function!", item);
        }

        public static string NotifyItemExistInfo(string item)
        {
            return $"This {item} is has the same information in the list";
        }

        public static string NotifyItemExistInTheList(string item, bool isExist = true)
        {
            string result = string.Empty;
            if (isExist)
                result = string.Format("This {0} already exists in the list", item);
            else
                result = string.Format("This {0} is currently not in the list", item);
            return result;
        }

        public static string NotifyListEmptyMessage(string item, string lstName = "List")
        {
            return $"There are no {item} in the {lstName}.";
        }

        public static string NotifyBookTitleExistInfo()
        {
            return "This book title is has the same information in the list";
        }

        public static string NotifyBookISBNExistInfo()
        {
            return "This book ISBN is has the same information in the list";
        }


        public static string NotifyPleaseSelect(string item)
        {
            return string.Format("Please select {0}", item);
        }

        public static string NotifyInValidFormInput()
        {
            return "Please enter correct information!";
        }

        public static string NotifySureToDelete()
        {
            return "Are you sure you want to delete this item?";
        }

        public static string NotifySureToRestore()
        {
            return "Are you sure you want to restore this item?";
        }

        public static string NotifyFeatureNotDevelop()
        {
            return "The feature is currently under development. We're sorry";
        }

        public static string NotifyAddSuccessfully(string item)
        {
            var message = string.Format("Add new {0} successfully!", item);
            return message;
        }

        public static string NotifyDeleteSuccessfully(string item)
        {
            var message = string.Format("Delete {0} successfully!", item);
            return message;
        }

        public static string NotifyNotValidToDelete(string item)
        {
            var message = string.Format("Can not delete this {0}. Because this {0} is currently use!", item);
            return message;
        }

        public static string NotifyRestoreSuccessfully(string item)
        {
            var message = string.Format("Restore {0} successfully!", item);
            return message;
        }

        public static string NotifyUpdateSuccessfully(string item)
        {
            var message = string.Format("Update {0} successfully!", item);
            return message;
        }

        public static string NotifyDeleteSuccessfullyAdultReader(bool isHasChild)
        {
            string message = string.Empty;
            if (!isHasChild)
            {
                message = string.Format("Delete {0} successfully!", "Adult");
            }
            else
            {
                message = string.Format("Delete {0} and all childs successfully!", "Adult");
            }
            return message;
        }

        public static string NotifyDeleteSuccessfullyParentFunction(bool isHasChild)
        {
            string message = string.Empty;
            if (!isHasChild)
            {
                message = string.Format("Delete {0} successfully!", "Function");
            }
            else
            {
                message = string.Format("Delete {0} and all childs successfully!", "Parent function");
            }
            return message;
        }

        public static string NotifyRestoreSuccessfullyParentFunction(bool isHasParent)
        {
            string message = string.Empty;
            if (!isHasParent)
            {
                message = string.Format("Restore {0} successfully!", "Function");
            }
            else
            {
                message = string.Format("Restore {0} function and child function successfully!", "Parent");
            }
            return message;
        }

        public static string NotifyRestoreSuccessfullyAdultReader(bool isHasAdult)
        {
            string message = string.Empty;
            if (!isHasAdult)
            {
                message = string.Format("Restore {0} successfully!", "child reader");
            }
            else
            {
                message = string.Format("Restore {0} reader and child reader successfully!", "adult");
            }
            return message;
        }

        #endregion

        #region Validation
        // Validation notify
        public static string ValidateNoteFormNotEmptyRule()
        {
            return "This form can not empty!";
        }
        public static string ValidateNoteInputNumberRule()
        {
            return "Please input number only!";
        }
        public static string ValidateNoteInputNumberRangeRule(int? min, int? max)
        {
            string message = string.Empty;

            if (max == null)
            {
                if (min == null)
                {
                    return string.Empty;
                }
                else
                {
                    message = $"Please enter an number greater than {min}.";
                }
            }
            else
            {
                if (min == null)
                {
                    message = $"Please enter an number less than {max}.";
                }
                else
                {
                    message = $"Please enter an number in range: {min} - {max}.";
                }
            }
            return message;
        }
        public static string ValidateNoteInputNumberLengthRangeRule(int? min, int? max)
        {
            string message = string.Empty;

            if (max == null)
            {
                if (min == null)
                {
                    return string.Empty;
                }
                else
                {
                    message = $"Please enter an number in range greater than {min}.";
                }
            }
            else
            {
                if (min == null)
                {
                    message = $"Please enter an number in range less than {max}.";
                }
                else
                {
                    message = $"Please enter an number in range: {min} - {max}.";
                }
            }
            return message;
        }
        public static string ValidateNoteSelectedItemRule()
        {
            return $"Please select item";
        }
        public static string ValidateNoteFixLengthRule(int fixLength)
        {
            return $"Please enter an number with {fixLength} digits.";
        }
        public static string ValidateNoteDateTimeRangeRule(DateTime min)
        {
            return $"Please select a date between {min.ToShortDateString()} and today.";
        }
        public static string ValidateNoteInputUnicodeTextRule()
        {
            return "Please input text only!";
        }
        public static string ValidateNoteInputUnicodeTextNumberRule()
        {
            return "Please input text without special characters!";
        }
        public static string ValidateNoteInputParagraphRule()
        {
            return "Please input text only!";
        }
        public static string ValidateNoteQuantityEqual0()
        {
            return "Please input quantity greater than 0";
        }

        // Validation checkings
        public static bool FormNotEmptyRule(object value)
        {
            string getValue = (string)value;
            if (value != null && !IsCheckEmptyString(getValue))
            {
                return true;
            }
            return false;
        }

        public static bool InputNumberRule(string value)
        {
            foreach (char c in value)
            {
                if (char.IsDigit(c) == false)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool InputNumberRule(string value, char KeyChar)
        {
            if (!char.IsControl(KeyChar) && !char.IsDigit(KeyChar))
            {
                return false;
            }
            return true;
        }

        public static bool InputDecimalRule(string value, char KeyChar)
        {
            if (!char.IsControl(KeyChar) && !char.IsDigit(KeyChar)
                && (KeyChar != '.'))
            {
                return false;
            }

            // only allow one decimal point
            if ((KeyChar == '.') && (value.IndexOf('.') > -1))
            {
                return false;
            }
            return true;
        }

        public static bool FixLengthRule(string value, int fixLength)
        {
            if (value.Length != fixLength)
            {
                return false;
            }
            return true;
        }

        public static bool DateTimeRangeRule(DateTime value, DateTime min, DateTime max)
        {
            if (value >= min && value <= max)
            {
                return true;
            }
            return false;
        }

        public static bool InputUnicodeTextRule(string value, bool isAllowSpace)
        {
            foreach (char c in value)
            {
                if (!InputUnicodeTextRule(c, isAllowSpace))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool InputUnicodeTextNumberRule(string value, bool isAllowSpace)
        {
            foreach (char c in value)
            {
                if (char.IsDigit(c))
                {
                    continue;
                }
                if (!InputUnicodeTextRule(c, isAllowSpace))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool InputUnicodeTextRule(char c, bool isAllowSpace)
        {
            if (isAllowSpace == true && c == ' ')
            {
                return true;
            }
            if (char.IsLetter(c))
            {
                return true;
            }
            return false;
        }

        public static bool InputParagraphRule(string value, bool isAllowSpace, List<char> allowCharacters)
        {
            bool result = value.All((c) =>
            {
                if (allowCharacters.Contains(c))
                {
                    return true;
                }
                if (char.IsDigit(c))
                {
                    return true;
                }
                if (InputUnicodeTextRule(c, isAllowSpace))
                {
                    return true;
                }
                return false;
            });
            return result;
        }
        #endregion

        #region String-Uti

        public static string RemoveDiacritics(string text)
        {
            string formD = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char ch in formD)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        // Check is null, is empty, is str only have WhiteSpace characters
        public static bool IsCheckEmptyString(string value)
        {
            bool result = string.IsNullOrEmpty(value)
                || string.IsNullOrWhiteSpace(value);
            return result;
        }


        public static string ToCapitalizeEachWord(string str)
        {
            // Creates a TextInfo based on the "en-US" culture.
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            string result = textInfo.ToTitleCase(str);
            return result;
        }

        public static string ToCapitalizeInParagragh(string str)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string lipsum2lower = textInfo.ToLower(str);

            string[] lipsum2split = lipsum2lower.Split(' ');

            bool first = true;

            string result = string.Empty;
            foreach (string s in lipsum2split)
            {
                if (first)
                {
                    result += textInfo.ToTitleCase(s);
                    first = false;
                }
                else
                {
                    result += s;
                }
            }
            return result;
        }

        #endregion
        
        #region ViewModelBase-Uti
        public static ObservableCollection<T> FillByStatus<T>(ObservableCollection<T> items, bool? statusValue)
        {
            ObservableCollection<T> result = new ObservableCollection<T>();
            foreach (T item in items)
            {
                PropertyInfo statusProp = item.GetType().GetProperty("Status");

                if (statusProp == null) // Obj không có trường Status
                    return items;

                if (statusValue == null || (bool)statusProp.GetValue(item) == statusValue)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static T FindInList<T>(IEnumerable<T> source, T findItem)
        {
            return source.FirstOrDefault(item => item.Equals(findItem));
        }

        public static void Copy(object dest, object source)
        {
            IsCheckProperties isCheckProperties = new IsCheckProperties(CheckPropertyType.Except);
            Copy(dest, source, isCheckProperties);
        }

        public static void Copy(object dest, object source, IsCheckProperties isCheckProperties)
        {
            const string propSelector = "Name";
            bool isAllProperties = false;
            if (isCheckProperties.ListProperties.Count == 0 && isCheckProperties.Type == CheckPropertyType.Except)
            {
                isAllProperties = true;
            }

            var dest_props = getPropsFromType(dest);
            var source_props = getPropsFromType(source);

            var propsString = Utilities.InnerJoin(dest_props, source_props, propSelector).ToList();
            dest_props = FillPropertiesByName(dest_props, propsString.ToArray());
            source_props = FillPropertiesByName(source_props, propsString.ToArray());

            for (int i = 0; i < dest_props.Count(); i++)
            {
                PropertyInfo dest_prop = dest_props[i];
                PropertyInfo source_prop = source_props[i];

                if (!isAllProperties)
                {
                    if (isCheckProperties.Type == CheckPropertyType.Include)
                    {
                        var itemCheck = FindPropertyByName(isCheckProperties.ListProperties, dest_prop.Name);
                        if (itemCheck == null)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        var itemCheck = FindPropertyByName(isCheckProperties.ListProperties, dest_prop.Name);
                        if (itemCheck != null)
                        {
                            continue;
                        }
                    }
                }
                object value2 = getValueFromProperty(source_prop, source);

                if (value2 == null)
                {
                    dest_prop.SetValue(dest, null);
                }
                else
                {
                    if (!IsGeneric(value2.GetType()))
                    {
                        if (dest_prop.PropertyType.Name == source_prop.PropertyType.Name)
                        {
                            dest_prop.SetValue(dest, value2);
                        }
                    }
                }
            }
        }

        public static IEnumerable<T> OrderBy<T>(IEnumerable<T> source, PropertyInfo Tkey)
        {
            return source.OrderBy(item =>
            {
                return Tkey.GetValue(item);
            });
        }


        public static bool IsExistInformation<T>(ObservableCollection<T> items, T itemCheck, bool igNoreCase = true, params string[] checkProperties)
        {
            foreach (T item in items)
            {
                bool isEqual = IsExistInformation(item, itemCheck, igNoreCase, checkProperties);
                if (isEqual)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsExistInformation<T>(T item, T itemCheck, bool igNoreCase = true, params string[] checkProperties)
        {
            return IsEqual(item, itemCheck, igNoreCase, checkProperties);
        }

        public static bool IsEqual<T>(T item1, T item2, bool igNoreCase = true, params string[] checkProperties)
        {
            var item1_props = getPropsFromType(item1);
            var item2_props = getPropsFromType(item2);
            for (int i = 0; i < item1_props.Count(); i++)
            {
                PropertyInfo item1_prop = item1_props[i];
                PropertyInfo item2_prop = item2_props[i];

                var itemCheck = FindPropertyByName(checkProperties.ToList(), item1_prop.Name);
                if (itemCheck == null)
                {
                    continue;
                }
                object value1 = getValueFromProperty(item1_prop, item1);
                object value2 = getValueFromProperty(item2_prop, item2);

                if (value1 == null && value2 != null)
                {
                    return false;
                }
                if (value1 != null && value2 == null)
                {
                    return false;
                }


                if (value1 != null && value2 != null)
                {
                    if (value1 is string && value2 is string)
                    {
                        var tempValue1 = (value1 as string);
                        var tempValue2 = (value2 as string);
                        if (igNoreCase)
                        {
                            tempValue1 = tempValue1.ToLower();
                            tempValue2 = tempValue2.ToLower();
                        }

                        if (!tempValue1.Equals(tempValue2))
                        {
                            return false;
                        }
                        continue;
                    }
                    if (!value1.Equals(value2))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion


        #region OtherMethods
       
        
        public static List<int> GetIndex(List<string> first, List<string> second)
        {
            int[] result = new int[first.Count];

            for (int i = 0; i < first.Count; i++)
            {
                for (int j = 0; j < second.Count; j++)
                {
                    if (first[i] == second[j])
                    {
                        result[j] = i;
                    }
                }
            }
            return result.ToList();
        }

        public static int? GetMax(int a, int b)
        {
            if (a > b)
                return a;
            if (a < b)
                return b;
            return null;
        }

        public static bool IsCheckRange(int value, int? min, int? max)
        {
            bool isCheck = false;

            if (max == null)
            {
                if (min == null)
                {
                    isCheck = true;
                }
                else
                {
                    isCheck = value >= min;
                }
            }
            else
            {
                if (min == null)
                {
                    isCheck = value <= max;
                }
                else
                {
                    isCheck = value >= min && value <= max;
                }
            }
            return isCheck;
        }
        
        public static ObservableCollection<string> GetListAllLanguages()
        {
            ObservableCollection<string[]> result = new ObservableCollection<string[]>();
            
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);

            foreach (CultureInfo culture in cultures)
            {
                result.Add(new string[2] {culture.Name, culture.DisplayName });
            }

            ObservableCollection<string> getDistinct = new ObservableCollection<string>();
            foreach (var item in result)
            {
                getDistinct.Add(item[0].Split('-')[0]);
            }
            getDistinct = getDistinct.Distinct().ToTypedCollection<ObservableCollection<string>, string>();

            var query = getDistinct.Join(result, itemDis => itemDis, itemS => itemS[0], (itemDis, itemS) => itemS[1]);

            var lastResult = query.OrderBy(item => item).ToTypedCollection<ObservableCollection<string>, string>();
            return lastResult;
        }

        public static int ExtractNumberFromAString(string str)
        {
            string temp = string.Empty;
            int result = -1;

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                    temp += str[i];
            }

            if (temp.Length > 0)
                result = int.Parse(temp);
            return result;
        }
        #endregion

        #region Enum-Uti
        public static IEnumerable<T> GetListFromEnum<T>() where T : struct, IConvertible
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
        #endregion

        #region Entities-Uti
        public static PropertyInfo GetTablePropertyFromDatabase<T>(QuanLyHangHoaEntities dbSource)
        {
            foreach (PropertyInfo tableProperty in Utilities.getDerivePropsFromType(dbSource))
            {
                IEnumerable value = null;
                try
                {
                    value = (IEnumerable)Utilities.getValueFromProperty(tableProperty, dbSource);
                }
                catch
                {
                    continue;
                }
                Type itemDataType = Utilities.GetItemDataTypeInGenericList(value);
                if (itemDataType == typeof(T))
                {
                    return tableProperty;
                }
            }
            return null;
        }
        #endregion

        #region Property-Uti
        // check if it's a generic List<T> or IEnumerable<T>, ...
        public static Type GetGenericDataType(Type type)
        {
            return type.GetGenericTypeDefinition();
        }

        public static bool IsListType(Type type)
        {
            return GetGenericDataType(type) == typeof(List<>);
        }

        public static bool IsGeneric(Type type)
        {
            return type.IsGenericType;
        }

        public static bool IsGeneric(object obj)
        {
            return IsGeneric(obj.GetType());
        }

        public static Type GetItemDataTypeInGenericList(IEnumerable list)
        {
            Type type = list.GetType();
            Type itemType = type.GetGenericArguments().Single();
            return itemType;
        }


        public static Type GetLeftDataTypeOfVariable<T>(T x) => typeof(T);

        public static List<PropertyInfo> getPropsFromType(Type type)
        {
            return type.GetProperties().OrderBy(item => item.Name).ToList();
        }

        public static List<PropertyInfo> getPropsFromType(object obj)
        {
            return getPropsFromType(obj.GetType());
        }

        public static List<PropertyInfo> getBasePropsFromType(Type type)
        {
            return getPropsFromType(type.BaseType);
        }

        public static List<PropertyInfo> getBasePropsFromType(object obj)
        {
            return getBasePropsFromType(obj.GetType());
        }

        public static List<PropertyInfo> getDerivePropsFromType(Type type)
        {
            var props = getPropsFromType(type);
            return props.Where(p => p.DeclaringType.FullName != type.BaseType.FullName).ToList();
        }

        public static List<PropertyInfo> getDerivePropsFromType(object obj)
        {
            return getDerivePropsFromType(obj.GetType());
        }

        public static void SetValueToProperty(string propName, object item, object value)
        {
            PropertyInfo prop = item.GetType().GetProperty(propName);
            SetValueToProperty(prop, item, value);
        }

        public static void SetValueToProperty(PropertyInfo prop, object item, object value)
        {
            prop.SetValue(item, value);
        }

        public static object getValueFromProperty(string propName, object item)
        {
            PropertyInfo prop = item.GetType().GetProperty(propName);
            return getValueFromProperty(prop, item);
        }

        public static object getValueFromProperty(PropertyInfo prop, object item)
        {
            return prop.GetValue(item, null);
        }

        public static object ConvertFromString(string tempValue, Type getType)
        {
            TypeConverter typeConverter = TypeDescriptor.GetConverter(getType);

            if (IsCheckEmptyString(tempValue))
                return null;
            object result = typeConverter.ConvertFromString(tempValue);
            return result;
        }

        public static List<PropertyInfo> FillPropertiesByName(List<PropertyInfo> properties, params string[] propsName)
        {
            List<PropertyInfo> result = new List<PropertyInfo>();
            foreach (string prop in propsName)
            {
                PropertyInfo property = FindPropertyByName(properties, prop);
                result.Add(property);
            }
            return result;
        }

        public static PropertyInfo FindPropertyByName(List<PropertyInfo> properties, string propertyName)
        {
            foreach (PropertyInfo item in properties)
            {
                if (string.Compare(item.Name, propertyName) == 0)
                {
                    return item;
                }
            }
            return null;
        }

        public static string FindPropertyByName(List<string> properties, string propertyName)
        {
            foreach (string item in properties)
            {
                if (string.Compare(item, propertyName) == 0)
                {
                    return item;
                }
            }
            return null;
        }



        #endregion

        #region Xml-Uti
        public static void RemoveAllChilds(XmlNode parentNode)
        {
            XmlNodeList lstChild = parentNode.ChildNodes;
            while (lstChild.Count > 0)
            {
                parentNode.RemoveChild(lstChild[0]);
            }
        }

        private static int getIndexDirectory(string filePath)
        {
            if (!filePath.Contains(".xml"))
            {
                return -1;
            }
            int index = filePath.Length - 1;
            foreach (char c in filePath.Reverse())
            {
                if (c.ToString() == "\\" || c.ToString() == "/")
                {
                    break;
                }
                index--;
            }
            return index;
        }

        public static void CreateXML(string filePath, string rootName)
        {
            string temp_filePath = filePath;
            int indexOf = getIndexDirectory(filePath);
            if (indexOf == -1)
            {
                return;
            }
            string directory = filePath.Remove(indexOf);
            CreateDirectory(directory);

            filePath = temp_filePath;
            if (!File.Exists(filePath))
            {
                XmlDocument doc = new XmlDocument();
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);

                XmlNode root = doc.DocumentElement;
                doc.InsertBefore(xmlDeclaration, root);

                XmlElement element1 = doc.CreateElement(string.Empty, rootName, string.Empty);
                doc.AppendChild(element1);
                try { doc.Save(filePath); }
                catch { }
            }
        }
        #endregion

        #region Directory-Uti
        private static string GetDebugDirectory()
        {
            return System.IO.Directory.GetCurrentDirectory();
        }

        private static string GetProjectDirectory()
        {
            string startupPath = GetDebugDirectory();

            startupPath = Directory.GetParent(startupPath).FullName;
            startupPath = Directory.GetParent(startupPath).FullName;

            return startupPath;
        }

        public static string GetDirectoryImage()
        {
            string startupPath = GetProjectDirectory();
            string appPath = startupPath + Constants.StartUrlImage;
            Utilities.CreateDirectory(appPath);

            return appPath;
        }

        public static void SaveFile(string source, string dest, string fileName)
        {
            try
            {
                File.Copy(source, dest + fileName);
            }
            catch (IOException io_exception)
            {
                //File Exist. So not copy
            }
        }

        public static string GetUrlImage()
        {
            string fileName = string.Empty;
            return Constants.StartUrlImage + fileName;
        }

        public static string SaveImage()
        {
            string source = string.Empty; //openFile.FileName;
            string dest = Utilities.GetDirectoryImage();
            string fileName = string.Empty; //openFile.SafeFileName;

            string sourceDir = source.Replace(fileName, "");

            if (sourceDir != dest)
                SaveFile(source, dest, fileName);

            return Constants.StartUrlImage + fileName;
        }

        public static void RemoveImage(string urlImage)
        {
            string filePath = GetDirectoryImage().Replace(Constants.StartUrlImage, string.Empty) + urlImage;
            DeleteFile(filePath);
        }

        #region Diretory-File
        public static void CreateDirectory(string folderPath)
        {
            // If directory does not exist, create it
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        public static void RenameDirectory(string oldName, string newName)
        {
            // If directory does not exist, create it
            if (Directory.Exists(oldName))
            {
                Directory.Move(oldName, newName);
            }
        }

        public static void DeleteDirectory(string folderPath)
        {
            // If directory does not exist, create it
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
            }
        }

        public static void RenameFile(string oldName, string newName)
        {
            // If directory does not exist, create it
            if (File.Exists(oldName))
            {
                File.Move(oldName, newName);
            }
        }

        public static void DeleteFile(string filePath)
        {
            // If directory does not exist, create it
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        #endregion

        #endregion

        #region Hash-Password
        public static string Base64Encode(string plainText)
        {
            if (plainText == string.Empty || plainText == null)
                return string.Empty;
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
                hash.Append(bytes[i].ToString("x2"));
            return hash.ToString();
        }

        public static string Md5HashType2(string input)
        {
            using (var md5 = MD5.Create())
            {
                byte[] arr = Encoding.ASCII.GetBytes(input);
                byte[] arrMd5 = md5.ComputeHash(arr);
                StringBuilder sb = new StringBuilder();
                foreach (var b in arrMd5)
                {
                    sb.AppendFormat("{0:X}", b);
                }
                return sb.ToString();
            }
        }
        #endregion

        public static IEnumerable<T> RemoveItemInList<T>(IEnumerable<T> list, IEnumerable<T> removeItems)
        {
            IEnumerable<T> result = list.Where(item => !removeItems.Any(sub => sub.Equals(item)));
            return result;
        }

        public static IEnumerable<string> InnerJoin<T>(IEnumerable<T> bigSource, IEnumerable<T> smallSource, string propSelector)
        {
            Func<T, string> outerKeySelector = bigItem => getValueFromProperty(bigItem.GetType().GetProperty(propSelector), bigItem).ToString();
            Func<T, string> innerKeySelector = smallItem => getValueFromProperty(smallItem.GetType().GetProperty(propSelector), smallItem).ToString();

            IEnumerable<string> result = bigSource.Join(smallSource, outerKeySelector, innerKeySelector, (bigItem, smallItem) => getValueFromProperty(bigItem.GetType().GetProperty(propSelector), bigItem).ToString());
            return result;
        }

        public static IEnumerable<string> OuterJoin<T>(IEnumerable<T> bigSource, IEnumerable<T> smallSource, string propSelector)
        {
            List<string> result = new List<string>();

            foreach (var bigItem in bigSource)
            {
                var bigItemName = getValueFromProperty(bigItem.GetType().GetProperty(propSelector), bigItem).ToString();
                var itemFinded = smallSource.FirstOrDefault(smallItem =>
                {
                    var smallItemName = getValueFromProperty(smallItem.GetType().GetProperty(propSelector), smallItem).ToString();
                    return smallItemName == bigItemName;
                });
                if (itemFinded == null)
                {
                    result.Add(bigItemName);
                }
            }
            return result;
        }

        public static IEnumerable<string> GetAllColumnNameInDatabase(SqlDataReader reader)
        {
            var columns = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).OrderBy(item => item).ToList();
            return columns;
        }

        public static IEnumerable<Type> GetAllFieldTypeInDatabase(SqlDataReader reader)
        {
            var fieldTypes = Enumerable.Range(0, reader.FieldCount).Select(reader.GetFieldType).OrderBy(item => item).ToList();
            return fieldTypes;
        }

        public static IEnumerable<string> GetAllDataTypeInDatabase(SqlDataReader reader)
        {
            var databaseTypes = Enumerable.Range(0, reader.FieldCount).Select(reader.GetDataTypeName).OrderBy(item => item).ToList();
            return databaseTypes;
        }

        public static bool IsCheckEmptyItem(object item, bool isExceptProperty, params string[] checkProperties)
        {
            var props = Utilities.getPropsFromType(item);

            bool isAllProperties = false;
            if (checkProperties.Length == 0)
            {
                isAllProperties = true;
            }

            foreach (var property in props)
            {
                if (isExceptProperty)
                {
                    var itemCheck = FindPropertyByName(checkProperties.ToList(), property.Name);
                    if (itemCheck != null)
                    {
                        continue;
                    }
                }
                else if (!isAllProperties)
                {
                    var itemCheck = FindPropertyByName(checkProperties.ToList(), property.Name);
                    if (itemCheck == null)
                    {
                        continue;
                    }
                }

                if (property.PropertyType == typeof(string))
                {
                    if (Utilities.IsCheckEmptyString(Utilities.getValueFromProperty(property, item)?.ToString()))
                    {
                        return false;
                    }
                }
                else if (property.PropertyType == typeof(DateTime))
                {
                    if ((DateTime)Utilities.getValueFromProperty(property, item) == Constants.dateEmptyValue)
                    {
                        return false;
                    }
                }
                else if (property.PropertyType == typeof(int))
                {
                    if ((int)Utilities.getValueFromProperty(property, item) == 0)
                    {
                        return false;
                    }
                }
                else if (property.PropertyType == typeof(double))
                {
                    if ((double)Utilities.getValueFromProperty(property, item) == 0)
                    {
                        return false;
                    }
                }
                else if (property.PropertyType == typeof(decimal))
                {
                    if ((decimal)Utilities.getValueFromProperty(property, item) == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public static string GetIndexerNameInCollection(object collection)
        {
            // GetValue Indexer to get item property in collection
            string indexerName = ((DefaultMemberAttribute)collection.GetType().GetCustomAttributes(typeof(DefaultMemberAttribute), true)[0]).MemberName;
            return indexerName;
        }

        public static object[] GetMaxOccurrenceInArray(ObservableCollection<string> source)
        {
            var sourceMerge = source.Distinct().ToList();

            var counts = sourceMerge.Select(itemM => source.Count(itemS => itemS == itemM)).ToList();

            var indexMax = counts.IndexOf(counts.Max());

            var maxValue = sourceMerge[indexMax];
            return new object[] { maxValue, counts.Max() };
        }

        public static Dictionary<string, int> GetOccurrenceInArray(ObservableCollection<string> source)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            var sourceMerge = source.Distinct().ToList();

            var counts = sourceMerge.Select(itemM => source.Count(itemS => itemS == itemM)).ToList();

            int index = 0;
            sourceMerge.ForEach(item =>
            {
                result.Add(item, counts[index]);
                index++;
            });

            return result;
        }

        public static string FormatCurrency(string currencyCode, decimal amount)
        {
            CultureInfo culture = (from c in CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                                   let r = new RegionInfo(c.LCID)
                                   where r != null
                                   && r.ISOCurrencySymbol.ToUpper() == currencyCode.ToUpper()
                                   select c).FirstOrDefault();
            if (culture == null)
            {
                // fall back to current culture if none is found
                // you could throw an exception here if that's not supposed to happen
                culture = CultureInfo.CurrentCulture;
            }
            culture = (CultureInfo)culture.Clone();
            culture.NumberFormat.CurrencySymbol = currencyCode;

            // Add spaces between the figure and the currency code
            culture.NumberFormat.CurrencyPositivePattern = culture.NumberFormat.CurrencyPositivePattern == 0 ? 2 : 3;
            var cnp = culture.NumberFormat.CurrencyNegativePattern;
            switch (cnp)
            {
                case 0: cnp = 14; break;
                case 1: cnp = 9; break;
                case 2: cnp = 12; break;
                case 3: cnp = 11; break;
                case 4: cnp = 15; break;
                case 5: cnp = 8; break;
                case 6: cnp = 13; break;
                case 7: cnp = 10; break;
            }
            culture.NumberFormat.CurrencyNegativePattern = cnp;

            return amount.ToString("C" + ((amount % 1) == 0 ? "0" : "2"), culture);
        }


        public static void SetAlert(TempDataDictionary TempData, string message, int type)
        {
            TempData["AlertMessage"] = message;
            if (type == 1)
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == 2)
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == 3)
            {
                TempData["AlertType"] = "alert-danger";
            }
            else
            {
                TempData["AlertType"] = "alert-info";
            }
        }

        public static bool IsLogged()
        {
            User getUser = new User();
            UserLogin user = new UserLogin();

            var Session = HttpContext.Current.Session;
            var Cookies = HttpContext.Current.Request.Cookies;

            if (Session[nameof(user.Username)] == null && Session[nameof(user.Password)] == null)
            {
                if (Cookies["userId"] != null)
                {
                    int id = Convert.ToInt32(Cookies["userId"].Value);

                    User getLoginUser = null;

                    using (var qlbh = new QuanLyHangHoaEntities())
                    {
                        getLoginUser = qlbh.Users.FirstOrDefault(item => item.Id == id);
                    }
                    Session[nameof(user.Username)] = getLoginUser.Username;
                    Session[nameof(user.Password)] = getLoginUser.Password;
                    return true;
                }
                return false;
            }
            return true;
        }

        public static Cart GetCart()
        {
            if (HttpContext.Current.Session[nameof(Cart)] == null)
            {
                HttpContext.Current.Session[nameof(Cart)] = new Cart();
            }
            return (Cart)HttpContext.Current.Session[nameof(Cart)];
        }

        public static void MinusQuantity(Product product)
        {
            Cart cart = Utilities.GetCart();
            var listCartItems = cart.Items.Where(cartItem => cartItem.Product.Id == product.Id);
            listCartItems.ForEach(cartItem =>
            {
                product.Quantity -= cartItem.Quantity;
            });
        }

        public static void MinusQuantity(IEnumerable<Product> productList)
        {
            productList.ForEach(product =>
            {
                Utilities.MinusQuantity(product);
            });
        }

        public static void UpdateCart(Cart cart)
        {
            HttpContext.Current.Session[nameof(Cart)] = cart;
        }
    }
}