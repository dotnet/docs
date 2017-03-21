' Define a custom section.
' The CustomSection type allows to define a custom section 
' programmatically.

NotInheritable Public Class CustomSection
   Inherits ConfigurationSection
   ' The collection (property bag) that contains 
   ' the section properties.
   Private Shared _Properties As ConfigurationPropertyCollection
   
   ' Internal flag to disable 
   ' property setting.
   Private Shared _ReadOnly As Boolean
   
   ' The FileName property.
    Private Shared _FileName As New ConfigurationProperty( _
    "fileName", GetType(String), _
    "default.txt", _
    ConfigurationPropertyOptions.IsRequired)
   
   ' The MaxUsers property.
    Private Shared _MaxUsers As New ConfigurationProperty( _
    "maxUsers", GetType(Long), _
    CType(1000, Long), _
    ConfigurationPropertyOptions.None)
   
   ' The MaxIdleTime property.
    Private Shared _MaxIdleTime As New ConfigurationProperty( _
    "maxIdleTime", GetType(TimeSpan), _
    TimeSpan.FromMinutes(5), _
    ConfigurationPropertyOptions.IsRequired)
   
   
   ' CustomSection constructor.
   Public Sub New()
      ' Property initialization
        _Properties = _
        New ConfigurationPropertyCollection()
      
      _Properties.Add(_FileName)
      _Properties.Add(_MaxUsers)
      _Properties.Add(_MaxIdleTime)
   End Sub 'New
   
   
   ' This is a key customization. 
   ' It returns the initialized property bag.
    Protected Overrides ReadOnly Property Properties() _
    As ConfigurationPropertyCollection
        Get
            Return _Properties
        End Get
    End Property
   
   
   
   Private Shadows ReadOnly Property IsReadOnly() As Boolean
      Get
         Return _ReadOnly
      End Get
   End Property
   
   
   ' Use this to disable property setting.
   Private Sub ThrowIfReadOnly(propertyName As String)
      If IsReadOnly Then
            Throw New ConfigurationErrorsException( _
            "The property " + propertyName + " is read only.")
      End If
   End Sub 'ThrowIfReadOnly
   
   
   
   ' Customizes the use of CustomSection
    ' by setting _ReadOnly to false.
   ' Remember you must use it along with ThrowIfReadOnly.
   Protected Overrides Function GetRuntimeObject() As Object
      ' To enable property setting just assign true to
      ' the following flag.
      _ReadOnly = True
      Return MyBase.GetRuntimeObject()
   End Function 'GetRuntimeObject
   
   
    <StringValidator( _
    InvalidCharacters:=" ~!@#$%^&*()[]{}/;'""|\", _
    MinLength:=1, MaxLength:=60)> _
    Public Property FileName() As String
        Get
            Return CStr(Me("fileName"))
        End Get
        Set(ByVal value As String)
            ' With this you disable the setting.
            ' Remember that the _ReadOnly flag must
            ' be set to true in the GetRuntimeObject.
            ThrowIfReadOnly("FileName")
            Me("fileName") = value
        End Set
    End Property
   
   
    <LongValidator( _
    MinValue:=1, MaxValue:=1000000, _
    ExcludeRange:=False)> _
    Public Property MaxUsers() As Long
        Get
            Return Fix(Me("maxUsers"))
        End Get
        Set(ByVal value As Long)
            Me("maxUsers") = Value
        End Set
    End Property
   
   
    <TimeSpanValidator( _
    MinValueString:="0:0:30", _
    MaxValueString:="5:00:0", ExcludeRange:=False)> _
    Public Property MaxIdleTime() As TimeSpan
        Get
            Return CType(Me("maxIdleTime"), TimeSpan)
        End Get
        Set(ByVal value As TimeSpan)
            Me("maxIdleTime") = Value
        End Set
    End Property
End Class 'CustomSection 