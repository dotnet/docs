'<Snippet1>
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

'   This sample demonstrates how to perform a series of actions in a designer 
'   transaction, how to change values of properties of a component from a 
'   designer, and how to complete transactions without being interrupted 
'   by other activities.

'   To run this sample, add this code to a class library project and compile. 
'   Create a new Windows Forms project or load a form in the designer. Add a 
'   reference to the class library that was compiled in the first step.
'   Right-click the Toolbox in design mode and click Customize Toolbox.  
'   Browse to the class library that was compiled in the first step and 
'   select OK until the DTComponent item appears in the Toolbox.  Add an 
'   instance of this component to the form.  

'   When the component is created and added to the component tray for your
'   design project, the Initialize method of the designer is called. 
'   This method displays a message box informing you that designer transaction
'   event handlers are being registered unless you click Cancel. When you set 
'   properties in the properties window, each change will be encapsulated in 
'   a designer transaction, allowing the change to be undone later.  

'   When you right-click the component, the shortcut menu for the component 
'   is displayed. The designer constructs this menu according to whether 
'   designer transaction notifications are enabled, and offers the option
'   of enabling or disabling the notifications, depending on the current 
'   mode. The shortcut menu also presents a Perform Example Transaction 
'   item which will set the values of the component's StringProperty and 
'   CountProperty properties. You can undo the last designer transaction using 
'   the Undo command provided by the Visual Studio development environment.	

Namespace DesignerTransactionSample

    ' Associate the DTDesigner with this component
    <DesignerAttribute(GetType(DTDesigner))> _
    Public Class DTComponent
        Inherits System.ComponentModel.Component
        Private m_String As String
        Private m_Count As Integer

        Public Property StringProperty() As String
            Get
                Return m_String
            End Get
            Set(ByVal Value As String)
                m_String = Value
            End Set
        End Property

        Public Property CountProperty() As Integer
            Get
                Return m_Count
            End Get
            Set(ByVal Value As Integer)
                m_Count = Value
            End Set
        End Property

        Private Sub InitializeComponent()
            m_String = "Initial Value"
            m_Count = 0
        End Sub 'InitializeComponent

    End Class 'DTComponent

    Friend Class DTDesigner
        Inherits ComponentDesigner

        Private notification_mode As Boolean = False
        Private count As Integer = 10

        ' The Verbs property is overridden from ComponentDesigner
        Public Overrides ReadOnly Property Verbs() As DesignerVerbCollection
            Get
                Dim dvc As New DesignerVerbCollection()
                dvc.Add(New DesignerVerb("Perform Example Transaction", AddressOf Me.DoTransaction))
                If notification_mode Then
                    dvc.Add(New DesignerVerb("End Designer Transaction Notifications", AddressOf Me.UnlinkDTNotifications))
                Else
                    dvc.Add(New DesignerVerb("Show Designer Transaction Notifications", AddressOf Me.LinkDTNotifications))
                End If
                Return dvc
            End Get
        End Property

        Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
            MyBase.Initialize(component)

            Dim host As IDesignerHost = CType(GetService(GetType(IDesignerHost)), IDesignerHost)
            If host Is Nothing Then
                MessageBox.Show("The IDesignerHost service interface could not be obtained.")
                Return
            End If

            If MessageBox.Show("Press the Yes button to display notification message boxes for the designer transaction opened and closed notifications.", "Link DesignerTransaction Notifications?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) = DialogResult.Yes Then
                AddHandler host.TransactionOpened, AddressOf OnDesignerTransactionOpened
                AddHandler host.TransactionClosed, AddressOf OnDesignerTransactionClosed
                notification_mode = True
            End If
        End Sub 'Initialize

        Private Sub LinkDTNotifications(ByVal sender As Object, ByVal e As EventArgs)
            If notification_mode = False Then
                Dim host As IDesignerHost = CType(GetService(GetType(IDesignerHost)), IDesignerHost)
                If (host IsNot Nothing) Then
                    notification_mode = True
                    AddHandler host.TransactionOpened, AddressOf OnDesignerTransactionOpened
                    AddHandler host.TransactionClosed, AddressOf OnDesignerTransactionClosed
                End If
            End If
        End Sub 'LinkDTNotifications

        Private Sub UnlinkDTNotifications(ByVal sender As Object, ByVal e As EventArgs)
            If notification_mode Then
                Dim host As IDesignerHost = CType(GetService(GetType(IDesignerHost)), IDesignerHost)
                If (host IsNot Nothing) Then
                    notification_mode = False
                    RemoveHandler host.TransactionOpened, AddressOf Me.OnDesignerTransactionOpened
                    RemoveHandler host.TransactionClosed, AddressOf Me.OnDesignerTransactionClosed
                End If
            End If
        End Sub 'UnlinkDTNotifications

        Private Sub OnDesignerTransactionOpened(ByVal sender As Object, ByVal e As EventArgs)
            System.Windows.Forms.MessageBox.Show("A Designer Transaction was started. (TransactionOpened)")
        End Sub 'OnDesignerTransactionOpened

        Private Sub OnDesignerTransactionClosed(ByVal sender As Object, ByVal e As DesignerTransactionCloseEventArgs)
            System.Windows.Forms.MessageBox.Show("A Designer Transaction was completed. (TransactionClosed)")
        End Sub 'OnDesignerTransactionClosed

        Private Sub DoTransaction(ByVal sender As Object, ByVal e As EventArgs)
            Dim host As IDesignerHost = CType(GetService(GetType(IDesignerHost)), IDesignerHost)
            Dim t As DesignerTransaction = host.CreateTransaction("Change Text and Size")

            ' The code within the using statement is considered to be a single transaction.
            ' When the user selects Undo, the system will undo everything executed in this code block. 
            Try
                If (notification_mode) Then
                    System.Windows.Forms.MessageBox.Show("Entering a Designer-Initiated Designer Transaction")
                End If

                Dim someText As PropertyDescriptor = TypeDescriptor.GetProperties(Component)("StringProperty")
                someText.SetValue(Component, "This text was set by the designer for this component.")
                Dim anInteger As PropertyDescriptor = TypeDescriptor.GetProperties(Component)("CountProperty")
                anInteger.SetValue(Component, count)
                count = count + 1

                Exit Try
            Finally
                t.Commit()                
            End Try
            If (notification_mode) Then
                System.Windows.Forms.MessageBox.Show("Designer-Initiated Designer Transaction Completed")
            End If
        End Sub 'DoTransaction

        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            UnlinkDTNotifications(Me, New EventArgs())
            MyBase.Dispose(disposing)
        End Sub 'Dispose

    End Class 'DTDesigner
End Namespace 'DesignerTransactionSample
'</Snippet1>