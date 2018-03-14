        static void CreateIconInWordDoc2008()
        {
            var wordApp = new Word.Application();
            wordApp.Visible = true;

            // The Add method has four parameters, all of which are optional. 
            // In Visual C# 2008 and earlier versions, an argument has to be sent 
            // for every parameter. Because the parameters are reference  
            // parameters of type object, you have to create an object variable
            // for the arguments that represents 'no value'. 

            object useDefaultValue = Type.Missing;

            wordApp.Documents.Add(ref useDefaultValue, ref useDefaultValue,
                ref useDefaultValue, ref useDefaultValue);

            // PasteSpecial has seven reference parameters, all of which are
            // optional. In this example, only two of the parameters require
            // specified values, but in Visual C# 2008 an argument must be sent
            // for each parameter. Because the parameters are reference parameters,
            // you have to contruct variables for the arguments.
            object link = true;
            object displayAsIcon = true;

            wordApp.Selection.PasteSpecial( ref useDefaultValue,
                                            ref link,
                                            ref useDefaultValue,
                                            ref displayAsIcon,
                                            ref useDefaultValue,
                                            ref useDefaultValue,
                                            ref useDefaultValue);
        }