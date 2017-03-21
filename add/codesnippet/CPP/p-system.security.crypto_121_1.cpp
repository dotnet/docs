         virtual array<Byte>^ get() override
         {
            return dynamic_cast<array<Byte>^>(keyedCrypto->Key->Clone());
         }

         virtual void set( array<Byte>^value ) override
         {
            keyedCrypto->Key = dynamic_cast<array<Byte>^>(value->Clone());
         }
      }