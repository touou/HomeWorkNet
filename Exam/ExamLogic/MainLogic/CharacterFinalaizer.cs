
using ExamLogic.Models;

namespace ExamLogic.MainLogic;

public static class CharacterFinalaizer
{
    public static CalculatedCharacter Finalaize(Character character) =>
        new CalculatedCharacter()
        {
            Name = character.Name,
            HitPoints = character.HitPoints,
            AttackModifier = character.AttackModifier,
            AttackPerRound = character.AttackPerRound,
            DiceType = character.DiceType,
            DamageModifier = character.DamageModifier,
            Weapon = character.Weapon,
            Ac = character.Ac,
            
            MinAcToAlwaysHit = character.AttackModifier + character.Weapon + 1,
            MinDamagePerRound = (character.Damage + character.Weapon + character.DamageModifier) *
                                character.AttackPerRound,
            MaxDamagePerRound = (character.Damage * character.DiceType + character.Weapon + character.DamageModifier) *
                                character.AttackPerRound
        };
}