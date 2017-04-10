using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BindingValidationSnippets
{
    //<SnippetIDataErrorInfoData>
    public class PersonImplementsIDataErrorInfo : IDataErrorInfo
    {
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Error
        {
            get
            {
                return "";
            }
        }

        public string this[string name]
        {
            get
            {
                string result = null;

                if (name == "Age")
                {
                    if (this.age < 0 || this.age > 150)
                    {
                        result = "Age must not be less than 0 or greater than 150.";
                    }
                }
                return result;
            }
        }
    }
    //</SnippetIDataErrorInfoData>

    //<SnippetThrowExceptionData>
    public class PersonThrowException
    {
        private int age;

        public int Age
        {
            get { return age; }
            set
            {

                if (value < 0 || value > 150)
                {
                    throw new ArgumentException("Age must not be less than 0 or greater than 150.");
                }
                age = value;
            }
        }
    }
    //</SnippetThrowExceptionData>
}
