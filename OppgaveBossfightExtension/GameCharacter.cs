using System;

namespace OppgaveBossfightExtension
{
    public class GameCharacter
    {
        public readonly string Name;
        public int Health { get; private set; }
        private readonly int InitialHealth;
        private int Strength;
        private int Stamina;
        private readonly int InitialStamina;
        private bool Invulnerable;
        private bool HeightenedStrength;

        public GameCharacter(string name, int health, int strength, int stamina)
        {
            Name = name;
            Health = health;
            InitialHealth = health;
            Strength = strength;
            Stamina = stamina;
            InitialStamina = stamina;
            Invulnerable = false;
            HeightenedStrength = false;
        }
        public void Fight(GameCharacter opponent)
        {
            if (opponent.Invulnerable)
            {
                /* 
                 * I have not reduced the attackers stamina while the other character is invulnerable
                 * as the Boss always one with that algorithm.
                 */
                Console.WriteLine($"{opponent.Name} is invulnerable, {Name}'s attack caused no damage");
                opponent.Invulnerable = false;
            }
            else if (Stamina == 0)
            {
                Console.WriteLine($"{Name} has no stamina, {opponent.Name} was not attacked");
                Recharge();
            }
            else
            {
                opponent.Health = (opponent.Health - Strength) < 0 ? 0 : (opponent.Health - Strength);
                Stamina  = (Stamina - 10) < 0 ? 0 : (Stamina - 10);

                Console.WriteLine($"{Name} hit {opponent.Name} with {Strength} damage, {opponent.Name} now has {opponent.Health} health left.");

                if (HeightenedStrength)
                {
                    HeightenedStrength = false;
                    Strength -= 30;
                }
            }
        }
        public void Recharge()
        {
            Stamina = InitialStamina;
            Invulnerable = true;
            Console.WriteLine($"{Name}'s stamina has been restored to what it was at the start of the fight ({InitialStamina}), {Name} will take no damage during the next attack)");
        }

        public void PickupItem(Item item)
        {
            switch (item.ItemType)
            {
                case "StaminaPotion":
                    Console.WriteLine("A Stamina Potion has been dropped and picked up by the Hero");
                    Recharge();
                    break;
                case "HealthPotion":
                    Console.WriteLine($"A Health Potion has been dropped and picked up by the Hero, his health is restored to {InitialHealth}");
                    Health = InitialHealth;
                    break;
                case "StrengthPotion":
                    Console.WriteLine("A Strength Potion has been dropped and picked  up by the Hero");
                    Strength += 30;
                    HeightenedStrength = true;
                    break;
            }
        }
    }
}