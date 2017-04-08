'<Snippet1>
Imports System
Imports System.Globalization
Imports System.Reflection
Imports System.Resources
Imports System.Windows.Forms


<assembly: System.Resources.NeutralResourcesLanguageAttribute("en-US")>
Namespace GlobalizationLibrary

    Public Class DoNotPassLiterals

        Dim stringManager As System.Resources.ResourceManager

        Sub New()
            stringManager = New System.Resources.ResourceManager( _
                "en-US", System.Reflection.Assembly.GetExecutingAssembly())
        End Sub

        Sub TimeMethod(hour As Integer, minute As Integer)
        
            If(hour < 0 Or hour > 23) Then
                MessageBox.Show( _
                    "The valid range is 0 - 23.") 'CA1303 fires because the parameter for method Show is Text
            End If

            If(minute < 0 Or minute > 59) Then
                 MessageBox.Show( _
                    stringManager.GetString("minuteOutOfRangeMessage", _
                        System.Globalization.CultureInfo.CurrentUICulture))
            End If

        End Sub

    End Class

End Namespace
'</Snippet1>
