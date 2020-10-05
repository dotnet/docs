Public Module Example
   Public Sub Main()
      Dim name = "Horace"
      Dim age = 34
      Dim s1 = $"He asked, ""Is your name {name}?"", but didn't wait for a reply."
      Console.WriteLine(s1)
      
      Dim s2 = $"{name} is {age:D3} year{If(age = 1, "", "s")} old."
      Console.WriteLine(s2) 
   End Sub
End Module
' The example displays the following output:
'       He asked, "Is your name Horace?", but didn't wait for a reply.
'       Horace is 034 years old.
