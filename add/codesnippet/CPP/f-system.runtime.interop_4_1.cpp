[DllImport("user32.dll", CharSet=CharSet::Ansi, ExactSpelling=true)]
int MessageBoxA(IntPtr hWnd, String^ Text,
                String^ Caption, unsigned int Type);