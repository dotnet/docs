 '
'** This program is used as the server for 
'** the programs demonstrating the use of 
'** cookies. If the initial request from the 
'** client has cookies, the server uses these
'** cookies to generate a page structured with
'** the information provided. Otherwise the 
'** server sends a page to the client requesting
'** some information, this information is used
'** to structure the subsequent page that is sent
'** to the client alongwith the cookies that need
'** to be stored by the client for any subsequent
'** communication with the server.
'

Imports System
Imports System.IO
Imports System.Text
Imports System.Collections.Specialized
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Net



Public Class CookiesPage
    Inherits Page
    
    Private myForm As HtmlForm
    
    Private userNameTextBox As TextBox
    
    Private dateBirthTextBox As TextBox
    
    Private placeBirthTextBox As TextBox
    
    
    ' Associate the event handlers with the events.
    Public Sub New() 
        AddHandler Load, AddressOf GenerateCookies
        AddHandler [Error], AddressOf UnhandledException
        AddHandler Init, AddressOf PageInit
    
    End Sub 'New
    
    
    ' Create the controls for the web page.
    Private Sub PageInit(ByVal Sender As [Object], ByVal e As EventArgs) 
        userNameTextBox = New TextBox()
        userNameTextBox.ID = "UserName"
        dateBirthTextBox = New TextBox()
        dateBirthTextBox.ID = "DateOfBirth"
        placeBirthTextBox = New TextBox()
        placeBirthTextBox.ID = "PlaceOfBirth"
        placeBirthTextBox.AutoPostBack = True
        myForm = New HtmlForm()
        myForm.Method = "POST"
    
    End Sub 'PageInit
    
    
    
    Private Sub UnhandledException(ByVal Sender As [Object], ByVal e As EventArgs) 
        Response.Write("There was an unhandled exception on this page")
    
    End Sub 'UnhandledException
    
    
    Private Sub GenerateCookies(ByVal Sender As [Object], ByVal e As EventArgs) 
        Dim noCookieHeader As Boolean = False
        If Request.Cookies("UserName") Is Nothing Then
            noCookieHeader = True
        End If 
        ' If there is no cookies in the request then send a web page querying info.
        If noCookieHeader Then
            ' Compose a page with the info sent from the client as a post back.
            If IsPostBack Then
                RemoveControls()
                Dim myHttpCookie As New HttpCookie("UserName", Request.Form("UserName"))
                myHttpCookie.Domain = Request.Url.Host
                myHttpCookie.Path = Request.Path
                myHttpCookie.Expires = DateTime.Now.AddHours(- 12)
                myHttpCookie.Secure = False
                Response.Cookies.Add(myHttpCookie)
                myHttpCookie = New HttpCookie("DateOfBirth", Request.Form("DateOfBirth"))
                myHttpCookie.Domain = Request.Url.Host
                myHttpCookie.Path = Request.Path
                myHttpCookie.Expires = DateTime.Now.AddHours(- 12)
                myHttpCookie.Secure = False
                Response.Cookies.Add(myHttpCookie)
                myHttpCookie = New HttpCookie("PlaceOfBirth", Request.Form("PlaceOfBirth"))
                myHttpCookie.Domain = Request.Url.Host
                myHttpCookie.Path = Request.Path
                myHttpCookie.Expires = DateTime.Now.AddHours(- 12)
                myHttpCookie.Secure = False
                Response.Cookies.Add(myHttpCookie)
                Response.Write(Request.Form("UserName") + " , was born on " + Request.Form("DateOfBirth") + " at " + Request.Form("PlaceOfBirth"))
            ' Request information from the client.
            Else
                AddControls()
                Response.Write("Please enter the values : ")
            End If
        ' Compose a page with the information in the cookies sent over.
        Else
            Response.Write(Request.Cookies("UserName").Value + " , was born on " + Request.Cookies("DateOfBirth").Value + " at " + Request.Cookies("PlaceOfBirth").Value)
        End If
    
    End Sub 'GenerateCookies
    
    
    Protected Sub AddControls() 
        Controls.Add(myForm)
        myForm.Controls.Add(userNameTextBox)
        myForm.Controls.Add(dateBirthTextBox)
        myForm.Controls.Add(placeBirthTextBox)
    
    End Sub 'AddControls
    
    
    Protected Sub RemoveControls() 
        Controls.Remove(myForm)
        myForm.Controls.Remove(userNameTextBox)
        myForm.Controls.Remove(dateBirthTextBox)
        myForm.Controls.Remove(placeBirthTextBox)
    
    End Sub 'RemoveControls
End Class 'CookiesPage