	public class Temperature {
		// Parses the temperature from a string in form
		// [ws][sign]digits['F|'C][ws]
		public static Temperature Parse(string s) {
			Temperature temp = new Temperature();

			if( s.TrimEnd(null).EndsWith("'F") ) {
				temp.Value = Double.Parse( s.Remove(s.LastIndexOf('\''), 2) );
			}
			else if( s.TrimEnd(null).EndsWith("'C") ) {
				temp.Celsius = Double.Parse( s.Remove(s.LastIndexOf('\''), 2) );
			}
			else {
				temp.Value = Double.Parse(s);
			}

			return temp;
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