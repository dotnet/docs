Class Class10bba104e3fd451bb672faa472530502
    ' #If...Then...#Else Directives

    Public Sub Method1()
        ' <snippet1>
#Const CustomerNumber = 36
#If CustomerNumber = 35 Then
        ' Insert code to be compiled for customer # 35.
#ElseIf CustomerNumber = 36 Then
        ' Insert code to be compiled for customer # 36.
#Else
        ' Insert code to be compiled for all other customers.
#End If
        ' </snippet1>
    End Sub

End Class

Class Class2bedb7b31657436c9a4f0258e7ba2864
    ' Conditional Compilation Constants

    Public Sub Method2()
        ' <snippet2>
#If TARGET = "winexe" Then
        ' Insert code to be compiled for a Windows application.
#ElseIf TARGET = "exe" Then
        ' Insert code to be compiled for a console application.
#End If
        ' </snippet2>
    End Sub

End Class

Class Class707669e523f94f178622a0d534429386
    ' #Const Directive

    Public Sub Method3()
        ' <snippet3>
#Const MyLocation = "USA"
#Const Version = "8.0.0012"
#Const CustomerNumber = 36
        ' </snippet3>
    End Sub

End Class

Class Class90a6a1043cbf47d0bdc4b585d0921b87
    ' #Region Directive


    ' <snippet4>
#Region "MathFunctions"
    ' Insert code for the Math functions here.
#End Region
    ' </snippet4>

End Class

Class Class9c35e55e7eee44fba586dad1f1884848
    ' Conditional Compilation Overview

    Public Sub Method5()
        ' <snippet5>
#If FrenchVersion Then
   ' <code specific to the French language version>.
#ElseIf GermanVersion Then
   ' <code specific to the German language version>.
#Else
        ' <code specific to other versions>.
#End If
        ' </snippet5>
    End Sub

End Class

Class Classb770e8f5e07d491aab4ba977980f9ba2
    ' How to: Collapse and Hide Sections of Code

    Dim Text As String

    ' <snippet6>
#Region "This is the code to be collapsed"
    Private components As System.ComponentModel.Container
    Dim WithEvents Form1 As System.Windows.Forms.Form

    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
        Me.Text = "Form1"
    End Sub
#End Region
    ' </snippet6>

End Class

