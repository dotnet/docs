 ' Types:System.Security.IPermission Vendor:Richter
' Types:System.Security.ISecurityEncodable Vendor:Richter
'<snippet1>
Imports System
Imports System.Security
Imports System.Security.Permissions
Imports System.Reflection


' Enumerated type for permission states.
<Serializable()>  _
Public Enum SoundPermissionState
    NoSound = 0
    PlaySystemSounds = 1
    PlayAnySound = 2
End Enum 'SoundPermissionState

' Derive from CodeAccessPermission to gain implementations of the following
' sealed IStackWalk methods: Assert, Demand, Deny, and PermitOnly.
' Implement the following abstract IPermission methods: Copy, Intersect, and IsSubSetOf.
' Implementing the Union method of the IPermission class is optional.
' Implement the following abstract ISecurityEncodable methods: FromXml and ToXml.
' Making the class 'sealed' is optional.

NotInheritable Public Class SoundPermission
    Inherits CodeAccessPermission
    Implements IPermission, IUnrestrictedPermission, ISecurityEncodable, ICloneable
    Private m_specifiedAsUnrestricted As [Boolean] = False
    Private m_flags As SoundPermissionState = SoundPermissionState.NoSound
    ' This constructor creates and initializes a permission with generic access.
    Public Sub New(ByVal state As PermissionState) 
        m_specifiedAsUnrestricted = state = PermissionState.Unrestricted
    
    End Sub 'New    
    ' This constructor creates and initializes a permission with specific access.        
    Public Sub New(ByVal flags As SoundPermissionState) 
        If Not [Enum].IsDefined(GetType(SoundPermissionState), flags) Then
            Throw New ArgumentException("flags value is not valid for the SoundPermissionState enuemrated type")
        End If
        m_specifiedAsUnrestricted = False
        m_flags = flags
    
    End Sub 'New   
    ' For debugging, return the state of this object as XML.
    Public Overrides Function ToString() As String 
        Return ToXml().ToString()
    
    End Function 'ToString   
    ' Private method to cast (if possible) an IPermission to the type.
    Private Function VerifyTypeMatch(ByVal target As IPermission) As SoundPermission
        If [GetType]() <> target.GetType() Then
            Throw New ArgumentException(String.Format("target must be of the {0} type", [GetType]().FullName))
        End If
        Return CType(target, SoundPermission)

    End Function 'VerifyTypeMatch
    ' This is the Private Clone helper method. 
    Private Function Clone(ByVal specifiedAsUnrestricted As [Boolean], ByVal flags As SoundPermissionState) As SoundPermission
        Dim soundPerm As SoundPermission = CType(Clone(), SoundPermission)
        soundPerm.m_specifiedAsUnrestricted = specifiedAsUnrestricted
        soundPerm.m_flags = IIf(specifiedAsUnrestricted, SoundPermissionState.PlayAnySound, m_flags)
        Return soundPerm

    End Function 'Clone

