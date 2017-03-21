                _cbmParameter = new ClientBuildManagerParameter();
                _cbmParameter.PrecompilationFlags = _flags;
                _cbmParameter.StrongNameKeyFile = _keyFile;

                builder = new
                        ClientBuildManager(_vPath, _pPath, _tPath, _cbmParameter);