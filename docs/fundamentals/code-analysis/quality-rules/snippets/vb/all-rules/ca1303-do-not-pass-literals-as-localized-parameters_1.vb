<Assembly: System.Resources.NeutralResourcesLanguageAttribute("en-US")>
Namespace GlobalizationLibrary

    Public Class DoNotPassLiterals

        Dim stringManager As System.Resources.ResourceManager

        Sub New()
            stringManager = New System.Resources.ResourceManager(
                "en-US", System.Reflection.Assembly.GetExecutingAssembly())
        End Sub

        Sub TimeMethod(hour As Integer, minute As Integer)

            If (hour < 0 Or hour > 23) Then
                'CA1303 fires because a literal string
                'is passed as the 'value' parameter.
                Console.WriteLine("The valid range is 0 - 23.")
            End If

            If (minute < 0 Or minute > 59) Then
                Console.WriteLine(
                    stringManager.GetString("minuteOutOfRangeMessage",
                        System.Globalization.CultureInfo.CurrentUICulture))
            End If

        End Sub

    End Class

End Namespace
