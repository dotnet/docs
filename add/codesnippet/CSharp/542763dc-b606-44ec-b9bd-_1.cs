            // Create an InstallContext object with the given parameters.
            String[] commandLine = new string[ args.Length ];
            for( int i = 0; i < args.Length; i++ )
            {
               commandLine[ i ] = args[ i ];
            }
            myInstallObject.myInstallContext = new InstallContext( args[ 0 ], commandLine);