  Public Shadows Structure height
      ' Need Shadows because System.Windows.Forms.Form also defines property Height.
      Private feet As Integer
      Private inches As Double
      Public Sub New(ByVal f As Integer, ByVal i As Double)
          Me.feet = f + (CInt(i) \ 12)
          Me.inches = i Mod 12.0
      End Sub
      Public Overloads Function ToString() As String
          Return Me.feet & "' " & Me.inches & """"
      End Function
      Public Shared Operator +(ByVal h1 As height, 
                               ByVal h2 As height) As height
          Return New height(h1.feet + h2.feet, h1.inches + h2.inches)
      End Operator
  End Structure