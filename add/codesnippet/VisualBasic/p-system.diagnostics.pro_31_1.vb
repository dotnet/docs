            Dim myProcess As New Process()
            Dim myProcessStartInfo As New ProcessStartInfo("net ", "use " + args(1))

            myProcessStartInfo.UseShellExecute = False
            myProcessStartInfo.RedirectStandardError = True
            myProcess.StartInfo = myProcessStartInfo
            myProcess.Start()

            Dim myStreamReader As StreamReader = myProcess.StandardError
            ' Read the standard error of net.exe and write it on to console.
            Console.WriteLine(myStreamReader.ReadLine())
            myProcess.Close()