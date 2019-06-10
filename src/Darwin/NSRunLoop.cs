using System;
using static Darwin.Native.libobjc;

namespace Darwin
{
    public class NSRunLoop : NSObject
    {
        private const string PerformSelectorOnMainThreadName = "performSelectorOnMainThread:withObject:waitUntilDone:";

        #region Class Handle

        private static readonly IntPtr s_classHandle;

        static NSRunLoop() => s_classHandle = objc_getClass(nameof(NSRunLoop));

        public virtual IntPtr ClassHandle => s_classHandle;

        #endregion

        #region Constructors

        internal NSRunLoop(IntPtr handle)
            : base(handle)
        {
        }

        #endregion

        public static NSRunLoop MainRunLoop => Runtime.GetObject<NSRunLoop>(objc_msgSend_IntPtr(s_classHandle, "mainRunLoop"));

        public void BeginInvokeOnMainThread(Action action)
        {
            var d = new NSActionDispatcher(action);
            objc_msgSend(d.Handle, PerformSelectorOnMainThreadName, NSDispatcher.SelectorHandle, d.Handle, false);
        }

        internal void BeginInvokeOnMainThread(System.Threading.SendOrPostCallback cb, object state)
        {
            var d = new NSSynchronizationContextDispatcher(cb, state);
            objc_msgSend(d.Handle, PerformSelectorOnMainThreadName, NSDispatcher.SelectorHandle, d.Handle, false);
        }

        public void InvokeOnMainThread(Action action)
        {
            using (var d = new NSActionDispatcher(action))
            {
                objc_msgSend(d.Handle, PerformSelectorOnMainThreadName, NSDispatcher.SelectorHandle, d.Handle, true);
            }
        }

        internal void InvokeOnMainThread(System.Threading.SendOrPostCallback cb, object state)
        {
            using (var d = new NSSynchronizationContextDispatcher(cb, state))
            {
                objc_msgSend(d.Handle, PerformSelectorOnMainThreadName, NSDispatcher.SelectorHandle, d.Handle, true);
            }
        }
    }
}
