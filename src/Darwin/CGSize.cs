using System;

namespace Darwin
{
    [Serializable]
    public struct CGSize
    {
        public static readonly CGSize Empty = default;

        public float Height;
        public float Width;

        public CGSize(float w, float h)
        {
            Width = w;
            Height = h;
        }
    }
}
