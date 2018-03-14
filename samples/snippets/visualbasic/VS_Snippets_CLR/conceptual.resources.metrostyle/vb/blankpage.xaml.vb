' <Snippet2>
Imports System.Globalization
Imports Windows.ApplicationModel.Resources
Imports Windows.ApplicationModel.Resources.Core
Imports Windows.UI.Xaml.Controls

Public Class Example
    Public Shared Sub Run(outputBlock As Windows.UI.Xaml.Controls.TextBlock)
        outputBlock.Text += String.Format("{1}The current culture is {0}.{1}",
                                          CultureInfo.CurrentCulture.Name, vbCrLf)
        Dim rl As ResourceLoader = New ResourceLoader()

        ' Display greeting using the resources of the current culture.
        Dim greeting As String = rl.GetString("Greeting")
        outputBlock.Text += String.Format("{0}{1}",
                                          If(String.IsNullOrEmpty(greeting), "Здравствуйте", greeting),
                                          vbCrLf)

        ' Display greeting using fr-FR resources.
        Dim ctx As ResourceContext = New Windows.ApplicationModel.Resources.Core.ResourceContext()
        ctx.Languages = {"fr-FR"}

        Dim rmap As ResourceMap = ResourceManager.Current.MainResourceMap.GetSubtree("Resources")
        Dim newGreeting As String = rmap.GetValue("Greeting", ctx).ValueAsString()

        outputBlock.Text += String.Format("{1}{1}Culture of Current Context: {0}{1}",
                                          ctx.Languages(0), vbCrLf)
        outputBlock.Text += String.Format("{0}{1}", If(String.IsNullOrEmpty(newGreeting),
                                                       greeting, newGreeting), vbCrLf)
    End Sub
End Class
' </Snippet2>




Public NotInheritable Class BlankPage
    Inherits Page

    ' <Snippet1>
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Example.Run(outputBlock)
    End Sub
    ' </Snippet1>
End Class
