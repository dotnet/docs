' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Class Mymemberinfo

    Public Shared Function Main() As Integer
        Console.WriteLine(ControlChars.Cr + "Reflection.MemberInfo")

        ' Get the Type and MemberInfo.
        Dim MyType As Type = Type.GetType("System.Reflection.PropertyInfo")
        Dim Mymemberinfoarray As MemberInfo() = MyType.GetMembers()

        ' Get the MemberType method and display the elements.
        Console.Write(ControlChars.Cr + "There are {0} members in ", _
           Mymemberinfoarray.GetLength(0))
        Console.Write("{0}.", MyType.FullName)

        Dim counter As Integer
        For counter = 0 To Mymemberinfoarray.Length - 1
            Console.Write(ControlChars.CrLf + counter.ToString() + ". " _
               + Mymemberinfoarray(counter).Name _
               + " Member type - " _
               + Mymemberinfoarray(counter).MemberType.ToString())
        Next counter
        Return 0
    End Function
End Class
' </Snippet1>