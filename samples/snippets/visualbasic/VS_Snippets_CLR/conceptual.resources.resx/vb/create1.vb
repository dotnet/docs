' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Drawing
Imports System.Resources

<Serializable()> Public Class Automobile
   Private carMake As String
   Private carModel As String
   Private carYear As Integer
   Private carDoors AS Integer
   Private carCylinders As Integer
   
   Public Sub New(make As String, model As String, year As Integer) 
      Me.New(make, model, year, 0, 0)   
   End Sub
   
   Public Sub New(make As String, model As String, year As Integer, 
                  doors As Integer, cylinders As Integer)
      Me.carMake = make
      Me.carModel = model
      Me.carYear = year
      Me.carDoors = doors
      Me.carCylinders = cylinders
   End Sub

   Public ReadOnly Property Make As String
      Get
         Return Me.carMake
      End Get   
   End Property       
   
   Public ReadOnly Property Model As String
      Get
         Return Me.carModel
      End Get   
   End Property       
   
   Public ReadOnly Property Year As Integer
      Get
         Return Me.carYear
      End Get   
   End Property       
   
   Public ReadOnly Property Doors As Integer
      Get
         Return Me.carDoors
      End Get   
   End Property       
   
   Public ReadOnly Property Cylinders As Integer
      Get
         Return Me.carCylinders
      End Get   
   End Property       
End Class

Module Example
   Public Sub Main()
      ' Instantiate an Automobile object.
      Dim car1 As New Automobile("Ford", "Model N", 1906, 0, 4)
      Dim car2 As New Automobile("Ford", "Model T", 1909, 2, 4)
      ' Define a resource file named CarResources.resx.
      Using resx As New ResXResourceWriter(".\CarResources.resx")
         resx.AddResource("Title", "Classic American Cars")
         resx.AddResource("HeaderString1", "Make")
         resx.AddResource("HeaderString2", "Model")
         resx.AddResource("HeaderString3", "Year")
         resx.AddResource("HeaderString4", "Doors")
         resx.AddResource("HeaderString5", "Cylinders")
         resx.AddResource("Information", SystemIcons.Information) 
         resx.AddResource("EarlyAuto1", car1)
         resx.AddResource("EarlyAuto2", car2)  
      End Using
   End Sub
End Module
' </Snippet1>
