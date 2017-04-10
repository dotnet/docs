' <Snippet1>

Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Text
Imports System.AddIn.Hosting
Imports CalcHVAs

Namespace MathHost
    Class Program

        Public Shared Sub Main()

' <Snippet2>
' Get the path for the pipeline root.  
' Assumes that the current directory is the
' pipline directory structure root directory.
Dim pipeRoot As String = Environment.CurrentDirectory
' <Snippet3>
' Update the cache files of the
' pipeline segments and add-ins.
Dim warnings() As String = AddInStore.Update(pipeRoot)
For Each warning As String In warnings
    Console.WriteLine(warning)
Next

' </Snippet3>
' <Snippet4>
' Search for add-ins of type Calculator (the host view of the add-in)
' specifying the host's application base, instead of a path,
' for the FindAddIns method.
Dim tokens As Collection(Of AddInToken) = _
    AddInStore.FindAddIns(GetType(Calculator), PipelineStoreLocation.ApplicationBase)
' </Snippet4>
' </Snippet2>

' <Snippet5>
'Ask the user which add-in they would like to use.
Dim selectedToken As AddInToken = ChooseAddIn(tokens)
'Activate the selected AddInToken in a new
'application domain with the Internet trust level.
Dim CalcAddIn As Calculator = selectedToken.Activate(Of Calculator)(AddInSecurityLevel.Internet)
'Run the add-in using a custom method.
RunCalculator(CalcAddIn)
' </Snippet5>

' <Snippet6>
' Find a specific add-in.
' Construct the path to the add-in.
Dim addInFilePath As String = (pipeRoot + "\AddIns\P3AddIn2\P3AddIn2.dll")
' The fourth parameter, addinTypeName, takes the full name 
' of the type qualified by its namespace. Same as AddInToken.AddInFullName.
Dim tokenColl As System.Collections.ObjectModel.Collection(Of AddInToken) = AddInStore.FindAddIn(GetType(Calculator), pipeRoot, addInFilePath, "CalcAddIns.P3AddIn2")
Console.WriteLine("Found {0}", tokenColl(0).Name)
' </Snippet6>

' <Snippet8>
' Get the AddInController of a 
' currently activated add-in (CalcAddIn).
Dim aiController As AddInController = AddInController.GetAddInController(CalcAddIn)

' Select another token.
Dim selectedToken2 As AddInToken = ChooseAddIn(tokens)

' Activate a second add-in, CalcAddIn2, in the same
' appliation domain and process as the first add-in by passing
' the first add-in's AddInEnvironment object to the Activate method.

Dim aiEnvironment As AddInEnvironment = aiController.AddInEnvironment
Dim CalcAddIn2 As Calculator = _
    selectedToken2.Activate(Of Calculator)(aiEnvironment)

' Get the AddInController for the second add-in to compare environments.
Dim aiController2 As AddInController = AddInController.GetAddInController(CalcAddIn2)

Console.WriteLine("Add-ins in same application domain: {0}", _
    aiController.AppDomain.Equals(aiController2.AppDomain))
Console.WriteLine("Add-ins in same process: {0}", _
    aiEnvironment.Process.Equals(aiController2.AddInEnvironment.Process))
' </Snippet8>

'<Snippet9>
' Get the application domain
' of an existing add-in (CalcAddIn).

Dim aiCtrl As AddInController = AddInController.GetAddInController(CalcAddIn)
Dim AddInAppDom As AppDomain = aiCtrl.AppDomain

' Activate another add-in in the same appliation domain.
Dim CalcAddIn3 As Calculator = selectedToken2.Activate(Of Calculator)(AddInAppDom)

' Show that the CalcAddIn3 was loaded
' into CalcCaddIn's application domain.
Dim aic As AddInController = AddInController.GetAddInController(CalcAddIn3)
Console.WriteLine("Add-in loaded into existing application domain: {0}", _
 aic.AppDomain.Equals(AddInAppDom))
' </Snippet9>

' <Snippet10>
' Create an external process.
Dim pExternal As New AddInProcess()

' Activate an add-in in the external process
' with a full trust security level.
Dim CalcAddIn4 As Calculator = _
    selectedToken.Activate(Of Calculator)(pExternal, _
        AddInSecurityLevel.FullTrust)

