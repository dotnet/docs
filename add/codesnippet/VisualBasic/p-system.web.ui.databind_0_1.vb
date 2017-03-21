            ' Use the DataBindingCollection.GetEnumerator method
            ' to iterate through the myDataBindingCollection object
            ' and write the PropertyName, PropertyType, and Expression
            ' properties to a file for each DataBinding object
            ' in the MyDataBindingCollection object. 
            myDataBindingCollection = DataBindings
            Dim myEnumerator As IEnumerator = myDataBindingCollection.GetEnumerator()

            While myEnumerator.MoveNext()
                myDataBinding2 = CType(myEnumerator.Current, DataBinding)
                Dim dataBindingOutput1, dataBindingOutput2, dataBindingOutput3 As [String]
                dataBindingOutput1 = [String].Concat("The property name is ", myDataBinding2.PropertyName)
                dataBindingOutput2 = [String].Concat("The property type is ", myDataBinding2.PropertyType.ToString(), "-", dataBindingOutput1)
                dataBindingOutput3 = [String].Concat("The expression is ", myDataBinding2.Expression, "-", dataBindingOutput2)
                WriteToFile(dataBindingOutput3)

                myDataBindingExpression2 = [String].Concat("<%#", myDataBinding2.Expression, "%>")
                myStringReplace2 = myDataBinding2.PropertyName.Replace(".", "-")
                myHtmlControlDesignBehavior.SetAttribute(myStringReplace2, myDataBindingExpression2)
                Dim index As Integer = myStringReplace2.IndexOf("-"c)
            End While ' while loop ends
        End Sub 'OnBindingsCollectionChanged