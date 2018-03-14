Namespace SDKSample

    Partial Public Class ThemeWindow
        Inherits System.Windows.Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub AeroNormalColorClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim uri1 As New Uri("PresentationFramework.Aero;V3.0.0.0;31bf3856ad364e35;component\themes/aero.normalcolor.xaml", UriKind.Relative)
            MyBase.Resources.MergedDictionaries.Add(TryCast(Application.LoadComponent(uri1), ResourceDictionary))
        End Sub

        Private Sub ClassicClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim uri1 As New Uri("PresentationFramework.Classic;V3.0.0.0;31bf3856ad364e35;component\themes/classic.xaml", UriKind.Relative)
            MyBase.Resources.MergedDictionaries.Add(TryCast(Application.LoadComponent(uri1), ResourceDictionary))
        End Sub

        Private Sub LunaHomesteadClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim uri1 As New Uri("PresentationFramework.Luna;V3.0.0.0;31bf3856ad364e35;component\themes/luna.homestead.xaml", UriKind.Relative)
            MyBase.Resources.MergedDictionaries.Add(TryCast(Application.LoadComponent(uri1), ResourceDictionary))
        End Sub

        Private Sub LunaMetallicClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim uri1 As New Uri("PresentationFramework.Luna;V3.0.0.0;31bf3856ad364e35;component\themes/luna.metallic.xaml", UriKind.Relative)
            MyBase.Resources.MergedDictionaries.Add(TryCast(Application.LoadComponent(uri1), ResourceDictionary))
        End Sub

        Private Sub LunaNormalColorClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim uri1 As New Uri("PresentationFramework.Luna;V3.0.0.0;31bf3856ad364e35;component\themes/luna.normalcolor.xaml", UriKind.Relative)
            MyBase.Resources.MergedDictionaries.Add(TryCast(Application.LoadComponent(uri1), ResourceDictionary))
        End Sub

        Private Sub RoyaleNormalColorClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim uri1 As New Uri("PresentationFramework.Royale;V3.0.0.0;31bf3856ad364e35;component\themes/royale.normalcolor.xaml", UriKind.Relative)
            MyBase.Resources.MergedDictionaries.Add(TryCast(Application.LoadComponent(uri1), ResourceDictionary))
        End Sub

    End Class

End Namespace