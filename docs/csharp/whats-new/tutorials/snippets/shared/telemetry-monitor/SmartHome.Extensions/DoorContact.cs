using SmartHome.Core;

namespace SmartHome.Extensions;

// <DoorContact>
// This type lives in a different assembly than the closed Sensor hierarchy.
// It can't derive from Sensor directly, but it can extend the unsealed Contact
// leaf. A DoorContact still matches the 'Contact' case, so switches over Sensor
// stay exhaustive.
public sealed record class DoorContact(bool Open, string Door) : Contact(Open);
// </DoorContact>
