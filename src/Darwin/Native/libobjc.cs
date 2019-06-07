using System;
using System.Runtime.InteropServices;
using Darwin.Native.Services;
using static System.Runtime.InteropServices.CallingConvention;
using static System.Runtime.InteropServices.UnmanagedType;
using static Darwin.Native.Services.Utf8Marshaler;

namespace Darwin.Native
{
    public static partial class libobjc
    {
        private const string Library = "libobjc";

        [DllImport(Library, CallingConvention = Cdecl)]
        public static extern IntPtr objc_getClass(
            [MarshalAs(CustomMarshaler, MarshalCookie = ToNative, MarshalTypeRef = typeof(Utf8Marshaler))]
            string name);

        [DllImport(Library, CallingConvention = Cdecl)]
        public static extern IntPtr sel_registerName(
            [MarshalAs(CustomMarshaler, MarshalCookie = ToNative, MarshalTypeRef = typeof(Utf8Marshaler))]
            string name);

        [DllImport(Library, CallingConvention = Cdecl)]
        public static extern IntPtr sel_getName(IntPtr selector);
    }
}
