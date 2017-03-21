[DllImport("user32.dll", SetLastError=true)]
int MessageBoxA(IntPtr hWnd, String^ Text,
                String^ Caption, unsigned int Type);