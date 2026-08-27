using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;


namespace DigiPet
{
    /// DET HER HAR JEG SØGT EFTER, ku ikke finde ud af at få mine interfaces og items til at save rigtigt
    [JsonDerivedType(typeof(Food), "food")]
    [JsonDerivedType(typeof(Potion), "potion")]
    interface IItem
    {
        string Name { get; }
        int Price { get; }

        IItem Copy();
    }

    interface IUseable : IItem
    {
        string Use(DigiPet target);

    }

    interface IConsumable : IUseable
    {
    }

    interface IEquippable : IItem
    {
        int Damage { get; }
        int Armor { get; }
    }
}
