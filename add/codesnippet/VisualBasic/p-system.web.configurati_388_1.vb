                    ' Get the <cache> section.
                    Dim cache As CacheSection = _
                    cachingSectionGroup.Cache

                    ' Display one of its properties.
                    msg = String.Format( _
                    "Cache disable expiration: {0}" + _
                    ControlChars.Lf, cache.DisableExpiration)

                    Console.Write(msg)
