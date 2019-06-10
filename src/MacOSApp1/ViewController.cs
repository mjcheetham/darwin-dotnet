using System;

using AppKit;
using CoreGraphics;
using Foundation;
using WebKit;

namespace MacOSApp1
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NSWindow


            var result = NSRunResponse;
            while (result == NSRunResponse.Continues)
            {
                using (var pool = new NSAutoreleasePool())
                {
                    var nextEvent = NSApplication.SharedApplication.NextEvent(
                        NSEventMask.AnyEvent,
                        NSDate.DistantFuture,
                        NSRunLoopMode.Default,
                        true);

                    // Discard events that are for other windows, else they remain somewhat interactive
                    if (nextEvent.Window != null && nextEvent.Window != window)
                    {
                        continue;
                    }

                    NSApplication.SharedApplication.SendEvent(nextEvent);

                    // Run the window modally until there are no events to process
                    result = (NSRunResponse)(long)NSApplication.SharedApplication.RunModalSession(session);

                    // Give the main loop some time
                    NSRunLoop.Current.LimitDateForMode(NSRunLoopMode.Default);
                }
            }

            NSApplication.SharedApplication.EndModalSession(session);



            // Do any additional setup after loading the view.
        }

        public override void LoadWindow()
        {
            var parentWindow = _parentWindow ?? NSApplication.SharedApplication.MainWindow;

            CGRect windowRect;
            if (parentWindow != null)
            {
                windowRect = parentWindow.Frame;
            }
            else
            {
                // If we didn't get a parent window then center it in the screen
                windowRect = NSScreen.MainScreen.Frame;
            }

            // Calculate the center of the current main window so we can position our window in the center of it
            CGRect centerRect = CenterRect(windowRect, new CGRect(0, 0, DEFAULT_WINDOW_WIDTH, DEFAULT_WINDOW_HEIGHT));

            var window = new NSWindow(centerRect, NSWindowStyle.Titled | NSWindowStyle.Closable, NSBackingStore.Buffered, true)
            {
                BackgroundColor = NSColor.WindowBackground,
                WeakDelegate = this,
                AccessibilityIdentifier = "SIGN_IN_WINDOW"
            };

            var contentView = window.ContentView;
            contentView.AutoresizesSubviews = true;

            _webView = new WKWebView(contentView.Frame, new WKWebViewConfiguration())
            {
                FrameLoadDelegate = this,
                PolicyDelegate = this,
                AutoresizingMask = NSViewResizingMask.HeightSizable | NSViewResizingMask.WidthSizable,
                AccessibilityIdentifier = "SIGN_IN_WEBVIEW"
            };

            contentView.AddSubview(_webView);

            // There's a noticeable lag between the window showing and the page loading, so starting with the spinner
            // at least make it looks like something is happening.
            _progressIndicator = new NSProgressIndicator(
                new CGRect(
                    (DEFAULT_WINDOW_WIDTH / 2) - 16,
                    (DEFAULT_WINDOW_HEIGHT / 2) - 16,
                    32,
                    32))
            {
                Style = NSProgressIndicatorStyle.Spinning,
                // Keep the item centered in the window even if it's resized.
                AutoresizingMask = NSViewResizingMask.MinXMargin | NSViewResizingMask.MaxXMargin | NSViewResizingMask.MinYMargin | NSViewResizingMask.MaxYMargin
            };

            _progressIndicator.Hidden = false;
            _progressIndicator.StartAnimation(null);

            contentView.AddSubview(_progressIndicator);

            Window = window;

            _webView.MainFrameUrl = _initialUrl;
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
