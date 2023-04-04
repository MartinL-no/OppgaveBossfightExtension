using System;

namespace OppgaveBossfightExtension
{
    class Program
    {
        static Random Rand = new Random();
        private static List<Item> Items;

        static void Main(string[] args)
        {
            RunGame();
        }
        static void RunGame()
        {
            var randomStrength = Rand.Next(31);
            var isHeroesTurn = Rand.Next(2) == 1;
            Items = GetRandomListOfItems();

            var Hero = new GameCharacter("Hero", 100, 20, 40);
            var Boss = new GameCharacter("Boss", 400, randomStrength, 10);

            var counter = 1;
            while (true)
            {
                if (counter % 3 == 0 && Rand.Next(5) == 1)
                {
                    DropItem(Hero);
                }
                CharacterTurn(isHeroesTurn, Hero, Boss);

                if (Hero.Health == 0)
                {
                    Console.WriteLine($"{Boss.Name} is the winner!");
                    break;
                }
                else if (Boss.Health == 0)
                {
                    Console.WriteLine($"{Hero.Name} is the winner!");
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
                var randomItem = Rand.Next(3);
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
                Items.Remove(healthPotionOrLastItem);
            }
            else
            {
                hero.PickupItem(Items.Last());
                Items.Remove(Items.Last());
            }
        }
        static Item GetHealthPotion()
        {
            var healthPotion = Items.Find(x => x.ItemType == "HealthPotion");

            if (healthPotion == null) return Items.Last();
            else return healthPotion;
        }
    }
}