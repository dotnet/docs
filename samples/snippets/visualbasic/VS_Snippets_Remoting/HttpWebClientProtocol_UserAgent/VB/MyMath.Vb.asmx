<%@ WebService Language="VB"  Class = "MyMath" %>
Imports System.Web.Services
Imports System
 
public class MyMath 
   <WebMethod >Public Function Add(num1 As Integer, num2 As Integer) As Integer
      Return num1+num2
   End Function
End Class
