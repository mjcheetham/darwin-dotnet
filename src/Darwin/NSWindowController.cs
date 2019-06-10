using System;
using static Darwin.Native.libobjc;

namespace Darwin
{
    public class NSWindowController : NSResponder
    {
        #region Class Handle

        private static readonly IntPtr s_classHandle;

        static NSWindowController() => s_classHandle = objc_getClass(nameof(NSWindowController));

        public virtual IntPtr ClassHandle => s_classHandle;

        #endregion

        #region Constructors

        internal NSWindowController(IntPtr handle)
            : base(handle) { }

        #endregion

        public virtual void LoadWindow()
        {
            NSApplication.EnsureUIThread();
            objc_msgSend(this, "loadWindow");
        }
    }
}
