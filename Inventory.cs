using System;

public abstract class Item
{
    public abstract string Name { get; }
    public abstract void Use(PlayerCharacter player);
}

public class HealthBoost : Item
{
    public override string Name => "Health Boost";

    public override void Use(PlayerCharacter player)
    {
        player.Health += 20;
        Console.WriteLine($"{player.CharacterName} uses Health Boost. Health is now {player.Health}");
    }
}

public class AttackBoost : Item
{
    public override string Name => "Attack Boost";

    public override void Use(PlayerCharacter player)
    {
        player.Attack += 5;
        Console.WriteLine($"{player.CharacterName} uses Attack Boost. Attack is now {player.Attack}");
    }
}

public class InventorySystem
{
    private List<Item> _items = new List<Item>();

    public void AddItem(Item item)
    {
        _items.Add(item);
        Console.WriteLine($"{item.Name} added to inventory.");
    }

    public void UseItem(Item item, PlayerCharacter player)
    {
        item.Use(player);
        _items.Remove(item);
    }
}
