Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Controls.Primitives
Imports System.Windows.Media.Imaging


    '@ <summary>
    '@ Interaction logic for Window1.xaml
    '@ </summary>

    public partial class Window1 
inherits window

 
    Private Sub WindowLoaded(ByVal Sender As Object, ByVal e As RoutedEventArgs)

        MakeExpander()
    End Sub


    '<Snippet1>

    Sub MakeExpander()

        'Create containing stack panel and assign to Grid row/col
        Dim sp As StackPanel = New StackPanel()
        Grid.SetRow(sp, 0)
        Grid.SetColumn(sp, 1)
        sp.Background = Brushes.LightSalmon

        'Create column title
        Dim colTitle As TextBlock = New TextBlock()
        colTitle.Text = "EXPANDER CREATED FROM CODE"
        colTitle.HorizontalAlignment = HorizontalAlignment.Center
        colTitle.Margin.Bottom.Equals(20)
        sp.Children.Add(colTitle)

        'Create Expander object
        Dim exp As Expander = New Expander()

        'Create Bullet Panel for Expander Header
        '<SnippetBulletDecorator>
        Dim bp As BulletDecorator = New BulletDecorator()
        Dim i As Image = New Image()
        Dim bi As BitmapImage = New BitmapImage()
        bi.UriSource = New Uri("pack://application:,,./images/icon.jpg")
        i.Source = bi
        i.Width = 10
        bp.Bullet = i
        Dim tb As TextBlock = New TextBlock()
        tb.Text = "My Expander"
        tb.Margin = New Thickness(20, 0, 0, 0)
        bp.Child = tb
        '</SnippetBulletDecorator>
        exp.Header = bp

        'Create TextBlock with ScrollViewer for Expander Content
        Dim spScroll As StackPanel = New StackPanel()
        Dim tbc As TextBlock = New TextBlock()
        tbc.Text = _
                "Lorem ipsum dolor sit amet, consectetur adipisicing elit," + _
                "sed do eiusmod tempor incididunt ut labore et dolore magna" + _
                "aliqua. Ut enim ad minim veniam, quis nostrud exercitation" + _
                "ullamco laboris nisi ut aliquip ex ea commodo consequat." + _
                "Duis aute irure dolor in reprehenderit in voluptate velit" + _
                "esse cillum dolore eu fugiat nulla pariatur. Excepteur sint" + _
                "occaecat cupidatat non proident, sunt in culpa qui officia" + _
                "deserunt mollit anim id est laborum."
        tbc.TextWrapping = TextWrapping.Wrap

        spScroll.Children.Add(tbc)
        Dim scr As ScrollViewer = New ScrollViewer()
        scr.Content = spScroll
        scr.Height = 50
        exp.Content = scr

        'Insert Expander into the StackPanel and add it to the
        'Grid
        exp.Width = 200
        exp.HorizontalContentAlignment = HorizontalAlignment.Stretch
        sp.Children.Add(exp)
        myGrid.Children.Add(sp)
    End Sub
    '</Snippet1>
End Class