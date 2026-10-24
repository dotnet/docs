module Region

// <Region>
#if EU_WAREHOUSE
let dispatchTimeZone = "Europe/Paris"
#elif US_WAREHOUSE
let dispatchTimeZone = "America/New_York"
#else
let dispatchTimeZone = "UTC"
#endif

System.Console.WriteLine(dispatchTimeZone)
// </Region>
