<Serializable> Public Structure PersonTable
   Public ReadOnly nColumns As Integer
   Public Readonly column1 As String
   Public ReadOnly column2 As String
   Public ReadOnly column3 As String
   Public ReadOnly width1 As Integer
   Public ReadOnly width2 As Integer
   Public ReadOnly width3 As Integer
   
   Public Sub New(column1 As String, column2 As String, column3 As String,
                  width1 As Integer, width2 As Integer, width3 As Integer)
      Me.column1 = column1
      Me.column2 = column2
      Me.column3 = column3
      Me.width1 = width1
      Me.width2 = width2
      Me.width3 = width3
      Me.nColumns = Me.GetType().GetFields().Count \ 2 
   End Sub
End Structure