            Dim ProcID As Integer
            ' Start the Calculator application, and store the process id.
            ProcID = Shell("CALC.EXE", AppWinStyle.NormalFocus)
            ' Activate the Calculator application.
            AppActivate(ProcID)
            ' Send the keystrokes to the Calculator application.
            My.Computer.Keyboard.SendKeys("22", True)
            My.Computer.Keyboard.SendKeys("*", True)
            My.Computer.Keyboard.SendKeys("44", True)
            My.Computer.Keyboard.SendKeys("=", True)
            ' The result is 22 * 44 = 968.