#include "pch.h"

#include "Contoso_h.h"
#include <wrl.h>

using namespace Microsoft::WRL;
using namespace Windows::Foundation;

namespace ABI
{
    namespace Contoso
    {
        class Calculator: public RuntimeClass<ICalculator>
        {
            InspectableClass(L"Contoso.Calculator", BaseTrust)

        public:
            Calculator()
            {
            }

            // <snippet2>
            HRESULT __stdcall Add(_In_ int a, _In_ int b, _Out_ int* value)
            {
                if (value == nullptr)
                {
                    return E_POINTER;
                }
                *value = a + b;
                return S_OK;
            }
            // </snippet2>
        };

        ActivatableClass(Calculator);
    }
}