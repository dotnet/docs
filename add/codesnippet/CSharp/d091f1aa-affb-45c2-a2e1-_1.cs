
	MethodBuilder myMethod = myDynamicType.DefineMethod("MyMethod",
						MethodAttributes.Public,
						typeof(int),
						new Type[] { typeof(string) });

	// A 128-bit key in hex form, represented as a byte array.
	byte[] keyVal = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			  0x00, 0x00, 0x00, 0x00, 0x00, 0x60, 0xFF, 0xFF };	

	System.Text.ASCIIEncoding encoder = new System.Text.ASCIIEncoding();
	byte[] symFullName = encoder.GetBytes("My Dynamic Method");

	myMethod.SetSymCustomAttribute("SymID", keyVal);
	myMethod.SetSymCustomAttribute("SymFullName", symFullName);
