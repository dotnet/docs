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