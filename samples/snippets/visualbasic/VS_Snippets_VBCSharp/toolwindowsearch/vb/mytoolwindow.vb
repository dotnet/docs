' Walkthrough: Adding Search to a Tool Window
' f78c4892-8060-49c4-8ecd-4360f1b4d133

'<Snippet3>
Imports System
Imports System.Collections.Generic
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Controls
Imports Microsoft.Internal.VisualStudio.PlatformUI
Imports Microsoft.VisualStudio
Imports Microsoft.VisualStudio.PlatformUI
Imports Microsoft.VisualStudio.Shell
Imports Microsoft.VisualStudio.Shell.Interop
'</Snippet3>



''' <summary>
''' This class implements the tool window exposed by this package and hosts a user control.
'''
''' In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane, 
''' usually implemented by the package implementer.
'''
''' This class derives from the ToolWindowPane class provided from the MPF in order to use its 
''' implementation of the IVsUIElementPane interface.
''' </summary>
<Guid("dd3f95d9-1f87-4fdc-9019-adac667908ed")> _
Public Class MyToolWindow
    Inherits ToolWindowPane

    ''' <summary>
    ''' Standard constructor for the tool window.
    ''' </summary>
    Public Sub New()
        MyBase.New(Nothing)
        ' Set the window title reading it from the resources.
        Me.Caption = Resources.ToolWindowTitle
        ' Set the image that will appear on the tab of the window frame
        ' when docked with an other window
        ' The resource ID correspond to the one defined in the resx file
        ' while the Index is the offset in the bitmap strip. Each image in
        ' the strip being 16x16.
        Me.BitmapResourceID = 301
        Me.BitmapIndex = 1

        'This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
        'we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on 
        'the object returned by the Content property.
        Me.Content = New MyControl()
    End Sub

    '<Snippet2>
    Public Overrides ReadOnly Property SearchEnabled As Boolean
        Get
            Return True
        End Get
    End Property
    '</Snippet2>


    '<Snippet4>
    Public Overrides Function CreateSearch(ByVal dwCookie As UInteger, ByVal pSearchQuery As IVsSearchQuery, ByVal pSearchCallback As IVsSearchCallback) As IVsSearchTask
        If pSearchQuery Is Nothing Or pSearchCallback Is Nothing Then
            Return Nothing
        Else
            Return New TestSearchTask(dwCookie, pSearchQuery, pSearchCallback, Me)
        End If
    End Function

    Public Overrides Sub ClearSearch()
        Dim control = DirectCast(Me.Content, MyControl)
        control.SearchResultsTextBox.Text = control.SearchContent
    End Sub

    Friend Class TestSearchTask
        Inherits VsSearchTask

        Private m_toolWindow As MyToolWindow

        Public Sub New(ByVal dwCookie As UInteger, ByVal pSearchQuery As IVsSearchQuery, ByVal pSearchCallback As IVsSearchCallback, ByVal toolwindow As MyToolWindow)
            MyBase.New(dwCookie, pSearchQuery, pSearchCallback)

            m_toolWindow = toolwindow
        End Sub

        Protected Overrides Sub OnStartSearch()
            ' Use the original content of the text box as the target of the search.
            Dim separator = New String() {Environment.NewLine}
            Dim contentArr As String() = DirectCast(m_toolWindow.Content, MyControl).SearchContent.Split(separator, StringSplitOptions.None)

            ' Get the search option.
            Dim matchCase As Boolean = False
            ' matchCase = m_toolWindow.MatchCaseOption.Value

            ' Set variables that are used in the finally block.
            Dim sb As New StringBuilder("")
            Dim resultCount As UInteger = 0
            Me.ErrorCode = VSConstants.S_OK

            Try
                Dim searchString As String = Me.SearchQuery.SearchString

                ' Determine the results.
                Dim progress As UInteger = 0
                For Each line As String In contentArr

                    If matchCase = True Then
                        If line.Contains(searchString) Then
                            sb.AppendLine(line)
                            resultCount += 1
                        End If
                    Else
                        If line.ToLower().Contains(searchString.ToLower()) Then
                            sb.AppendLine(line)
                            resultCount += 1
                        End If
                    End If
                    ' SearchCallback.ReportProgress(Me, progress, CUInt(contentArr.GetLength(0)))
                    ' progress += 1

                    ' Uncomment the following line to demonstrate the progress bar.
                    '<Snippet8>
                    ' System.Threading.Thread.Sleep(100)
                    '</Snippet8>
                Next
            Catch e As Exception
                Me.ErrorCode = VSConstants.E_FAIL
            Finally
                ThreadHelper.Generic.Invoke(
                    Sub()
                        DirectCast(DirectCast(m_toolWindow.Content, MyControl).SearchResultsTextBox, TextBox).Text = sb.ToString()
                    End Sub)

                Me.SearchResults = resultCount
            End Try

            ' Call the implementation of this method in the base class.
            ' This sets the task status to complete and reports task completion.
            MyBase.OnStartSearch()
        End Sub

        Protected Overrides Sub OnStopSearch()
            Me.SearchResults = 0
        End Sub
    End Class
    '</Snippet4>


    Friend Class TestSearchTask2
        Inherits VsSearchTask

        Private m_toolWindow As MyToolWindow

        Public Sub New(ByVal dwCookie As UInteger, ByVal pSearchQuery As IVsSearchQuery, ByVal pSearchCallback As IVsSearchCallback, ByVal toolwindow As MyToolWindow)
            MyBase.New(dwCookie, pSearchQuery, pSearchCallback)

            m_toolWindow = toolwindow
        End Sub

        Private Sub Misc()
            '<Snippet7>
            System.Threading.Thread.Sleep(100)
            '</Snippet7>
        End Sub

        '<Snippet13>
        Private Function RemoveFromString(ByVal origString As String, ByVal stringToRemove As String) As String
            Dim index As Integer = origString.IndexOf(stringToRemove)
            If index = -1 Then
                Return origString
            Else
                Return origString.Substring(0, index) & origString.Substring(index + stringToRemove.Length)
            End If
        End Function

        Private Function GetEvenItems(ByVal contentArr As String()) As String()
            Dim length As Integer = contentArr.Length \ 2
            Dim evenContentArr = New String(length) {}

            Dim indexB = 0
            For index = 1 To contentArr.Length - 1 Step 2
                evenContentArr(indexB) = contentArr(index)
                indexB += 1
            Next

            Return evenContentArr
        End Function
        '</Snippet13>

        '<Snippet14>
        Protected Overrides Sub OnStartSearch()
            ' Use the original content of the text box as the target of the search.
            Dim separator = New String() {Environment.NewLine}
            Dim contentArr As String() = DirectCast(m_toolWindow.Content, MyControl).SearchContent.Split(separator, StringSplitOptions.None)

            ' Get the search option.
            Dim matchCase As Boolean = False
            '<Snippet11>
            matchCase = m_toolWindow.MatchCaseOption.Value
            '</Snippet11>

            ' Set variables that are used in the finally block.
            Dim sb As New StringBuilder("")
            Dim resultCount As UInteger = 0
            Me.ErrorCode = VSConstants.S_OK

            Try
                Dim searchString As String = Me.SearchQuery.SearchString

                ' If the search string contains the filter string, filter the content array.
                Dim filterString = "lines:""even"""

                If searchString.Contains(filterString) Then
                    ' Retain only the even items in the array.
                    contentArr = GetEvenItems(contentArr)

                    ' Remove 'lines:"even"' from the search string.
                    searchString = RemoveFromString(searchString, filterString)
                End If

                ' Determine the results.
                Dim progress As UInteger = 0
                For Each line As String In contentArr
                    If matchCase = True Then
                        If line.Contains(searchString) Then
                            sb.AppendLine(line)
                            resultCount += 1
                        End If
                    Else
                        If line.ToLower().Contains(searchString.ToLower()) Then
                            sb.AppendLine(line)
                            resultCount += 1
                        End If
                    End If

                    '<Snippet15>
                    SearchCallback.ReportProgress(Me, progress, CUInt(contentArr.GetLength(0)))
                    progress += 1
                    '</Snippet15>

                    ' Uncomment the following line to demonstrate the progress bar.
                    ' System.Threading.Thread.Sleep(100)
                Next
            Catch e As Exception
                Me.ErrorCode = VSConstants.E_FAIL
            Finally
                ThreadHelper.Generic.Invoke(
                    Sub()
                        DirectCast(DirectCast(m_toolWindow.Content, MyControl).SearchResultsTextBox, TextBox).Text = sb.ToString()
                    End Sub)

                Me.SearchResults = resultCount
            End Try

            ' Call the implementation of this method in the base class.
            ' This sets the task status to complete and reports task completion.
            MyBase.OnStartSearch()
        End Sub
        '</Snippet14>

        Protected Overrides Sub OnStopSearch()
            Me.SearchResults = 0
        End Sub
    End Class


    '<Snippet5>
    Public Overrides Sub ProvideSearchSettings(ByVal pSearchSettings As IVsUIDataSource)
        Utilities.SetValue(pSearchSettings, SearchSettingsDataSource.SearchStartTypeProperty.Name, CUInt(VSSEARCHSTARTTYPE.SST_INSTANT))
    End Sub
    '</Snippet5>

    Private Sub ProvideSearchSettings2(ByVal pSearchSettings As IVsUIDataSource)
        '<Snippet6>
        Utilities.SetValue(pSearchSettings, SearchSettingsDataSource.SearchProgressTypeProperty.Name, CUInt(VSSEARCHPROGRESSTYPE.SPT_DETERMINATE))
        '</Snippet6>
    End Sub

    '<Snippet9>
    Private m_optionsEnum As IVsEnumWindowSearchOptions
    Public Overrides ReadOnly Property SearchOptionsEnum() As IVsEnumWindowSearchOptions
        Get
            If m_optionsEnum Is Nothing Then
                Dim list As New List(Of IVsWindowSearchOption)()

                list.Add(Me.MatchCaseOption)

                m_optionsEnum = TryCast(New WindowSearchOptionEnumerator(list), IVsEnumWindowSearchOptions)
            End If

            Return m_optionsEnum
        End Get
    End Property

    Private m_matchCaseOption As WindowSearchBooleanOption
    Public ReadOnly Property MatchCaseOption
        Get
            If m_matchCaseOption Is Nothing Then
                m_matchCaseOption = New WindowSearchBooleanOption("Match case", "Match case", False)
            End If

            Return m_matchCaseOption
        End Get
    End Property
    '</Snippet9>

    '<Snippet12>
    Public Overrides ReadOnly Property SearchFiltersEnum() As IVsEnumWindowSearchFilters
        Get
            Dim list As New List(Of IVsWindowSearchFilter)()
            list.Add(New WindowSearchSimpleFilter("Search even lines only", "Search even lines only", "lines", "even"))
            Return TryCast(New WindowSearchFilterEnumerator(list), IVsEnumWindowSearchFilters)
        End Get
    End Property
    '</Snippet12>

End Class
