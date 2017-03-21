                    ' Get the .<outputCache> section
                    Dim outputCache _
                    As OutputCacheSection = _
                    cachingSectionGroup.OutputCache

                    ' Display one of its properties.
                    msg = String.Format( _
                    "Enable output cache: {0}" + _
                    ControlChars.Lf, _
                    outputCache.EnableOutputCache.ToString())

                    Console.Write(msg)
