'<snippet0>
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.IO
Imports System.Xml
'</snippet0>

<DataContract()> _
Public Class MyCar
    <DataMember()> _
    Public Features As CarFeatures
End Class


Public Class Test
    Shared Sub Main()
        Console.WriteLine("Starting")
        Dim t As new Test()
        t.Run()
        Console.WriteLine("Done")
        Console.ReadLine()
    End Sub

    Private Sub Run()

        Dim fs As FileStream = New FileStream("carsVB.xml", FileMode.Create)
        Dim writer As XmlDictionaryWriter = XmlDictionaryWriter.CreateTextWriter(fs, Encoding.UTF8)

        Dim ser As DataContractSerializer = new DataContractSerializer(GetType(MyCar))
        Dim cf2 As CarFeatures = ctype(5, CarFeatures)
        ' Serialized as <cf2>AirConditioner PowerDoors</cf2> since 5=1+4
        Dim car2 As MyCar = new MyCar()
        car2.Features = cf2
        ser.WriteObject(writer, car2)
        writer.Close()
    End Sub
End Class


'<snippet1>
<DataContract()> _
Public Class Car
    <DataMember()> _
    Public model As String
    <DataMember()> _
    Public condition As CarConditionEnum
End Class

<DataContract(Name:="CarCondition")> _
Public Enum CarConditionEnum
    <EnumMember> NewCar
    <EnumMember> Used
    <EnumMember> Rental
    Broken
    Stolen
End Enum
'</snippet1>

'<snippet2>
<DataContract(Name:="CarCondition")> _
Public Enum CarConditionWithNumbers
    <EnumMember> NewCar = 10
    <EnumMember> Used = 20
    <EnumMember> Rental = 30
End Enum
'</snippet2>

'<snippet3>
<DataContract(Name:="CarCondition")> _
Public Enum CarConditionWithDifferentNames
    <EnumMember(Value:="New")> BrandNew
    <EnumMember(Value:="Used")> PreviouslyOwned
    <EnumMember> Rental
End Enum
'</snippet3>

'<snippet4>
<DataContract(), Flags()> _
Public Enum CarFeatures
    None = 0
    <EnumMember> AirConditioner = 1
    <EnumMember> AutomaticTransmission = 2
    <EnumMember> PowerDoors = 4
    AlloyWheels = 8
    DeluxePackage = AirConditioner Or AutomaticTransmission Or PowerDoors Or AlloyWheels
    <EnumMember> CDPlayer = 16
    <EnumMember> TapePlayer = 32
    MusicPackage = CDPlayer Or TapePlayer
    <EnumMember> Everything = DeluxePackage Or MusicPackage
End Enum
'</snippet4>

Public Class FlagsExample
    '<snippet5>
    Private cf1 As CarFeatures = CarFeatures.AutomaticTransmission
    'Serialized as <cf1>AutomaticTransmission</cf1>

    Private cf2 As CarFeatures = ctype(5, CarFeatures)
    'Serialized as <cf2>AirConditioner PowerDoors</cf2> since 5=1+4

    Private cf3 As CarFeatures = CarFeatures.MusicPackage
    'Serialized as <cf3>CDPlayer TapePlayer</cf3> since MusicPackage 
    ' itself is not an EnumMember.

    Private cf4 As CarFeatures = CarFeatures.Everything
    'Serialized as <cf4>Everything</cf4> since Everything itself is an EnumMember.

    Private cf5 As CarFeatures = CarFeatures.DeluxePackage
    'Throws a SerializationException since neither DeluxePackage nor 
    ' AlloyWheels are EnumMembers.

    Private cf6 As CarFeatures = CarFeatures.None
    'Serialized as the empty list <cf6></cf6> since there is no EnumMember mapped to zero.
    '</snippet5>
End Class

'<snippet6>
Public Enum CarCondition
    [New]
    Used
    Rental
End Enum
'</snippet6>
