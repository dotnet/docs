                    ' Get the first client target 
                    ' in the collection.
                    clientTarget = clientTargets(0)

                    ' Get the alias.
                    aliasStr = clientTarget.Alias

                    msg = String.Format( _
                    "Alias:      {0}" + ControlChars.Lf, aliasStr)
