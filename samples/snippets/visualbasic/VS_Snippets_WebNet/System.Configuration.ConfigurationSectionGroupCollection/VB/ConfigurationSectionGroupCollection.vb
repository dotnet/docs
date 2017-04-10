 ' <Snippet1>
Imports System
Imports System.Configuration
Imports System.Collections


' Define a custom section.
NotInheritable Public Class CustomSection
   Inherits ConfigurationSection
   
   
   Public Sub New()
   End Sub 'New
   
    <ConfigurationProperty("fileName", _
    DefaultValue:="default.txt", _
    IsRequired:=True, _
    IsKey:=False), _
    StringValidator( _
    InvalidCharacters:=" ~!@#$%^&*()[]{}/;'""|\", _
    MinLength:=1, _
    MaxLength:=60)> _
    Public Property FileName() As String
        Get
            Return CStr(Me("fileName"))
        End Get
        Set(ByVal value As String)
            Me("fileName") = value
        End Set
    End Property

    <ConfigurationProperty("maxUsers", _
    DefaultValue:=10000, _
    IsRequired:=False), _
    LongValidator(MinValue:=1, _
    MaxValue:=10000000, _
    ExcludeRange:=False)> _
   Public Property MaxUsers() As Long
        Get
            Return Fix(Me("maxUsers"))
        End Get
        Set(ByVal value As Long)
            Me("maxUsers") = value
        End Set
    End Property

    <ConfigurationProperty("maxIdleTime", _
    DefaultValue:="0:10:0", _
    IsRequired:=False), _
    TimeSpanValidator(MinValueString:="0:0:30", _
    MaxValueString:="5:00:0", _
    ExcludeRange:=False)> _
    Public Property MaxIdleTime() As TimeSpan
        Get
            Return CType(Me("maxIdleTime"), TimeSpan)
        End Get
        Set(ByVal value As TimeSpan)
            Me("maxIdleTime") = value
        End Set
    End Property

End Class 'CustomSection 

' Define a custom section group.

NotInheritable Public Class CustomSectionGroup
   Inherits ConfigurationSectionGroup
   
   
   Public Sub New()
   End Sub 'New

   
   Public ReadOnly Property Custom() As CustomSection
      Get
            Return CType(Sections.Get("CustomSection"), _
            CustomSection)
      End Get
    End Property

End Class 'CustomSectionGroup 


