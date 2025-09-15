public record class GateAttendance(string GateId)
{
    public int Count { get; private set; }

    public static GateAttendance operator ++(GateAttendance gate)
    {
        GateAttendance updateGate = gate with { Count = gate.Count + 1 };
        return updateGate;
    }

    public static GateAttendance operator +(GateAttendance gate, int partySize)
    {
        GateAttendance updateGate = gate with { Count = gate.Count + partySize };
        return updateGate;
    }

    // <CompoundAssignmentOperators>
    public void operator ++() => Count++;

    public void operator +=(int partySize) => Count += partySize;
    // </CompoundAssignmentOperators>
}

namespace InitialImplementation
{
    // <GateAttendanceStarter>
    public record class GateAttendance(string GateId)
    {
        public int Count { get; init; }

        public static GateAttendance operator ++(GateAttendance gate)
        {
            GateAttendance updateGate = gate with { Count = gate.Count + 1 };
            return updateGate;
        }

        public static GateAttendance operator +(GateAttendance gate, int partySize)
        {
            GateAttendance updateGate = gate with { Count = gate.Count + partySize };
            return updateGate;
        }
    }     
    // </GateAttendanceStarter>
}
