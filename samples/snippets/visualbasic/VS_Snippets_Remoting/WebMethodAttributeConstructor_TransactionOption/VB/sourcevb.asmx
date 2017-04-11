' <Snippet1>
<%@ WebService Language="VB" Class="Bank"%>
<%@ assembly name="System.EnterpriseServices,Version=1.0.3300.0,Culture=neutral,PublicKeyToken=b03f5f7f11d50a3a" %>
 
Imports System
Imports System.Web.Services
Imports System.EnterpriseServices

Public Class Bank
    Inherits WebService    
    
    <WebMethod(True,TransactionOption.RequiresNew)> _	
    Public Sub Transfer(Amount As Long, AcctNumberTo As Long, _
        AcctNumberFrom As Long)
        
        Dim objBank As New MyCOMObject()
        
        If objBank.GetBalance(AcctNumberFrom) < Amount Then
            ' Explicitly end the transaction.
            ContextUtil.SetAbort()
        Else
            ' The Credit and Debit methods explictly determine, in their
            ' own code, whether to commit or end the transaction.
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