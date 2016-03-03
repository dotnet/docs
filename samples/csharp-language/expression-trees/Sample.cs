namespace ExpressionTreeSamples
{
    // Base class for all samples.
    public abstract class Sample
    {
        public abstract string Name { get; }
        public abstract void Run();
    }
}