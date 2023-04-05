using System;

namespace OppgaveBossfightExtension
{
    class Program
    {
        private static Random _rand = new Random();
        private static List<Item> _items;

        static void Main(string[] args)
        {
            RunGame();
        }
        static void RunGame()
        {
            var randomStrength = _rand.Next(31);
            var isHeroesTurn = _rand.Next(2) == 1;
            _items = GetRandomListOfItems();

            var Hero = new GameCharacter("Hero", 100, 20, 40);
            var Boss = new GameCharacter("Boss", 400, randomStrength, 10);

            var counter = 1;
            while (true)
            {
                if (counter % 3 == 0 && _rand.Next(5) == 1)
                {
                    DropItem(Hero);
                }
                CharacterTurn(isHeroesTurn, Hero, Boss);

                if (Hero.Health == 0)
                {
                    Console.WriteLine($"{Boss._name} is the winner!");
                    break;
                }
                else if (Boss.Health == 0)
                {
                    Console.WriteLine($"{Hero._name} is the winner!");
                    break;
                }
                isHeroesTurn = !isHeroesTurn;
                counter++;
            }
        }
        static void CharacterTurn(bool isHeroesTurn, GameCharacter hero, GameCharacter boss)
        {
            if (isHeroesTurn)
            {
                hero.Fight(boss);
            }
            else
            {
                boss.Fight(hero);
            }
        }
        static List<Item> GetRandomListOfItems()
        {
            var list = new List<Item>();

            for (int i = 0; i < 10; i++)
            {
                var randomItem = _rand.Next(3);
                Item item;
                switch (randomItem)
                {
                    case 0:
                        list.Add(new Item("StaminaPotion"));
                        break;
                    case 1:
                        list.Add(new Item("HealthPotion"));
                        break;
                    case 2:
                        list.Add(new Item("StrengthPotion"));
                        break;
                }
            }
            return list;
        }

        static void DropItem(GameCharacter hero)
        {
            if (hero.Health <= 30)
            {
                var healthPotionOrLastItem = GetHealthPotion();
                hero.PickupItem(healthPotionOrLastItem);
                _items.Remove(healthPotionOrLastItem);
            }
            else
            {
                hero.PickupItem(_items.Last());
                _items.Remove(_items.Last());
            }
        }
        static Item GetHealthPotion()
        {
            var healthPotion = _items.Find(x => x.ItemType == "HealthPotion");

            if (healthPotion == null) return _items.Last();
            else return healthPotion;
        }
    }
}