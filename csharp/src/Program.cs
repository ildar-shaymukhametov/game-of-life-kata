var max = 30;
var world = new World(new Size(max, max));
var random = new Random();
for (int i = 0; i < max * max / 2; i++)
{
    world.SetLivingAt(new Coordinates(random.Next(max), random.Next(max)));
}

while (true)
{
    System.Console.WriteLine(world);
    world.Tick();
    Thread.Sleep(100);
    System.Console.Clear();
}