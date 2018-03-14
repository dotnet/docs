// <snippet2>
#include "pch.h"

#include "WRLClassLibrary_h.h"
#include <wrl.h>

using namespace Microsoft::WRL;
using namespace Windows::Foundation;

namespace ABI
{
    namespace WRLClassLibrary
    {
        class WinRTClass: public RuntimeClass<IWinRTClass>
        {
            InspectableClass(L"WRLClassLibrary.WinRTClass", BaseTrust)

        public:
            WinRTClass()
            {
            }
        };

        ActivatableClass(WinRTClass);
    }
}
// </snippet2>