         int inputBlockSize = base64Transform->InputBlockSize;
         while ( inputBytes->Length - inputOffset > inputBlockSize )
         {
            base64Transform->TransformBlock(
               inputBytes,
               inputOffset,
               inputBytes->Length - inputOffset,
               outputBytes,
               0 );

            inputOffset += base64Transform->InputBlockSize;
            outputFileStream->Write(
               outputBytes,
               0,
               base64Transform->OutputBlockSize );
         }