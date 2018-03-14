Imports Microsoft.VisualStudio.TestTools.UnitTesting

Public Class Intermediate

    <TestClass()> Public Class Class1
        '<Snippet2>
        <TestMethod()> Public Sub AutomobileWithModelNameCanStart()
            Dim model As String = "Contoso"
            Dim topSpeed As Integer = 199
            Dim myAuto As New Automobile(model, topSpeed)
        End Sub
        '</Snippet2>
    End Class


    '<Snippet4>
    Public Class Automobile
        Sub New(ByVal model As String, ByVal topSpeed As Integer)
            _model = model
            _topSpeed = topSpeed
        End Sub
        Sub New()
            ' TODO: Complete member initialization 
        End Sub

        Property Model() As String
        Property TopSpeed As Integer
        Property IsRunning As Boolean
        Sub Start()
            Throw New NotImplementedException
        End Sub
    End Class
    '</Snippet4>
End Class
