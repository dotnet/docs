
//<snippet09>
// Address.h
#include "Address.details.h"
ref class Address
{
public:
  Address(Platform::String^ street, Platform::String^ city, Platform::String^ state,
    Platform::String^ zip, Platform::String^ country);
  property Platform::String^ Street { Platform::String^ get(); }
  property Platform::String^ City { Platform::String^ get(); }
  property Platform::String^ State { Platform::String^ get(); }
  property Platform::String^ Zip { Platform::String^ get(); }
  property Platform::String^ Country { Platform::String^ get(); }
};
//</snippet09>