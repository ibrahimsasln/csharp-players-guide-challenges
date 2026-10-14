using System;

public class CharberryTree
{
    private Random _random = new();
    public bool Ripe { get; set; }

    public event Action? Ripened;

    public void MaybeGrow()
    {
        // Only a tiny chance of ripening each time, but we try a lot!
        if (_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            Ripened?.Invoke();
        }
    }
}

class Notifier
{
    public Notifier(CharberryTree charberryTree)
    {
        charberryTree.Ripened += OnRipened;
    }
    private void OnRipened() => Console.WriteLine("A charberry fruit has ripened!");
}

class Harvester
{
    private int _harvestCount;
    private CharberryTree _charberryTree;
    public Harvester(CharberryTree charberryTree)
    {
        _charberryTree = charberryTree;
        _charberryTree.Ripened += OnRipened;
        _harvestCount++;
    }
    private void OnRipened()
    {
        _harvestCount++;
        _charberryTree.Ripe = false;
        Console.WriteLine($"The tree has been harvested {_harvestCount} times.");
    }
}
class Program
{
    static void Main()
    {
        CharberryTree tree = new();
        Notifier notifier = new(tree);
        Harvester harvester = new(tree);

        while (true) tree.MaybeGrow();
    }
}