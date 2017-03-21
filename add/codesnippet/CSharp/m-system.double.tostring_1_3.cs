	public class Temperature : IFormattable {
		// IFormattable.ToString implementation.
		public string ToString(string format, IFormatProvider provider) {
			if( format != null ) {
				if( format.Equals("F") ) {
					return String.Format("{0}'F", this.Value.ToString());
				}
				if( format.Equals("C") ) {
					return String.Format("{0}'C", this.Celsius.ToString());
				}
			}

			return m_value.ToString(format, provider);
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