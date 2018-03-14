// <Snippet4>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;

    // Define the enumeration to apply
    // to the OrderQty data field.
    // This enumeration is used for filtering.
    public enum QtyEnum
    {
        None        = 0,
        Small1      = 1,
        Small2      = 2,
        Small3      = 3,
        Medium10    = 10,
        Medium11    = 11,
        Medium12    = 12,
        Medium13    = 13,
        Medium14    = 14,
        Large21     = 21,
        Large22     = 22,
        Large23     = 23,
        XLarge60    = 60,
        XLarge70    = 70
    }

    [MetadataType(typeof(SalesOrderDetail_MD))]
    public partial class SalesOrderDetail {

        private class SalesOrderDetail_MD
        {
            // Qualify the OrderQty field 
            // with the applicable 
            // enumeration type.
            [EnumDataType(typeof(QtyEnum))] 
            public object OrderQty { get; set; }
        }
    }

// </Snippet4>