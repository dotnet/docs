' <Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.ComponentModel

Namespace Samples.AspNet.Configuration

    ' Implements a custom validator attribute. 
    <AttributeUsage(AttributeTargets.Property)> _
      Public NotInheritable Class CustomValidatorAttribute
        Inherits ConfigurationValidatorAttribute

        Public Sub New()
        End Sub 'New

        Public Sub New(ByVal validator As Type)
            MyBase.New(validator)
        End Sub 'New

        Public Shadows ReadOnly Property _
        ValidatorType() As Type
            Get
                Return [GetType]()
            End Get
        End Property

        Public Overrides ReadOnly Property ValidatorInstance() As ConfigurationValidatorBase
            Get
                ' <Snippet2>
                ' Create validator.
                Return New PositiveTimeSpanValidator()
                ' </Snippet2>
            End Get
        End Property
    End Class

    ' Implements a custom section class.
    Public Class SampleSection
        Inherits ConfigurationSection
        <ConfigurationProperty("name", DefaultValue:="MyBuildRoutine", IsRequired:=True), _
        StringValidator(InvalidCharacters:=" ~!@#$%^&*()[]{}/;'""|\", _
        MinLength:=1, MaxLength:=60)> _
         Public Property Name() As String
            Get
                Return CType(Me("name"), String)
            End Get
            Set(ByVal Value As String)
                Me("name") = Value
            End Set
        End Property

        <ConfigurationProperty("BuildStartTime", IsRequired:=True, _
          DefaultValue:="09:00:00")> _
        Public Property BuildStartTime() As TimeSpan
            Get
                Dim myTSC As TimeSpanConverter = New TimeSpanConverter()
                Return CType(Me("BuildStartTime"), TimeSpan)
            End Get
            Set(ByVal Value As TimeSpan)
                Me("BuildStartTime") = Value.ToString()
            End Set
        End Property

        <ConfigurationProperty("BuildEndTime", IsRequired:=True, _
          DefaultValue:="17:00:00")> _
        Public Property BuildEndTime() As TimeSpan
            Get
                Dim myTSC As TimeSpanConverter = New TimeSpanConverter()
                Return CType(Me("BuildEndTime"), TimeSpan)
            End Get
            Set(ByVal Value As TimeSpan)
                Me("BuildEndTime") = Value.ToString()
            End Set
        End Property
    End Class

    ' Implements the console user interface.
    Class TestingCustomValidatorAttribute
        ' Shows how to use the ValidatorInstance method.
        Public Shared Sub GetCustomValidatorInstance()
            Dim valBase As ConfigurationValidatorBase
            Dim customValAttr As CustomValidatorAttribute
            customValAttr = New CustomValidatorAttribute()

            Dim sampleSection As SampleSection = ConfigurationManager.GetSection("MyDailyProcess")

            Dim myTSC As TimeSpanConverter = New TimeSpanConverter()
            Dim StartTimeSpan As TimeSpan = CType(myTSC.ConvertFromString(SampleSection.BuildStartTime.ToString()), TimeSpan)
            Dim EndTimeSpan As TimeSpan = CType(myTSC.ConvertFromString(SampleSection.BuildEndTime.ToString()), TimeSpan)
            Dim resultTimeSpan As TimeSpan = EndTimeSpan - StartTimeSpan

            Try
                ' <Snippet3>
                ' Determine if the Validator can validate
                ' the type it contains.
                valBase = customValAttr.ValidatorInstance
                If valBase.CanValidate(resultTimeSpan.GetType()) Then
                    ' <Snippet4>
                    ' Validate the TimeSpan using a
                    ' custom PositiveTimeSpanValidator.
                    valBase.Validate(resultTimeSpan)
                    ' </Snippet4>
                End If
                ' </Snippet3>
            Catch e As ArgumentException
                ' Store error message.
                Dim msg As String = e.Message.ToString()
#If DEBUG Then
                Console.WriteLine("Error: {0}", msg)
#End If
            End Try
        End Sub

        ' Create required sections.
        Shared Sub CreateSection()
            ' Get the current configuration (file).
            Dim config As System.Configuration.Configuration = _
              ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

            ' Define the sample section.
            Dim sampleSection As SampleSection

            ' Create the handler section named MyDailyProcess 
            ' in the <configSections>. Also, create the 
            ' <MyDailyProcess> target section
            ' in <configuration>.
            If config.Sections("MyDailyProcess") Is Nothing Then
                sampleSection = New SampleSection()
                config.Sections.Add("MyDailyProcess", sampleSection)
                sampleSection.SectionInformation.ForceSave = True
                config.Save(ConfigurationSaveMode.Full)
            End If
        End Sub

        Shared Sub DisplaySectionProperties()
            Dim sampleSection As SampleSection = ConfigurationManager.GetSection("MyDailyProcess")

            If SampleSection Is Nothing Then
                Console.WriteLine("Failed to load section.")
            Else
                Console.WriteLine("Defaults:")
                Console.WriteLine("  Name: {0}", SampleSection.Name)
                Console.WriteLine("  BuildStartTime: {0}", SampleSection.BuildStartTime)
                Console.WriteLine("  BuildEndTime: {0}", SampleSection.BuildEndTime)
            End If
        End Sub

        Shared Sub Main(ByVal args() As String)
            Console.WriteLine("[Create a section]")
            CreateSection()

            Console.WriteLine("[Display section information]")
            DisplaySectionProperties()

            ' Show how to use the ValidatorInstance method.
            GetCustomValidatorInstance()

            ' Display and wait.
            Console.ReadLine()
        End Sub
    End Class
End Namespace
' </Snippet1>
