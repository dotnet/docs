/* Method must be compiled in an unsafe context because it uses the sizeof operator on a type not known to be a built-in type.*/ 
/* Without the unmanaged constraint, the sizeof operator is unavailable. */ 

unsafe public static byte[] ToByteArray<T>(this T argument) where T : unmanaged
{
    var size = sizeof(T);
    var result = new Byte[size];
    Byte* p = (byte*)&argument;
    for (var i = 0; i < size; i++)
        result[i] = *p++;
    return result;
}
