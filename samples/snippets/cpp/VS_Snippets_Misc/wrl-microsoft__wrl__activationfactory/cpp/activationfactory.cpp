// activationfactory.cpp
// compile with: /c
#include <wrl/module.h>

using namespace Microsoft::WRL;

namespace ABI
{
    namespace MyClassLibrary
    {
        [uuid({3B631C7A-B226-4F9A-8279-17D4CBAABA93})]
        interface IMyClass : IWeakReference
        {
            virtual HRESULT STDMETHODCALLTYPE Resolve( 
                /* [in] */ __RPC__in REFIID riid,
                /* [iid_is][out] */ __RPC__deref_out IInspectable **objectReference)
            {
                return S_OK;
            }
        };

        [uuid({3B631C7A-B226-4F9A-8279-17D4CBAABA93})]
        interface IMyAdditionalInterfaceOnFactory: IWeakReference
        {
            virtual HRESULT STDMETHODCALLTYPE Resolve( 
                /* [in] */ __RPC__in REFIID riid,
                /* [iid_is][out] */ __RPC__deref_out IInspectable **objectReference)
            {
                return S_OK;
            }
        };

        class MyClass: public RuntimeClass<IMyClass>
        {
            InspectableClass(L"MyClassLibrary.MyClass", BaseTrust)

        public:
            MyClass()
            {
            }
        };

        //ActivatableClass(MyClass);

        // <snippet1>
        struct MyClassFactory : public ActivationFactory<IMyAdditionalInterfaceOnFactory>
        {
            STDMETHOD(ActivateInstance) (_Outptr_result_nullonfailure_ IInspectable** ppvObject)
            {
                // my custom implementation

                return S_OK;
            }
        };

        ActivatableClassWithFactory(MyClass, MyClassFactory);
        // or if a default factory is used:
        //ActivatableClassWithFactory(MyClass, SimpleActivationFactory);
        // </snippet1>
    }
}
