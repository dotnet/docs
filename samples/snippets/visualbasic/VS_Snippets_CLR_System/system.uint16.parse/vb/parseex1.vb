' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Public Class Temperature 
	Protected n_value As UShort
   Protected s_value As String
   
	' Parses a string in the form [ws][sign]digits['F|'C][ws]
	Public Shared Function Parse(s As String) As Temperature
		Dim temp As New Temperature()
      
      If s Is Nothing Then 
         Throw New ArgumentNullException("s")
      End If
         
      s = s.TrimEnd()
		temp.s_value = s
      If s.EndsWith("'F") Or s.EndsWith("'C")  
			temp.Value = UInt16.Parse(s.Remove(s.LastIndexOf("'"), 2) )
		Else 
         Try
			  temp.Value = UInt16.Parse(s)
			Catch e As FormatException
            Throw New FormatException(String.Format("{0} is an invalid temperature.", s), e)
         Catch e As OverflowException
            Throw New OverflowException(String.Format("{0} is out of range.", s), e)
         End Try     
		End If

		Return temp
	End Function

	Public Property Value As UShort
		Get 
			Return n_value
		End Get
		Set 
			Me.n_value = value
		End Set
	End Property
End Class
' </Snippet1>

' <Snippet2>   
Module Example
   Public Sub Main()
      Dim values() As String = { "32'F", "32'C", "16", "-0", "-12", "", Nothing }
      For Each value As String In values
         Try
            Dim tmp as Temperature = Temperature.Parse(value)
            Console.WriteLine(tmp.Value)
         Catch e As FormatException
            Console.WriteLine("'{0}': Invalid Format", value.Trim())
         Catch e As OverflowException
            Console.WriteLine("{0}: Overflow", value.Trim())
         Catch e As ArgumentNullException
            Console.WriteLine("The {0} parameter is null.", e.ParamName)            
         End Try
      Next   
   End Sub
End Module
' The example displays the following output:
'       32
'       32
'       16
'       0
'       -12: Overflow
'       '': Invalid Format
'       The s parameter is null.
' </Snippet2>
