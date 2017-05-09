Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
 Dim bc As HttpBrowserCapabilities = Request.Browser
 Response.Write("<p>Browser Capabilities:</p>")
 Response.Write("Type = " & bc.Type & "<br>")
 Response.Write("Name = " & bc.Browser & "<br>")
 Response.Write("Version = " & bc.Version & "<br>")
 Response.Write("Major Version = " & bc.MajorVersion & "<br>")
 Response.Write("Minor Version = " & bc.MinorVersion & "<br>")
 Response.Write("Platform = " & bc.Platform & "<br>")
 Response.Write("Is Beta = " & bc.Beta & "<br>")
 Response.Write("Is Crawler = " & bc.Crawler & "<br>")
 Response.Write("Is AOL = " & bc.AOL & "<br>")
 Response.Write("Is Win16 = " & bc.Win16 & "<br>")
 Response.Write("Is Win32 = " & bc.Win32 & "<br>")
 Response.Write("Supports Frames = " & bc.Frames & "<br>")
 Response.Write("Supports Tables = " & bc.Tables & "<br>")
 Response.Write("Supports Cookies = " & bc.Cookies & "<br>")
 Response.Write("Supports VB Script = " & bc.VBScript & "<br>")
 Response.Write("Supports JavaScript = " & bc.JavaScript & "<br>")
 Response.Write("Supports Java Applets = " & bc.JavaApplets & "<br>")
 Response.Write("Supports ActiveX Controls = " & bc.ActiveXControls & "<br>")
 Response.Write("CDF = " & bc.CDF & "<br>")
    
' </Snippet1>
 End Sub
End Class
