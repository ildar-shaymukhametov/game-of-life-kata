using Xunit;

namespace test
{
    public class UnitTest1
    {
        [Fact]
        public void New_world_is_empty()
        {
            var world = new World();
            Assert.True(world.IsEmpty());
        }

        [Fact]
        public void World_with_a_living_cell_is_not_empty()
        {
            var world = new World();
            world.SetLivingAt(new RandomCoordinates());
            Assert.False(world.IsEmpty());
        }
    }

    public class RandomCoordinates : Coordinates
    {
        public RandomCoordinates(int x = 1, int y = 1) : base(x, y)
        {
        }
    }
}
