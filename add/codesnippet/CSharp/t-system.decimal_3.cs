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