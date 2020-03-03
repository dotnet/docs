<%-- <Snippet1> --%>
<%@ WebService Language="VB" Class="MyProfileService" %>

Imports System.Web.Services
Imports System.Collections.Generic
Imports System.Web.Script.Services

<ScriptService()>  _
Public Class MyProfileService
    Inherits System.Web.Services.WebService
    
    ' Returns a dictionary containing a name-value
    ' pair for all profile properties enabled for
    ' read access found on the current users profile.
    <WebMethod()> _
    Public Function GetAllPropertiesForCurrentUser() As _
        IDictionary(Of String, Object)
        
        'Place code here.
        Return Nothing
        
    End Function
    
    ' Given an array of one or more property names,
    ' returns a dictionary containing a name-value pair
    ' for each corresponding property found on the current
    ' users profile that are enabled for read access.
    <WebMethod()> _
    Public Function GetPropertiesForCurrentUser _
        (ByVal properties() As String) As _
        IDictionary(Of String, Object)

        'Place code here.
        Return Nothing
    
    End Function
    
    ' Given a dictionary with one or more name-value pairs,
    ' sets the values onto the corresponding properties of
    ' the current users profile. The method returns the count 
    ' of properties that were able to be updated.
    <WebMethod()> _
    Public Function SetPropertiesForCurrentUser(ByVal values As _
        IDictionary(Of String, Object)) As Integer
        
        'Place code here.
        Return 0
    
    End Function
    
End Class
' </Snippet1>
