using System;
using System.Runtime.InteropServices;
using System.Threading;
using static Darwin.Native.libobjc;

namespace Darwin
{
    public class NSApplication : NSResponder
    {
        public const string AppKitLibrary = "/System/Library/Frameworks/AppKit.framework/AppKit";

        private static Thread s_mainThread;

        #region Class Handle

        private static readonly IntPtr s_classHandle;
        private static bool s_initialized;

        static NSApplication() => s_classHandle = objc_getClass(nameof(NSApplication));

        public virtual IntPtr ClassHandle => s_classHandle;

        #endregion

        public static void Init()
        {
            if (s_initialized)
            {
                throw new InvalidOperationException ("Init has already be be invoked; it can only be invoke once");
            }

            s_initialized = true;

            if (SynchronizationContext.Current == null)
            {
                SynchronizationContext.SetSynchronizationContext(new AppKitSynchronizationContext());
            }

            s_mainThread = Thread.CurrentThread;
        }

        [DllImport(AppKitLibrary)]
        static extern int NSApplicationMain (int argc, string [] argv);

        public NSApplication()
        {
            Handle = objc_msgSend_IntPtr(this, "init");
        }

        internal NSApplication(IntPtr handle)
            : base (handle) { }
    }

    public class AppKitSynchronizationContext : SynchronizationContext
    {
        public override SynchronizationContext CreateCopy ()
        {
            return new AppKitSynchronizationContext ();
        }

        public override void Post (SendOrPostCallback d, object state)
        {
            NSRunLoop.MainRunLoop.BeginInvokeOnMainThread(d, state);
        }

        public override void Send (SendOrPostCallback d, object state)
        {
            NSRunLoop.MainRunLoop.InvokeOnMainThread(d, state);
        }
    }
}
