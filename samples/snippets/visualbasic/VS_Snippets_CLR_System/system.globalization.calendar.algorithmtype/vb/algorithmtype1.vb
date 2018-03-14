' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections
Imports System.Globalization
Imports System.Reflection

Module Example
   Public Sub Main()
      Dim assem As Assembly = Assembly.GetAssembly(GetType(Calendar))
      Dim types() As Type = assem.GetExportedTypes()
      Dim calendars() As Type = Array.FindAll(types, AddressOf IsValidCalendar)
      Array.Sort(calendars, New CalendarComparer())

      Console.WriteLine("{0,-30} {1}", "Calendar", "Algorithm Type")
      Console.WriteLine()
      For Each cal In calendars
         ' Instantiate a calendar object.
         Dim ctor As ConstructorInfo = cal.GetConstructor( {} )
         Dim calObj As Calendar = CType(ctor.Invoke( {} ), Calendar) 

         Console.WriteLine("{0,-30} {1}", 
                          cal.ToString().Replace("System.Globalization.", ""),
                          cal.InvokeMember("AlgorithmType", 
                                           BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.GetProperty,
                                           Nothing, calObj, Nothing))
      Next
   End Sub
   
   Private Function IsValidCalendar(ByVal t As Type) As Boolean
        If t.IsSubClassOf(GetType(Calendar)) Then
            If t.IsAbstract Then
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function
End Module

Public Class CalendarComparer : Implements IComparer
   Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
                  Implements IComparer.Compare
      Dim tX As Type = DirectCast(x, Type)
      Dim tY As Type = DirectCast(y, Type)

      Return tX.Name.CompareTo(tY.Name)
   End Function
End Class
' The example displays the following output:
'       Calendar                       Algorithm Type
'       
'       ChineseLunisolarCalendar       LunisolarCalendar
'       GregorianCalendar              SolarCalendar
'       HebrewCalendar                 LunisolarCalendar
'       HijriCalendar                  LunarCalendar
'       JapaneseCalendar               SolarCalendar
'       JapaneseLunisolarCalendar      LunisolarCalendar
'       JulianCalendar                 SolarCalendar
'       KoreanCalendar                 SolarCalendar
'       KoreanLunisolarCalendar        LunisolarCalendar
'       PersianCalendar                SolarCalendar
'       TaiwanCalendar                 SolarCalendar
'       TaiwanLunisolarCalendar        LunisolarCalendar
'       ThaiBuddhistCalendar           SolarCalendar
'       UmAlQuraCalendar               LunarCalendar
' </Snippet1>