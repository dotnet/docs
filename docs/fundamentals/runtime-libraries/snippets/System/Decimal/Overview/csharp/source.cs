using System;

namespace Snippets
{
	class Launcher {
		static void Main(string[] args)
		{
			PiggyBank pb = new PiggyBank();

			for(int i=0; i<378; i++) {
				pb.AddPenny();
			}

			Console.WriteLine(pb);

			Console.ReadLine();
		}
	}

	//<snippet1>
	/// <summary>
	/// Keeping my fortune in Decimals to avoid the round-off errors.
	/// </summary>
	class PiggyBank {
		protected decimal MyFortune;

		public void AddPenny() {
			MyFortune = Decimal.Add(MyFortune, .01m);
		}

		public decimal Capacity {
			get {
				return Decimal.MaxValue;
			}
		}

		public decimal Dollars {
			get {
				return Decimal.Floor(MyFortune);
			}
		}

		public decimal Cents {
			get {
				return Decimal.Subtract(MyFortune, Decimal.Floor(MyFortune));
			}
		}

		public override string ToString() {
			return MyFortune.ToString("C")+" in piggy bank";
		}
	}
	//</snippet1>
}

namespace Snippets2 {
	//<snippet2>
	class PiggyBank {
		public decimal Capacity {
			get {
				return Decimal.MaxValue;
			}
		}

		protected decimal MyFortune;

		public void AddPenny() {
			MyFortune += .01m;
		}
	}
	//</snippet2>
}

namespace Snippets3 {
	//<snippet3>
	class PiggyBank {
		public decimal Dollars {
			get {
				return Decimal.Floor(MyFortune);
			}
		}

		protected decimal MyFortune;

		public void AddPenny() {
			MyFortune += .01m;
		}
	}
	//</snippet3>
}

namespace Snippets4 {
	//<snippet4>
	class PiggyBank {
		public decimal Cents {
			get {
				return Decimal.Subtract(MyFortune, Decimal.Floor(MyFortune));
			}
		}

		protected decimal MyFortune;

		public void AddPenny() {
			MyFortune += .01m;
		}
	}
	//</snippet4>
}

namespace Snippets5 {
	//<snippet5>
	class PiggyBank {
		public void AddPenny() {
			MyFortune = Decimal.Add(MyFortune, .01m);
		}

		public override string ToString() {
			return MyFortune.ToString("C")+" in piggy bank";
		}

		protected decimal MyFortune;
	}
	//</snippet5>
}