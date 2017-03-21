                _cbmParameter = New ClientBuildManagerParameter()
                _cbmParameter.PrecompilationFlags = _flags
                _cbmParameter.StrongNameKeyFile = _keyFile

                builder = New ClientBuildManager(_vPath, _pPath, _tPath, _cbmParameter)