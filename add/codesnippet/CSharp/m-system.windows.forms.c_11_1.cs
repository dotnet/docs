    // Demonstrates SetAudio, ContainsAudio, and GetAudioStream.
    public System.IO.Stream SwapClipboardAudio(
        System.IO.Stream replacementAudioStream)
    {
        System.IO.Stream returnAudioStream = null;
        if (Clipboard.ContainsAudio())
        {
            returnAudioStream = Clipboard.GetAudioStream();
            Clipboard.SetAudio(replacementAudioStream);
        }
        return returnAudioStream;
    }