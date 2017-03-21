	// The Temperature class stores the temperature as a Double
	// and delegates most of the functionality to the Double
	// implementation.
	public class Temperature : IComparable, IFormattable 
    {
		// IComparable.CompareTo implementation.
		public int CompareTo(object obj) {
            if (obj == null) return 1;
            
			Temperature temp = obj as Temperature;
            if (obj != null) 
				return m_value.CompareTo(temp.m_value);
			else
     			throw new ArgumentException("object is not a Temperature");	
		}

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

		// Parses the temperature from a string in the form
		// [ws][sign]digits['F|'C][ws]
		public static Temperature Parse(string s, NumberStyles styles, IFormatProvider provider) {
			Temperature temp = new Temperature();

			if( s.TrimEnd(null).EndsWith("'F") ) {
				temp.Value = Double.Parse( s.Remove(s.LastIndexOf('\''), 2), styles, provider);
			}
			else if( s.TrimEnd(null).EndsWith("'C") ) {
				temp.Celsius = Double.Parse( s.Remove(s.LastIndexOf('\''), 2), styles, provider);
			}
			else {
				temp.Value = Double.Parse(s, styles, provider);
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