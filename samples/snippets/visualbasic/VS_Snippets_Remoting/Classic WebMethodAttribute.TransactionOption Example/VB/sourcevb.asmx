' <Snippet1>
<%@ WebService Language="VB" Class="Bank"%>
<%@ assembly name="System.EnterpriseServices,Version=1.0.3300.0,Culture=neutral,PublicKeyToken=b03f5f7f11d50a3a" %>
 
Imports System
Imports System.Web.Services
Imports System.EnterpriseServices

Public Class Bank
    Inherits WebService    
    
    <WebMethod(TransactionOption := TransactionOption.RequiresNew)> _	
    Public Sub Transfer(Amount As Long, AcctNumberTo As Long, AcctNumberFrom As Long)
        
        Dim objBank As New MyCOMObject()
        
        If objBank.GetBalance(AcctNumberFrom) < Amount Then
            ' Explicitly abort the transaction.
            ContextUtil.SetAbort()
        Else
            ' Credit and Debit method explictly vote within
            ' the code for their methods whether to commit or
            ' abort the transaction.
            objBank.Credit(Amount, AcctNumberTo)
            objBank.Debit(Amount, AcctNumberFrom)
        End If
    End Sub
End Class
      
' </Snippet1>
Public Class MyCOMObject
	Public Function GetBalance(AcctNumber As Long)
	End Function

	Public Sub Credit(Amount as Long, AcctNumber As Long)
	End Sub

	Public Sub Debit(Amount as Long, AcctNumber As Long)
	End Sub
	

End Class