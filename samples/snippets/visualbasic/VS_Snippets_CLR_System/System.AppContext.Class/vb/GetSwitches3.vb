' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Configuration
Imports System.Globalization
Imports System.Xml

Module Example
   Private Const SettingName As String = "AppContextSwitchOverrides"
   Private Const SwitchName As String = "Switch.Application.Utilities.SwitchName" 
   
   Public Sub Main()
      Dim flag As Boolean = False
      
      ' Determine whether the caller has used the AppContext class directly.
      If Not AppContext.TryGetSwitch(SwitchName, flag) Then
         ' If switch is not defined directly, attempt to retrieve it from a configuration file.
         Try
            Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            If config Is Nothing Then Exit Sub
            
            Dim sec As ConfigurationSection = config.GetSection("runtime")
            If sec IsNot Nothing Then 
               Dim rawXml As String = sec.SectionInformation.GetRawXml()
               If String.IsNullOrEmpty(rawXml) Then Exit Sub
               
               Dim doc As New XmlDocument()
               doc.LoadXml(rawXml)
               Dim root As XmlNode = doc.FirstChild
               ' Navigate the children.
               If root.HasChildNodes Then
                  For Each node As XmlNode In root.ChildNodes
                     If node.Name.Equals(SettingName, StringComparison.Ordinal) Then
                        ' Get attribute value
                        Dim attr As XmlAttribute = node.Attributes("value")
                        Dim nameValuePair() As String = attr.Value.Split("="c)
                        ' Determine whether the switch we want is present.
                        If SwitchName.Equals(nameValuePair(0), StringComparison.Ordinal) Then 
                           Dim tempFlag As Boolean = False
                           If Boolean.TryParse(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(nameValuePair(1)),
                                               tempFlag)
                              AppContext.SetSwitch(nameValuePair(0), tempFlag)                 
                           End If
                        End If
                     End If
                  Next 
               End If
            End If   
         Catch e As ConfigurationErrorsException
         End Try
      End If
   End Sub
End Module
' </Snippet3>
