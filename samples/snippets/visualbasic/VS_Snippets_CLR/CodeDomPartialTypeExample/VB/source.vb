' The following example builds a CodeDom source graph for a simple
' class that represents document properties.  The source for the 
' graph is generated, saved to a file, compiled into an executable, 
' and run.

Imports System
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports System.Collections
Imports System.ComponentModel
Imports System.IO
Imports System.Diagnostics

Namespace CompilerParametersSamples
    Class BuildDocumentClass

        '<Snippet2>
        ' Build the source graph using System.CodeDom types.
        Public Shared Function DocumentPropertyGraphBase() As CodeCompileUnit

            ' Create a new CodeCompileUnit for the source graph.
            Dim docPropUnit As CodeCompileUnit = New CodeCompileUnit()

            ' Declare a new namespace called DocumentSamples.
            Dim sampleSpace As CodeNamespace = New CodeNamespace("DocumentSamples")

            ' Add the new namespace to the compile unit.
            docPropUnit.Namespaces.Add(sampleSpace)

            ' Add an import statement for the System namespace.
            sampleSpace.Imports.Add(New CodeNamespaceImport("System"))

            ' Declare a new class called DocumentProperties.

            ' <Snippet3>
            Dim baseClass As CodeTypeDeclaration = New CodeTypeDeclaration("DocumentProperties")
            baseClass.IsPartial = True
            baseClass.IsClass = True
            baseClass.Attributes = MemberAttributes.Public
            baseClass.BaseTypes.Add(New CodeTypeReference(GetType(System.Object)))

            ' Add the DocumentProperties class to the namespace.
            sampleSpace.Types.Add(baseClass)
            ' </Snippet3>

            ' ------Build the DocumentProperty.Main method------

            ' Declare the Main method of the class.
            Dim mainMethod As CodeEntryPointMethod = New CodeEntryPointMethod()
            mainMethod.Comments.Add(New CodeCommentStatement(" Perform a simple test of the class methods."))

            ' Add the code entry point method to the Members
            ' collection of the type.
            baseClass.Members.Add(mainMethod)

            mainMethod.Statements.Add(New CodeCommentStatement("Initialize a class instance and display it."))

            ' <Snippet4>
            ' Initialize a local DocumentProperty instance, named myDoc.
            ' Use the DocumentProperty constructor to set the author, 
            ' title, and date.  Set the publish date to DateTime.Now.

            Dim docTitlePrimitive As CodePrimitiveExpression = New CodePrimitiveExpression("Cubicle Survival Strategies")
            Dim docAuthorPrimitive As CodePrimitiveExpression = New CodePrimitiveExpression("John Smith")

            ' Store the value of DateTime.Now in a local variable, to re-use
            ' the same value later.
            Dim docDateClass As CodeTypeReferenceExpression = New CodeTypeReferenceExpression("DateTime")
            Dim docDateNow As CodePropertyReferenceExpression = New CodePropertyReferenceExpression(docDateClass, "Now")
            Dim publishNow As CodeVariableDeclarationStatement = New CodeVariableDeclarationStatement(GetType(DateTime), "publishNow", docDateNow)
            mainMethod.Statements.Add(publishNow)

            Dim publishNowRef As CodeVariableReferenceExpression = New CodeVariableReferenceExpression("publishNow")

            Dim ctorParams() As CodeExpression = {docTitlePrimitive, docAuthorPrimitive, publishNowRef}
            Dim initDocConstruct As CodeObjectCreateExpression = New CodeObjectCreateExpression("DocumentProperties", ctorParams)
            Dim myDocDeclare As CodeVariableDeclarationStatement = New CodeVariableDeclarationStatement("DocumentProperties", "myDoc", initDocConstruct)
            mainMethod.Statements.Add(myDocDeclare)

            ' </Snippet4>
            ' Create a variable reference for the myDoc instance.
            Dim myDocInstance As CodeVariableReferenceExpression = New CodeVariableReferenceExpression("myDoc")

            ' Create a type reference for the System.Console class.
            Dim csSystemConsoleType As CodeTypeReferenceExpression = New CodeTypeReferenceExpression("System.Console")

            ' Build Console.WriteLine statement.
            Dim consoleWriteLine0 As CodeMethodInvokeExpression = New CodeMethodInvokeExpression( _
                csSystemConsoleType, "WriteLine", _
                New CodePrimitiveExpression("** Document properties test **"))

            ' Add the WriteLine call to the statement collection.
            mainMethod.Statements.Add(consoleWriteLine0)

            ' Build Console.WriteLine("First document:").
            Dim consoleWriteLine1 As CodeMethodInvokeExpression = New CodeMethodInvokeExpression( _
                csSystemConsoleType, "WriteLine", _
                New CodePrimitiveExpression("First document:"))

            ' Add the WriteLine call to the statement collection.
            mainMethod.Statements.Add(consoleWriteLine1)


            ' Add a statement to display the myDoc instance properties.
            Dim myDocToString As CodeMethodInvokeExpression = New CodeMethodInvokeExpression(myDocInstance, "ToString")
            Dim consoleWriteLine2 As CodeMethodInvokeExpression = New CodeMethodInvokeExpression( _
                csSystemConsoleType, "WriteLine", myDocToString)
            mainMethod.Statements.Add(consoleWriteLine2)

            ' Add a statement to display the myDoc instance hashcode property.
            Dim myDocHashCode As CodeMethodInvokeExpression = New CodeMethodInvokeExpression(myDocInstance, "GetHashCode")
            Dim writeHashCodeParams() As CodeExpression = {New CodePrimitiveExpression("  Hash code: {0}"), myDocHashCode}
            Dim consoleWriteLine3 As CodeMethodInvokeExpression = New CodeMethodInvokeExpression( _
                csSystemConsoleType, "WriteLine", writeHashCodeParams)
            mainMethod.Statements.Add(consoleWriteLine3)

            ' Add statements to create another instance.
            mainMethod.Statements.Add(New CodeCommentStatement("Create another instance."))
            Dim myNewDocDeclare As CodeVariableDeclarationStatement = New CodeVariableDeclarationStatement("DocumentProperties", "myNewDoc", initDocConstruct)
            mainMethod.Statements.Add(myNewDocDeclare)

            ' Create a variable reference for the myNewDoc instance.
            Dim myNewDocInstance As CodeVariableReferenceExpression = New CodeVariableReferenceExpression("myNewDoc")

            ' Build Console.WriteLine("Second document:").
            Dim consoleWriteLine5 As CodeMethodInvokeExpression = New CodeMethodInvokeExpression( _
                csSystemConsoleType, "WriteLine", _
                New CodePrimitiveExpression("Second document:"))

            ' Add the WriteLine call to the statement collection.
            mainMethod.Statements.Add(consoleWriteLine5)


            ' Add a statement to display the myNewDoc instance properties.
            Dim myNewDocToString As CodeMethodInvokeExpression = New CodeMethodInvokeExpression(myNewDocInstance, "ToString")
            Dim consoleWriteLine6 As CodeMethodInvokeExpression = New CodeMethodInvokeExpression( _
                csSystemConsoleType, "WriteLine", myNewDocToString)
            mainMethod.Statements.Add(consoleWriteLine6)

            ' Add a statement to display the myNewDoc instance hashcode property.
            Dim myNewDocHashCode As CodeMethodInvokeExpression = New CodeMethodInvokeExpression(myNewDocInstance, "GetHashCode")
            Dim writeNewHashCodeParams() As CodeExpression = {New CodePrimitiveExpression("  Hash code: {0}"), myNewDocHashCode}
            Dim consoleWriteLine7 As CodeMethodInvokeExpression = New CodeMethodInvokeExpression( _
                csSystemConsoleType, "WriteLine", _
                writeNewHashCodeParams)
            mainMethod.Statements.Add(consoleWriteLine7)

            ' <Snippet5>
            ' Build a compound statement to compare the two instances.
            mainMethod.Statements.Add(New CodeCommentStatement("Compare the two instances."))

            Dim myDocEquals As CodeMethodInvokeExpression = New CodeMethodInvokeExpression(myDocInstance, "Equals", myNewDocInstance)
            Dim equalLine As CodePrimitiveExpression = New CodePrimitiveExpression("Second document is equal to the first.")
            Dim notEqualLine As CodePrimitiveExpression = New CodePrimitiveExpression("Second document is not equal to the first.")
            Dim equalWriteLine As CodeMethodInvokeExpression = New CodeMethodInvokeExpression( _
                csSystemConsoleType, "WriteLine", equalLine)
            Dim notEqualWriteLine As CodeMethodInvokeExpression = New CodeMethodInvokeExpression( _
                csSystemConsoleType, "WriteLine", notEqualLine)
            Dim equalStatements() As CodeStatement = {New CodeExpressionStatement(equalWriteLine)}
            Dim notEqualStatements() As CodeStatement = {New CodeExpressionStatement(notEqualWriteLine)}
            Dim docCompare As CodeConditionStatement = New CodeConditionStatement(myDocEquals, equalStatements, notEqualStatements)
            mainMethod.Statements.Add(docCompare)
            ' </Snippet5>


            ' <Snippet6>
            ' Add a statement to change the myDoc.Author property:
            mainMethod.Statements.Add(New CodeCommentStatement("Change the author of the original instance."))

            Dim myDocAuthor As CodePropertyReferenceExpression = New CodePropertyReferenceExpression(myDocInstance, "Author")
            Dim newDocAuthor As CodePrimitiveExpression = New CodePrimitiveExpression("Jane Doe")
            Dim myDocAuthorAssign As CodeAssignStatement = New CodeAssignStatement(myDocAuthor, newDocAuthor)
            mainMethod.Statements.Add(myDocAuthorAssign)
            ' </Snippet6>

            ' Add a statement to display the modified instance.
            Dim consoleWriteLine8 As CodeMethodInvokeExpression = New CodeMethodInvokeExpression( _
                csSystemConsoleType, "WriteLine", _
                New CodePrimitiveExpression("Modified original document:"))
            mainMethod.Statements.Add(consoleWriteLine8)

            ' Reuse the myDoc.ToString statement built earlier.
            mainMethod.Statements.Add(consoleWriteLine2)

            ' Reuse the comparison block built earlier.
            mainMethod.Statements.Add(New CodeCommentStatement("Compare the two instances again."))
            mainMethod.Statements.Add(docCompare)

            ' Add a statement to prompt the user to hit a key.
            Dim consoleWriteLine9 As CodeMethodInvokeExpression = New CodeMethodInvokeExpression( _
                csSystemConsoleType, "WriteLine", _
                New CodePrimitiveExpression("Press the Enter key to continue."))
            mainMethod.Statements.Add(consoleWriteLine9)

            ' Build a call to System.ReadLine.
            Dim consoleReadLine As CodeMethodInvokeExpression = New CodeMethodInvokeExpression( _
                csSystemConsoleType, "ReadLine")
            mainMethod.Statements.Add(consoleReadLine)


            ' Define a few common expressions for the class methods.
            Dim thisTitle As CodePropertyReferenceExpression = New CodePropertyReferenceExpression(New CodeThisReferenceExpression(), "docTitle")
            Dim thisAuthor As CodePropertyReferenceExpression = New CodePropertyReferenceExpression(New CodeThisReferenceExpression(), "docAuthor")
            Dim thisDate As CodePropertyReferenceExpression = New CodePropertyReferenceExpression(New CodeThisReferenceExpression(), "docDate")
            Dim stringType As CodeTypeReferenceExpression = New CodeTypeReferenceExpression(GetType(String))
            Dim trueConst As CodePrimitiveExpression = New CodePrimitiveExpression(True)
            Dim falseConst As CodePrimitiveExpression = New CodePrimitiveExpression(False)


            ' ------Build the DocumentProperty.Equals method------

            Dim baseEquals As CodeMemberMethod = New CodeMemberMethod()
            baseEquals.Attributes = MemberAttributes.Public Or MemberAttributes.Override Or MemberAttributes.Overloaded
            baseEquals.ReturnType = New CodeTypeReference(GetType(Boolean))
            baseEquals.Name = "Equals"
            baseEquals.Parameters.Add(New CodeParameterDeclarationExpression(GetType(Object), "obj"))

            baseEquals.Statements.Add(New CodeCommentStatement("Override System.Object.Equals method."))

            Dim objVar As CodeVariableReferenceExpression = New CodeVariableReferenceExpression("obj")
            Dim objCast As CodeCastExpression = New CodeCastExpression("DocumentProperties", objVar)

            Dim objTitle As CodePropertyReferenceExpression = New CodePropertyReferenceExpression(objCast, "Title")
            Dim objAuthor As CodePropertyReferenceExpression = New CodePropertyReferenceExpression(objCast, "Author")
            Dim objDate As CodePropertyReferenceExpression = New CodePropertyReferenceExpression(objCast, "PublishDate")

            Dim objTitleEquals As CodeMethodInvokeExpression = New CodeMethodInvokeExpression(objTitle, "Equals", thisTitle)
            Dim objAuthorEquals As CodeMethodInvokeExpression = New CodeMethodInvokeExpression(objAuthor, "Equals", thisAuthor)
            Dim objDateEquals As CodeMethodInvokeExpression = New CodeMethodInvokeExpression(objDate, "Equals", thisDate)

            Dim andEquals1 As CodeBinaryOperatorExpression = New CodeBinaryOperatorExpression(objTitleEquals, CodeBinaryOperatorType.BooleanAnd, objAuthorEquals)
            Dim andEquals2 As CodeBinaryOperatorExpression = New CodeBinaryOperatorExpression(andEquals1, CodeBinaryOperatorType.BooleanAnd, objDateEquals)

            Dim returnTrueStatements() As CodeStatement = {New CodeMethodReturnStatement(trueConst)}
            Dim returnFalseStatements() As CodeStatement = {New CodeMethodReturnStatement(falseConst)}
            Dim objEquals As CodeConditionStatement = New CodeConditionStatement(andEquals2, returnTrueStatements, returnFalseStatements)

            baseEquals.Statements.Add(objEquals)
            baseClass.Members.Add(baseEquals)


            ' ------Build the DocumentProperty.GetHashCode method------

            Dim baseHash As CodeMemberMethod = New CodeMemberMethod()
            baseHash.Attributes = MemberAttributes.Public Or MemberAttributes.Override
            baseHash.ReturnType = New CodeTypeReference(GetType(Integer))
            baseHash.Name = "GetHashCode"

            baseHash.Statements.Add(New CodeCommentStatement("Override System.Object.GetHashCode method."))

            Dim hashTitle As CodeMethodInvokeExpression = New CodeMethodInvokeExpression(thisTitle, "GetHashCode")
            Dim hashAuthor As CodeMethodInvokeExpression = New CodeMethodInvokeExpression(thisAuthor, "GetHashCode")
            Dim hashDate As CodeMethodInvokeExpression = New CodeMethodInvokeExpression(thisDate, "GetHashCode")

            Dim orHash1 As CodeBinaryOperatorExpression = New CodeBinaryOperatorExpression(hashTitle, CodeBinaryOperatorType.BitwiseOr, hashAuthor)
            Dim andHash As CodeBinaryOperatorExpression = New CodeBinaryOperatorExpression(orHash1, CodeBinaryOperatorType.BitwiseAnd, hashDate)
            baseHash.Statements.Add(New CodeMethodReturnStatement(andHash))
            baseClass.Members.Add(baseHash)


            ' ------Build the DocumentProperty.ToString method------

            Dim docToString As CodeMemberMethod = New CodeMemberMethod()
            docToString.Attributes = MemberAttributes.Public Or MemberAttributes.Override
            docToString.ReturnType = New CodeTypeReference(GetType(String))
            docToString.Name = "ToString"

            docToString.Statements.Add(New CodeCommentStatement("Override System.Object.ToString method."))

            Dim baseToString As CodeMethodInvokeExpression = New CodeMethodInvokeExpression(New CodeBaseReferenceExpression(), "ToString")
            Dim formatString As CodePrimitiveExpression = New CodePrimitiveExpression("{0} ({1} by {2}, {3})")
            Dim formatParams() As CodeExpression = {formatString, baseToString, thisTitle, thisAuthor, thisDate}

            Dim stringFormat As CodeMethodInvokeExpression = New CodeMethodInvokeExpression(stringType, "Format", formatParams)

            docToString.Statements.Add(New CodeMethodReturnStatement(stringFormat))
            baseClass.Members.Add(docToString)

            Return docPropUnit

        End Function
        '</Snippet2>

        Public Shared Sub DocumentPropertyGraphExpand(ByRef docPropUnit As CodeCompileUnit)
            ' Expand on the DocumentProperties class,
            ' adding the constructor and property implementation.

            ' <Snippet7>
            Dim baseClass As CodeTypeDeclaration = New CodeTypeDeclaration("DocumentProperties")
            baseClass.IsPartial = True
            baseClass.IsClass = True
            baseClass.Attributes = MemberAttributes.Public

            ' Extend the DocumentProperties class in the unit namespace.
            docPropUnit.Namespaces(0).Types.Add(baseClass)
            ' </Snippet7>

            ' ------Declare the internal class fields------

            baseClass.Members.Add(New CodeMemberField("String", "docTitle"))
            baseClass.Members.Add(New CodeMemberField("String", "docAuthor"))
            baseClass.Members.Add(New CodeMemberField("DateTime", "docDate"))

            ' ------Build the DocumentProperty constructor------

            Dim docPropCtor As CodeConstructor = New CodeConstructor()
            docPropCtor.Attributes = MemberAttributes.Public
            docPropCtor.Parameters.Add(New CodeParameterDeclarationExpression("String", "title"))
            docPropCtor.Parameters.Add(New CodeParameterDeclarationExpression("String", "author"))
            docPropCtor.Parameters.Add(New CodeParameterDeclarationExpression("DateTime", "publishDate"))

            Dim myTitle As CodeFieldReferenceExpression = New CodeFieldReferenceExpression(New CodeThisReferenceExpression(), "docTitle")
            Dim inTitle As CodeVariableReferenceExpression = New CodeVariableReferenceExpression("title")
            Dim myDocTitleAssign As CodeAssignStatement = New CodeAssignStatement(myTitle, inTitle)
            docPropCtor.Statements.Add(myDocTitleAssign)

            Dim myAuthor As CodeFieldReferenceExpression = New CodeFieldReferenceExpression(New CodeThisReferenceExpression(), "docAuthor")
            Dim inAuthor As CodeVariableReferenceExpression = New CodeVariableReferenceExpression("author")
            Dim myDocAuthorAssign As CodeAssignStatement = New CodeAssignStatement(myAuthor, inAuthor)
            docPropCtor.Statements.Add(myDocAuthorAssign)

            Dim myDate As CodeFieldReferenceExpression = New CodeFieldReferenceExpression(New CodeThisReferenceExpression(), "docDate")
            Dim inDate As CodeVariableReferenceExpression = New CodeVariableReferenceExpression("publishDate")
            Dim myDocDateAssign As CodeAssignStatement = New CodeAssignStatement(myDate, inDate)
            docPropCtor.Statements.Add(myDocDateAssign)

            baseClass.Members.Add(docPropCtor)

            ' ------Build the DocumentProperty properties------

            Dim docTitleProp As CodeMemberProperty = New CodeMemberProperty()
            docTitleProp.HasGet = True
            docTitleProp.HasSet = True
            docTitleProp.Name = "Title"
            docTitleProp.Type = New CodeTypeReference("String")
            docTitleProp.Attributes = MemberAttributes.Public
            docTitleProp.GetStatements.Add(New CodeMethodReturnStatement(New CodeFieldReferenceExpression(New CodeThisReferenceExpression(), "docTitle")))
            docTitleProp.SetStatements.Add(New CodeAssignStatement(New CodeFieldReferenceExpression(New CodeThisReferenceExpression(), "docTitle"), New CodePropertySetValueReferenceExpression()))

            baseClass.Members.Add(docTitleProp)

            Dim docAuthorProp As CodeMemberProperty = New CodeMemberProperty()
            docAuthorProp.HasGet = True
            docAuthorProp.HasSet = True
            docAuthorProp.Name = "Author"
            docAuthorProp.Type = New CodeTypeReference("String")
            docAuthorProp.Attributes = MemberAttributes.Public
            docAuthorProp.GetStatements.Add(New CodeMethodReturnStatement(New CodeFieldReferenceExpression(New CodeThisReferenceExpression(), "docAuthor")))
            docAuthorProp.SetStatements.Add(New CodeAssignStatement(New CodeFieldReferenceExpression(New CodeThisReferenceExpression(), "docAuthor"), New CodePropertySetValueReferenceExpression()))

            baseClass.Members.Add(docAuthorProp)

            Dim docDateProp As CodeMemberProperty = New CodeMemberProperty()
            docDateProp.HasGet = True
            docDateProp.HasSet = True
            docDateProp.Name = "PublishDate"
            docDateProp.Type = New CodeTypeReference("DateTime")
            docDateProp.Attributes = MemberAttributes.Public
            docDateProp.GetStatements.Add(New CodeMethodReturnStatement(New CodeFieldReferenceExpression(New CodeThisReferenceExpression(), "docDate")))
            docDateProp.SetStatements.Add(New CodeAssignStatement(New CodeFieldReferenceExpression(New CodeThisReferenceExpression(), "docDate"), New CodePropertySetValueReferenceExpression()))

            baseClass.Members.Add(docDateProp)
        End Sub


        Public Shared Function GenerateCode(ByVal provider As CodeDomProvider, _
        ByVal compileunit As CodeCompileUnit) As String

            ' Build the source file name with the language extension (vb, cs, js).
            Dim sourceFile As String = ""

            ' Write the source out in the selected language if
            ' the code generator supports partial type declarations.
            If provider.Supports(GeneratorSupport.PartialTypes) Then

                If provider.FileExtension.StartsWith(".") Then
                    sourceFile = "DocProp" + provider.FileExtension
                Else
                    sourceFile = "DocProp." + provider.FileExtension
                End If

                ' Create a TextWriter to a StreamWriter to an output file.
                Dim tw As New IndentedTextWriter(New StreamWriter(sourceFile, False), "    ")

                ' Generate source code using the code generator.
                provider.GenerateCodeFromCompileUnit(compileunit, tw, _
                    New CodeGeneratorOptions())

                ' Close the output file.
                tw.Close()
            End If

            Return sourceFile
        End Function 'GenerateCode


        '<Snippet1>
        Public Shared Function CompileCode(ByVal provider As CodeDomProvider, _
        ByVal sourceFile As String, ByVal exeFile As String) As Boolean

            Dim cp As New CompilerParameters()

            ' Generate an executable instead of 
            ' a class library.
            cp.GenerateExecutable = True

            ' Set the assembly file name to generate.
            cp.OutputAssembly = exeFile

            ' Generate debug information.
            cp.IncludeDebugInformation = True

            ' Add an assembly reference.
            cp.ReferencedAssemblies.Add("System.dll")

            ' Save the assembly as a physical file.
            cp.GenerateInMemory = False

            ' Set the warning level at which 
            ' the compiler should abort compilation
            ' if a warning of this level occurs.
            cp.WarningLevel = 3

            ' Set whether to treat all warnings as errors.
            cp.TreatWarningsAsErrors = False

            If provider.Supports(GeneratorSupport.EntryPointMethod) Then
                ' Specify the class that contains 
                ' the main method of the executable.
                cp.MainClass = "DocumentSamples.DocumentProperties"
            End If

            ' Invoke compilation.
            Dim cr As CompilerResults = _
                provider.CompileAssemblyFromFile(cp, sourceFile)

            If cr.Errors.Count > 0 Then
                ' Display compilation errors.
                Console.WriteLine("Errors building {0} into {1}", _
                    sourceFile, cr.PathToAssembly)
                Dim ce As CompilerError
                For Each ce In cr.Errors
                    Console.WriteLine("  {0}", ce.ToString())
                    Console.WriteLine()
                Next ce
            Else
                Console.WriteLine("Source {0} built into {1} successfully.", _
                    sourceFile, cr.PathToAssembly)
            End If

            ' Return the results of compilation.
            If cr.Errors.Count > 0 Then
                Return False
            Else
                Return True
            End If
        End Function 'CompileCode
        '</Snippet1>

        <STAThread()> _
        Shared Sub Main()
            Dim exeName As String = "DocProp.exe"
            Dim provider As CodeDomProvider = Nothing

            Console.WriteLine("Enter the source language for DocumentProperties class (cs, vb, etc):")
            Dim inputLang As String = Console.ReadLine()
            Console.WriteLine()

            If CodeDomProvider.IsDefinedLanguage(inputLang) Then
                Dim docPropertyUnit As CodeCompileUnit = DocumentPropertyGraphBase()
                DocumentPropertyGraphExpand(docPropertyUnit)

                provider = CodeDomProvider.CreateProvider(inputLang)

                Dim sourceFile As String
                sourceFile = GenerateCode(provider, docPropertyUnit)

                If Not String.IsNullOrEmpty(sourceFile) Then

                    Console.WriteLine("Document property class source code generated.")

                    If CompileCode(provider, sourceFile, exeName) Then
                        Console.WriteLine("Starting DocProp executable.")
                        Process.Start(exeName)
                    End If
                Else
                    Console.WriteLine("Could not generate source file.")
                    Console.WriteLine("Target language code generator might not support partial type declarations.")
                End If
            End If

            If provider Is Nothing Then
                Console.WriteLine("There is no CodeDomProvider for the input language.")
            End If
        End Sub 'Main 


    End Class
End Namespace


