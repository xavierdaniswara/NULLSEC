using System;

public class PlayerCharacter
{
    private static PlayerCharacter _instance; // Singleton instance

    public string CharacterName { get; private set; }
    public string TechTree { get; private set; } // Tech Trees: Technician, Hacker, Enforcer, Infiltrator
    public int Level { get; private set; }
    public int SkillPoints { get; private set; }
    public int Health { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }

    // Private constructor to prevent instantiation from outside
    private PlayerCharacter(string characterName, string techTree)
    {
        CharacterName = characterName;
        TechTree = techTree;
        Level = 1;
        SkillPoints = 0;
        Health = 100;
        Attack = 10;
        Defense = 5;
    }

    // Singleton instance retrieval method
    public static PlayerCharacter GetInstance(string characterName, string techTree)
    {
        if (_instance == null)
        {
            _instance = new PlayerCharacter(characterName, techTree);
        }
        return _instance;
    }

    // Level up method, increases level and grants skill points
    public void LevelUp()
    {
        Level++;
        SkillPoints++;
        Console.WriteLine($"{CharacterName} leveled up to {Level}! Skill Points: {SkillPoints}");
    }

    // Method to allocate skill points to increase stats
    public void AllocateSkillPoint(string skill)
    {
        if (SkillPoints > 0)
        {
            switch (skill.ToLower())
            {
                case "health":
                    Health += 10;
                    Console.WriteLine($"{CharacterName} increased Health to {Health}");
                    break;
                case "attack":
                    Attack += 2;
                    Console.WriteLine($"{CharacterName} increased Attack to {Attack}");
                    break;
                case "defense":
                    Defense += 2;
                    Console.WriteLine($"{CharacterName} increased Defense to {Defense}");
                    break;
                default:
                    Console.WriteLine("Invalid skill choice.");
                    return;
            }
            SkillPoints--;
        }
        else
        {
            Console.WriteLine("No skill points available.");
        }
    }

    // Method to display the character's current status
    public void DisplayStatus()
    {
        Console.WriteLine($"Name: {CharacterName}, Tech Tree: {TechTree}, Level: {Level}, Health: {Health}, Attack: {Attack}, Defense: {Defense}, Skill Points: {SkillPoints}");
    }

    // Method for taking damage
    public void TakeDamage(int damage)
    {
        int damageTaken = Math.Max(damage - Defense, 0);
        Health -= damageTaken;
        Console.WriteLine($"{CharacterName} took {damageTaken} damage. Health is now {Health}");
        
        if (Health <= 0)
        {
            Console.WriteLine($"{CharacterName} has been defeated.");
            // Handle character defeat logic
        }
    }

    // Method for attacking an enemy
    public void AttackEnemy()
    {
        Console.WriteLine($"{CharacterName} attacks with {Attack} power!");
        // Additional logic for interacting with enemy
    }
}
