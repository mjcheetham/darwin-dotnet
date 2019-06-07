using System;

namespace Darwin
{
    [Serializable]
    public struct CGPoint
    {
        public static readonly CGRect Empty = default;

        public float X;
        public float Y;

        public CGPoint(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
