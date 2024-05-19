
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports System.Windows.Automation
Imports System.Diagnostics
Imports System.IO
Imports System.Threading
Imports System.Text

Namespace UIAAutomationID_snip

    ''' <summary>
    ''' Interaction logic for FindByAutomationID.xaml
    ''' </summary>
    Partial Public Class FindByAutomationID
        Inherits Window
        Private targetApp As AutomationElement

        Public Sub New()
            InitializeComponent()
        End Sub


        Private Sub btnStartTarget_Click(ByVal src As Object, ByVal e As RoutedEventArgs)
            targetApp = StartTargetApp()
            If targetApp Is Nothing Then
                Throw New ApplicationException("Unable to start target application.")
            End If

        End Sub


        Private Sub btnFindElement_Click(ByVal src As Object, ByVal e As RoutedEventArgs)
            Dim targetElements As AutomationElementCollection = FindElementFromAutomationID(targetApp, tbAutomationID.Text)
            System.Windows.MessageBox.Show(targetElements.Count.ToString())

        End Sub


        ' <Snippet100>
        '''--------------------------------------------------------------------
        ''' <summary>
        ''' Finds all elements in the UI Automation tree that have a specified
        ''' AutomationID.
        ''' </summary>
        ''' <param name="targetApp">
        ''' The root element from which to start searching.
        ''' </param>
        ''' <param name="automationID">
        ''' The AutomationID value of interest.
        ''' </param>
        ''' <returns>
        ''' The collection of automation elements that have the specified
        ''' AutomationID value.
        ''' </returns>
        '''--------------------------------------------------------------------
        Private Function FindElementFromAutomationID( _
        ByVal targetApp As AutomationElement, _
        ByVal automationID As String) As AutomationElementCollection
            Return targetApp.FindAll( _
            TreeScope.Descendants, _
            New PropertyCondition( _
            AutomationElement.AutomationIdProperty, automationID))
        End Function 'FindElementFromAutomationID
        ' </Snippet100>

        ''' <summary>
        ''' Starts the target application.
        ''' </summary>
        ''' <returns>The target automation element.</returns>
        Private Function StartTargetApp() As AutomationElement
            Try
                ' Start application.
                Dim p As Process = Process.Start("Notepad.exe")
                'Process.Start(System.Windows.Forms.Application.StartupPath +
                '"\\AutomationID_snip_Win32Target.exe");
                ' Give application some time to startup.
                If p.WaitForInputIdle(10000) = False Then
                    Return Nothing
                End If

                ' Only necessary for WPF applications that don't implement WaitForInputIdle correctly
                'Thread.Sleep(5000);
                ' Return the automation element
                Return AutomationElement.FromHandle(p.MainWindowHandle)
            Catch
                ' To do: error handling
                Return Nothing
            End Try

        End Function 'StartTargetApp


        ' <SnippetUIAWorkerThread>
        '''--------------------------------------------------------------------
        ''' <summary>
        ''' Creates a UI Automation thread.
        ''' </summary>
        ''' <param name="sender">Object that raised the event.</param>
        ''' <param name="e">Event arguments.</param>
        ''' <remarks>
        ''' UI Automation must be called on a separate thread if the client
        ''' application itself could become a target for event handling.
        ''' For example, focus tracking is a desktop event that could involve
        ''' the client application.
        ''' </remarks>
        '''--------------------------------------------------------------------
        Private Sub CreateUIAThread(ByVal sender As Object, ByVal e As EventArgs)

            ' Start another thread to do the UI Automation work.
            Dim threadDelegate As New ThreadStart(AddressOf CreateUIAWorker)
            Dim workerThread As New Thread(threadDelegate)
            workerThread.Start()

        End Sub


        '''--------------------------------------------------------------------
        ''' <summary>
        ''' Delegated method for ThreadStart. Creates a UI Automation worker
        ''' class that does all UI Automation related work.
        ''' </summary>
        '''--------------------------------------------------------------------
        Public Sub CreateUIAWorker()

            uiautoWorker = New UIAWorker(targetApp)

        End Sub

        Private uiautoWorker As UIAWorker

        ' </SnippetUIAWorkerThread>
        ' <SnippetPlayback>
        '''--------------------------------------------------------------------
        ''' <summary>
        ''' Function to playback through a series of recorded events calling
        ''' a WriteToScript function for each event of interest.
        ''' </summary>
        ''' <remarks>
        ''' A major drawback to using AutomationID for recording user
        ''' interactions in a volatile UI is the probability of catastrophic
        ''' change in the UI. For example, the 'Processes' dialog where items
        ''' in the listbox container can change with no input from the user.
        ''' This mandates that a record and playback application must be
        ''' reliant on the tester owning the UI being tested. In other words,
        ''' there has to be a contract between the provider and client that
        ''' excludes uncontrolled, external applications. The added benefit
        ''' is the guarantee that each control in the UI should have an
        ''' AutomationID assigned to it.
        '''
        ''' This function relies on a UI Automation worker class to create
        ''' the System.Collections.Generic.Queue object that stores the
        ''' information for the recorded user interactions. This
        ''' allows post-processing of the recorded items prior to actually
        ''' writing them to a script. If this is not necessary the interaction
        ''' could be written to the script immediately.
        ''' </remarks>
        '''--------------------------------------------------------------------
        Private Sub Playback(ByVal targetApp As AutomationElement)

            Dim element As AutomationElement
            Dim storedItem As ElementStore
            For Each storedItem In uiautoWorker.elementQueue
                Dim propertyCondition As New PropertyCondition( _
                AutomationElement.AutomationIdProperty, storedItem.AutomationID)
                ' Confirm the existence of a control.
                ' Depending on the controls and complexity of interaction
                ' this step may not be necessary or may require additional
                ' functionality. For example, to confirm the existence of a
                ' child menu item that had been invoked the parent menu item
                ' would have to be expanded.
                element = targetApp.FindFirst( _
                TreeScope.Descendants, propertyCondition)
                If element Is Nothing Then
                    ' Control not available, unable to continue.
                    ' TODO: Handle error condition.
                    Return
                End If
                WriteToScript(storedItem.AutomationID, storedItem.EventID)
            Next storedItem

        End Sub


        '''--------------------------------------------------------------------
        ''' <summary>
        ''' Generates script code and outputs the code to a text control in
        ''' the client.
        ''' </summary>
        ''' <param name="automationID">
        ''' The AutomationID of the current control.
        ''' </param>
        ''' <param name="eventID">
        ''' The event recorded on that control.
        ''' </param>
        '''--------------------------------------------------------------------
        Private Sub WriteToScript( _
        ByVal automationID As String, ByVal eventID As String)

            ' Script code would be generated and written to an output file
            ' as plain text at this point, but for the
            ' purposes of this example we just write to the console.
            Console.WriteLine(automationID + " - " + eventID)

        End Sub
        ' </SnippetPlayback>

        Class TargetApplication

            Public Property AutomationElement() As AutomationElement
                Get
                    Return target
                End Get
                Set(ByVal value As AutomationElement)
                    target = value
                End Set
            End Property
            Private target As AutomationElement
        End Class
    End Class
    '
    'ToDo: Error processing original source shown below
    '    }
    '}
    '-^--- expression expected

End Namespace
