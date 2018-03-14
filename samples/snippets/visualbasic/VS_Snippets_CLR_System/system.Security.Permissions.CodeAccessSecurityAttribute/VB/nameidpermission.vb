#Const debug = True
' This custom permission is intended only for the purposes of illustration.
' The following code shows how to create a custom permission that inherits
' from CodeAccessPermission. The code implements all required overrides.
' A wildcard character ('*') is implemented for the Name property.
Imports System
Imports System.Security
Imports System.Security.Permissions
Imports System.IO
Imports System.Security.Policy
Imports System.Collections
Imports Microsoft.VisualBasic

' Use the command line option '/keyfile' or appropriate project settings to sign this assembly.
<Assembly: System.Security.AllowPartiallyTrustedCallersAttribute()> 
Namespace MyPermission

    <Serializable()> _
                   Public NotInheritable Class NameIdPermission
        Inherits CodeAccessPermission
        Implements IUnrestrictedPermission
        Private m_Name As String
        Private m_Unrestricted As Boolean


        Public Sub New(ByVal name As String)
            m_name = name
        End Sub 'New


        Public Sub New(ByVal state As PermissionState)
            If state = PermissionState.None Then
                m_name = ""
            ElseIf state = PermissionState.Unrestricted Then
                Throw New ArgumentException("Unrestricted state is not allowed for identity permissions.")
            Else
                Throw New ArgumentException("Invalid permission state.")
            End If
        End Sub 'New 

        Public Property Name() As String
            Get
                Return m_name
            End Get
            Set(ByVal Value As String)
                m_name = Value
            End Set
        End Property

        Public Overrides Function Copy() As IPermission
            Dim name As String
            name = m_name
            Return New NameIdPermission(name)
        End Function 'Copy

        Public Function IsUnrestricted() As Boolean Implements IUnrestrictedPermission.IsUnrestricted
            ' Always false, unrestricted state is not allowed.
            Return m_Unrestricted
        End Function 'IsUnrestricted

        Private Function VerifyType(ByVal target As IPermission) As Boolean
            Return TypeOf target Is NameIdPermission
        End Function 'VerifyType

        Public Overrides Function IsSubsetOf(ByVal target As IPermission) As Boolean

#If (Debug) Then

            Console.WriteLine("************* Entering IsSubsetOf *********************")
#End If
            If target Is Nothing Then
                Console.WriteLine("IsSubsetOf: target == null")
                Return False
            End If
#If (Debug) Then
            Console.WriteLine(("This is = " + CType(Me, NameIdPermission).Name))
            Console.WriteLine(("Target is " + CType(target, NameIdPermission).m_name))
#End If
            Try
                Dim operand As NameIdPermission = CType(target, NameIdPermission)

                ' The following check for unrestricted permission is only included as an example for
                ' permissions that allow the unrestricted state. It is of no value for this permission.
                If True = operand.m_Unrestricted Then
                    Return True
                ElseIf True = Me.m_Unrestricted Then
                    Return False
                End If

                If Not (Me.m_name Is Nothing) Then
                    If operand.m_name Is Nothing Then
                        Return False
                    End If
                    If Me.m_name = "" Then
                        Return True
                    End If
                End If
                If Me.m_name.Equals(operand.m_name) Then
                    Return True
                Else
                    ' Check for wild card character '*'.
                    Dim i As Integer = operand.m_name.LastIndexOf("*")

                    If i > 0 Then
                        Dim prefix As String = operand.m_name.Substring(0, i)

                        If Me.m_name.StartsWith(prefix) Then
                            Return True
                        End If
                    End If
                End If

                Return False
            Catch
                Throw New ArgumentException(String.Format("Argument_WrongType", Me.GetType().FullName))
            End Try
        End Function 'IsSubsetOf

        Public Overrides Function Intersect(ByVal target As IPermission) As IPermission
            Console.WriteLine("************* Entering Intersect *********************")
            If target Is Nothing Then
                Return Nothing
            End If
#If (Debug) Then

            Console.WriteLine(("This is = " + CType(Me, NameIdPermission).Name))
            Console.WriteLine(("Target is " + CType(target, NameIdPermission).m_name))
#End If
            If Not VerifyType(target) Then
                Throw New ArgumentException(String.Format("Argument is wrong type.", Me.GetType().FullName))
            End If

            Dim operand As NameIdPermission = CType(target, NameIdPermission)

            If operand.IsSubsetOf(Me) Then
                Return operand.Copy()
            ElseIf Me.IsSubsetOf(operand) Then
                Return Me.Copy()
            Else
                Return Nothing
            End If
        End Function 'Intersect

        Public Overrides Function Union(ByVal target As IPermission) As IPermission
#If (Debug) Then

            Console.WriteLine("************* Entering Union *********************")
#End If
            If target Is Nothing Then
                Return Me
            End If
#If (Debug) Then
            Console.WriteLine(("This is = " + CType(Me, NameIdPermission).Name))
            Console.WriteLine(("Target is " + CType(target, NameIdPermission).m_name))
#End If
            If Not VerifyType(target) Then
                Throw New ArgumentException(String.Format("Argument_WrongType", Me.GetType().FullName))
            End If

            Dim operand As NameIdPermission = CType(target, NameIdPermission)

            If operand.IsSubsetOf(Me) Then
                Return Me.Copy()
            ElseIf Me.IsSubsetOf(operand) Then
                Return operand.Copy()
            Else
                Return Nothing
            End If
        End Function 'Union

        Public Overrides Sub FromXml(ByVal e As SecurityElement)
            ' The following code for unrestricted permission is only included as an example for
            ' permissions that allow the unrestricted state. It is of no value for this permission.
            Dim elUnrestricted As String = e.Attribute("Unrestricted")
            If Nothing <> elUnrestricted Then
                m_Unrestricted = Boolean.Parse(elUnrestricted)
                Return
            End If

            Dim elName As String = e.Attribute("Name")
            m_name = IIf(elName Is Nothing, Nothing, elName)
        End Sub 'FromXml

        Public Overrides Function ToXml() As SecurityElement
            ' Use the SecurityElement class to encode the permission to XML.
            Dim esd As New SecurityElement("IPermission")

            Dim name As String = GetType(NameIdPermission).AssemblyQualifiedName
            esd.AddAttribute("class", name)
            esd.AddAttribute("version", "1.0")

            ' The following code for unrestricted permission is only included as an example for
            ' permissions that allow the unrestricted state. It is of no value for this permission.
            If m_Unrestricted Then
                esd.AddAttribute("Unrestricted", True.ToString())
            End If
            If Not (m_Name Is Nothing) Then
                esd.AddAttribute("Name", m_Name)
            End If
            Return esd
        End Function 'ToXml
    End Class ' NameIdPermission 
End Namespace
