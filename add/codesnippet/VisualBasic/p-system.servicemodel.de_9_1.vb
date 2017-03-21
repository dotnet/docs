			Dim hasProtectionLevel As Boolean = cd.HasProtectionLevel
			If hasProtectionLevel Then
				Dim protectionLevel As ProtectionLevel = cd.ProtectionLevel
				Console.WriteLine(Constants.vbTab & "Protection Level: {0}", protectionLevel.ToString())
			End If