	public class Temperature {
		public static uint MinValue {
			get {
				return UInt32.MinValue;
			}
		}

		public static uint MaxValue {
			get {
				return UInt32.MaxValue;
			}
		}

		// The value holder
		protected uint m_value;

		public uint Value {
			get {
				return m_value;
			}
			set {
				m_value = value;
			}
		}
	}