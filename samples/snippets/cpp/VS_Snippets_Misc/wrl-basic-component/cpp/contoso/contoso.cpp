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

            // <snippet11>
            HRESULT __stdcall Add(_In_ int a, _In_ int b, _Out_ int* value)
            {
                if (value == nullptr)
                {
                    return E_POINTER;
                }
                int c = a + b;
                if (IsPrime(c))
                {
                    m_events.InvokeAll(c);
                }
                *value = c;
                return S_OK;
            }
            // </snippet11>

            // <snippet8>
            HRESULT __stdcall add_PrimeNumberFound(_In_ IPrimeNumberEvent* event, _Out_ EventRegistrationToken* eventCookie)
            {
                return m_events.Add(event, eventCookie);
            }

            HRESULT __stdcall remove_PrimeNumberFound(_In_ EventRegistrationToken eventCookie)
            {
                return m_events.Remove(eventCookie);
            }
            // </snippet8>

        private:
            // <snippet7>
            EventSource<IPrimeNumberEvent> m_events;
            // </snippet7>

            // <snippet12>
            // Determines whether the input value is prime.
            bool IsPrime(int n)
            {
                if (n < 2)
                {
                    return false;
                }
                for (int i = 2; i < n; ++i)
                {
                    if ((n % i) == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            // </snippet12>
        };

        ActivatableClass(Calculator);
    }
}

/*
// <snippet13>
MIDL_INTERFACE("3FBED04F-EFA7-4D92-B04D-59BD8B1B055E")
IPrimeNumberEvent : public IUnknown
{
public:
    virtual HRESULT STDMETHODCALLTYPE Invoke( 
        int primeNumber) = 0;

};
// </snippet13>
*/