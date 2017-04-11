' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      CreateInvariant1()
      Console.WriteLine()
      CreateNeutral2()
      Console.WriteLine()
      CreateSpecific3()
   End Sub
   
   Private Sub CreateInvariant1()
      ' <Snippet1>
      Dim dtfi As System.Globalization.DateTimeFormatInfo
      
      dtfi = System.Globalization.DateTimeFormatInfo.InvariantInfo
      Console.WriteLine(dtfi.IsReadOnly)               

      dtfi = New System.Globalization.DateTimeFormatInfo()
      Console.WriteLine(dtfi.IsReadOnly)               
      
      dtfi = System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat
      Console.WriteLine(dtfi.IsReadOnly) 
      ' The example displays the following output:
      '       True
      '       False
      '       True      
      ' </Snippet1>
   End Sub   

   Private Sub CreateNeutral2()
      ' <Snippet2>
      Dim specific, neutral As System.Globalization.CultureInfo
      Dim dtfi As System.Globalization.DateTimeFormatInfo
     
      ' Instantiate a culture by creating a specific culture and using its Parent property.
      specific = System.Globalization.CultureInfo.GetCultureInfo("fr-FR")
      neutral = specific.Parent
      dtfi = neutral.DateTimeFormat
      Console.WriteLine("{0} from Parent property: {1}", neutral.Name, dtfi.IsReadOnly)
      
      dtfi = System.Globalization.CultureInfo.GetCultureInfo("fr-FR").Parent.DateTimeFormat
      Console.WriteLine("{0} from Parent property: {1}", neutral.Name, dtfi.IsReadOnly)

      ' Instantiate a neutral culture using the CultureInfo constructor.
      neutral = New System.Globalization.CultureInfo("fr")
      dtfi = neutral.DateTimeFormat
      Console.WriteLine("{0} from CultureInfo constructor: {1}", neutral.Name, dtfi.IsReadOnly)

      ' Instantiate a culture using CreateSpecificCulture. 
      neutral = System.Globalization.CultureInfo.CreateSpecificCulture("fr")
      dtfi = neutral.DateTimeFormat
      Console.WriteLine("{0} from CreateSpecificCulture: {1}", neutral.Name, dtfi.IsReadOnly)
      
      ' Retrieve a culture by calling the GetCultureInfo method.
      neutral = System.Globalization.CultureInfo.GetCultureInfo("fr")
      dtfi = neutral.DateTimeFormat
      Console.WriteLine("{0} from GetCultureInfo: {1}", neutral.Name, dtfi.IsReadOnly)
      
      ' Instantiate a DateTimeFormatInfo object by calling GetInstance.  
      neutral = System.Globalization.CultureInfo.CreateSpecificCulture("fr")
      dtfi = System.Globalization.DateTimeFormatInfo.GetInstance(neutral)
      Console.WriteLine("{0} from GetInstance: {1}", neutral.Name, dtfi.IsReadOnly)

      ' The example displays the following output:
      '       fr from Parent property: False
      '       fr from Parent property: False
      '       fr from CultureInfo constructor: False
      '       fr-FR from CreateSpecificCulture: False
      '       fr from GetCultureInfo: True
      '       fr-FR from GetInstance: False       
      ' </Snippet2>
   End Sub
   
   Private Sub CreateSpecific3()
      ' <Snippet3>
      Dim ci As System.Globalization.CultureInfo = Nothing
      Dim dtfi As System.Globalization.DateTimeFormatInfo = Nothing
      
      ' Instantiate a culture using CreateSpecificCulture.
      ci = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
      dtfi = ci.DateTimeFormat
      Console.WriteLine("{0} from CreateSpecificCulture: {1}", ci.Name, dtfi.IsReadOnly)
      
      ' Instantiate a culture using the CultureInfo constructor.
      ci = new System.Globalization.CultureInfo("en-CA") 
      dtfi = ci.DateTimeFormat
      Console.WriteLine("{0} from CultureInfo constructor: {1}", ci.Name, dtfi.IsReadOnly)

      ' Retrieve a culture by calling the GetCultureInfo method.
      ci = System.Globalization.CultureInfo.GetCultureInfo("en-AU")
      dtfi = ci.DateTimeFormat
      Console.WriteLine("{0} from GetCultureInfo: {1}", ci.Name, dtfi.IsReadOnly)


      ' Instantiate a DateTimeFormatInfo object by calling DateTimeFormatInfo.GetInstance.  
      ci = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB")
      dtfi = System.Globalization.DateTimeFormatInfo.GetInstance(ci)
      Console.WriteLine("{0} from GetInstance: {1}", ci.Name, dtfi.IsReadOnly)

      ' The example displays the following output:
      '      en-US from CreateSpecificCulture: False
      '      en-CA from CultureInfo constructor: False
      '      en-AU from GetCultureInfo: True
      '      en-GB from GetInstance: False
      ' </Snippet3>
   End Sub
End Module

