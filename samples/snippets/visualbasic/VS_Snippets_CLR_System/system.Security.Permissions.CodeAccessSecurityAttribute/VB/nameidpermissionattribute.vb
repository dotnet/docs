'<Snippet1>
Imports System
Imports System.IO
Imports System.Runtime.Remoting
Imports System.Security
Imports System.Security.Permissions
Imports System.Reflection
Imports MyPermission
Imports Microsoft.VisualBasic


' Use the command line option '/keyfile' or appropriate project settings to sign this assembly.
<Assembly: System.Security.AllowPartiallyTrustedCallersAttribute()> 
Namespace MyPermissionAttribute

    <AttributeUsage(AttributeTargets.All, AllowMultiple:=True, Inherited:=False)> Public NotInheritable Class NameIdPermissionAttribute
        Inherits CodeAccessSecurityAttribute
        Private m_Name As String = Nothing
        Private m_unrestricted As Boolean = False


        Public Sub New(ByVal action As SecurityAction)
            MyBase.New(action)
        End Sub 'New


        Public Property Name() As String
            Get
                Return m_name
            End Get
            Set(ByVal Value As String)
                m_name = Value
            End Set
        End Property

        Public Overrides Function CreatePermission() As IPermission
            If m_unrestricted Then
                Throw New ArgumentException("Unrestricted permissions not allowed in identity permissions.")
            Else
                If m_name Is Nothing Then
                    Return New NameIdPermission(PermissionState.None)
                End If
                Return New NameIdPermission(m_name)
            End If
        End Function 'CreatePermission
    End Class ' NameIdPermissionAttribute
End Namespace
'</Snippet1>
