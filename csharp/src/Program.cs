var world = new World();
var random = new Random();
var max = 30;
for (int i = 0; i < max * 8; i++)
{
    world.SetLivingAt(new Coordinates(random.Next(max), random.Next(max)));
}
world.SetLivingAt(new Coordinates(2, 2));
world.SetLivingAt(new Coordinates(1, 2));

while (true)
{
    System.Console.WriteLine(world);
    world.Tick();
    Thread.Sleep(100);
    System.Console.Clear();
}