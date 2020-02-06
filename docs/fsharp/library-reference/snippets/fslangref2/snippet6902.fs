
 [<Measure>] type degC // temperature, Celsius/Centigrade
 [<Measure>] type degF // temperature, Fahrenheit

 let convertCtoF ( temp : float<degC> ) = 9.0<degF> / 5.0<degC> * temp + 32.0<degF>
 let convertFtoC ( temp: float<degF> ) = 5.0<degC> / 9.0<degF> * ( temp - 32.0<degF>)

 // Define conversion functions from dimensionless floating point values.
 let degreesFahrenheit temp = temp * 1.0<degF>
 let degreesCelsius temp = temp * 1.0<degC>

 printfn "Enter a temperature in degrees Fahrenheit."
 let input = System.Console.ReadLine()
 let mutable floatValue = 0.
 if System.Double.TryParse(input, &floatValue)
    then 
       printfn "That temperature in Celsius is %8.2f degrees C." ((convertFtoC (degreesFahrenheit floatValue))/(1.0<degC>))
    else
       printfn "Error parsing input."