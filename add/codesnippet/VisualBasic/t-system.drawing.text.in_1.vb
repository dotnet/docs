    	Private ifc As New InstalledFontCollection()
    	
	Private Sub EnumerateInstalledFonts(ByVal e As PaintEventArgs)
          Dim families As FontFamily() = ifc.Families
       	  Dim x As Single = 0.0F
       	  Dim y As Single = 0.0F
        	For i As Integer = 0 To ifc.Families.Length - 1
            	  If ifc.Families(i).IsStyleAvailable(FontStyle.Regular) Then
                	e.Graphics.DrawString(ifc.Families(i).Name, New Font(ifc.Families(i), 12),  _ 
			  Brushes.Black, x, y)
                	y += 20
                	If y Mod 700 = 0 Then
                          x += 140
                    	  y = 0
                        End If
            	  End If
        	Next
       End Sub