module formatoverload2

open System

// <Snippet9>
// Create a list of 5-tuples with population data for three U.S. cities, 1940-1950.
let cities = 
    [ "Los Angeles", DateTime(1940, 1, 1), 1504277, DateTime(1950, 1, 1), 1970358
      "New York", DateTime(1940, 1, 1), 7454995, DateTime(1950, 1, 1), 7891957
      "Chicago", DateTime(1940, 1, 1), 3396808, DateTime(1950, 1, 1), 3620962
      "Detroit", DateTime(1940, 1, 1), 1623452, DateTime(1950, 1, 1), 1849568 ]

// Display header
String.Format("{0,-12}{1,8}{2,12}{1,8}{2,12}{3,14}\n", "City", "Year", "Population", "Change (%)")
|> printfn "%s"

for name, year1, pop1, year2, pop2 in cities do
    String.Format("{0,-12}{1,8:yyyy}{2,12:N0}{3,8:yyyy}{4,12:N0}{5,14:P1}",
                  name, year1, pop1, year2, pop2,
                  double (pop2 - pop1) / double pop1)
    |> printfn "%s"
// The example displays the following output:
//    City            Year  Population    Year  Population    Change (%)
//  
//    Los Angeles     1940   1,504,277    1950   1,970,358        31.0 %
//    New York        1940   7,454,995    1950   7,891,957         5.9 %
//    Chicago         1940   3,396,808    1950   3,620,962         6.6 %
//    Detroit         1940   1,623,452    1950   1,849,568        13.9 %
// </Snippet9>