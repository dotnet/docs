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