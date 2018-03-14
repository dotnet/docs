//BitmapFrame.h file

#pragma once

/*#using <C:\Program Files\Reference Assemblies\Microsoft\Framework\v3.0\PresentationCore.dll>
#using <C:\Program Files\Reference Assemblies\Microsoft\Framework\v3.0\PresentationFramework.dll>
#using <C:\Program Files\Reference Assemblies\Microsoft\Framework\v3.0\UIAutomationProvider.dll>
#using <C:\Program Files\Reference Assemblies\Microsoft\Framework\v3.0\WindowsBase.dll>
#using <C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\System.dll>
#using <system.dll>
#using <system.XML.dll>
#using <system.drawing.dll>
#using <system.windows.forms.dll> */
namespace SDKSample {
	ref class app;
	ref class EntryClass;
}

using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Windows;
using namespace System::Windows::Controls;
using namespace System::Windows::Media;
using namespace System::Windows::Media::Imaging;
using namespace System::Threading;

namespace SDKSample {

	public ref class app : Application {

		private: System::Windows::Window^ mainWindow;

		protected: virtual void OnStartup (System::Windows::StartupEventArgs^ e) override ;

		private: void CreateAndShowMainWindow () ;
	};

	private ref class EntryClass {

		public: 
		[System::STAThread()]
		static void Main () ;
	};
}

