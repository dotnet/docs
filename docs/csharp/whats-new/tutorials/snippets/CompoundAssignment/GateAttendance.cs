public record class GateAttendance(string GateId)
{
    private int count = 0;

    public int Count => count;

    public static GateAttendance operator ++(GateAttendance gate)
    {
        GateAttendance updateGate = gate with { count = gate.count + 1 };
        return updateGate;
    }

    public static GateAttendance operator +(GateAttendance gate, int partySize)
    {
        GateAttendance updateGate = gate with { count = gate.count + partySize };
        return updateGate;
    }

    // New style:
    public void operator ++() => this.count++;

    public void operator +=(int partySize) => this.count += partySize;
}

