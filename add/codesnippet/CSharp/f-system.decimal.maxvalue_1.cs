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