namespace SystemTextJsonSamples
{
    // <ImmutablePoint>
    public readonly struct ImmutablePoint
    {
        public ImmutablePoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
    }
    // </ImmutablePoint>
}
