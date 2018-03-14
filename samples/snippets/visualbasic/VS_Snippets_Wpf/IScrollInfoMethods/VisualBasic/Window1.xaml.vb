Imports System     
Imports System.Windows     
Imports System.Windows.Controls     
Imports System.Windows.Controls.Primitives     
Imports System.Windows.Documents     
Imports System.Windows.Navigation     
Imports System.Text     

namespace ScrollViewer_Methods

    Partial Public Class Window1
        Inherits Window
        ' <Snippet4>
        Private Sub onLoad(ByVal sender As Object, ByVal args As RoutedEventArgs)
            CType(sp1, IScrollInfo).CanVerticallyScroll = True
            CType(sp1, IScrollInfo).CanHorizontallyScroll = True
            CType(sp1, IScrollInfo).ScrollOwner = sv1
        End Sub
        '</Snippet4>

        ' <Snippet3>
        Private Sub spLineUp(ByVal sender As Object, ByVal args As RoutedEventArgs)

            CType(sp1, IScrollInfo).LineUp()
        End Sub
        Private Sub spLineDown(ByVal sender As Object, ByVal args As RoutedEventArgs)

            CType(sp1, IScrollInfo).LineDown()
        End Sub
        ' </Snippet3>

        ' <Snippet5>
        Private Sub spLineRight(ByVal sender As Object, ByVal args As RoutedEventArgs)

            CType(sp1, IScrollInfo).LineRight()
        End Sub
        ' </Snippet5>

        ' <Snippet6>
        Private Sub spLineLeft(ByVal sender As Object, ByVal args As RoutedEventArgs)

            CType(sp1, IScrollInfo).LineLeft()
        End Sub
        ' </Snippet6>

        ' <Snippet7>
        Private Sub spPageUp(ByVal sender As Object, ByVal args As RoutedEventArgs)

            CType(sp1, IScrollInfo).PageUp()
        End Sub
        ' </Snippet7>

        ' <Snippet8>
        Private Sub spPageDown(ByVal sender As Object, ByVal args As RoutedEventArgs)

            CType(sp1, IScrollInfo).PageDown()
        End Sub
        ' </Snippet8>

        ' <Snippet9>
        Private Sub spPageRight(ByVal sender As Object, ByVal args As RoutedEventArgs)

            CType(sp1, IScrollInfo).PageRight()
        End Sub
        ' </Snippet9>

        ' <Snippet10>
        Private Sub spPageLeft(ByVal sender As Object, ByVal args As RoutedEventArgs)

            CType(sp1, IScrollInfo).PageLeft()
        End Sub
        ' </Snippet10>

        ' <Snippet11>
        Private Sub spMouseWheelDown(ByVal sender As Object, ByVal args As RoutedEventArgs)

            CType(sp1, IScrollInfo).MouseWheelDown()
        End Sub
        ' </Snippet11>

        ' <Snippet12>
        Private Sub spMouseWheelUp(ByVal sender As Object, ByVal args As RoutedEventArgs)

            CType(sp1, IScrollInfo).MouseWheelUp()
        End Sub
        ' </Snippet12>

        ' <Snippet13>
        Private Sub spMouseWheelLeft(ByVal sender As Object, ByVal args As RoutedEventArgs)

            CType(sp1, IScrollInfo).MouseWheelLeft()
        End Sub
        ' </Snippet13>

        ' <Snippet14>
        Private Sub spMouseWheelRight(ByVal sender As Object, ByVal args As RoutedEventArgs)

            CType(sp1, IScrollInfo).MouseWheelRight()
        End Sub
        ' </Snippet14>
    End Class
    End Namespace
