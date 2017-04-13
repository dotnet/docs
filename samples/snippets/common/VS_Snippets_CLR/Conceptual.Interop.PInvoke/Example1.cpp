using namespace System::Runtime::InteropServices;

typedef void* HWND;

[DllImport("user32", CharSet=CharSet::Auto)]
extern "C" IntPtr MessageBox(HWND hWnd,
                             String* pText,
                             String* pCaption,
                             unsigned int uType);

void main() 
{
     String* pText = L"Hello World!";
     String* pCaption = L"Platform Invoke Sample";
     MessageBox(0, pText, pCaption, 0);
}
