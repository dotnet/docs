	class PiggyBank {
		public void AddPenny() {
			MyFortune = Decimal.Add(MyFortune, .01m);
		}

		public override string ToString() {
			return MyFortune.ToString("C")+" in piggy bank";
		}

		protected decimal MyFortune;
	}