using System;

namespace Darwin
{
    [Serializable]
    public struct CGRect
    {
        public static readonly CGRect Empty = default;

        public float X;
        public float Height;
        public float Width;
        public float Y;

        public CGRect(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public CGRect(CGPoint location, CGSize size)
            : this(location.X, location.Y, size.Width, size.Height) {}

        public CGPoint Location
        {
            get => new CGPoint(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public CGSize Size
        {
            get => new CGSize(Width, Height);
            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }
    }
}
