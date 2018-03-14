 '<Snippet1>
' To use the custom trust manager MyTrustManager, compile it into CustomTrustManager.dll, 
' place that assembly in the GAC, and  put the following elements in
' an ApplicationTrust.config file in the config folder in the Microsoft .NET framework
' installation folder.
'<?xml version="1.0" encoding="utf-8" ?>
'<configuration>
'    <mscorlib>
'        <security>
'            <policy>
'                <ApplicationSecurityManager>
'                    <ApplicationEntries />
'                    <IApplicationTrustManager class="MyNamespace.MyTrustManager, CustomTrustManager, Version=1.0.0.3, Culture=neutral, PublicKeyToken=5659fc598c2a503e"/>
'                </ApplicationSecurityManager>
'            </policy>
'        </security>
'    </mscorlib>
'</configuration>
Imports System
Imports System.Security
Imports System.Security.Policy
Imports System.Windows.Forms


Public Class MyTrustManager
    Implements IApplicationTrustManager
    
    '<Snippet2>
    Public Function DetermineApplicationTrust(ByVal appContext As ActivationContext, ByVal context As TrustManagerContext) As ApplicationTrust Implements IApplicationTrustManager.DetermineApplicationTrust
        Dim trust As New ApplicationTrust(appContext.Identity)
        trust.IsApplicationTrustedToRun = False

        Dim asi As New ApplicationSecurityInfo(appContext)
        trust.DefaultGrantSet = New PolicyStatement(asi.DefaultRequestSet, _
        PolicyStatementAttribute.Nothing)
        If context.UIContext = TrustManagerUIContext.Run Then
            Dim message As String = "Do you want to run " + asi.ApplicationId.Name + " ?"
            Dim caption As String = "MyTrustManager"
            Dim buttons As MessageBoxButtons = MessageBoxButtons.YesNo
            Dim result As DialogResult

            ' Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons)

            If result = DialogResult.Yes Then
                trust.IsApplicationTrustedToRun = True
                If Not (context Is Nothing) Then
                    trust.Persist = context.Persist
                Else
                    trust.Persist = False
                End If
            End If
        End If
        Return trust

    End Function 'DetermineApplicationTrust
    
    '</Snippet2>
    '<Snippet3>
    Public Function ToXml() As SecurityElement Implements IApplicationTrustManager.ToXml
        Dim se As New SecurityElement("IApplicationTrustManager")
        se.AddAttribute("class", GetType(MyTrustManager).AssemblyQualifiedName)
        Return se

    End Function 'ToXml
    
    '</Snippet3>
    '<Snippet4>
    Public Sub FromXml(ByVal se As SecurityElement) Implements IApplicationTrustManager.FromXml
        If se.Tag <> "IApplicationTrustManager" OrElse _
        CStr(se.Attributes("class")) <> GetType(MyTrustManager).AssemblyQualifiedName Then
            Throw New ArgumentException("Invalid tag")
        End If

    End Sub 'FromXml 
    '</Snippet4>
End Class 'MyTrustManager
'</Snippet1>