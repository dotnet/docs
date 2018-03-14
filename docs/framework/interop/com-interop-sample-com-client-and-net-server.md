---
title: "COM Interop Sample: COM Client and .NET Server"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "interoperation with unmanaged code, samples"
  - "COM interop, samples"
ms.assetid: a219cb2c-9fa2-4c90-9b26-939e0788f178
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# COM Interop Sample: COM Client and .NET Server
This sample demonstrates the interoperation of a [COM Client](#cpconcominteropsamplecomclientnetserveranchor1) and a [.NET Server](#cpconcominteropsamplecomclientnetserveranchor2) that performs mortgage calculations. In this example, the client creates and calls an instance of the managed `Loan` class, passes four arguments (one of those four being equal to zero) to the instance, and displays the computations. Code examples from this sample appear throughout this section.  
  
<a name="cpconcominteropsamplecomclientnetserveranchor1"></a>   
## COM Client  
  
```cpp  
// ConLoan.cpp : Defines the entry point for the console application.  
#include "stdafx.h"  
#import "..\LoanLib\LoanLib.tlb" raw_interfaces_only  
using namespace LoanLib;  
  
int main(int argc, char* argv[])  
{  
    HRESULT hr = CoInitialize(NULL);  
  
    ILoanPtr pILoan(__uuidof(Loan));  
  
    if (argc < 5)   
    {  
        printf("Usage: ConLoan Balance Rate Term Payment\n");  
        printf("    Either Balance, Rate, Term, or Payment must be 0\n");  
        return -1;  
    }  
  
    double openingBalance = atof(argv[1]);  
    double rate = atof(argv[2])/100.0;  
    short  term = atoi(argv[3]);  
    double payment = atof(argv[4]);  
  
    pILoan->put_OpeningBalance(openingBalance);  
    pILoan->put_Rate(rate);  
    pILoan->put_Term(term);  
    pILoan->put_Payment(payment);  
  
    if (openingBalance == 0.00)   
         pILoan->ComputeOpeningBalance(&openingBalance);  
    if (rate == 0.00) pILoan->ComputeRate(&rate);  
    if (term == 0) pILoan->ComputeTerm(&term);  
    if (payment == 0.00) pILoan->ComputePayment(&payment);  
  
    printf("Balance = %.2f\n", openingBalance);  
    printf("Rate    = %.1f%%\n", rate*100);  
    printf("Term    = %.2i\n", term);  
    printf("Payment = %.2f\n", payment);  
  
    VARIANT_BOOL MorePmts;  
    double Balance = 0.0;  
    double Principal = 0.0;  
    double Interest = 0.0;  
  
    printf("%4s%10s%12s%10s%12s\n", "Nbr", "Payment", "Principal", "Interest", "Balance");  
    printf("%4s%10s%12s%10s%12s\n", "---", "-------", "---------",   
"--------", "-------");  
  
    pILoan->GetFirstPmtDistribution(payment, &Balance, &Principal, &Interest, &MorePmts);  
  
    for (short PmtNbr = 1; MorePmts; PmtNbr++)   
    {  
        printf("%4i%10.2f%12.2f%10.2f%12.2f\n",  
        PmtNbr, payment, Principal, Interest, Balance);  
  
        pILoan->GetNextPmtDistribution(payment, &Balance, &Principal, &Interest, &MorePmts);   
    }  
  
    CoUninitialize();  
    return 0;  
}  
```  
  
<a name="cpconcominteropsamplecomclientnetserveranchor2"></a>   
## .NET Server  
  
```vb  
Imports System  
Imports System.Reflection  
  
<Assembly: AssemblyKeyFile("sample.snk")>  
Namespace LoanLib      
  
    Public Interface ILoan          
        Property OpeningBalance() As Double  
        Property Rate() As Double         
        Property Payment() As Double         
        Property Term() As Short          
        Property RiskRating() As String  
        Function ComputePayment() As Double  
        Function ComputeOpeningBalance() As Double  
        Function ComputeRate() As Double  
        Function ComputeTerm() As Short  
        Function GetFirstPmtDistribution(PmtAmt As Double, _  
           ByRef Balance As Double, ByRef PrinPortion As Double, _  
           ByRef IntPortion As Double) As Boolean  
        Function GetNextPmtDistribution(PmtAmt As Double, _  
           ByRef Balance As Double, ByRef PrinPortion As Double, _  
           ByRef IntPortion As Double) As Boolean  
    End Interface      
  
    Public Class Loan  
        Implements ILoan  
        Private m_openingBalance As Double  
        Private m_rate As Double  
        Private m_payment As Double  
        Private m_term As Short  
        Private m_riskRating As String   
  
        Public Property OpeningBalance() As Double _  
        Implements ILoan.OpeningBalance  
  
            Get  
                Return m_openingBalance  
            End Get  
            Set  
                m_openingBalance = value  
            End Set  
        End Property   
  
        Public Property Rate() As Double _  
        Implements ILoan.Rate  
  
            Get  
                Return m_rate  
            End Get  
            Set  
                m_rate = value  
            End Set  
        End Property   
  
        Public Property Payment() As Double _  
        Implements ILoan.Payment  
  
            Get  
                Return m_payment  
            End Get  
            Set  
                m_payment = value  
            End Set  
        End Property   
  
        Public Property Term() As Short _  
        Implements ILoan.Term  
  
            Get  
                Return m_term  
            End Get  
            Set  
                m_term = value  
            End Set  
        End Property   
  
        Public Property RiskRating() As String _  
        Implements ILoan.RiskRating  
  
            Get  
                Return m_riskRating  
            End Get  
            Set  
                m_riskRating = value  
            End Set  
        End Property  
  
        Public Function ComputePayment() As Double _  
        Implements ILoan.ComputePayment  
  
            Payment = Util.Round(OpeningBalance *(Rate / _  
               (1 - Math.Pow(1 + Rate, - Term))), 2)  
            Return Payment  
        End Function          
  
        Public Function ComputeOpeningBalance() As Double _  
        Implements ILoan.ComputeOpeningBalance  
  
            OpeningBalance = Util.Round(Payment /(Rate / _  
               (1 - Math.Pow(1 + Rate, - Term))), 2)  
            Return OpeningBalance  
        End Function          
  
        Public Function ComputeRate() As Double _  
        Implements ILoan.ComputeRate  
  
            Dim DesiredPayment As Double = Payment  
  
            For m_rate = 0.001 To 28.0 - 0.001 Step 0.001  
                Payment = Util.Round(OpeningBalance *(Rate / _  
                   (1 - Math.Pow(1 + Rate, - Term))), 2)  
  
                If Payment >= DesiredPayment Then  
                    Exit For  
                End If  
            Next  
            Return Rate  
        End Function          
  
        Public Function ComputeTerm() As Short _  
        Implements ILoan.ComputeTerm  
  
            Dim DesiredPayment As Double = Payment  
  
            For m_term = 1 To 479  
                Payment = Util.Round(OpeningBalance *(Rate / _  
                   (1 - Math.Pow(1 + Rate, - Term))), 2)  
  
                If Payment <= DesiredPayment Then  
                    Exit For  
                End If  
            Next  
            Return Term  
        End Function          
  
        Public Function GetFirstPmtDistribution(PmtAmt As Double, _  
        ByRef Balance As Double, ByRef PrinPortion As Double, _  
        ByRef IntPortion As Double) As Boolean _  
        Implements ILoan.GetFirstPmtDistribution  
  
            Balance = OpeningBalance  
            Return GetNextPmtDistribution(PmtAmt, Balance, PrinPortion, _  
               IntPortion)  
        End Function          
  
        Public Function GetNextPmtDistribution(PmtAmt As Double, _  
        ByRef Balance As Double, ByRef PrinPortion As Double, _  
        ByRef IntPortion As Double) As Boolean _  
        Implements ILoan.GetNextPmtDistribution  
  
            IntPortion = Util.Round(Balance * Rate, 2)  
            PrinPortion = Util.Round(PmtAmt - IntPortion, 2)  
            Balance = Util.Round(Balance - PrinPortion, 2)  
  
            If Balance <= 0.0 Then  
                Return False  
            End If   
            Return True  
        End Function  
    End Class      
  
    Friend Class Util  
  
        Public Shared Function Round(value As Double, digits As Short) _  
                                      As Double  
            Dim factor As Double = Math.Pow(10, digits)  
            Return Math.Round((value * factor)) / factor  
        End Function  
  
    End Class  
  
End Namespace  
```  
  
```csharp  
using System;  
using System.Reflection;  
  
[assembly:AssemblyKeyFile("sample.snk")]  
namespace LoanLib {  
  
    public interface ILoan {  
        double OpeningBalance{get; set;}  
        double Rate{get; set;}  
        double Payment{get; set;}     
        short  Term{get; set;}  
        String RiskRating{get; set;}  
  
        double ComputePayment();  
        double ComputeOpeningBalance();  
        double ComputeRate();  
        short ComputeTerm();  
        bool GetFirstPmtDistribution(double PmtAmt, ref double Balance,  
            out double PrinPortion, out double IntPortion);  
        bool GetNextPmtDistribution(double PmtAmt, ref double Balance,  
            out double PrinPortion, out double IntPortion);  
    }  
  
    public class Loan : ILoan {  
        private double openingBalance;  
        private double rate;  
        private double payment;  
        private short  term;  
        private String riskRating;        
  
        public double OpeningBalance {  
            get { return openingBalance; }  
            set { openingBalance = value; }  
        }  
  
        public double Rate {  
            get { return rate; }  
            set { rate = value; }  
        }  
  
        public double Payment {  
            get { return payment; }  
            set { payment = value; }  
        }  
  
        public short Term {  
            get { return term; }  
            set { term = value; }  
        }  
  
        public String RiskRating {  
            get { return riskRating; }  
            set { riskRating = value; }  
        }  
  
        public double ComputePayment() {  
             Payment = Util.Round(OpeningBalance * (Rate / (1 –   
                        Math.Pow((1 + Rate), -Term))), 2);  
             return Payment;  
        }  
  
        public double ComputeOpeningBalance() {  
            OpeningBalance = Util.Round(Payment / (Rate / (1 - Math.Pow((1   
                              + Rate), -Term))), 2);  
             return OpeningBalance;  
        }  
  
        public double ComputeRate() {  
            double DesiredPayment = Payment;  
  
            for (Rate = 0.001; Rate < 28.0; Rate += 0.001) {  
                Payment = Util.Round(OpeningBalance * (Rate / (1 –   
                           Math.Pow((1 + Rate), -Term))), 2);  
  
                if (Payment >= DesiredPayment)  
                    break;  
            }  
            return Rate;     
        }  
  
        public short ComputeTerm() {  
            double DesiredPayment = Payment;  
  
            for (Term = 1; Term < 480 ; Term ++) {  
                Payment = Util.Round(OpeningBalance * (Rate / (1 –   
                           Math.Pow((1 + Rate), -Term))),2);  
  
                if (Payment <= DesiredPayment)  
                    break;  
            }  
  
            return Term;     
        }  
  
        public bool GetFirstPmtDistribution(double PmtAmt, ref double   
            Balance, out double PrinPortion, out double IntPortion) {  
             Balance = OpeningBalance;  
             return GetNextPmtDistribution(PmtAmt, ref Balance, out   
             PrinPortion, out IntPortion);   
        }  
  
        public bool GetNextPmtDistribution(double PmtAmt, ref double   
           Balance, out double PrinPortion, out double IntPortion) {  
            IntPortion = Util.Round(Balance * Rate, 2);  
            PrinPortion = Util.Round(PmtAmt - IntPortion,2);  
            Balance = Util.Round(Balance - PrinPortion,2);  
  
            if (Balance <= 0.0)   
                return false;  
  
            return true;  
        }  
     }  
  
    internal class Util {  
        public static double Round(double value, short digits) {  
            double factor = Math.Pow(10, digits);  
            return Math.Round(value * factor) / factor;  
         }  
    }  
}  
```  
  
## See Also  
 [Exposing .NET Framework Components to COM](../../../docs/framework/interop/exposing-dotnet-components-to-com.md)
