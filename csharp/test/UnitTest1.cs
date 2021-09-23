using Xunit;

namespace test
{
    public class UnitTest1
    {
        [Fact]
        public void New_world_is_empty()
        {
            var world = CreateWorld();
            Assert.True(world.IsEmpty());
        }

        [Fact]
        public void World_with_a_living_cell_is_not_empty()
        {
            var world = CreateWorld();
            world.SetLivingAt(new RandomCoordinates());
            Assert.False(world.IsEmpty());
        }

        [Fact]
        public void After_a_tick_empty_world_is_still_empty()
        {
            var world = CreateWorld();
            world.Tick();
            Assert.True(world.IsEmpty());
        }

        [Fact]
        public void After_a_tick_a_dead_cell_with_three_neighbours_comes_to_life()
        {
            var world = CreateWorld();
            world.SetLivingAt(new Coordinates(2, 1));
            world.SetLivingAt(new Coordinates(2, 2));
            world.SetLivingAt(new Coordinates(1, 2));

            world.Tick();

            Assert.True(world.IsLivingAt(new Coordinates(1, 1)));
        }

        [Fact]
        public void After_a_tick_a_living_cell_with_more_than_three_neighbours_dies()
        {
            var world = CreateWorld();
            world.SetLivingAt(new Coordinates(2, 1));
            world.SetLivingAt(new Coordinates(2, 2));
            world.SetLivingAt(new Coordinates(0, 2));
            world.SetLivingAt(new Coordinates(1, 2));
            world.SetLivingAt(new Coordinates(1, 1));

            world.Tick();

            Assert.True(world.IsDeadAt(new Coordinates(1, 1)));
        }

        [Fact]
        public void After_a_tick_a_living_cell_with_less_than_two_neighbours_dies()
        {
            var world = CreateWorld();
            world.SetLivingAt(new Coordinates(2, 2));
            world.SetLivingAt(new Coordinates(1, 1));

            world.Tick();

            Assert.True(world.IsDeadAt(new Coordinates(1, 1)));
        }

        [Fact]
        public void Repeating_pattern()
        {
            var world = CreateWorld();
            world.SetLivingAt(new Coordinates(1, 0));
            world.SetLivingAt(new Coordinates(1, 1));
            world.SetLivingAt(new Coordinates(1, 2));

            world.Tick();

            Assert.True(world.IsLivingAt(new Coordinates(0, 1)));
            Assert.True(world.IsLivingAt(new Coordinates(1, 1)));
            Assert.True(world.IsLivingAt(new Coordinates(2, 1)));
            Assert.True(world.IsDeadAt(new Coordinates(1, 0)));
            Assert.True(world.IsDeadAt(new Coordinates(1, 2)));
        }

        private static World CreateWorld()
        {
            return new World(new Size(3, 3));
        }
    }

    public class RandomCoordinates : Coordinates
    {
        public RandomCoordinates(int x = 1, int y = 1) : base(x, y)
        {
        }
    }
}
