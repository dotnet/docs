' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Module Example
   Public Sub Main()
      Dim rnd As New Random()
      Dim malePetNames() As String = { "Rufus", "Bear", "Dakota", "Fido", 
                                    "Vanya", "Samuel", "Koani", "Volodya", 
                                    "Prince", "Yiska" }
      Dim femalePetNames() As String = { "Maggie", "Penny", "Saya", "Princess", 
                                         "Abby", "Laila", "Sadie", "Olivia", 
                                         "Starlight", "Talla" }                                      
      
      ' Generate random indexes for pet names.
      Dim mIndex As Integer = rnd.Next(0, malePetNames.Length)
      Dim fIndex As Integer = rnd.Next(0, femalePetNames.Length)
      
      ' Display the result.
      Console.WriteLine("Suggested pet name of the day: ")
      Console.WriteLine("   For a male:     {0}", malePetNames(mIndex))
      Console.WriteLine("   For a female:   {0}", femalePetNames(fIndex))
   End Sub
End Module
' The example displays output like the following:
'       Suggested pet name of the day:
'          For a male:     Koani
'          For a female:   Maggie
' </Snippet4>
