using System;
using static Darwin.Native.libobjc;

namespace Darwin
{
    public class NSAutoreleasePool : NSObject
    {
        #region Class Handle

        private static readonly IntPtr s_classHandle;

        static NSAutoreleasePool() => s_classHandle = objc_getClass(nameof(NSAutoreleasePool));

        public virtual IntPtr ClassHandle => s_classHandle;

        #endregion

        public NSAutoreleasePool()
        {
            Handle = objc_msgSend_IntPtr(this, "init");
        }

        internal NSAutoreleasePool(IntPtr handle)
            : base (handle) { }
    }
}
