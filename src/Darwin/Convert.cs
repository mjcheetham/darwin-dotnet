using System;
using static Darwin.Native.libobjc;

namespace Darwin
{
    public static class Convert
    {
        public static T[] FromNSArray<T>(IntPtr ptr) where T : NSObject
        {
            if (ptr == IntPtr.Zero)
            {
                return null;
            }

            uint count = objc_msgSend_UInt32(ptr, "count");
            var array = new T[count];

            for (uint i = 0; i < count; i += 1)
            {
                IntPtr obj = objc_msgSend_IntPtr(ptr, "objectAtIndex:", i);
                array[(int)i] = Runtime.GetObject<T>(obj);
            }

            return array;
        }
    }
}
