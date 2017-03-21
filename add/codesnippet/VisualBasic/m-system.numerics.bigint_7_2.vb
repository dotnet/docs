Module Example
   Public Sub Main()
      Dim star As StarInfo
      Dim stars As New List(Of StarInfo)
      
      star = New StarInfo("Sirius", 8.6d)
      stars.Add(star)
      star = New StarInfo("Rigel", 1400d)
      stars.Add(star)
      star = New StarInfo("Castor", 49d)
      stars.Add(star)
      star = New StarInfo("Antares", 520d)
      stars.Add(star)
      
      stars.Sort()
      
      For Each star In stars
         Console.WriteLine(star)
      Next   
   End Sub
End Module
' The example displays the following output:
'       Sirius     (50,568,000,000,000)
'       Castor     (288,120,000,000,000)
'       Antares    (3,057,600,000,000,000)
'       Rigel      (8,232,000,000,000,000)