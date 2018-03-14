' <Snippet1>

Imports System
Imports System.Xml
Imports System.Reflection
Imports Microsoft.VisualBasic

Public Class MyFindInterfacesSample
    Public Shared Sub Main()
        Try
            Dim myXMLDoc As New XmlDocument()
            myXMLDoc.LoadXml("<book genre='novel' ISBN='1-861001-57-5'>" _
                & "<title>Pride And Prejudice</title>" & "</book>")
            Dim myType As Type = myXMLDoc.GetType()

            ' Specify the TypeFilter delegate that compares the 
            ' interfaces against filter criteria.
            Dim myFilter As New TypeFilter(AddressOf MyInterfaceFilter)
            Dim myInterfaceList() As String = _
                {"System.Collections.IEnumerable", _
                "System.Collections.ICollection"}
            Dim index As Integer
            For index = 0 To myInterfaceList.Length - 1
                Dim myInterfaces As Type() = _
                    myType.FindInterfaces(myFilter, myInterfaceList(index))
                If myInterfaces.Length > 0 Then
                    Console.WriteLine(ControlChars.Cr & _
                        "{0} implements the interface {1}.", _
                        myType, myInterfaceList(index))
                    Dim j As Integer
                    For j = 0 To myInterfaces.Length - 1
                        Console.WriteLine("Interfaces supported: {0}", _
                            myInterfaces(j).ToString())
                    Next j
                Else
                    Console.WriteLine(ControlChars.Cr & _
                        "{0} does not implement the interface {1}.", _
                        myType, myInterfaceList(index))
                End If
            Next index
        Catch e As ArgumentNullException
            Console.WriteLine("ArgumentNullException: " & e.Message)
        Catch e As TargetInvocationException
            Console.WriteLine("TargetInvocationException: " & e.Message)
        Catch e As Exception
            Console.WriteLine("Exception: " & e.Message)
        End Try
    End Sub 'Main
    Public Shared Function MyInterfaceFilter(ByVal typeObj As Type, _
        ByVal criteriaObj As [Object]) As Boolean
        If typeObj.ToString() = criteriaObj.ToString() Then
            Return True
        Else
            Return False
        End If
    End Function 'MyInterfaceFilter 
End Class 'MyFindInterfacesSample
' </Snippet1>

