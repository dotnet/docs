' Visual Basic .NET Document
Option Strict On

<Assembly: CLSCompliant(True)>
Module Example

   Public Sub Main()
      UseStringFormat()
      Console.WriteLine()
      UseStringConcat()
      Console.WriteLine()
      UseStringJoin()
      Console.WriteLine()
      UseStringInsert()
      Console.WriteLine()
      UseStringCopyTo()
   End Sub
   
   Private Sub UseStringFormat()
      ' <Snippet1>
      Dim numberOfFleas As Integer = 12
      Dim miscInfo As String = String.Format("Your dog has {0} fleas. " & _
                                             "It is time to get a flea collar. " & _ 
                                             "The current universal date is: {1:u}.", _ 
                                             numberOfFleas, Date.Now)
      Console.WriteLine(miscInfo)
      ' The example displays the following output:
      '       Your dog has 12 fleas. It is time to get a flea collar. 
      '       The current universal date is: 2008-03-28 13:31:40Z.
      ' </Snippet1>
   End Sub
   
   Private Sub UseStringConcat()
      ' <Snippet2>
      Dim helloString1 As String = "Hello"
      Dim helloString2 As String = "World!"
      Console.WriteLine(String.Concat(helloString1, " "c, helloString2))
      ' The example displays the following output:
      '      Hello World!
      ' </Snippet2>      
   End Sub

   Private Sub UseStringJoin()
      ' <Snippet3>
      Dim words() As String = {"Hello", "and", "welcome", "to", "my" , "world!"}
      Console.WriteLine(String.Join(" ", words))
      ' The example displays the following output:
      '      Hello and welcome to my world!
      ' </Snippet3>      
   End Sub

   Private Sub UseStringInsert()
       ' <Snippet4>
     Dim sentence As String = "Once a time."   
      Console.WriteLine(sentence.Insert(4, " upon"))
      ' The example displays the following output:
      '      Once upon a time.
      ' </Snippet4>      
   End Sub

   Private Sub UseStringCopyTo()
      ' <Snippet5>
      Dim greeting As String = "Hello World!"
      Dim charArray() As Char = {"W"c, "h"c, "e"c, "r"c, "e"c}
      Console.WriteLine("The original character array: {0}", New String(charArray))
      greeting.CopyTo(0, charArray,0 ,5)
      Console.WriteLine("The new character array: {0}", New String(charArray))
      ' The example displays the following output:
      '       The original character array: Where
      '       The new character array: Hello
      ' </Snippet5>      
   End Sub
End Module

