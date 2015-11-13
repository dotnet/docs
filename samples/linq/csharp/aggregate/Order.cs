using System;

namespace Aggregate
{
	public class Order
	{
		public int OrderID { get; set; }
		public int CustomerID { get; set;}
		public DateTime OrderDate { get; set; }
		public decimal Total { get; set; }
	}
}