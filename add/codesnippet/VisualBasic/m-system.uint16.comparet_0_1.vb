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