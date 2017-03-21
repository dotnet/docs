            object[] myCollectionArray = new object[myExceptionDictionary.Count];
            myExceptionDictionary.Values.CopyTo((Array)myCollectionArray,0);
            Console.WriteLine(" Values are :");
            foreach(object myObj in myCollectionArray)
            {
               Console.WriteLine(" " + myObj.ToString());
            }