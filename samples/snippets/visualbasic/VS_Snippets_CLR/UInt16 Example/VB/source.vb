Option Strict On

Imports System.Globalization

Namespace Snippet1
   Module Launcher 
   	Public Sub Main()
   		Dim t1 As Temperature = Temperature.Parse("20'F", NumberStyles.Integer, _
                                                   Nothing)
   		Console.WriteLine(t1.ToString("F", Nothing))
   
   		Dim str1 As String = t1.ToString("G", Nothing)
   		Console.WriteLine(str1)
   
   		Dim t2 As Temperature = Temperature.Parse(str1, NumberStyles.Integer, _
                                                   Nothing)
   		Console.WriteLine(t2.ToString("F", Nothing))
   
   		Console.WriteLine(t1.CompareTo(t2))
   
   		Dim t3 As Temperature = Temperature.Parse("30'F", NumberStyles.Integer, _
                                                   Nothing)
   		Console.WriteLine(t3.ToString("F", Nothing))
   
   		Console.WriteLine(t1.CompareTo(t3))
   
   		Console.ReadLine()
   	End Sub
   End Module

   ' <Snippet1>
   ''' <summary>
   ''' Temperature class stores the value as UInt16
   ''' and delegates most of the functionality 
   ''' to the UInt16 implementation.
   ''' </summary>
   Public Class Temperature : Implements IComparable, IFormattable 
   
   	' The value holder
   	Protected m_value As UShort
   
   	''' <summary>
   	''' IComparable.CompareTo implementation.
   	''' </summary>
   	Public Function CompareTo(obj As Object) As Integer _
                                      Implements IComparable.CompareTo
   		If TypeOf(obj) Is Temperature Then
   			Dim temp As Temperature = DirectCast(obj, Temperature)
   
   			Return m_value.CompareTo(temp.m_value)
   		End If
   			
   		Throw New ArgumentException("object is not a Temperature")	
   	End Function
   
   	''' <summary>
   	''' IFormattable.ToString implementation.
   	''' </summary>
   	Public Overloads Function ToString(format As String, _
                                         provider As IFormatProvider) _
                                         As String _
                       Implements IFormattable.ToString 
   
   		If Not String.IsNullOrEmpty(format) AndAlso format.Equals("F") Then _
   			Return String.Format("{0}'F", Me.Value.ToString())
   
   		Return m_value.ToString(format, provider)
   	End Function
   
   	''' <summary>
   	' Parses the temperature from a string in form
   	' [ws][sign]digits['F|'C][ws]
   	' </summary>
   	Public Shared Function Parse(s As String, styles As NumberStyles, _
                                   provider AS IFormatProvider) As Temperature
   		Dim temp As New Temperature()
   
   		If s.TrimEnd(Nothing).EndsWith("'F") Then
   			temp.Value = UInt16.Parse(s.Remove(s.LastIndexOf("'"), 2), styles, provider)
      	Else 
   			temp.Value = UInt16.Parse(s, styles, provider)
   		End If
   
   		Return temp
   	End Function
   
   	Public Property Value As UShort
   		Get 
   			Return m_value
   		End Get
   		Set 
   			m_value = value
   		End Set
   	End Property
   End Class
   ' </Snippet1>
End Namespace

Namespace Snippet2
   ' <Snippet2>
   Public Class Temperature 
		' The value holder
		Protected m_value As UShort

		Public Shared ReadOnly Property MinValue As UShort
			Get 
				Return UInt16.MinValue
			End Get
		End Property

		Public Shared ReadOnly Property MaxValue As UShort
			Get 
				Return UInt16.MaxValue
			End Get
		End Property

		Public Property Value As UShort
			Get 
				Return Me.m_value
			End Get
			Set 
				Me.m_value = value
			End Set
		End Property
   End Class
	' </Snippet2>
End Namespace

