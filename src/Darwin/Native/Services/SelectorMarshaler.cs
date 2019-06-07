using System;
using System.Runtime.InteropServices;

namespace Darwin.Native.Services
{
    public class SelectorMarshaler : ICustomMarshaler
    {
        private static readonly SelectorMarshaler Instance = new SelectorMarshaler();

        public static ICustomMarshaler GetInstance(string cookie)
        {
            return Instance;
        }

        public void CleanUpManagedData(object managedObj)
        {
        }

        public void CleanUpNativeData(IntPtr pNativeData)
        {
        }

        public int GetNativeDataSize()
        {
            return IntPtr.Size;
        }

        public IntPtr MarshalManagedToNative(object managedObj)
        {
            var name = managedObj as string;
            if (string.IsNullOrEmpty(name))
            {
                return IntPtr.Zero;
            }

            return libobjc.sel_registerName(name);
        }

        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            return libobjc.sel_getName(pNativeData);
        }
    }
}
