using System;
using static Darwin.Native.libobjc;

namespace Darwin
{
    public class NSView : NSObject
    {
        #region Class Handle

        private static readonly IntPtr s_classHandle;

        static NSView() => s_classHandle = objc_getClass(nameof(NSView));

        public virtual IntPtr ClassHandle => s_classHandle;

        #endregion

        #region Constructors

        public NSView()
        {
            objc_msgSend_IntPtr(this, "init");
        }

        public NSView(CGRect frame)
        {
            Handle = objc_msgSend_IntPtr(this, "initWithFrame:", frame);
        }

        internal NSView(IntPtr handle)
            : base(handle) { }

        #endregion

        public CGRect Frame
        {
            get => objc_msgSend_CGRect(this, "frame");
            set => objc_msgSend(this, "setFrame:", value);
        }

        public CGRect Bounds
        {
            get => objc_msgSend_CGRect(this, "bounds");
            set => objc_msgSend(this, "setBounds:", value);
        }

        public CGPoint Center
        {
            get => objc_msgSend_CGPoint(this, "center");
            set => objc_msgSend(this, "setCenter:", value);
        }

        public bool Hidden
        {
            get => objc_msgSend_Boolean(this, "isHidden");
            set => objc_msgSend(this, "setHidden:", value);
        }

        public float Alpha
        {
            get => objc_msgSend_Float(this, "alpha");
            set => objc_msgSend(this, "setAlpha:", value);
        }

        public NSWindow Window => Runtime.GetObject<NSWindow>(objc_msgSend_IntPtr(this, "window"));

        public NSView[] Subviews => Convert.FromNSArray<NSView>(objc_msgSend_IntPtr(this, "subviews"));

        public NSView Superview => Runtime.GetObject<NSView>(objc_msgSend_IntPtr(this, "superview"));

        public void AddSubview(NSView view)
        {
            objc_msgSend(this, "addSubview:", view);
        }

        public void BringSubviewToFront(NSView view)
        {
            objc_msgSend(this, "bringSubviewToFront:", view);
        }

        public void SendSubviewToBack(NSView view)
        {
            objc_msgSend(this, "sendSubviewToBack:", view);
        }

        public void RemoveFromSuperview()
        {
            objc_msgSend(this, "removeFromSuperview");
        }
    }
}
