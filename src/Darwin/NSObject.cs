using System;
using static Darwin.Native.libobjc;

namespace Darwin
{
    public class NSObject : IDisposable
    {
        private readonly bool _ownsHandle;
        private bool _isDisposed;

        #region Class Handle

        private static readonly IntPtr s_classHandle;

        static NSObject() => s_classHandle = objc_getClass(nameof(NSObject));

        public virtual IntPtr ClassHandle => s_classHandle;

        #endregion

        #region Instance Handle

        public IntPtr Handle { get; protected set; }

        public bool IsHandleValid => Handle != IntPtr.Zero;

        public static implicit operator IntPtr(NSObject obj) => obj.Handle;

        #endregion

        #region Constructors

        public NSObject()
        {
            Handle = objc_msgSend_IntPtr(ClassHandle, "alloc");
            _ownsHandle = true;
            Runtime.RegisterObject(this);
        }

        public NSObject(IntPtr handle)
        {
            Handle = handle;
            _ownsHandle = false;
            Runtime.RegisterObject(this);
        }

        #endregion

        #region IDisposable

        ~NSObject() => Dispose(false);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (disposing)
            {
                FreeManaged();
            }

            FreeNative();

            Runtime.UnregisterObject(this);

            if (_ownsHandle && IsHandleValid)
            {
                objc_msgSend(this, "release");
            }

            _isDisposed = true;
        }

        protected void ThrowIfDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        protected virtual void FreeManaged() { }

        protected virtual void FreeNative() { }

        #endregion
    }
}
