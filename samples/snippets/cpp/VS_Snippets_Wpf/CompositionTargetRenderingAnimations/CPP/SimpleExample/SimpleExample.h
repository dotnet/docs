//SimpleExample.h file

#pragma once

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Controls;
using namespace System::Windows::Data;
using namespace System::Windows::Documents;
using namespace System::Windows::Media;
using namespace System::Windows::Navigation;
using namespace System::Windows::Shapes;

namespace Microsoft {
	namespace Samples {
		namespace PerFrameAnimations {
			public ref class SimpleExample : Page {
				public: 
               SimpleExample () ;

				private: 
               Random^ rand;
               SolidColorBrush^ animatedBrush;

				private: 
               void _initFields() ;

				protected: 
               void UpdateColor(Object^ sender, EventArgs^ e) ;
			};
		}
	}
}

