            object[] myArray = new object[myExceptionDictionary.Count];
            myExceptionDictionary.Keys.CopyTo((Array)myArray,0);
            Console.WriteLine(" Keys are :");
            foreach(object myObj in myArray)
            {
               Console.WriteLine(" " + myObj.ToString());
            }