Namespace Snippet3 
	' <Snippet3>
	Public Class Temperature : Implements IComparable 
		' The value holder
		Protected m_value As UShort

		''' <summary>
		''' IComparable.CompareTo implementation.
		''' </summary>
		Public Function CompareTo(obj As Object) As Integer _
		       Implements IComparable.CompareTo
		       
			If TypeOf(obj) Is Temperature Then
				Dim temp As Temperature = DirectCast(obj, Temperature) 

				Return m_value.CompareTo(temp.m_value)
			End If
			
			Throw New ArgumentException("object is not a Temperature")	
		End Function

		Public Property Value As UShort
			Get 
				Return m_value
			End Get
			Set 
				Me.m_value = value
			End Set
		End Property
	End Class
	' </Snippet3>
End Namespace

Namespace Snippet4 
	' <Snippet4>
	Public Class Temperature : Implements IFormattable
		' The value holder
		Protected m_value As UShort

		''' <summary>
		''' IFormattable.ToString implementation.
		''' </summary>
		Public Overloads Function ToString(format As String, _
                                         provider As IFormatProvider) _
                                         As String _ 
             Implements IFormattable.ToString

			If Not String.IsNullOrEmpty(format) AndAlso format.Equals("F") Then _
				Return String.Format("{0}'F", Me.Value.ToString())

			Return m_value.ToString(format, provider)
		End Function

		Public Property Value As UShort
			Get 
				Return Me.m_value
			End Get
			Set 
				Me.m_value = value
			End Set
		End Property
	End Class
	' </Snippet4>
End Namespace

Namespace Snippet5 
	' <Snippet5>
	Public Class Temperature 
		' The value holder
		Protected m_value As UShort

		' <summary>
		' Parses the temperature from a string in form
		' [ws][sign]digits['F|'C][ws]
		' </summary>
		Public Shared Function Parse(s As String) As Temperature
			Dim temp As New Temperature()

			If s.TrimEnd(Nothing).EndsWith("'F")  
				temp.Value = UInt16.Parse(s.Remove(s.LastIndexOf("'"), 2) )
			Else 
				temp.Value = UInt16.Parse(s)
			End If

			Return temp
		End Function

		Public Property Value As UShort
			Get 
				Return m_value
			End Get
			Set 
				Me.m_value = value
			End Set
		End Property
	End Class
	' </Snippet5>
End Namespace

Namespace Snippet6 
	' <Snippet6>
	Public Class Temperature 
		' The value holder
		Protected m_value As UShort

		' <summary>
		' Parses the temperature from a string in form
		' [ws][sign]digits['F|'C][ws]
		' </summary>
		Public Shared Function Parse(s As string, _
                                   provider As IFormatProvider) _
                                   As Temperature
			Dim temp As New Temperature()

			If s.TrimEnd(Nothing).EndsWith("'F") Then
				temp.Value = UInt16.Parse(s.Remove(s.LastIndexOf("'"), 2), provider)
			Else 
				temp.Value = UInt16.Parse(s, provider)
			End If

			Return temp
		End Function

		Public Property Value As UShort 
			Get 
				Return m_value
			End Get
			Set 
				Me.m_value = value
			End Set
		End Property
	End Class
	' </Snippet6>
End Namespace

Namespace Snippet7 
	' <Snippet7>
	Public Class Temperature 
		' The value holder
		Protected m_value As UShort

		' <summary>
		' Parses the temperature from a string in form
		' [ws][sign]digits['F|'C][ws]
		' </summary>
		Public Shared Function Parse(s As String, _
                                   styles As NumberStyles) As Temperature
			Dim temp As New Temperature()

			If s.TrimEnd(Nothing).EndsWith("'F") Then
				temp.Value = UInt16.Parse(s.Remove(s.LastIndexOf("'"), 2), styles)
			Else
				temp.Value = UInt16.Parse(s, styles)
			End If

			Return temp
		End Function

		Public Property Value As UShort 
			Get 
				Return Me.m_value
			End Get
			Set 
				Me.m_value = value
			End Set
		End Property
	End Class
	' </Snippet7>
End Namespace

Namespace Snippet8 
	' <Snippet8>
	Public Class Temperature 
		' The value holder
		Protected m_value As UShort

		''' <summary>
		''' Parses the temperature from a string in form
		''' [ws][sign]digits['F|'C][ws]
		''' </summary>
		Public Shared Function Parse(s As String, styles As NumberStyles, _
                                   provider As IFormatProvider) As Temperature
			Dim temp As New Temperature()

			If s.TrimEnd(Nothing).EndsWith("'F") Then
				temp.Value = UInt16.Parse(s.Remove(s.LastIndexOf("'"), 2), styles, provider)
			Else 
				temp.Value = UInt16.Parse(s, styles, provider)
			End If

			Return temp
		End Function

		Public Property Value As UShort 
			Get 
				Return m_value
			End Get
			Set 
				Me.m_value = value
			End Set
		End Property
	End Class
	' </Snippet8>
End Namespace
