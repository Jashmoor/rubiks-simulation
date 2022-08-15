
namespace RubiksSimulation.Core
{
    public interface IMoveStrategy
    {
        void Move(Direction direction);
        abstract Orientation Orientation { get; }
    }
}
