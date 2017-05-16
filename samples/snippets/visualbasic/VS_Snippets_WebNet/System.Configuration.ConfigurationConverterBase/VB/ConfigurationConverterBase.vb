 '<Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Globalization
Imports System.ComponentModel



' Define a custom section.

NotInheritable Public Class CustomSection
   Inherits ConfigurationSection
   
   
   Public Sub New()
   End Sub 'New
   
   
    <ConfigurationProperty("fileName", _
    DefaultValue:="default.txt", _
    IsRequired:=True, IsKey:=False), _
    StringValidator(InvalidCharacters:=" ~!@#$%^&*()[]{}/;'""|\", _
    MinLength:=1, MaxLength:=60)> _
    Public Property FileName() As String
        Get
            Return CStr(Me("fileName"))
        End Get
        Set(ByVal value As String)
            Me("fileName") = value
        End Set
    End Property
   
   
   
    <ConfigurationProperty("maxIdleTime"), _
    TypeConverter(GetType(TsMinutesConverter))> _
    Public Property MaxIdleTime() As TimeSpan
        Get
            Return CType(Me("maxIdleTime"), TimeSpan)
        End Get
        Set(ByVal value As TimeSpan)
            Me("maxIdleTime") = Value
        End Set
    End Property

End Class 'CustomSection 

'<Snippet2>

NotInheritable Public Class TsMinutesConverter
   Inherits ConfigurationConverterBase
   
   Friend Function ValidateType(value As Object, expected As Type) As Boolean
      Dim result As Boolean
      
        If Not (value Is Nothing) _
        AndAlso (value.GetType().Equals(expected) <> True) Then
            result = False
        Else
            result = True
        End If
      Return result
   End Function 'ValidateType
   
   
   '<Snippet3>
    Public Overrides Function CanConvertTo( _
    ByVal ctx As ITypeDescriptorContext, _
    ByVal type As Type) As Boolean

        Return type.Equals(GetType(String))

    End Function 'CanConvertTo
   
   '</Snippet3>

    '<Snippet4>
    Public Overrides Function CanConvertFrom( _
    ByVal ctx As ITypeDescriptorContext, _
    ByVal type As Type) As Boolean

        Return type.Equals(GetType(String))

    End Function 'CanConvertFrom
   
    '</Snippet4>

    Public Overrides Function ConvertTo( _
    ByVal ctx As ITypeDescriptorContext, ByVal ci As CultureInfo, _
    ByVal value As Object, ByVal type As Type) As Object
        ValidateType(value, GetType(TimeSpan))

        Dim data As Long = _
        Fix(CType(value, TimeSpan).TotalMinutes)

        Return data.ToString(CultureInfo.InvariantCulture)

    End Function 'ConvertTo
   
   
    Public Overrides Function ConvertFrom( _
    ByVal ctx As ITypeDescriptorContext, ByVal ci As CultureInfo, _
    ByVal data As Object) As Object

        Dim min As Long = _
        Long.Parse(CStr(data), _
        CultureInfo.InvariantCulture)

        Return TimeSpan.FromMinutes( _
        System.Convert.ToDouble(min))

    End Function 'ConvertFrom
End Class 'TsMinutesConverter
'</Snippet2>

Class UsingConfigutationConverterBase
   
   
   ' Create a custom section.
   Shared Sub CreateSection()
      Try
         
         Dim customSection As CustomSection
         
         ' Get the current configuration file.
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)
         
         ' Create the section entry  
         ' in the <configSections> and the 
         ' related target section in <configuration>.
         If config.Sections("CustomSection") Is Nothing Then
            customSection = New CustomSection()
            config.Sections.Add("CustomSection", customSection)
            customSection.SectionInformation.ForceSave = True
            config.Save(ConfigurationSaveMode.Full)
         End If
      Catch err As ConfigurationErrorsException
         Console.WriteLine(err.ToString())
      End Try
   End Sub 'CreateSection
    
   
   
   ' Change custom section and write it to disk.
   Shared Sub SerializeCustomSection()
      Try
            Dim config _
               As System.Configuration.Configuration = _
               ConfigurationManager.OpenExeConfiguration( _
               ConfigurationUserLevel.None)

            Dim customSection _
            As CustomSection = _
            config.Sections.Get("CustomSection")
         Dim ts As New TimeSpan(1, 30, 30)
         
         customSection.MaxIdleTime = ts
         
         config.Save()
         
            Dim maxIdleTime As String = _
            customSection.MaxIdleTime.ToString()
         
            Console.WriteLine( _
            "New max idle time: {0}", maxIdleTime)
      Catch e As Exception
         Console.WriteLine(e.ToString())
      End Try
   End Sub 'SerializeCustomSection
    
   
   ' Read custom section from disk.
   Shared Sub DeserializeCustomSection()
      
      Try
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)
         
            Dim customSection _
            As CustomSection = _
            config.Sections.Get("CustomSection")
         
            Dim maxIdleTime As TimeSpan = _
            customSection.MaxIdleTime
         
         
            Console.WriteLine( _
            "Max idle time: {0}", maxIdleTime.ToString())
      Catch e As Exception
         Console.WriteLine(e.ToString())
      End Try
   End Sub 'DeserializeCustomSection
   

    Public Overloads Shared Sub Main(ByVal args() As String)
        CreateSection()
        SerializeCustomSection()
        DeserializeCustomSection()
    End Sub 'Main 
End Class 'UsingConfigutationConverterBase
'</Snippet1>