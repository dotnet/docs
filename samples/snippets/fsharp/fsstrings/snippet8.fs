
    let sayLetter inputChar =
        if (not (System.Char.IsLetterOrDigit(inputChar))) then () else
        let simpleSound = new System.Media.SoundPlayer(sprintf "%s\\%c.wav" basePath (System.Char.ToLower(inputChar)))
        simpleSound.Play()
        System.Threading.Thread.Sleep(1000)
    while true do
        let input = System.Console.ReadLine()
        String.iter (fun c -> sayLetter(c)) input