#Region "IPermission Members"

    '<snippet2>
    ' Return a new object that contains the intersection of 'this' and 'target'.
    Public Overrides Function Intersect(ByVal target As IPermission) As IPermission
        ' If 'target' is null, return null.
        If target Is Nothing Then
            Return Nothing
        End If
        ' Both objects must be the same type.
        Dim soundPerm As SoundPermission = VerifyTypeMatch(target)

        ' If 'this' and 'target' are unrestricted, return a new unrestricted permission.
        If m_specifiedAsUnrestricted AndAlso soundPerm.m_specifiedAsUnrestricted Then
            Return Clone(True, SoundPermissionState.PlayAnySound)
        End If
        ' Calculate the intersected permissions. If there are none, return null.
        Dim val As SoundPermissionState = CType(Math.Min(CType(m_flags, Int32), CType(soundPerm.m_flags, Int32)), SoundPermissionState)
        If val = 0 Then
            Return Nothing
        End If
        ' Return a new object with the intersected permission value.
        Return Clone(False, val)

    End Function 'Intersect

    '</snippet2>
    '<snippet3>
    ' Called by the Demand method: returns true if 'this' is a subset of 'target'.
    Public Overrides Function IsSubsetOf(ByVal target As IPermission) As [Boolean]
        ' If 'target' is null and this permission allows nothing, return true.
        If target Is Nothing Then
            Return m_flags = 0
        End If
        ' Both objects must be the same type.
        Dim soundPerm As SoundPermission = VerifyTypeMatch(target)

        ' Return true if the permissions of 'this' is a subset of 'target'.
        Return m_flags <= soundPerm.m_flags

    End Function 'IsSubsetOf

    '</snippet3>
    '<snippet4>
    ' Return a new object that matches 'this' object's permissions.
    Public Overrides Function Copy() As IPermission
        Return CType(Clone(), IPermission)

    End Function 'Copy

    '</snippet4>
    '<snippet5>
    ' Return a new object that contains the union of 'this' and 'target'.
    ' Note: You do not have to implement this method. If you do not, the version
    ' in CodeAccessPermission does this:
    '    1. If target is not null, a NotSupportedException is thrown.
    '    2. If target is null, then Copy is called and the new object is returned.
    Public Overrides Function Union(ByVal target As IPermission) As IPermission
        ' If 'target' is null, then return a copy of 'this'.
        If target Is Nothing Then
            Return Copy()
        End If
        ' Both objects must be the same type.
        Dim soundPerm As SoundPermission = VerifyTypeMatch(target)

        ' If 'this' or 'target' are unrestricted, return a new unrestricted permission.
        If m_specifiedAsUnrestricted OrElse soundPerm.m_specifiedAsUnrestricted Then
            Return Clone(True, SoundPermissionState.PlayAnySound)
        End If
        ' Return a new object with the calculated, unioned permission value.
        Return Clone(False, CType(Math.Max(CType(m_flags, Int32), CType(soundPerm.m_flags, Int32)), SoundPermissionState))

    End Function 'Union
    '</snippet5>
#End Region
#Region "ISecurityEncodable Members"

    '<snippet6>
    ' Populate the permission's fields from XML.
    Public Overrides Sub FromXml(ByVal e As SecurityElement)
        m_specifiedAsUnrestricted = False
        m_flags = 0

        ' If XML indicates an unrestricted permission, make this permission unrestricted.
        Dim s As String = CStr(e.Attributes("Unrestricted"))
        If Not (s Is Nothing) Then
            m_specifiedAsUnrestricted = Convert.ToBoolean(s)
            If m_specifiedAsUnrestricted Then
                m_flags = SoundPermissionState.PlayAnySound
            End If
        End If
        ' If XML indicates a restricted permission, parse the flags.
        If Not m_specifiedAsUnrestricted Then
            s = CStr(e.Attributes("Flags"))
            If Not (s Is Nothing) Then
                m_flags = CType(Convert.ToInt32([Enum].Parse(GetType(SoundPermission), s, True)), SoundPermissionState)
            End If
        End If

    End Sub 'FromXml

    '</snippet6>
    '<snippet7>
    ' Produce XML from the permission's fields.
    Public Overrides Function ToXml() As SecurityElement
        ' These first three lines create an element with the required format.
        Dim e As New SecurityElement("IPermission")
        ' Replace the double quotation marks ("") with single quotation marks (‘’)
        ' to remain XML compliant when the culture is not neutral.
        e.AddAttribute("class", [GetType]().AssemblyQualifiedName.Replace(ControlChars.Quote, "'"c))
        e.AddAttribute("version", "1")

        If Not m_specifiedAsUnrestricted Then
            e.AddAttribute("Flags", [Enum].Format(GetType(SoundPermissionState), m_flags, "G"))
        Else
            e.AddAttribute("Unrestricted", "true")
        End If
        Return e

    End Function 'ToXml
    '</snippet7>
#End Region
#Region "IUnrestrictedPermission Members"

    '<snippet8>
    ' Returns true if permission is effectively unrestricted.
    Public Function IsUnrestricted() As [Boolean] Implements IUnrestrictedPermission.IsUnrestricted
        ' This means that the object is unrestricted at runtime.
        Return m_flags = SoundPermissionState.PlayAnySound

    End Function 'IsUnrestricted
    '</snippet8>
#End Region
#Region "ICloneable Members"
    ' Return a copy of the permission.
    Public Function Clone() As [Object] Implements System.ICloneable.Clone
        Return MemberwiseClone()

    End Function 'Clone 
#End Region

End Class 'SoundPermission
'</snippet1>