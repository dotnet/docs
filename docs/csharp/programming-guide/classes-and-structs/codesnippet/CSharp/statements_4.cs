            void ProcessMessages()
            {
                while (ProcessMessage())
                    ; // Statement needed here.
            }

            void F()
            {
                //...
                if (done) goto exit;
            //...
            exit:
                ; // Statement needed here.
            }