' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Globalization
Imports System.Threading

Module Example
   Public Sub Main()
      Dim cultureNames() As String = { "en-US", "se-SE" }
      Dim strings1() As String = { "case",  "encyclopædia",  
                                   "encyclopædia", "Archæology" }
      Dim strings2() As String = { "Case", "encyclopaedia", 
                                   "encyclopedia" , "ARCHÆOLOGY" }
      Dim comparisons() As StringComparison = CType([Enum].GetValues(GetType(StringComparison)),
                                           StringComparison())
      
      For Each cultureName In cultureNames
         Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName)
         Console.WriteLine("Current Culture: {0}", CultureInfo.CurrentCulture.Name)
         For ctr As Integer = 0 To strings1.GetUpperBound(0)
            For Each comparison In comparisons
               Console.WriteLine("   {0} = {1} ({2}): {3}", strings1(ctr),
                                 strings2(ctr), comparison, 
                                 strings1(ctr).Equals(strings2(ctr), comparison))
            Next
            Console.WriteLine()         
         Next
         Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output:
'    Current Culture: en-US
'       case = Case (CurrentCulture): False
'       case = Case (CurrentCultureIgnoreCase): True
'       case = Case (InvariantCulture): False
'       case = Case (InvariantCultureIgnoreCase): True
'       case = Case (Ordinal): False
'       case = Case (OrdinalIgnoreCase): True
'    
'       encyclopædia = encyclopaedia (CurrentCulture): True
'       encyclopædia = encyclopaedia (CurrentCultureIgnoreCase): True
'       encyclopædia = encyclopaedia (InvariantCulture): True
'       encyclopædia = encyclopaedia (InvariantCultureIgnoreCase): True
'       encyclopædia = encyclopaedia (Ordinal): False
'       encyclopædia = encyclopaedia (OrdinalIgnoreCase): False
'    
'       encyclopædia = encyclopedia (CurrentCulture): False
'       encyclopædia = encyclopedia (CurrentCultureIgnoreCase): False
'       encyclopædia = encyclopedia (InvariantCulture): False
'       encyclopædia = encyclopedia (InvariantCultureIgnoreCase): False
'       encyclopædia = encyclopedia (Ordinal): False
'       encyclopædia = encyclopedia (OrdinalIgnoreCase): False
'    
'       Archæology = ARCHÆOLOGY (CurrentCulture): False
'       Archæology = ARCHÆOLOGY (CurrentCultureIgnoreCase): True
'       Archæology = ARCHÆOLOGY (InvariantCulture): False
'       Archæology = ARCHÆOLOGY (InvariantCultureIgnoreCase): True
'       Archæology = ARCHÆOLOGY (Ordinal): False
'       Archæology = ARCHÆOLOGY (OrdinalIgnoreCase): True
'    
'    
'    Current Culture: se-SE
'       case = Case (CurrentCulture): False
'       case = Case (CurrentCultureIgnoreCase): True
'       case = Case (InvariantCulture): False
'       case = Case (InvariantCultureIgnoreCase): True
'       case = Case (Ordinal): False
'       case = Case (OrdinalIgnoreCase): True
'    
'       encyclopædia = encyclopaedia (CurrentCulture): False
'       encyclopædia = encyclopaedia (CurrentCultureIgnoreCase): False
'       encyclopædia = encyclopaedia (InvariantCulture): True
'       encyclopædia = encyclopaedia (InvariantCultureIgnoreCase): True
'       encyclopædia = encyclopaedia (Ordinal): False
'       encyclopædia = encyclopaedia (OrdinalIgnoreCase): False
'    
'       encyclopædia = encyclopedia (CurrentCulture): False
'       encyclopædia = encyclopedia (CurrentCultureIgnoreCase): False
'       encyclopædia = encyclopedia (InvariantCulture): False
'       encyclopædia = encyclopedia (InvariantCultureIgnoreCase): False
'       encyclopædia = encyclopedia (Ordinal): False
'       encyclopædia = encyclopedia (OrdinalIgnoreCase): False
'    
'       Archæology = ARCHÆOLOGY (CurrentCulture): False
'       Archæology = ARCHÆOLOGY (CurrentCultureIgnoreCase): True
'       Archæology = ARCHÆOLOGY (InvariantCulture): False
'       Archæology = ARCHÆOLOGY (InvariantCultureIgnoreCase): True
'       Archæology = ARCHÆOLOGY (Ordinal): False
'       Archæology = ARCHÆOLOGY (OrdinalIgnoreCase): True
' </Snippet4>
