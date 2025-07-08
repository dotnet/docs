module TestProp2

open System
open System.IO

module FileUtilities =
    type EncodingType =
        | None = 0
        | Unknown = -1
        | Utf8 = 1
        | Utf16 = 2
        | Utf32 = 3

    // <Snippet4>
    let getEncodingType (fs: FileStream) = 
        task {
            if not fs.CanRead then
                return EncodingType.Unknown
            else
                let bytes = Array.zeroCreate<byte> 4
                let! bytesRead = fs.ReadAsync(bytes, 0, 4)
                if bytesRead < 2 then
                    return EncodingType.None

                elif bytesRead >= 3 && bytes[0] = 0xEFuy && bytes[1] = 0xBBuy && bytes[2] = 0xBFuy then
                    return EncodingType.Utf8
                else
                    let value = BitConverter.ToUInt32(bytes, 0)
                    if bytesRead = 4 && (value = 0x0000FEFFu || value = 0xFEFF0000u) then
                        return EncodingType.Utf32
                    else
                        let value16 = BitConverter.ToUInt16(bytes, 0)
                        if value16 = 0xFEFFus || value16 = 0xFFFEus then
                            return EncodingType.Utf16
                        else
                            return EncodingType.Unknown
        }
    // The example displays the following output:
    //       Filename: .\TestFile.dat, Encoding: Unknown
    // </Snippet4>

let main _ = 
    task {
        let name = @".\TestFile.dat"
        let fs = new FileStream(name, FileMode.Create, FileAccess.Write)
        let! et = FileUtilities.getEncodingType fs
        printfn $"Filename: {name}, Encoding: {et}"
    }
