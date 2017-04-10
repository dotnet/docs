// <snippet1>
// Create a namespace that contains a class, named 
// SimpleDesigner, that extends the ControlDesigner class.
// The DataBinding and DataBindingCollection classes 
// are available only at design time, so manipulating their 
// methods and properties must occur at design time as well.
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI.Design;
using System.IO;
using System.Text;
using System.Collections;

namespace DataBindingTest
{

    // <snippet2>
    // Create the custom class that accesses the DataBinding and
    // DataBindingCollection classes at design time.
    public class SimpleDesigner : System.Web.UI.Design.ControlDesigner
    {
        // <snippet3>
        // Create a Text property with accessors that obtain 
        // the property value from and set the property value
        // to the Text key in the DataBindingCollection class.
        public string Text
        {
            get
            {
                DataBinding myBinding = DataBindings["Text"];
                if (myBinding != null)
                {
                    return myBinding.Expression;
                }
                return String.Empty;
            }
            set
            {

                if ((value == null) || (value.Length == 0))
                {
                    DataBindings.Remove("Text");
                }
                else
                {

                    DataBinding binding = DataBindings["Text"];

                    if (binding == null)
                    {
                        binding = new DataBinding("Text", typeof(string), value);
                    }
                    else
                    {
                        binding.Expression = value;
                    }
                    // Call the DataBinding constructor, then add
                    // the initialized DataBinding object to the 
                    // DataBindingCollection for this custom designer.
                    DataBinding binding1 = (DataBinding)DataBindings.SyncRoot;
                    DataBindings.Add(binding);
                    DataBindings.Add(binding1);
                }
                PropertyChanged("Text");
            }
        }
        // </Snippet3>
        protected void PropertyChanged(string propName)
        {
            IControlDesignerTag myHtmlControlDesignBehavior = this.Tag;
            
            DataBindingCollection myDataBindingCollection;
            DataBinding myDataBinding1, myDataBinding2;
            String myStringReplace1, myDataBindingExpression1, removedBinding, removedBindingAfterReplace, myDataBindingExpression2, myStringReplace2;
            string[] removedBindings1, removedBindings2;
            Int32 temp;

            if (myHtmlControlDesignBehavior == null)
                return;
            // <Snippet4>
            // Use the DataBindingCollection constructor to 
            // create the myDataBindingCollection1 object.
            // Then set this object equal to the
            // DataBindings property of the control created
            // by this custom designer.
            DataBindingCollection myDataBindingCollection1 = new DataBindingCollection();
            myDataBindingCollection1 = myDataBindingCollection = DataBindings;
            // </Snippet4>
	    // <Snippet7>
            if (myDataBindingCollection.Contains(propName))
            {
                myDataBinding1 = myDataBindingCollection[propName];
                myStringReplace1 = propName.Replace(".", "-");
                if (myDataBinding1 == null)
                {
                    myHtmlControlDesignBehavior.RemoveAttribute(myStringReplace1);
                    return;
                }
                // DataBinding is not null.
                myDataBindingExpression1 = String.Concat("<%#", myDataBinding1.Expression, "%>");
                myHtmlControlDesignBehavior.SetAttribute(myStringReplace1, myDataBindingExpression1);
                int index = myStringReplace1.IndexOf("-");
            }
            else
            {
                // <Snippet5>
                // Use the DataBindingCollection.RemovedBindings 
                // property to set the value of the removedBindings
                // arrays.
                removedBindings2 = removedBindings1 = DataBindings.RemovedBindings;
                // </Snippet5>
                temp = 0;
                while (removedBindings2.Length > temp)
                {
                    removedBinding = removedBindings2[temp];
                    removedBindingAfterReplace = removedBinding.Replace('.', '-');
                    myHtmlControlDesignBehavior.RemoveAttribute(removedBindingAfterReplace);
                    temp = temp + 1;
                }
            }
            // </Snippet7>
            // <Snippet6>
            // Use the DataBindingCollection.GetEnumerator method
            // to iterate through the myDataBindingCollection object
            // and write the PropertyName, PropertyType, and Expression
            // properties to a file for each DataBinding object
            // in the MyDataBindingCollection object. 
            myDataBindingCollection = DataBindings;
            IEnumerator myEnumerator = myDataBindingCollection.GetEnumerator();

            while (myEnumerator.MoveNext())
            {
                myDataBinding2 = (DataBinding)myEnumerator.Current;
                String dataBindingOutput1, dataBindingOutput2, dataBindingOutput3;
                dataBindingOutput1 = String.Concat("The property name is ", myDataBinding2.PropertyName);
                dataBindingOutput2 = String.Concat("The property type is ", myDataBinding2.PropertyType.ToString(), "-", dataBindingOutput1);
                dataBindingOutput3 = String.Concat("The expression is ", myDataBinding2.Expression, "-", dataBindingOutput2);
                WriteToFile(dataBindingOutput3);

                myDataBindingExpression2 = String.Concat("<%#", myDataBinding2.Expression, "%>");
                myStringReplace2 = myDataBinding2.PropertyName.Replace(".", "-");
                myHtmlControlDesignBehavior.SetAttribute(myStringReplace2, myDataBindingExpression2);
                int index = myStringReplace2.IndexOf('-');
            }// while loop ends
            // </snippet6>
        }
        public void WriteToFile(string input)
        {
            // The WriteToFile custom method writes
            // the values of the DataBinding properties
            // to a file on the C drive at design time.
            StreamWriter myFile = File.AppendText("C:\\DataBindingOutput.txt");
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] ByteArray = encoder.GetBytes(input);
            char[] CharArray = encoder.GetChars(ByteArray);
            myFile.WriteLine(CharArray, 0, input.Length);
            myFile.Close();
        }
    }
    // </snippet2>
}
// </snippet1>
