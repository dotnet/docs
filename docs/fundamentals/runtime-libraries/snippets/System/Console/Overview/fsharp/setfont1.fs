// <Snippet3>
module Example

open System
open System.Runtime.InteropServices

[<Literal>]
let STD_OUTPUT_HANDLE = -11

[<Literal>]
let TMPF_TRUETYPE = 4

[<Literal>]
let LF_FACESIZE = 32

let INVALID_HANDLE_VALUE = IntPtr(-1)


[<Struct>]
[<StructLayout(LayoutKind.Sequential)>]
type COORD =
    val mutable X: int16
    val mutable Y: int16

    internal new(x: int16, y: int16) =
        { X = x
          Y = y }

[<Struct>]
[<StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)>]
type CONSOLE_FONT_INFO_EX =
    val mutable cbSize: uint32
    val mutable nFont: uint32
    val mutable dwFontSize: COORD
    val mutable FontFamily: int
    val mutable FontWeight: int
    [<MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)>]
    val mutable FaceName: string

[<DllImport("kernel32.dll", SetLastError = true)>]
extern IntPtr GetStdHandle(int nStdHandle)

[<DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)>]
extern bool GetCurrentConsoleFontEx(IntPtr consoleOutput, bool maximumWindow, CONSOLE_FONT_INFO_EX lpConsoleCurrentFontEx)

[<DllImport("kernel32.dll", SetLastError = true)>]
extern bool SetCurrentConsoleFontEx(IntPtr consoleOutput, bool maximumWindow, CONSOLE_FONT_INFO_EX consoleCurrentFontEx)

[<EntryPoint>]
let main argv =
    let fontName = "Lucida Console"
    let hnd = GetStdHandle(STD_OUTPUT_HANDLE)
    if hnd <> INVALID_HANDLE_VALUE then
        let mutable info = CONSOLE_FONT_INFO_EX()
        info.cbSize <- uint32 (Marshal.SizeOf(info))
        // First determine whether there's already a TrueType font.
        if (GetCurrentConsoleFontEx(hnd, false, info)) then
            if (((info.FontFamily) &&& TMPF_TRUETYPE) = TMPF_TRUETYPE) then
                Console.WriteLine("The console already is using a TrueType font.")
            else
                // Set console font to Lucida Console.
                let mutable newInfo = CONSOLE_FONT_INFO_EX()
                newInfo.cbSize <- uint32 (Marshal.SizeOf(newInfo))
                newInfo.FontFamily <- TMPF_TRUETYPE
                newInfo.FaceName <- fontName
                // Get some settings from current font.
                newInfo.dwFontSize <- COORD(info.dwFontSize.X, info.dwFontSize.Y)
                newInfo.FontWeight <- info.FontWeight
                SetCurrentConsoleFontEx(hnd, false, newInfo) |> ignore
                Console.WriteLine("The console is now using a TrueType font.")

    // Return zero for success
    0
// </Snippet3>
