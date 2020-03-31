// <snippet2>
#include "stdafx.h"

#include "CalculatorComponent_h.h"
#include <wrl.h>

using namespace Microsoft::WRL;

class CalculatorComponent: public RuntimeClass<RuntimeClassFlags<ClassicCom>, ICalculatorComponent>
{
public:
    CalculatorComponent()
    {
    }

    STDMETHODIMP Add(_In_ int a, _In_ int b, _Out_ int* value)
    {
        *value = a + b;
        return S_OK;
    }
};

CoCreatableClass(CalculatorComponent);
// </snippet2>
