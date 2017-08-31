Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.ComponentModel.Design
Imports Microsoft.Win32
Imports Microsoft.VisualStudio
Imports Microsoft.VisualStudio.Shell.Interop
Imports Microsoft.VisualStudio.OLE.Interop
Imports Microsoft.VisualStudio.Shell

''' <summary>
''' This is the class that implements the package exposed by this assembly.
'''
''' The minimum requirement for a class to be considered a valid package for Visual Studio
''' is to implement the IVsPackage interface and register itself with the shell.
''' This package uses the helper classes defined inside the Managed Package Framework (MPF)
''' to do it: it derives from the Package class that provides the implementation of the 
''' IVsPackage interface and uses the registration attributes defined in the framework to 
''' register itself and its components with the shell.
''' </summary>
' The PackageRegistration attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class
' is a package.
'
' The InstalledProductRegistration attribute is used to register the information needed to show this package
' in the Help/About dialog of Visual Studio.
    '
' The ProvideMenuResource attribute is needed to let the shell know that this package exposes some menus.
    '
' The ProvideToolWindow attribute registers a tool window exposed by this package.

    <PackageRegistration(UseManagedResourcesOnly := true), _ 
    InstalledProductRegistration("#110", "#112", "1.0", IconResourceID := 400), _
    ProvideMenuResource("Menus.ctmenu", 1), _
    ProvideToolWindow(GetType(MyToolWindow)), _    
    Guid(GuidList.guidTestToolWindowSearchVBPkgString)> _
    Public NotInheritable Class TestToolWindowSearchVBPackage
Inherits Package

''' <summary>
''' Default constructor of the package.
''' Inside this method you can place any initialization code that does not require 
''' any Visual Studio service because at this point the package object is created but 
''' not sited yet inside Visual Studio environment. The place to do all the other 
''' initialization is the Initialize method.
''' </summary>
Public Sub New()
    Trace.WriteLine(String.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", Me.GetType().Name))
End Sub

        ''' <summary>
''' This function is called when the user clicks the menu item that shows the 
''' tool window. See the Initialize method to see how the menu item is associated to 
''' this function using the OleMenuCommandService service and the MenuCommand class.
''' </summary>
Private Sub ShowToolWindow(ByVal sender As Object, ByVal e As EventArgs)
    ' Get the instance number 0 of this tool window. This window is single instance so this instance
    ' is actually the only one.
    ' The last flag is set to true so that if the tool window does not exists it will be created.
    Dim window As ToolWindowPane = Me.FindToolWindow(GetType(MyToolWindow), 0, True)
    If (window Is Nothing) Or (window.Frame Is Nothing) Then
        Throw New NotSupportedException(Resources.CanNotCreateWindow)
    End If

    Dim windowFrame As IVsWindowFrame = TryCast(window.Frame, IVsWindowFrame)
    Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(windowFrame.Show())
End Sub


''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' Overridden Package Implementation
#Region "Package Members"

''' <summary>
''' Initialization of the package; this method is called right after the package is sited, so this is the place
''' where you can put all the initialization code that rely on services provided by VisualStudio.
''' </summary>
Protected Overrides Sub Initialize()
    Trace.WriteLine(String.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", Me.GetType().Name))
    MyBase.Initialize()

            ' Add our command handlers for menu (commands must exist in the .vsct file)
    Dim mcs As OleMenuCommandService = TryCast(GetService(GetType(IMenuCommandService)), OleMenuCommandService)
    If Not mcs Is Nothing Then
                ' Create the command for the tool window
                Dim toolwndCommandID As New CommandID(GuidList.guidTestToolWindowSearchVBCmdSet, CInt(PkgCmdIDList.cmdidTestSearchWindowVB))
        Dim menuToolWin As New MenuCommand(New EventHandler(AddressOf ShowToolWindow), toolwndCommandID)
        mcs.AddCommand(menuToolWin)
            End If
        End Sub
#End Region

End Class
