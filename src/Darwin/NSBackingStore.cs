using System;

namespace TestApp
{
    public enum NSBackingStore : ulong
    {
        [Obsolete] Retained,
        [Obsolete] Nonretained,
        Buffered,
    }
}