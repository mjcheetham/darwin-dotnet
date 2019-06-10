using System;
using Darwin.Native;
using static Darwin.Native.libobjc;

namespace Darwin
{
    public class NSResponder : NSObject
    {
        #region Class Handle

        private static readonly IntPtr s_classHandle;

        static NSResponder() => s_classHandle = libobjc.objc_getClass(nameof(NSResponder));

        public virtual IntPtr ClassHandle => s_classHandle;

        #endregion

        public NSResponder()
        {
            Handle = objc_msgSend_IntPtr(this, "init");
        }

        internal NSResponder(IntPtr handle)
            : base (handle) { }
    }
}
