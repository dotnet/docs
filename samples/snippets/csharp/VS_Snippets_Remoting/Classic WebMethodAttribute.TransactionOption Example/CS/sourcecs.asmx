// <Snippet1>
<%@ WebService Language="C#" Class="Bank"%>
<%@ assembly name="System.EnterpriseServices,Version=1.0.3300.0,Culture=neutral,PublicKeyToken=b03f5f7f11d50a3a" %>
 
 using System;
 using System.Web.Services;
 using System.EnterpriseServices;
 
 public class Bank : WebService {
 
      [ WebMethod(TransactionOption=TransactionOption.RequiresNew) ]
      public void Transfer(long Amount, long AcctNumberTo, long AcctNumberFrom)  {
            MyCOMObject objBank = new MyCOMObject();
               
            if (objBank.GetBalance(AcctNumberFrom) < Amount )
               // Explicitly abort the transaction.
               ContextUtil.SetAbort();
            else {
               // Credit and Debit methods explictly vote within
               // the code for their methods whether to commit or
               // abort the transaction.
               objBank.Credit(Amount, AcctNumberTo);
               objBank.Debit(Amount, AcctNumberFrom);
            }
      }
 }
      
// </Snippet1>


 public class MyCOMObject {
	public long GetBalance(long AcctNumber){return 0;}
	public void Credit( long Amount, long AcctNumber) {}
	public void Debit( long Amount, long AcctNumber) {}

 }