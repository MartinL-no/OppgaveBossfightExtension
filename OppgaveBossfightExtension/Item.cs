using System;

namespace OppgaveBossfightExtension
{
    /*
        Quest “BossFight Extension”
        This task is an extension and assumes that you have solved the BossFight task which is under the intro to object orientation first ^^ 
        We will expand our Console Application to include the ability for the "hero" to pick up items in the battle.
        Create a class called Item with a property of type string called ItemType.

        An item can have one of the following item types: StaminaPotion, HealthPotion and StrengthPotion

        Create a list of 10 random Items in program.cs.These can either replenish stamina, replenish life or increase strength(for one round).
        StaminaPotion does the same as the Recharge method.HealthPotion restores full health and StrengthPotion increases strength by 30 for 
        the current round.

        For every third round of the battle, an item must have the opportunity to "drop". Whether an item is "dropped" or not is random.When 
        an item is "dropped" it is picked up by the hero who immediately gets the effect it gives.

        Create a method in program.cs that can find and return a HealthPotion from the list of items.If the Hero has 30 or less in Health,
        health potion shall be the item type to be dropped.

        Log to the console when an item is dropped and used by the hero, as well as its effect.
    */
    public class Item
    {
        public readonly string ItemType;

        public Item(string itemType)
        {
            ItemType = itemType;
        }
    }
}