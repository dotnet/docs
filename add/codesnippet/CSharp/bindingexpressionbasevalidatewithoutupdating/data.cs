//<SnippetData>
using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Globalization;

namespace BindingExpressionBaseValidateWithoutUpdating
{
    // LibraryItem implements INotifyPropertyChanged so that the 
    // application is notified when a property changes.  It 
    // implements IEditableObject so that pending changes can be discarded.
    // In this example, the application does not discard changes.
    public class LibraryItem : INotifyPropertyChanged, IEditableObject
    {
        struct ItemData
        {
            internal string Title;
            internal string CallNumber;
            internal DateTime DueDate;
        }

        ItemData copyData;
        ItemData currentData;

        public LibraryItem(string title, string callNum, DateTime dueDate)
        {
            Title = title;
            CallNumber = callNum;
            DueDate = dueDate;
        }

        public string Title
        {
            get { return currentData.Title; }
            set
            {
                if (currentData.Title != value)
                {
                    currentData.Title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        public string CallNumber
        {
            get { return currentData.CallNumber; }
            set
            {
                if (currentData.CallNumber != value)
                {
                    currentData.CallNumber = value;
                    NotifyPropertyChanged("CallNumber");
                }
            }
        }

        public DateTime DueDate
        {
            get { return currentData.DueDate; }
            set
            {
                if (value != currentData.DueDate)
                {
                    currentData.DueDate = value;
                    NotifyPropertyChanged("DueDate");
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion

        #region IEditableObject Members

        public virtual void BeginEdit()
        {
            copyData = currentData;
        }

        public virtual void CancelEdit()
        {
            currentData = copyData;
            NotifyPropertyChanged("");

        }

        public virtual void EndEdit()
        {
            copyData = new ItemData();

        }

        #endregion

    }

    public class CallNumberRule : ValidationRule
    {
        // A valid call number contains a period (.)
        // and 6 characters after the period.
        public override ValidationResult Validate(object value, 
                                         CultureInfo cultureInfo)
        {
            string callNum = (string)value;

            int dotIndex = callNum.IndexOf(".");
            if (dotIndex == -1 || dotIndex == 0)
            {
                return new ValidationResult(false, 
                    "There must be characters followed by a period (.) in the call number.");
            }

            string substr = callNum.Substring(dotIndex + 1);

            if (substr.Length != 6)
            {
                return new ValidationResult(false, 
                    "The call number must have 6 characters after the period (.).");

            }

            return ValidationResult.ValidResult;
        }
    }

}
//</SnippetData>
