using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This file contains versions of the code used in the patterns & objects tutorial
namespace InterimSteps
{
    // <APIDesign>
    public enum WaterLevel
    {
        Low,
        High
    }
    public class CanalLock
    {
        // Query canal lock state:
        public WaterLevel CanalLockWaterLevel { get; private set; } = WaterLevel.Low;
        public bool HighWaterGateOpen { get; private set; } = false;
        public bool LowWaterGateOpen { get; private set; } = false;

        // Change the upper gate.
        public void SetHighGate(bool open)
        {
            throw new NotImplementedException();
        }

        // Change the lower gate.
        public void SetLowGate(bool open)
        {
            throw new NotImplementedException();
        }

        // Change water level.
        public void SetWaterLevel(WaterLevel newLevel)
        {
            throw new NotImplementedException();
        }

        public override string ToString() =>
            $"The lower gate is {(LowWaterGateOpen ? "Open" : "Closed")}. " +
            $"The upper gate is {(HighWaterGateOpen ? "Open" : "Closed")}. " +
            $"The water level is {CanalLockWaterLevel}.";
    }
    // </APIDesign>

    public class CanalLockV2
    {
        // Query canal lock state:
        public WaterLevel CanalLockWaterLevel { get; private set; } = WaterLevel.Low;
        public bool HighWaterGateOpen { get; private set; } = false;
        public bool LowWaterGateOpen { get; private set; } = false;

        // <FirstImplementation>
        // Change the upper gate.
        public void SetHighGate(bool open)
        {
            HighWaterGateOpen = open;
        }

        // Change the lower gate.
        public void SetLowGate(bool open)
        {
            LowWaterGateOpen = open;
        }

        // Change water level.
        public void SetWaterLevel(WaterLevel newLevel)
        {
            CanalLockWaterLevel = newLevel;
        }
        // </FirstImplementation>
    }

    public class CanalLockV3
    {
        // Query canal lock state:
        public WaterLevel CanalLockWaterLevel { get; private set; } = WaterLevel.Low;
        public bool HighWaterGateOpen { get; private set; } = false;
        public bool LowWaterGateOpen { get; private set; } = false;

        // <SecondImplementation>
        // Change the upper gate.
        public void SetHighGate(bool open)
        {
            if (open && (CanalLockWaterLevel == WaterLevel.High))
                HighWaterGateOpen = true;
            else if (open && (CanalLockWaterLevel == WaterLevel.Low))
                throw new InvalidOperationException("Cannot open high gate when the water is low");
        }
        // </SecondImplementation>

        private void SetHighGateV2(bool open)
        {
#pragma warning disable CS8524 // The switch expression does not handle some values of its input type (it is not exhaustive) involving an unnamed enum value.
            // <ThirdImplementation>
            HighWaterGateOpen = (open, HighWaterGateOpen, CanalLockWaterLevel) switch
            {
                (false, false, WaterLevel.High) => false,
                (false, false, WaterLevel.Low) => false,
                (false, true, WaterLevel.High) => false,
                (false, true, WaterLevel.Low) => false, // should never happen
                (true, false, WaterLevel.High) => true,
                (true, false, WaterLevel.Low) => throw new InvalidOperationException("Cannot open high gate when the water is low"),
                (true, true, WaterLevel.High) => true,
                (true, true, WaterLevel.Low) => false, // should never happen
            };
            // </ThirdImplementation>
#pragma warning restore CS8524 // The switch expression does not handle some values of its input type (it is not exhaustive) involving an unnamed enum value.
        }
    }
}
