using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiFarePrediction
{
    // <Snippet1>
    static class TestTrips
    // </Snippet1>
    {
        // <Snippet2>
        internal static readonly TaxiTrip Trip1 = new TaxiTrip
        {
            VendorId = "VTS",
            RateCode = "1",
            PassengerCount = 1,
            TripDistance = 10.33f,
            PaymentType = "CSH",
            FareAmount = 0 // predict it. actual = 29.5
        };
        // </Snippet2>
    }
}
