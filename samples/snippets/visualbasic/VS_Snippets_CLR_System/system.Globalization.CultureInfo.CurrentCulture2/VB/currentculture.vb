' <snippet11>
Imports System.Globalization
Imports System.Threading

Public Module Example
   Public Sub Main()

      ' Display the name of the current thread culture.
      Console.WriteLine("CurrentCulture is {0}.", CultureInfo.CurrentCulture.Name)

      ' Change the current culture to th-TH.
      CultureInfo.CurrentCulture = New CultureInfo("th-TH", False)
      Console.WriteLine("CurrentCulture is now {0}.", CultureInfo.CurrentCulture.Name)

      ' Display the name of the current UI culture.
      Console.WriteLine("CurrentUICulture is {0}.", CultureInfo.CurrentUICulture.Name)

      ' Change the current UI culture to ja-JP.
      CultureInfo.CurrentUICulture = New CultureInfo("ja-JP", False)
      Console.WriteLine("CurrentUICulture is now {0}.", CultureInfo.CurrentUICulture.Name)
   End Sub 
End Module
' The example displays the following output:
'       CurrentCulture is en-US.
'       CurrentCulture is now th-TH.
'       CurrentUICulture is en-US.
'       CurrentUICulture is now ja-JP.
' </snippet11>