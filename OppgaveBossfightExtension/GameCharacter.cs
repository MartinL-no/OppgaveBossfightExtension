using System;

namespace OppgaveBossfightExtension
{
    public class GameCharacter
    {
        public readonly string _name;
        public int Health { get; private set; }
        private readonly int _initialHealth;
        private int _strength;
        private int _stamina;
        private readonly int _initialStamina;
        private bool _invulnerable;
        private bool _heightenedStrength;

        public GameCharacter(string name, int health, int strength, int stamina)
        {
            _name = name;
            Health = health;
            _initialHealth = health;
            _strength = strength;
            _stamina = stamina;
            _initialStamina = stamina;
            _invulnerable = false;
            _heightenedStrength = false;
        }
        public void Fight(GameCharacter opponent)
        {
            if (opponent._invulnerable)
            {
                /* 
                 * I have not reduced the attackers stamina while the other character is invulnerable
                 * as the Boss always one with that algorithm.
                 */
                Console.WriteLine($"{opponent._name} is invulnerable, {_name}'s attack caused no damage");
                opponent._invulnerable = false;
            }
            else if (_stamina == 0)
            {
                Console.WriteLine($"{_name} has no stamina, {opponent._name} was not attacked");
                Recharge();
            }
            else
            {
                opponent.Health = (opponent.Health - _strength) < 0 ? 0 : (opponent.Health - _strength);
                _stamina  = (_stamina - 10) < 0 ? 0 : (_stamina - 10);

                Console.WriteLine($"{_name} hit {opponent._name} with {_strength} damage, {opponent._name} now has {opponent.Health} health left.");

                if (_heightenedStrength)
                {
                    _heightenedStrength = false;
                    _strength -= 30;
                    Console.WriteLine("Hero's strength has been restored to it's original level");
                }
            }
        }
        public void Recharge()
        {
            _stamina = _initialStamina;
            _invulnerable = true;
            Console.WriteLine($"{_name}'s stamina has been restored to what it was at the start of the fight ({_initialStamina}), {_name} will take no damage during the next attack)");
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
                    Console.WriteLine($"A Health Potion has been dropped and picked up by the Hero, his health is restored to {_initialHealth}");
                    Health = _initialHealth;
                    break;
                case "StrengthPotion":
                    Console.WriteLine("A Strength Potion has been dropped and picked up by the Hero, his strength has been increased by 30 for one round");
                    _strength += 30;
                    _heightenedStrength = true;
                    break;
            }
        }
    }
}