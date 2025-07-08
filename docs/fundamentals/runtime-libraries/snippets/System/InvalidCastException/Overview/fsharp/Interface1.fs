module Interface1

// <Snippet3>
open System
open System.Globalization

let culture = CultureInfo.InvariantCulture
let provider: IFormatProvider = culture

let dt = provider :?> DateTimeFormatInfo

// The example displays the following output:
//    Unhandled Exception: System.InvalidCastException:
//       Unable to cast object of type //System.Globalization.CultureInfo// to
//           type //System.Globalization.DateTimeFormatInfo//.
//       at Example.main()
// </Snippet3>