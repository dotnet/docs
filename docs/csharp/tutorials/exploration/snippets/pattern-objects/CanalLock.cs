using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pattern_objects
{
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

        // change the upper gate
        public void SetHighGate(bool open)
        {
            HighWaterGateOpen = (open, HighWaterGateOpen, CanalLockWaterLevel) switch
            {
                (false, _,    _)               => false,
                (true, _,     WaterLevel.High) => true,
                (true, false, WaterLevel.Low)  => throw new InvalidOperationException("Cannot open high gate when the water is low"),
                _                              => throw new InvalidOperationException("Invalid internal state"),
            };
        }

        // change the lower gate
        public void SetLowGate(bool open)
        {
            LowWaterGateOpen = (open, LowWaterGateOpen, CanalLockWaterLevel) switch
            {
                (false, _, _) => false,
                (true, _, WaterLevel.Low) => true,
                (true, false, WaterLevel.High) => throw new InvalidOperationException("Cannot open high gate when the water is low"),
                _ => throw new InvalidOperationException("Invalid internal state"),
            };
        }

        // Change water level
        public void SetWaterLevel(WaterLevel newLevel)
        {
            CanalLockWaterLevel = (newLevel, CanalLockWaterLevel, LowWaterGateOpen, HighWaterGateOpen) switch
            {
                (WaterLevel.Low, WaterLevel.Low, true, false) => WaterLevel.Low,
                (WaterLevel.High, WaterLevel.High, false, true) => WaterLevel.High,
                (WaterLevel.Low, _, false, false) => WaterLevel.Low,
                (WaterLevel.High, _, false, false) => WaterLevel.High,
                (WaterLevel.Low, WaterLevel.High, false, true) => throw new InvalidOperationException("Cannot lower water when the high gate is open"),
                (WaterLevel.High, WaterLevel.Low, true, false) => throw new InvalidOperationException("Cannot raise water when the low gate is open"),
                _ => throw new InvalidOperationException("Invalid internal state"),
            };
        }

        public override string ToString() =>
            $"The lower gate is {(LowWaterGateOpen ? "Open" : "Closed")}. " +
            $"The upper gate is {(HighWaterGateOpen ? "Open" : "Closed")}. " +
            $"The water level is {CanalLockWaterLevel}.";

        // Interim steps:
        private void SetHighGateV1(bool open)
        {
            if (open && (CanalLockWaterLevel == WaterLevel.High))
                HighWaterGateOpen = true;
            else if (open && (CanalLockWaterLevel == WaterLevel.Low))
                throw new InvalidOperationException("Cannot open high gate when the water is low");
        }
        private void SetHighGateV2(bool open)
        {
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
                _ => throw new InvalidOperationException("Invalid internal state"),
            };

        }
    }
}
