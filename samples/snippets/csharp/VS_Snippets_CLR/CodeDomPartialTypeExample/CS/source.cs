// The following example builds a CodeDom source graph for a simple
// class that represents document properties.  The source for the 
// graph is generated, saved to a file, compiled into an executable, 
// and run.

using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;

namespace CompilerParametersSamples
{
    class BuildDocumentClass
    {
        //<Snippet2>
        // Build the source graph using System.CodeDom types.
        public static CodeCompileUnit DocumentPropertyGraphBase()
        {
            // Create a new CodeCompileUnit for the source graph.
            CodeCompileUnit docPropUnit = new CodeCompileUnit();

            // Declare a new namespace called DocumentSamples.
            CodeNamespace sampleSpace = new CodeNamespace("DocumentSamples");
            // Add the new namespace to the compile unit.
            docPropUnit.Namespaces.Add(sampleSpace);

            // Add an import statement for the System namespace.
            sampleSpace.Imports.Add(new CodeNamespaceImport("System"));

            // Declare a new class called DocumentProperties.

            // <Snippet3>
            CodeTypeDeclaration baseClass = new CodeTypeDeclaration("DocumentProperties");
            baseClass.IsPartial = true;
            baseClass.IsClass = true;
            baseClass.Attributes = MemberAttributes.Public;
            baseClass.BaseTypes.Add(new CodeTypeReference(typeof(System.Object
)));

            // Add the DocumentProperties class to the namespace.
            sampleSpace.Types.Add(baseClass);
            // </Snippet3>

            // ------Build the DocumentProperty.Main method------

            // Declare the Main method of the class.
            CodeEntryPointMethod mainMethod = new CodeEntryPointMethod();
            mainMethod.Comments.Add(new CodeCommentStatement(
                " Perform a simple test of the class methods."));

            // Add the code entry point method to the Members
            // collection of the type.
            baseClass.Members.Add(mainMethod);

            mainMethod.Statements.Add(new CodeCommentStatement(
                "Initialize a class instance and display it."));

            // <Snippet4>
            // Initialize a local DocumentProperty instance, named myDoc.
            // Use the DocumentProperty constructor to set the author, 
            // title, and date.  Set the publish date to DateTime.Now.

            CodePrimitiveExpression docTitlePrimitive = new 
CodePrimitiveExpression("Cubicle Survival Strategies");
            CodePrimitiveExpression docAuthorPrimitive = new 
CodePrimitiveExpression("John Smith");

            // Store the value of DateTime.Now in a local variable, to re-use
            // the same value later.
            CodeTypeReferenceExpression docDateClass = new 
CodeTypeReferenceExpression("DateTime");
            CodePropertyReferenceExpression docDateNow = new 
CodePropertyReferenceExpression(docDateClass, "Now");
            CodeVariableDeclarationStatement publishNow = new 
CodeVariableDeclarationStatement(typeof(DateTime), "publishNow", docDateNow);
            mainMethod.Statements.Add(publishNow);

            CodeVariableReferenceExpression publishNowRef = new 
CodeVariableReferenceExpression("publishNow");

            CodeExpression[] ctorParams = { docTitlePrimitive, 
docAuthorPrimitive, publishNowRef };
            CodeObjectCreateExpression initDocConstruct = new 
CodeObjectCreateExpression("DocumentProperties", ctorParams);
            CodeVariableDeclarationStatement myDocDeclare = new 
CodeVariableDeclarationStatement("DocumentProperties", "myDoc", 
initDocConstruct);
            mainMethod.Statements.Add(myDocDeclare);
            // </Snippet4>

            // Create a variable reference for the myDoc instance.
            CodeVariableReferenceExpression myDocInstance = new 
CodeVariableReferenceExpression("myDoc");

            // Create a type reference for the System.Console class.
            CodeTypeReferenceExpression csSystemConsoleType = new 
CodeTypeReferenceExpression("System.Console");

            // Build Console.WriteLine statement.
            CodeMethodInvokeExpression consoleWriteLine0 = new 
CodeMethodInvokeExpression(
                csSystemConsoleType, "WriteLine",
                new CodePrimitiveExpression("** Document properties test **"));

            // Add the WriteLine call to the statement collection.
            mainMethod.Statements.Add(consoleWriteLine0);

            // Build Console.WriteLine("First document:").
            CodeMethodInvokeExpression consoleWriteLine1 = new 
CodeMethodInvokeExpression(
                csSystemConsoleType, "WriteLine",
                new CodePrimitiveExpression("First document:"));

            // Add the WriteLine call to the statement collection.
            mainMethod.Statements.Add(consoleWriteLine1);


            // Add a statement to display the myDoc instance properties.
            CodeMethodInvokeExpression myDocToString = new 
CodeMethodInvokeExpression(myDocInstance, "ToString");
            CodeMethodInvokeExpression consoleWriteLine2 = new 
CodeMethodInvokeExpression(
                csSystemConsoleType, "WriteLine", myDocToString);
            mainMethod.Statements.Add(consoleWriteLine2);

            // Add a statement to display the myDoc instance hashcode property.
            CodeMethodInvokeExpression myDocHashCode = new 
CodeMethodInvokeExpression(myDocInstance, "GetHashCode");
            CodeExpression[] writeHashCodeParams = { new 
CodePrimitiveExpression("  Hash code: {0}"), myDocHashCode };
            CodeMethodInvokeExpression consoleWriteLine3 = new 
CodeMethodInvokeExpression(
                csSystemConsoleType, "WriteLine",
                writeHashCodeParams);
            mainMethod.Statements.Add(consoleWriteLine3);

            // Add statements to create another instance.
            mainMethod.Statements.Add(new CodeCommentStatement("Create another instance."));
            CodeVariableDeclarationStatement myNewDocDeclare = new 
CodeVariableDeclarationStatement("DocumentProperties", "myNewDoc", 
initDocConstruct);
            mainMethod.Statements.Add(myNewDocDeclare);

            // Create a variable reference for the myNewDoc instance.
            CodeVariableReferenceExpression myNewDocInstance = new 
CodeVariableReferenceExpression("myNewDoc");

            // Build Console.WriteLine("Second document:").
            CodeMethodInvokeExpression consoleWriteLine5 = new 
CodeMethodInvokeExpression(
                csSystemConsoleType, "WriteLine",
                new CodePrimitiveExpression("Second document:"));

            // Add the WriteLine call to the statement collection.
            mainMethod.Statements.Add(consoleWriteLine5);


            // Add a statement to display the myNewDoc instance properties.
            CodeMethodInvokeExpression myNewDocToString = new 
CodeMethodInvokeExpression(myNewDocInstance, "ToString");
            CodeMethodInvokeExpression consoleWriteLine6 = new 
CodeMethodInvokeExpression(
                csSystemConsoleType, "WriteLine", myNewDocToString);
            mainMethod.Statements.Add(consoleWriteLine6);

            // Add a statement to display the myNewDoc instance hashcode property.
            CodeMethodInvokeExpression myNewDocHashCode = new 
CodeMethodInvokeExpression(myNewDocInstance, "GetHashCode");
            CodeExpression[] writeNewHashCodeParams = { new 
CodePrimitiveExpression("  Hash code: {0}"), myNewDocHashCode };
            CodeMethodInvokeExpression consoleWriteLine7 = new 
CodeMethodInvokeExpression(
                csSystemConsoleType, "WriteLine",
                writeNewHashCodeParams);
            mainMethod.Statements.Add(consoleWriteLine7);

            // <Snippet5>
            // Build a compound statement to compare the two instances.
            mainMethod.Statements.Add(new CodeCommentStatement("Compare the two instances."));

            CodeMethodInvokeExpression myDocEquals = new 
CodeMethodInvokeExpression(myDocInstance, "Equals", myNewDocInstance);
            CodePrimitiveExpression equalLine = new CodePrimitiveExpression(
                "Second document is equal to the first.");
            CodePrimitiveExpression notEqualLine = new CodePrimitiveExpression
("Second document is not equal to the first.");
            CodeMethodInvokeExpression equalWriteLine = new 
CodeMethodInvokeExpression(
                csSystemConsoleType, "WriteLine",
                equalLine);
            CodeMethodInvokeExpression notEqualWriteLine = new 
CodeMethodInvokeExpression(
                csSystemConsoleType, "WriteLine",
                notEqualLine);
            CodeStatement[] equalStatements = { new CodeExpressionStatement(
equalWriteLine) };
            CodeStatement[] notEqualStatements = { new CodeExpressionStatement
(notEqualWriteLine) };
            CodeConditionStatement docCompare = new CodeConditionStatement(
myDocEquals, equalStatements, notEqualStatements);
            mainMethod.Statements.Add(docCompare);
            // </Snippet5>


            // <Snippet6>
            // Add a statement to change the myDoc.Author property:
            mainMethod.Statements.Add(new CodeCommentStatement(
                "Change the author of the original instance."));

            CodePropertyReferenceExpression myDocAuthor = new 
CodePropertyReferenceExpression(myDocInstance, "Author");
            CodePrimitiveExpression newDocAuthor = new CodePrimitiveExpression
("Jane Doe");
            CodeAssignStatement myDocAuthorAssign = new CodeAssignStatement(
myDocAuthor, newDocAuthor);
            mainMethod.Statements.Add(myDocAuthorAssign);
            // </Snippet6>

            // Add a statement to display the modified instance.
            CodeMethodInvokeExpression consoleWriteLine8 = new 
CodeMethodInvokeExpression(
                csSystemConsoleType, "WriteLine",
                new CodePrimitiveExpression("Modified original document:"));
            mainMethod.Statements.Add(consoleWriteLine8);

            // Reuse the myDoc.ToString statement built earlier.
            mainMethod.Statements.Add(consoleWriteLine2);

            // Reuse the comparison block built earlier.
            mainMethod.Statements.Add(new CodeCommentStatement(
                "Compare the two instances again."));
            mainMethod.Statements.Add(docCompare);

            // Add a statement to prompt the user to hit a key.
            CodeMethodInvokeExpression consoleWriteLine9 = new 
CodeMethodInvokeExpression(
                // Build another call to System.WriteLine.
                csSystemConsoleType, "WriteLine",
                // Add string parameter to the WriteLine method.
                new CodePrimitiveExpression("Press the Enter key to continue."
));
            mainMethod.Statements.Add(consoleWriteLine9);

            // Build a call to System.ReadLine.
            CodeMethodInvokeExpression consoleReadLine = new 
CodeMethodInvokeExpression(
                csSystemConsoleType, "ReadLine");
            mainMethod.Statements.Add(consoleReadLine);


            // Define a few common expressions for the class methods.
            CodePropertyReferenceExpression thisTitle = new 
CodePropertyReferenceExpression(new CodeThisReferenceExpression(), "docTitle");
            CodePropertyReferenceExpression thisAuthor = new 
CodePropertyReferenceExpression(new CodeThisReferenceExpression(), "docAuthor"
);
            CodePropertyReferenceExpression thisDate = new 
CodePropertyReferenceExpression(new CodeThisReferenceExpression(), "docDate");
            CodeTypeReferenceExpression stringType = new 
CodeTypeReferenceExpression(typeof(String));
            CodePrimitiveExpression trueConst = new CodePrimitiveExpression(
true);
            CodePrimitiveExpression falseConst = new CodePrimitiveExpression(
false);


            // ------Build the DocumentProperty.Equals method------

            CodeMemberMethod baseEquals = new CodeMemberMethod();
            baseEquals.Attributes = MemberAttributes.Public | MemberAttributes
.Override | MemberAttributes.Overloaded;
            baseEquals.ReturnType = new CodeTypeReference(typeof(bool));
            baseEquals.Name = "Equals";
            baseEquals.Parameters.Add(new CodeParameterDeclarationExpression(
typeof(object), "obj"));

            baseEquals.Statements.Add(new CodeCommentStatement(
                "Override System.Object.Equals method."));

            CodeVariableReferenceExpression objVar = new 
CodeVariableReferenceExpression("obj");
            CodeCastExpression objCast = new CodeCastExpression("DocumentProperties", objVar);

            CodePropertyReferenceExpression objTitle = new 
CodePropertyReferenceExpression(objCast, "Title");
            CodePropertyReferenceExpression objAuthor = new 
CodePropertyReferenceExpression(objCast, "Author");
            CodePropertyReferenceExpression objDate = new 
CodePropertyReferenceExpression(objCast, "PublishDate");

            CodeMethodInvokeExpression objTitleEquals = new 
CodeMethodInvokeExpression(objTitle, "Equals", thisTitle);
            CodeMethodInvokeExpression objAuthorEquals = new 
CodeMethodInvokeExpression(objAuthor, "Equals", thisAuthor);
            CodeMethodInvokeExpression objDateEquals = new 
CodeMethodInvokeExpression(objDate, "Equals", thisDate);

            CodeBinaryOperatorExpression andEquals1 = new 
CodeBinaryOperatorExpression(objTitleEquals, CodeBinaryOperatorType.BooleanAnd
, objAuthorEquals);
            CodeBinaryOperatorExpression andEquals2 = new 
CodeBinaryOperatorExpression(andEquals1, CodeBinaryOperatorType.BooleanAnd, 
objDateEquals);

            CodeStatement[] returnTrueStatements = { new 
CodeMethodReturnStatement(trueConst) };
            CodeStatement[] returnFalseStatements = { new 
CodeMethodReturnStatement(falseConst) };
            CodeConditionStatement objEquals = new CodeConditionStatement(
andEquals2, returnTrueStatements, returnFalseStatements);

            baseEquals.Statements.Add(objEquals);
            baseClass.Members.Add(baseEquals);


            // ------Build the DocumentProperty.GetHashCode method------

            CodeMemberMethod baseHash = new CodeMemberMethod();
            baseHash.Attributes = MemberAttributes.Public | MemberAttributes.
Override;
            baseHash.ReturnType = new CodeTypeReference(typeof(int));
            baseHash.Name = "GetHashCode";

            baseHash.Statements.Add(new CodeCommentStatement("Override System.Object.GetHashCode method."));

            CodeMethodInvokeExpression hashTitle = new 
CodeMethodInvokeExpression(thisTitle, "GetHashCode");
            CodeMethodInvokeExpression hashAuthor = new 
CodeMethodInvokeExpression(thisAuthor, "GetHashCode");
            CodeMethodInvokeExpression hashDate = new 
CodeMethodInvokeExpression(thisDate, "GetHashCode");

            CodeBinaryOperatorExpression orHash1 = new 
CodeBinaryOperatorExpression(hashTitle, CodeBinaryOperatorType.BitwiseOr, 
hashAuthor);
            CodeBinaryOperatorExpression andHash = new 
CodeBinaryOperatorExpression(orHash1, CodeBinaryOperatorType.BitwiseAnd, 
hashDate);
            baseHash.Statements.Add(new CodeMethodReturnStatement(andHash));
            baseClass.Members.Add(baseHash);


            // ------Build the DocumentProperty.ToString method------

            CodeMemberMethod docToString = new CodeMemberMethod();
            docToString.Attributes = MemberAttributes.Public | 
MemberAttributes.Override;
            docToString.ReturnType = new CodeTypeReference(typeof(string));
            docToString.Name = "ToString";

            docToString.Statements.Add(new CodeCommentStatement("Override System.Object.ToString method."));

            CodeMethodInvokeExpression baseToString = new 
CodeMethodInvokeExpression(new CodeBaseReferenceExpression(), "ToString");
            CodePrimitiveExpression formatString = new CodePrimitiveExpression
("{0} ({1} by {2}, {3})");
            CodeExpression[] formatParams = { formatString, baseToString, 
thisTitle, thisAuthor, thisDate };

            CodeMethodInvokeExpression stringFormat = new 
CodeMethodInvokeExpression(stringType, "Format", formatParams);

            docToString.Statements.Add(new CodeMethodReturnStatement(stringFormat));
            baseClass.Members.Add(docToString);

            return docPropUnit;
        }
        //</Snippet2>

