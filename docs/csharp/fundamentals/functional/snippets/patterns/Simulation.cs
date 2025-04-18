namespace patterns;

public enum Operation
{
    SystemTest,
    Start,
    Stop,
    Reset
}

public enum State
{
    Off,
    Ready,
    Running
}

class Simulation
{
    // <PerformOperation>
    public State PerformOperation(Operation command) =>
       command switch
       {
           Operation.SystemTest => RunDiagnostics(),
           Operation.Start => StartSystem(),
           Operation.Stop => StopSystem(),
           Operation.Reset => ResetToReady(),
           _ => throw new ArgumentException("Invalid enum value for command", nameof(command)),
       };
    // </PerformOperation>

    // <PerformStringOperation>
    public State PerformOperation(string command) =>
       command switch
       {
           "SystemTest" => RunDiagnostics(),
           "Start" => StartSystem(),
           "Stop" => StopSystem(),
           "Reset" => ResetToReady(),
           _ => throw new ArgumentException("Invalid string value for command", nameof(command)),
       };
    // </PerformStringOperation>

    // <PerformSpanOperation>
    public State PerformOperation(ReadOnlySpan<char> command) =>
       command switch
       {
           "SystemTest" => RunDiagnostics(),
           "Start" => StartSystem(),
           "Stop" => StopSystem(),
           "Reset" => ResetToReady(),
           _ => throw new ArgumentException("Invalid string value for command", nameof(command)),
       };
    // </PerformSpanOperation>

    // <RelationalPattern>
    string WaterState(int tempInFahrenheit) =>
        tempInFahrenheit switch
        {
            < 32 => "solid",
            32 => "solid/liquid transition",
            (> 32) and (< 212) => "liquid",
            212 => "liquid / gas transition",
            > 212 => "gas",
        };
    // </RelationalPattern>

    // <RelationalPattern2>
    string WaterState2(int tempInFahrenheit) =>
        tempInFahrenheit switch
        {
            < 32 => "solid",
            32 => "solid/liquid transition",
            < 212 => "liquid",
            212 => "liquid / gas transition",
            _ => "gas",
    };
    // </RelationalPattern2>

    private State ResetToReady() => State.Ready;
    private State StopSystem() => State.Off;
    private State StartSystem() => State.Running;
    private State RunDiagnostics() => State.Ready;
}
