' <Snippet1>
Imports System.Collections.Generic

Class StringContainer
    ' Define a delegate to handle string display. 
    Delegate Sub CheckAndPrintDelegate(ByVal str As String)

    ' A generic list object that holds the strings.
    Private container As New List(Of String)()

     ' A method that adds strings to the collection. 
     Public Sub AddString(ByVal s As String)
        container.Add(s)
    End Sub

    ' Iterate through the strings and invoke the method(s) that the delegate points to.
    Public Sub DisplayAllQualified(ByVal displayDelegate As CheckAndPrintDelegate)
        For Each s In container
            displayDelegate(s)
        Next
    End Sub
End Class

' This class defines some methods to display strings. 
Class StringExtensions
    ' Display a string if it starts with a consonant. 
    Public Shared Sub ConStart(ByVal str As String)
        If Not (str.Chars(0) = "a"c Or str.Chars(0) = "e"c Or str.Chars(0) = "i"c _ 
                Or str.Chars(0) = "o"c Or str.Chars(0) = "u"c) Then
            Console.WriteLine(str)
        End If
    End Sub 

    ' Display a string if it starts with a vowel.
    Public Shared Sub VowelStart(ByVal str As String)
        If (str.Chars(0) = "a"c Or str.Chars(0) = "e"c Or str.Chars(0) = "i"c _
            Or str.Chars(0) = "o"c Or str.Chars(0) = "u"c) Then
            Console.WriteLine(str)
        End If
    End Sub 
End Class 

' Demonstrate the use of delegates, including the Remove and 
' Combine methods to create and modify delegate combinations. 
Class Test
    Public Shared Sub Main()
        ' Declare the StringContainer class and add some strings
        Dim container As New StringContainer()
        container.AddString("this")
        container.AddString("is")
        container.AddString("a")
        container.AddString("multicast")
        container.AddString("delegate")
        container.AddString("example")

        ' Create two delegates individually using different methods.
        Dim constart As StringContainer.CheckAndPrintDelegate = AddressOf StringExtensions.ConStart
        Dim vowelStart As StringContainer.CheckAndPrintDelegate = AddressOf StringExtensions.VowelStart

        ' Get the list of all delegates assigned to this MulticastDelegate instance. 
        Dim delegateList() As [Delegate] = conStart.GetInvocationList()
        Console.WriteLine("conStart contains {0} delegate(s).", delegateList.Length)
        delegateList = vowelStart.GetInvocationList()
        Console.WriteLine("vowelStart contains {0} delegate(s).", delegateList.Length)
        Console.WriteLine()
        
        ' Determine whether the delegates are System.Multicast delegates
        If TypeOf conStart Is System.MulticastDelegate And TypeOf vowelStart Is System.MulticastDelegate Then
            Console.WriteLine("conStart and vowelStart are derived from MulticastDelegate.")
            Console.WriteLine()
        End If

        ' Run the two single delegates one after the other.
        Console.WriteLine("Executing the conStart delegate:")
        container.DisplayAllQualified(conStart)
        Console.WriteLine("Executing the vowelStart delegate:")
        container.DisplayAllQualified(vowelStart)
        Console.WriteLine()

        ' Create a new MulticastDelegate and call Combine to add two delegates.
        Dim multipleDelegates As StringContainer.CheckAndPrintDelegate = 
                  CType([Delegate].Combine(conStart, vowelStart), 
                  StringContainer.CheckAndPrintDelegate)

        ' How many delegates does multipleDelegates contain?
        delegateList = multipleDelegates.GetInvocationList()
        Console.WriteLine("{1}multipleDelegates contains {0} delegates.{1}",
                          delegateList.Length, vbCrLf)

        ' Pass this mulitcast delegate to DisplayAllQualified.
        Console.WriteLine("Executing the multipleDelegate delegate.")
        container.DisplayAllQualified(multipleDelegates)

        ' Call remove and combine to change the contained delegates.
        multipleDelegates = CType([Delegate].Remove(multipleDelegates, vowelStart), 
                            StringContainer.CheckAndPrintDelegate)
        multipleDelegates = CType([Delegate].Combine(multipleDelegates, conStart), 
                            StringContainer.CheckAndPrintDelegate)

        ' Pass multipleDelegates to DisplayAllQualified again.
        Console.WriteLine()
        Console.WriteLine("Executing the multipleDelegate delegate with two conStart delegates:")
        container.DisplayAllQualified(multipleDelegates)
    End Sub 
End Class 
' The example displays the following output:
'    conStart contains 1 delegate(s).
'    vowelStart contains 1 delegate(s).
'    
'    conStart and vowelStart are derived from MulticastDelegate.
'    
'    Executing the conStart delegate:
'    This
'    multicast
'    delegate
'    
'    Executing the vowelStart delegate:
'    is
'    a
'    example
'    
'    
'    multipleDelegates contains 2 delegates.
'    
'    Executing the multipleDelegate delegate.
'    This
'    is
'    a
'    multicast
'    delegate
'    example
'    
'    Executing the multipleDelegate delegate with two conStart delegates:
'    This
'    This
'    multicast
'    multicast
'    delegate
'    delegate
' </Snippet1>