        public static void DocumentPropertyGraphExpand(ref CodeCompileUnit 
docPropUnit)
        {
            // Expand on the DocumentProperties class,
            // adding the constructor and property implementation.

            // <Snippet7>
            CodeTypeDeclaration baseClass = new CodeTypeDeclaration("DocumentProperties");
            baseClass.IsPartial = true;
            baseClass.IsClass = true;
            baseClass.Attributes = MemberAttributes.Public;

            // Extend the DocumentProperties class in the unit namespace.
            docPropUnit.Namespaces[0].Types.Add(baseClass);
            // </Snippet7>

            // ------Declare the internal class fields------

            baseClass.Members.Add(new CodeMemberField("String", "docTitle"));
            baseClass.Members.Add(new CodeMemberField("String", "docAuthor"));
            baseClass.Members.Add(new CodeMemberField("DateTime", "docDate"));

            // ------Build the DocumentProperty constructor------

            CodeConstructor docPropCtor = new CodeConstructor();
            docPropCtor.Attributes = MemberAttributes.Public;
            docPropCtor.Parameters.Add(new CodeParameterDeclarationExpression(
"String", "title"));
            docPropCtor.Parameters.Add(new CodeParameterDeclarationExpression(
"String", "author"));
            docPropCtor.Parameters.Add(new CodeParameterDeclarationExpression(
"DateTime", "publishDate"));

            CodeFieldReferenceExpression myTitle = new 
CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "docTitle");
            CodeVariableReferenceExpression inTitle = new 
CodeVariableReferenceExpression("title");
            CodeAssignStatement myDocTitleAssign = new CodeAssignStatement(
myTitle, inTitle);
            docPropCtor.Statements.Add(myDocTitleAssign);

