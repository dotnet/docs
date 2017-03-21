	public class Temperature {
		public static double MinValue {
			get {
				return Double.MinValue;
			}
		}

		public static double MaxValue {
			get {
				return Double.MaxValue;
			}
		}

		// The value holder
		protected double m_value;

		public double Value {
			get {
				return m_value;
			}
			set {
				m_value = value;
			}
		}

		public double Celsius {
			get {
				return (m_value-32.0)/1.8;
			}
			set {
				m_value = 1.8*value+32.0;
			}
		}
	}