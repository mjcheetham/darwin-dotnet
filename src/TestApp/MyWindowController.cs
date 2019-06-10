using System;
using Darwin;

namespace TestApp
{
    internal class MyWindowController : NSWindowController
    {
        private const int DEFAULT_WINDOW_WIDTH = 420;
        private const int DEFAULT_WINDOW_HEIGHT = 650;

        private readonly NSWindow _parentWindow;
        private readonly string _windowTitle;
        private readonly string _initialUrl;

        public MyWindowController(NSWindow parentWindow, string windowTitle, string initialUrl)
        {
            _parentWindow = parentWindow;
            _windowTitle = windowTitle;
            _initialUrl = initialUrl;
        }

        public void Run()
        {
            var window = Window;
            IntPtr session = NSApplication.SharedApplication.BeginModalSession(window);
            var result = NSRunResponse.Continues;

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
                BackgroundColor = NSColor.WindowBackground
            };

            Window = window;
        }

        private static CGRect CenterRect(CGRect rect1, CGRect rect2)
        {
            float x = rect1.X + (rect1.Width  - rect2.Width)  / 2;
            float y = rect1.Y + (rect1.Height - rect2.Height) / 2;

            x = x < 0 ? 0 : x;
            y = y < 0 ? 0 : y;

            rect2.X = x;
            rect2.X = y;

            return rect2;
        }
    }
}
