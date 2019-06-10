using System;
using System.Runtime.InteropServices;
using Darwin.Native.Services;
using static System.Runtime.InteropServices.CallingConvention;
using static System.Runtime.InteropServices.UnmanagedType;

namespace Darwin.Native
{
    public static partial class libobjc
    {
        #region Void

        [DllImport(Library, CallingConvention = Cdecl, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(
            IntPtr obj,
            [MarshalAs(CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))]
            string selector);

        [DllImport(Library, CallingConvention = Cdecl, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr obj,
            [MarshalAs(CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))]
            string selector,
            IntPtr arg1);

        [DllImport(Library, CallingConvention = Cdecl, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr obj,
            [MarshalAs(CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))]
            string selector,
            bool arg1);

        [DllImport(Library, CallingConvention = Cdecl, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr obj,
            [MarshalAs(CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))]
            string selector,
            float arg1);

        [DllImport(Library, CallingConvention = Cdecl, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr obj,
            [MarshalAs(CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))]
            string selector,
            CGRect arg1);

        [DllImport(Library, CallingConvention = Cdecl, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr obj,
            [MarshalAs(CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))]
            string selector,
            CGPoint arg1);

        [DllImport(Library, CallingConvention = Cdecl, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr obj,
            [MarshalAs(CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))]
            string selector,
            IntPtr arg1,
            IntPtr arg2,
            bool arg3);

        #endregion

        #region IntPtr

        [DllImport(Library, CallingConvention = Cdecl, EntryPoint = "objc_msgSend")]
        public static extern IntPtr objc_msgSend_IntPtr(IntPtr obj,
            [MarshalAs(CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))]
            string selector);

        [DllImport(Library, CallingConvention = Cdecl, EntryPoint = "objc_msgSend")]
        public static extern IntPtr objc_msgSend_IntPtr(IntPtr obj,
            [MarshalAs(CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))]string selector,
            uint arg1);

        [DllImport(Library, CallingConvention = Cdecl, EntryPoint = "objc_msgSend")]
        public static extern IntPtr objc_msgSend_IntPtr(IntPtr obj,
            [MarshalAs(CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))]
            string selector,
            CGRect arg1);

        #endregion

        #region Boolean

        [DllImport(Library, CallingConvention = Cdecl, EntryPoint = "objc_msgSend")]
        public static extern bool objc_msgSend_Boolean(IntPtr obj,
            [MarshalAs(CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))]
            string selector);

        #endregion

        #region String

        [DllImport(Library, CallingConvention = Cdecl, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(CustomMarshaler, MarshalTypeRef = typeof(Utf8Marshaler))]
        public static extern string objc_msgSend_String(IntPtr obj,
            [MarshalAs(CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))]
            string selector);

        #endregion

        #region CGRect

        [DllImport(Library, CallingConvention = Cdecl, EntryPoint = "objc_msgSend")]
        public static extern CGRect objc_msgSend_CGRect(IntPtr obj,
            [MarshalAs(CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))]
            string selector);

        #endregion

        #region CGPoint

        [DllImport(Library, CallingConvention = Cdecl, EntryPoint = "objc_msgSend")]
        public static extern CGPoint objc_msgSend_CGPoint(IntPtr obj,
            [MarshalAs(CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))]
            string selector);

        #endregion

        #region Float

        [DllImport(Library, CallingConvention = Cdecl, EntryPoint = "objc_msgSend")]
        public static extern float objc_msgSend_Float(IntPtr obj,
            [MarshalAs(CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))]
            string selector);

        #endregion

        #region UInt32

        [DllImport(Library, CallingConvention = Cdecl, EntryPoint = "objc_msgSend")]
        public static extern uint objc_msgSend_UInt32(IntPtr obj,
            [MarshalAs(CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))]
            string selector);

        #endregion
    }
}