' Show that the add-in is an an external process
' by verifying that it is not in the current (host's) process.
Dim AddinCtl As AddInController = AddInController.GetAddInController(CalcAddIn4)
Console.WriteLine("Add-in in host's process: {0}", _
 AddinCtl.AddInEnvironment.Process.IsCurrentProcess)
' </Snippet10>

' <Snippet11>
' Use qualification data to control
' how an add-in should be activated.

If selectedToken.QualificationData(AddInSegmentType.AddIn)("Isolation").Equals("NewProcess") Then
    ' Create an external process.
    Dim external As AddInProcess = New AddInProcess

    ' Activate an add-in in an automatically generated
    ' application domain with a full trust security level.
    Dim CalcAddin5 As Calculator = _
        selectedToken.Activate(Of Calculator)(external, _
            AddInSecurityLevel.FullTrust)
    Console.WriteLine("Add-in activated per qualification data.")
Else
    Console.WriteLine("This add-in is not designated to be activated in a new process.")
End If
' </Snippet11>

' <Snippet12>
' Show the qualification data for each
' token in an AddInToken collection.
For Each token As AddInToken In tokens
    For Each qdi As QualificationDataItem In token
        Console.WriteLine("{0} {1}\n\t QD Name: {2}, QD Value: {3}", _
            token.Name, qdi.Segment, qdi.Name, qdi.Value)
    Next
Next
' </Snippet12>

End Sub
' <Snippet13>
' Method to select a token by 
' enumeratng the AddInToken collection.

Private Shared Function ChooseAddIn(ByVal tokens As System.Collections.ObjectModel.Collection(Of AddInToken)) As AddInToken
    If (tokens.Count = 0) Then
        Console.WriteLine("No add-ins are available")
        Return Nothing
    End If
    Console.WriteLine("Available add-ins: ")
    ' <Snippet7>
    ' Show the token properties for each token 
    ' in the AddInToken collection (tokens),
    ' preceded by the add-in number in [] brackets.

    Dim tokNumber As Integer = 1
    For Each tok As AddInToken In tokens
        Console.WriteLine(vbTab & "{0}: {1} - {2}" & _
                vbLf & vbTab & "{3}" & _
                vbLf & vbTab & "{4}" & _
                vbLf & vbTab & "{5} - {6}", _
                tokNumber.ToString, tok.Name, _
                tok.AddInFullName, tok.AssemblyName, _
                tok.Description, tok.Version, tok.Publisher)
        tokNumber = tokNumber + 1
    Next
    ' </Snippet7>
    Console.WriteLine("Which calculator do you want to use?")
    Dim line As String = Console.ReadLine
    Dim selection As Integer
    If Int32.TryParse(line, selection) Then
        If (selection <= tokens.Count) Then
            Return tokens((selection - 1))
        End If
    End If
    Console.WriteLine("Invalid selection: {0}. Please choose again.", line)
    Return ChooseAddIn(tokens)

End Function
'</Snippet13>

Private Shared Sub RunCalculator(ByVal calc As Calculator)
    If IsNothing(calc) Then
        'No calculators were found, read a line and exit.
        Console.ReadLine()
    End If
    Console.WriteLine(("Available operations: " + calc.Operations))
    Console.WriteLine("Type 'exit' to exit")
    Dim line As String = Console.ReadLine

    While Not line.Equals("exit")
        ' The Parser class parses the user's input.
        Try
            Dim c As Parser = New Parser(line)
            Console.WriteLine(calc.Operate(c.Action, c.A, c.B))
        Catch Ex As System.Exception
            Console.WriteLine("Invalid command: {0}. Commands must be formated: [number] [operation] [number]", line)
            Console.WriteLine(("Available operations: " + calc.Operations))
        End Try
        line = Console.ReadLine

    End While
End Sub
    End Class

    Class Parser

        Private partA As Double

        Private partB As Double

        Private act As String

        Friend Sub New(ByVal line As String)
            MyBase.New()
            Dim parts() As String = line.Trim.Split(" ")
            partA = Double.Parse(parts(0))
            act = parts(1)
            partB = Double.Parse(parts(2))
        End Sub

        Public ReadOnly Property A() As Double
            Get
                Return partA
            End Get
        End Property

        Public ReadOnly Property B() As Double
            Get
                Return partB
            End Get
        End Property

        Public ReadOnly Property Action() As String
            Get
                Return act
            End Get
        End Property
    End Class
End Namespace
' </Snippet1>

