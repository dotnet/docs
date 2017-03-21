   Public Class Temperature 
		' The value holder
		Protected m_value As UInteger

		Public Shared ReadOnly Property MinValue As UInteger
			Get 
				Return UInt32.MinValue
			End Get
		End Property

		Public Shared ReadOnly Property MaxValue As UInteger
			Get 
				Return UInt32.MaxValue
			End Get
		End Property

		Public Property Value As UInteger
			Get 
				Return Me.m_value
			End Get
			Set 
				Me.m_value = value
			End Set
		End Property
   End Class