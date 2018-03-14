' <Snippet1>
Public Class Example
    Public Shared Sub Main()
        Dim animal1 As String = "fox"
        Dim animal2 As String = "dog"
        Dim strTarget As String = String.Format("The {0} jumped over the {1}.", 
                                                animal1, animal2)
        
        Console.WriteLine("The original string is: {0}{1}{0}", 
                          Environment.NewLine, strTarget)
        
        Console.Write("Enter an adjective (or group of adjectives) " +
                      "to describe the {0}: ==> ", animal1)
        Dim adj1 As String = Console.ReadLine()
        
        Console.Write("Enter an adjective (or group of adjectives) " + 
                      "to describe the {0}: ==> ", animal2)
        Dim adj2 As String = Console.ReadLine()
        
        adj1 = adj1.Trim() + " "
        adj2 = adj2.Trim() + " "
        
        strTarget = strTarget.Insert(strTarget.IndexOf(animal1), adj1)
        strTarget = strTarget.Insert(strTarget.IndexOf(animal2), adj2)
        
        Console.WriteLine("{0}The final string is:{0}{1}", 
                          Environment.NewLine, strTarget)
    End Sub 
End Class 
' Output from the example might appear as follows:
'       The original string is:
'       The fox jumped over the dog.
'       
'       Enter an adjective (or group of adjectives) to describe the fox: ==> bold
'       Enter an adjective (or group of adjectives) to describe the dog: ==> lazy
'       
'       The final string is:
'       The bold fox jumped over the lazy dog.
' </Snippet1>
