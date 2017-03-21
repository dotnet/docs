         Exception^ myException = myExceptionDictionary[ myUrlKey ];
         Console::WriteLine( " Source : {0}", myException->Source );
         Console::WriteLine( " Exception : {0}", myException->Message );