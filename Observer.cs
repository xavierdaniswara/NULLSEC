using System;
using System.Collections.Generic;

public interface IObserver
{
    void OnPlayerDetected(PlayerCharacter player);
}

public class SentinelSquad : IObserver
{
    public void OnPlayerDetected(PlayerCharacter player)
    {
        Console.WriteLine("Sentinel squad alerted to player position!");
        // Additional logic to mobilize Sentinel units
    }
}

public class WolfPack : IObserver
{
    public void OnPlayerDetected(PlayerCharacter player)
    {
        Console.WriteLine("Wolf pack moves in on player's location!");
        // Additional logic to mobilize Wolf units
    }
}

public class UAV
{
    private List<IObserver> _observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void DetectPlayer(PlayerCharacter player)
    {
        Console.WriteLine("UAV detects player and alerts all nearby units.");
        NotifyObservers(player);
    }

    private void NotifyObservers(PlayerCharacter player)
    {
        foreach (var observer in _observers)
        {
            observer.OnPlayerDetected(player);
        }
    }
}
