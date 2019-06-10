using System;

namespace Darwin
{
    [Flags]
    public enum NSWindowStyle
    {
        Borderless = 0,
        Titled = 1,
        Closable = 2,
        Miniaturizable = 4,
        Resizable = 8,
        Utility = 16,                  // 0x0000000000000010
        DocModal = 64,                 // 0x0000000000000040
        NonactivatingPanel = 128,      // 0x0000000000000080
        TexturedBackground = 256,      // 0x0000000000000100
        [Obsolete] Unscaled = 2048,    // 0x0000000000000800
        UnifiedTitleAndToolbar = 4096, // 0x0000000000001000
        Hud = 8192,                    // 0x0000000000002000
        FullScreenWindow = 16384,      // 0x0000000000004000
        FullSizeContentView = 32768,   // 0x0000000000008000
    }
}
