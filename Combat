using System;
using System.Collections.Generic;

public interface IAttackStrategy
{
    void ExecuteAttack(Enemy enemy, PlayerCharacter player);
}

public class CloseRangeAttack : IAttackStrategy
{
    public void ExecuteAttack(Enemy enemy, PlayerCharacter player)
    {
        int damage = enemy.AttackPower - player.Defense;
        player.TakeDamage(damage);
        Console.WriteLine($"{enemy.Faction} attacks up close for {damage} damage.");
    }
}

public class RangedAttack : IAttackStrategy
{
    public void ExecuteAttack(Enemy enemy, PlayerCharacter player)
    {
        int damage = enemy.AttackPower - (player.Defense / 2); // Reduced effectiveness due to range
        player.TakeDamage(damage);
        Console.WriteLine($"{enemy.Faction} fires from a distance for {damage} damage.");
    }
}

public class EnemyAI
{
    private IAttackStrategy _attackStrategy;

    public EnemyAI(IAttackStrategy strategy)
    {
        _attackStrategy = strategy;
    }

    public void SetAttackStrategy(IAttackStrategy strategy)
    {
        _attackStrategy = strategy;
    }

    public void ExecuteAttack(Enemy enemy, PlayerCharacter player)
    {
        _attackStrategy.ExecuteAttack(enemy, player);
    }
}
