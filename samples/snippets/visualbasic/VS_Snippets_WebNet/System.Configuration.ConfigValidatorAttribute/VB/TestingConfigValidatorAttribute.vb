 ' File name: TestingConfigValidatorAttribute.cs
' Allowed snippet tags range: [41 - 50].
' <Snippet41>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration




Class TestingConfigValidatorAttribute
    
    Shared Sub New() 
        Try
            
            Dim car As SelectCar
            
            ' Get the current configuration file.
            Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            
            ' Create the section entry for the selected car.
            If config.Sections("Cars") Is Nothing Then
                
                car = New SelectCar()
                
                config.Sections.Add("Cars", car)
                
                car.SectionInformation.ForceSave = True
                config.Save(ConfigurationSaveMode.Full)
            End If 
        
        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    
    End Sub 'New
    
    
    
    Private Shared Sub GetCars() 
        
        Try
            ' Get the current configuration file.
            Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            
            ' Get the Cars section.
            Dim cars As SelectCar = config.GetSection("Cars")
            
            Console.WriteLine("Dream Make: {0} Color: {1} Miles: {2} Year: {3}", cars.Dream.Make, cars.Dream.Color, cars.Dream.Miles, cars.Dream.Year)
            
            Console.WriteLine("Commute Make: {0} Color: {1} Miles: {2} Year: {3}", cars.Commute.Make, cars.Commute.Color, cars.Commute.Miles, cars.Commute.Year)
        
        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    
    End Sub 'GetCars
    
    
    
    Private Shared Sub NotAllowedCars() 
        
        Try
            ' Get the current configuration file.
            Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            
            Dim dreamCar As New Automobile()
            dreamCar.Color = "Red"
            dreamCar.Make = "BMW"
            dreamCar.Miles = 10
            dreamCar.Year = 2005
            
            Dim commuteCar As New Automobile()
            commuteCar.Color = "Blue"
            commuteCar.Make = "Yugo"
            commuteCar.Miles = 10
            commuteCar.Year = 1990
            
            ' Get the Cars section.
            Dim cars As SelectCar = config.GetSection("Cars")
              
            cars.Dream = dreamCar
            cars.Commute = commuteCar
        
        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    
    End Sub 'NotAllowedCars
    
    
    Shared Sub Main(ByVal args() As String) 
        GetCars()
        NotAllowedCars()
    
    End Sub 'Main 
End Class 'TestingConfigValidatorAttribute

' </Snippet41>