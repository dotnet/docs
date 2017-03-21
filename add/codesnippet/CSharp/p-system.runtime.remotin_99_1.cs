         Console.WriteLine("Message Properties");
         IDictionary myDictionary = myMesg.Properties;
         IDictionaryEnumerator myEnum = (IDictionaryEnumerator) myDictionary.GetEnumerator();

         while (myEnum.MoveNext())
         {
            object myKey = myEnum.Key;
            string myKeyName = myKey.ToString();
            object myValue = myEnum.Value;

            Console.WriteLine("{0} : {1}", myKeyName, myEnum.Value);
            if (myKeyName == "__Args")
            {
               object[] myArgs = (object[])myValue;
               for (int myInt = 0; myInt < myArgs.Length; myInt++)
                  Console.WriteLine("arg: {0} myValue: {1}", myInt, myArgs[myInt]);
            }

            if ((myKeyName == "__MethodSignature") && (null != myValue))
            {
               object[] myArgs = (object[])myValue;
               for (int myInt = 0; myInt < myArgs.Length; myInt++)
                  Console.WriteLine("arg: {0} myValue: {1}", myInt, myArgs[myInt]);
            }
         }

         Console.WriteLine("myUrl1 {0} object URI{1}",myUrl,myObjectURI);

         myDictionary["__Uri"] = myUrl;
         Console.WriteLine("URI {0}", myDictionary["__URI"]);