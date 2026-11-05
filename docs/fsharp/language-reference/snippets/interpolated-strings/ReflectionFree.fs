module ReflectionFree

// <ReflectionFree>
type Reading = { Sensor: string; Value: int }
type Outcome = Recorded of Reading | Unavailable

let reading = { Sensor = "north"; Value = 12 }
printn reading
printn (Recorded reading)
// </ReflectionFree>

do
    let text = string reading
    let outcome = string (Recorded reading)
    if not (text.Contains("north") && text.Contains("12") && outcome.Contains("Recorded")) then
        failwith "Generated structural output"
