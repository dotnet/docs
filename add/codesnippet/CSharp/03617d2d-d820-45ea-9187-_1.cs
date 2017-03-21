        static void CompileCode(CodeCompileUnit ccu, string sourceName)
        {
            CodeDomProvider provider = null;
            FileInfo sourceFile = new FileInfo(sourceName);
            // Select the code provider based on the input file extension, either C# or Visual Basic.
            if (sourceFile.Extension.ToUpper(CultureInfo.InvariantCulture) == ".CS")
            {
                provider = new Microsoft.CSharp.CSharpCodeProvider();
            }
            else if (sourceFile.Extension.ToUpper(CultureInfo.InvariantCulture) == ".VB")
            {
                provider = new Microsoft.VisualBasic.VBCodeProvider();
            }
            else
            {
                Console.WriteLine("Source file must have a .cs or .vb extension");
            }
            if (provider != null)
            {
                CodeGeneratorOptions options = new CodeGeneratorOptions();
                // Set code formatting options to your preference.
                options.BlankLinesBetweenMembers = true;
                options.BracingStyle = "C";

                StreamWriter sw = new StreamWriter(sourceName);
                provider.GenerateCodeFromCompileUnit(ccu, sw, options);
                sw.Close();
            }
        }