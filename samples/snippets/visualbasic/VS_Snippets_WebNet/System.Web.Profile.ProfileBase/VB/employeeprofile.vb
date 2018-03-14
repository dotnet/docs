'<Snippet1>
Imports System
Imports System.Web.Profile

Namespace Samples.AspNet.Profile

  Public Class EmployeeProfile
    Inherits ProfileBase

    <SettingsAllowAnonymous(False)> _
    <ProfileProvider("EmployeeInfoProvider")> _
    Public Property Department As String
      Get
        Return MyBase.Item("EmployeeDepartment").ToString()
      End Get
      Set
        MyBase.Item("EmployeeDepartment") = value
      End Set
    End Property

    <SettingsAllowAnonymous(False)> _
    <ProfileProvider("EmployeeInfoProvider")> _
    Public Property Details As EmployeeInfo
      Get
        Return CType(MyBase.Item("EmployeeInfo"), EmployeeInfo)
      End Get
      Set
        MyBase.Item("EmployeeInfo") = value
      End Set
    End Property
  End Class

  Public Class EmployeeInfo
    Public Name As String
    Public Address As String
    Public Phone As String
    Public EmergencyContactName As String
    Public EmergencyContactAddress As String
    Public EmergencyContactPhone As String
  End Class

End Namespace
'</Snippet1>