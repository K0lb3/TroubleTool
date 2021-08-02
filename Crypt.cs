using System.Runtime.InteropServices;

namespace TroubleTool
{
    static class Crypt
    {
        [DllImport("troublecrypt.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern int encrypt(byte[] data, int size);
        [DllImport("troublecrypt.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern int decrypt(byte[] data, int size);
    }
}
