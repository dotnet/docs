Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.IO

' Interaction logic for Window1.xaml
Namespace SDKSamples
    Partial Public Class Window1
        Inherits Window

        ' Flag used to set the scope of the cursor.
        Dim cursorScopeElementOnly As Boolean

        '<SnippetChangeCursorsCustomCursor>
        Dim CustomCursor As Cursor

        Public Sub New()
            ' Setting CustomCursor to the file CustomCursor.cur.
            ' This assumes the file CustomCursor.cur has been added to the project
            ' as a resource.  One way to accomplish this to add the following: 
            'ItemGroup section to the project file
            '
            '  <ItemGroup>
            '    <Content Include="CustomCursor.cur">
            '       <CopyToOutputDirectory>Always</CopyToOutputDirectory>
            '    </Content>
            '  </ItemGroup>
            '
            CustomCursor = New Cursor(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "CustomCursor.cur")
        End Sub
        '</SnippetChangeCursorsCustomCursor>

        Private Sub OnLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)

            ' Setting the default curosr scope to only the element.
            cursorScopeElementOnly = True

            ' When the ui is finished loading, make the arrorw cursor
            ' the default cursor in the CursorSelector Combobox.
            CType(CursorSelector.Items(2), ComboBoxItem).IsSelected = True



        End Sub

        '<SnippetChangeCursorsSample>
        ' When the Radiobox changes, a new cursor type is set
        Private Sub CursorTypeChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)

            Dim item As String = CType(e.Source, ComboBox).SelectedItem.Content.ToString()

            Select Case item
                Case "AppStarting"
                    DisplayArea.Cursor = Cursors.AppStarting
                Case "ArrowCD"
                    DisplayArea.Cursor = Cursors.ArrowCD
                Case "Arrow"
                    DisplayArea.Cursor = Cursors.Arrow
                Case "Cross"
                    DisplayArea.Cursor = Cursors.Cross
                Case "HandCursor"
                    DisplayArea.Cursor = Cursors.Hand
                Case "Help"
                    DisplayArea.Cursor = Cursors.Help
                Case "IBeam"
                    DisplayArea.Cursor = Cursors.IBeam
                Case "No"
                    DisplayArea.Cursor = Cursors.No
                Case "None"
                    DisplayArea.Cursor = Cursors.None
                Case "Pen"
                    DisplayArea.Cursor = Cursors.Pen
                Case "ScrollSE"
                    DisplayArea.Cursor = Cursors.ScrollSE
                Case "ScrollWE"
                    DisplayArea.Cursor = Cursors.ScrollWE
                Case "SizeAll"
                    DisplayArea.Cursor = Cursors.SizeAll
                Case "SizeNESW"
                    DisplayArea.Cursor = Cursors.SizeNESW
                Case "SizeNS"
                    DisplayArea.Cursor = Cursors.SizeNS
                Case "SizeNWSE"
                    DisplayArea.Cursor = Cursors.SizeNWSE
                Case "SizeWE"
                    DisplayArea.Cursor = Cursors.SizeWE
                Case "UpArrow"
                    DisplayArea.Cursor = Cursors.UpArrow
                Case "WaitCursor"
                    DisplayArea.Cursor = Cursors.Wait
                Case "Custom"
                    DisplayArea.Cursor = CustomCursor
            End Select

            ' if the cursor scope is set to the entire application
            ' use OverrideCursor to force the cursor for all elements
            If (cursorScopeElementOnly = False) Then
                Mouse.OverrideCursor = DisplayArea.Cursor
            End If


        End Sub
        '</SnippetChangeCursorsSample>

        '<SnippetCursorsSampleOverrideCursor>
        ' Determines the scope the new cursor will have.
        '
        ' If the RadioButton rbScopeElement is selected, then the cursor
        ' will only change on the display element.
        ' 
        ' If the Radiobutton rbScopeApplication is selected, then the cursor
        ' will be changed for the entire application.
        '
        Private Sub CursorScopeSelected(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim source As RadioButton = CType(e.Source, RadioButton)

            If (source.Name = "rbScopeElement") Then
                ' Setting the element only scope flag to true.
                cursorScopeElementOnly = True
                ' Clearing out the OverrideCursor.
                Mouse.OverrideCursor = Nothing

            End If
            If (source.Name = "rbScopeApplication") Then
                ' Setting the element only scope flag to false.
                cursorScopeElementOnly = False
                ' Forcing the cursor for all elements.
                Mouse.OverrideCursor = DisplayArea.Cursor
            End If
        End Sub
      '</SnippetCursorsSampleOverrideCursor>
    End Class
End Namespace

