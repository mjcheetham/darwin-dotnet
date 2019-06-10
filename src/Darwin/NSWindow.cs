using System;
using TestApp;
using static Darwin.Native.libobjc;

namespace Darwin
{
    public class NSWindow : NSView
    {
        private NSWindow (IntPtr windowRef) : base(windowRef)
        {
            Handle = objc_msgSend_IntPtr(this, "initWithWindowRef:");
        }

        public static NSWindow FromWindowRef(IntPtr windowRef)
        {
            return new NSWindow (windowRef);
        }

        public NSWindow(CGRect frame, NSWindowStyle style, NSBackingStore backingStoreType, bool defer)
        {
            Handle = objc_msgSend_IntPtr(this, "init");
        }
    }
}