Class UsingCustomSectionGroupCollection

   
   ' Create a custom section group.
   Shared Sub CreateSectionGroup()
      Try
         
         Dim customSectionGroup As CustomSectionGroup
         
         ' Get the current configuration file.
            Dim config As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)
         
         ' Create the section group entry  
         ' in the <configSections> and the 
         ' related target section in <configuration>.
         If config.SectionGroups("CustomGroup") Is Nothing Then
            customSectionGroup = New CustomSectionGroup()
            config.SectionGroups.Add("CustomGroup", customSectionGroup)
            customSectionGroup.ForceDeclaration(True)
            config.Save(ConfigurationSaveMode.Full)
         End If
      
      Catch err As ConfigurationErrorsException
         Console.WriteLine(err.ToString())
      End Try
   End Sub 'CreateSectionGroup
    
   
   '<Snippet2>
   ' Get the collection group keys i.e.,
   ' the group names.
    'Shared Sub GetAllKeys()

    '   Try
    '         Dim config _
    '         As System.Configuration.Configuration = _
    '         ConfigurationManager.OpenExeConfiguration( _
    '         ConfigurationUserLevel.None)

    '         Dim groups _
    '         As ConfigurationSectionGroupCollection = _
    '         config.SectionGroups

    '      Dim name As String
    '      For Each name In  groups.AllKeys
    '         Console.WriteLine("Key value: {0}", name)
    '      Next name


    '   Catch err As ConfigurationErrorsException
    '      Console.WriteLine(err.ToString())
    '   End Try
    'End Sub 'GetAllKeys
   
   '</Snippet2>
   '<Snippet3>
   Shared Sub Clear()
      
      Try
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)


         config.SectionGroups.Clear()
         
         config.Save(ConfigurationSaveMode.Full)
      Catch err As ConfigurationErrorsException
         Console.WriteLine(err.ToString())
      End Try
   End Sub 'Clear
   
   '</Snippet3>

    '<Snippet4>
   Shared Sub GetGroup()
      
      Try
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            Dim groups _
            As ConfigurationSectionGroupCollection = _
            config.SectionGroups

            Dim customGroup _
            As ConfigurationSectionGroup = _
            groups.Get("CustomGroup")
         
         
         If customGroup Is Nothing Then
                Console.WriteLine( _
                "Failed to load CustomGroup.")
         Else
            ' Display section information
                Console.WriteLine("Name:       {0}", _
                customGroup.Name)
                Console.WriteLine("Type:   {0}", _
                customGroup.Type)
         End If
      
      
      Catch err As ConfigurationErrorsException
         Console.WriteLine(err.ToString())
      End Try
   End Sub 'GetGroup
   
    '</Snippet4>

   '<Snippet5>
   Shared Sub GetEnumerator()
      
      Try
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            Dim groups _
            As ConfigurationSectionGroupCollection = _
            config.SectionGroups

            Dim groupEnum As IEnumerator = _
            groups.GetEnumerator()
         
         '<Snippet6>
         Dim i As Integer = 0
         While groupEnum.MoveNext()
            Dim groupName As String = groups.GetKey(i)
            Console.WriteLine("Group name: {0}", groupName)
            i += 1
         End While
            '</Snippet6>

      Catch err As ConfigurationErrorsException
         Console.WriteLine(err.ToString())
      End Try
   End Sub 'GetEnumerator
   
   '</Snippet5>
   
   '<Snippet7>
   ' Get the collection keys i.e., the
   ' group names.
   Shared Sub GetKeys()
      
      Try
            Dim config _
          As System.Configuration.Configuration = _
          ConfigurationManager.OpenExeConfiguration( _
          ConfigurationUserLevel.None)

            Dim groups _
            As ConfigurationSectionGroupCollection = _
            config.SectionGroups

         Dim key As String
         For Each key In  groups.Keys
            
            Console.WriteLine("Key value: {0}", key)
         Next key
      
      
      Catch err As ConfigurationErrorsException
         Console.WriteLine(err.ToString())
      End Try
   End Sub 'GetKeys
      
   '</Snippet7>

    '<Snippet8>
   Shared Sub GetItems()
      
      Try
            Dim config _
        As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
        ConfigurationUserLevel.None)

            Dim groups _
            As ConfigurationSectionGroupCollection = _
            config.SectionGroups

            Dim group1 As ConfigurationSectionGroup = _
            groups.Get("system.net")
         
            Dim group2 As ConfigurationSectionGroup = _
            groups.Get("system.web")
         
         
         Console.WriteLine("Group1: {0}", group1.Name)
         
         Console.WriteLine("Group2: {0}", group2.Name)
      
      Catch err As ConfigurationErrorsException
         Console.WriteLine(err.ToString())
      End Try
   End Sub 'GetItems

   '</Snippet8>

    '<Snippet9>
   Shared Sub Remove()
      
      Try
         
            Dim config _
        As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
        ConfigurationUserLevel.None)

            Dim groups _
            As ConfigurationSectionGroupCollection = _
            config.SectionGroups

            Dim customGroup _
            As ConfigurationSectionGroup = groups.Get("CustomGroup")
         
         If Not (customGroup Is Nothing) Then
            config.SectionGroups.Remove("CustomGroup")
            config.Save(ConfigurationSaveMode.Full)
         Else
                Console.WriteLine( _
                "CustomGroup does not exists.")
         End If
      
      Catch err As ConfigurationErrorsException
         Console.WriteLine(err.ToString())
      End Try
   End Sub 'Remove
   
   '</Snippet9>
   
   
   ' Add custom section to the group.
   Shared Sub AddSection()
      Try
         
         Dim customSection As CustomSection
         
         ' Get the current configuration file.
            Dim config _
     As System.Configuration.Configuration = _
     ConfigurationManager.OpenExeConfiguration( _
     ConfigurationUserLevel.None)

            Dim groups _
            As ConfigurationSectionGroupCollection = _
            config.SectionGroups

         ' Create the section entry  
         ' in the <configSections> and the 
         ' related target section in <configuration>.
         Dim customGroup As ConfigurationSectionGroup
            customGroup = groups.Get("CustomGroup")
         
            If customGroup.Sections.Get( _
            "CustomSection") Is Nothing Then
                customSection = New CustomSection()
                customGroup.Sections.Add( _
                "CustomSection", customSection)
                customSection.SectionInformation.ForceSave = True
                config.Save(ConfigurationSaveMode.Full)
            End If
      Catch err As ConfigurationErrorsException
         Console.WriteLine(err.ToString())
      End Try
   End Sub 'AddSection
   
   
   ' Exercise the collection.
   ' Uncomment the function you want to exercise.
    ' Start with CreateSectionGroup().
    Public Overloads Shared Sub Main(ByVal args() As String)
        CreateSectionGroup()
        AddSection()
        ' GetEnumerator();
        ' GetKeys();
        ' GetItems();
        ' Remove();
        ' Clear();

    End Sub 'Main ' GetAllKeys();
End Class 'UsingCustomSectionGroupCollection ' GetGroup();

' </Snippet1>