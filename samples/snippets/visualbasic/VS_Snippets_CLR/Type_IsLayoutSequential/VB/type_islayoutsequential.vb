' <Snippet1>
Imports System
Imports System.Reflection
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic
Class MyTypeSequential1
End Class 'MyTypeSequential1
<StructLayoutAttribute(LayoutKind.Sequential)> Class MyTypeSequential2
    Public Shared Sub Main()
        Try
            ' Create an instance of MyTypeSequential1.
            Dim myObj1 As New MyTypeSequential1()
            Dim myTypeObj1 As Type = myObj1.GetType()
            ' Check for and display the SequentialLayout attribute.
            Console.WriteLine(ControlChars.Cr + "The object myObj1 has IsLayoutSequential: {0}.", myObj1.GetType().IsLayoutSequential.ToString())
            ' Create an instance of MyTypeSequential2.
            Dim myObj2 As New MyTypeSequential2()
            Dim myTypeObj2 As Type = myObj2.GetType()
            ' Check for and display the SequentialLayout attribute.
            Console.WriteLine(ControlChars.Cr + "The object myObj2 has IsLayoutSequential: {0}.", myObj2.GetType().IsLayoutSequential.ToString())
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "An exception occurred: {0}", e.Message.ToString())
        End Try
    End Sub 'Main
End Class 'MyTypeSeq2
' </Snippet1>