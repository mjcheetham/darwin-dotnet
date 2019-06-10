using System;

namespace Darwin
{
    [Flags]
    public enum NSEventMask : ulong
    {
        LeftMouseDown = 2,
        LeftMouseUp = 4,
        RightMouseDown = 8,
        RightMouseUp = 16, // 0x0000000000000010
        MouseMoved = 32, // 0x0000000000000020
        LeftMouseDragged = 64, // 0x0000000000000040
        RightMouseDragged = 128, // 0x0000000000000080
        MouseEntered = 256, // 0x0000000000000100
        MouseExited = 512, // 0x0000000000000200
        KeyDown = 1024, // 0x0000000000000400
        KeyUp = 2048, // 0x0000000000000800
        FlagsChanged = 4096, // 0x0000000000001000
        AppKitDefined = 8192, // 0x0000000000002000
        SystemDefined = 16384, // 0x0000000000004000
        ApplicationDefined = 32768, // 0x0000000000008000
        Periodic = 65536, // 0x0000000000010000
        CursorUpdate = 131072, // 0x0000000000020000
        ScrollWheel = 4194304, // 0x0000000000400000
        TabletPoint = 8388608, // 0x0000000000800000
        TabletProximity = 16777216, // 0x0000000001000000
        OtherMouseDown = 33554432, // 0x0000000002000000
        OtherMouseUp = 67108864, // 0x0000000004000000
        OtherMouseDragged = 134217728, // 0x0000000008000000
        EventGesture = 536870912, // 0x0000000020000000
        EventMagnify = 1073741824, // 0x0000000040000000
        EventSwipe = 2147483648, // 0x0000000080000000
        EventRotate = 262144, // 0x0000000000040000
        EventBeginGesture = 524288, // 0x0000000000080000
        EventEndGesture = 1048576, // 0x0000000000100000
        SmartMagnify = 4294967296, // 0x0000000100000000
        Pressure = 17179869184, // 0x0000000400000000
        DirectTouch = 137438953472, // 0x0000002000000000
        AnyEvent = 18446744073709551615, // 0xFFFFFFFFFFFFFFFF
    }
}