            CodeFieldReferenceExpression myAuthor = new 
CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "docAuthor");
            CodeVariableReferenceExpression inAuthor = new 
CodeVariableReferenceExpression("author");
            CodeAssignStatement myDocAuthorAssign = new CodeAssignStatement(
myAuthor, inAuthor);
            docPropCtor.Statements.Add(myDocAuthorAssign);

            CodeFieldReferenceExpression myDate = new 
CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "docDate");
            CodeVariableReferenceExpression inDate = new 
CodeVariableReferenceExpression("publishDate");
            CodeAssignStatement myDocDateAssign = new CodeAssignStatement(
myDate, inDate);
            docPropCtor.Statements.Add(myDocDateAssign);

            baseClass.Members.Add(docPropCtor);

            // ------Build the DocumentProperty properties------

            CodeMemberProperty docTitleProp = new CodeMemberProperty();
            docTitleProp.HasGet = true;
            docTitleProp.HasSet = true;
            docTitleProp.Name = "Title";
            docTitleProp.Type = new CodeTypeReference("String");
            docTitleProp.Attributes = MemberAttributes.Public;
            docTitleProp.GetStatements.Add(new CodeMethodReturnStatement(new 
CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "docTitle")));
            docTitleProp.SetStatements.Add(new CodeAssignStatement(new 
CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "docTitle"), 
new CodePropertySetValueReferenceExpression()));

            baseClass.Members.Add(docTitleProp);

            CodeMemberProperty docAuthorProp = new CodeMemberProperty();
            docAuthorProp.HasGet = true;
            docAuthorProp.HasSet = true;
            docAuthorProp.Name = "Author";
            docAuthorProp.Type = new CodeTypeReference("String");
            docAuthorProp.Attributes = MemberAttributes.Public;
            docAuthorProp.GetStatements.Add(new CodeMethodReturnStatement(new 
CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "docAuthor")));
            docAuthorProp.SetStatements.Add(new CodeAssignStatement(new 
CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "docAuthor"), 
new CodePropertySetValueReferenceExpression()));

            baseClass.Members.Add(docAuthorProp);

            CodeMemberProperty docDateProp = new CodeMemberProperty();
            docDateProp.HasGet = true;
            docDateProp.HasSet = true;
            docDateProp.Name = "PublishDate";
            docDateProp.Type = new CodeTypeReference("DateTime");
            docDateProp.Attributes = MemberAttributes.Public;
            docDateProp.GetStatements.Add(new CodeMethodReturnStatement(new 
CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "docDate")));
            docDateProp.SetStatements.Add(new CodeAssignStatement(new 
CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "docDate"), 
new CodePropertySetValueReferenceExpression()));

            baseClass.Members.Add(docDateProp);

        }

        public static String GenerateCode(CodeDomProvider provider,
                                          CodeCompileUnit compileUnit)
        {
            // Build the source file name with the language
            // extension (vb, cs, js).
            String sourceFile = "";

            // Write the source out in the selected language if
            // the code generator supports partial type declarations.
            if (provider.Supports(GeneratorSupport.PartialTypes))
            {
                if (provider.FileExtension[0] == '.')
                {
                    sourceFile = "DocProp" + provider.FileExtension;
                }
                else
                {
                    sourceFile = "DocProp." + provider.FileExtension;
                }

                // Create a TextWriter to a StreamWriter to an output file.
                IndentedTextWriter outWriter = new IndentedTextWriter(new 
StreamWriter(sourceFile, false), "    ");
                // Generate source code using the code generator.
                provider.GenerateCodeFromCompileUnit(compileUnit, outWriter, 
null);
                // Close the output file.
                outWriter.Close();
            }

            return sourceFile;
        }

        //<Snippet1>
        public static bool CompileCode(CodeDomProvider provider,
            String sourceFile,
            String exeFile)
        {

            CompilerParameters cp = new CompilerParameters();

            // Generate an executable instead of 
            // a class library.
            cp.GenerateExecutable = true;

            // Set the assembly file name to generate.
            cp.OutputAssembly = exeFile;

            // Save the assembly as a physical file.
            cp.GenerateInMemory = false;

            // Generate debug information.
            cp.IncludeDebugInformation = true;

            // Add an assembly reference.
            cp.ReferencedAssemblies.Add("System.dll");

            // Set the warning level at which 
            // the compiler should abort compilation
            // if a warning of this level occurs.
            cp.WarningLevel = 3;

            // Set whether to treat all warnings as errors.
            cp.TreatWarningsAsErrors = false;

            if (provider.Supports(GeneratorSupport.EntryPointMethod))
            {
                // Specify the class that contains 
                // the main method of the executable.
                cp.MainClass = "DocumentSamples.DocumentProperties";
            }

            // Invoke compilation.
            CompilerResults cr = provider.CompileAssemblyFromFile(cp, 
sourceFile);

            if (cr.Errors.Count > 0)
            {
                // Display compilation errors.
                Console.WriteLine("Errors building {0} into {1}",
                    sourceFile, cr.PathToAssembly);
                foreach (CompilerError ce in cr.Errors)
                {
                    Console.WriteLine("  {0}", ce.ToString());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Source {0} built into {1} successfully.",
                    sourceFile, cr.PathToAssembly);
            }

            // Return the results of compilation.
            if (cr.Errors.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //</Snippet1>

        [STAThread]
        static void Main()
        {
            CodeDomProvider provider = null;
            String exeName = "DocProp.exe";

            Console.WriteLine("Enter the source language for DocumentProperties class (cs, vb, etc):");
            String inputLang = Console.ReadLine();
            Console.WriteLine();

            if (CodeDomProvider.IsDefinedLanguage(inputLang))
            {
                provider = CodeDomProvider.CreateProvider(inputLang);
            }

            if (provider == null)
            {
                Console.WriteLine("There is no CodeDomProvider for the input language.");
            }
            else
            {
                CodeCompileUnit docPropertyUnit = DocumentPropertyGraphBase();

                DocumentPropertyGraphExpand(ref docPropertyUnit);

                String sourceFile = GenerateCode(provider, docPropertyUnit);

                if (!String.IsNullOrEmpty(sourceFile))
                {
                    Console.WriteLine("Document property class code generated.");

                    if (CompileCode(provider, sourceFile, exeName))
                    {
                        Console.WriteLine("Starting DocProp executable.");
                        Process.Start(exeName);
                    }
                }
                else
                {
                    Console.WriteLine("Could not generate source file.");
                    Console.WriteLine(
    "Target language code generator might not support partial type declarations.");
                }
            }
        }
    }
}

