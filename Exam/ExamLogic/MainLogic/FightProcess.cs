using System.Text;
using ExamLogic.Controllers;
using ExamLogic.Controllers;
using ExamLogic.Models;

namespace ExamLogic.MainLogic;

public static class FightProcess
{
    public static FightController.FightLog GetFightLog(Character player, Character monster)
    {
        var stringBuilder = new StringBuilder();
        while(true)
        {
            if (CheckHealthPoints(player, monster, stringBuilder))
                break;
            if(Hit(player, monster, stringBuilder))
                break;
            if (CheckHealthPoints(player, monster, stringBuilder))
                break;
            if (Hit(monster, player, stringBuilder))
                break;
        }

        return new FightController.FightLog(stringBuilder.ToString(), player);
    }
    
    private static bool CheckHealthPoints(Character player, Character monster, StringBuilder stringBuilder)
    {
        if (player.HitPoints <= 0)
        {
            stringBuilder.Append($"{monster.Name} победил\r\n");
            
            return true;
        }

        if (monster.HitPoints <= 0)
        {
            stringBuilder.Append($"{player.Name} победил\r\n");
            
            return true;
        }

        return false;
    }

    private static bool Hit(Character character1, Character character2, StringBuilder stringBuilder)
    {
        for (var i = 0; i < character1.AttackPerRound; i++)
        {
            var random = Random.Shared.Next(20) + 1;
            var modifiers = character1.AttackModifier + character1.Weapon;
            stringBuilder.Append($"{character1.Name} получает {random}(+{modifiers}) на шанс к попаданию\r\n");
            
            if (random == 20)
            {
                stringBuilder.Append("у чела нет шансов)\r\n");
            }

            if (random + modifiers <= character2.Ac)
            {
                stringBuilder.Append("промах\r\n");
                continue;
            }
            stringBuilder.Append($"шанс к попаданию > {character2.Ac}\r\n");
            
            stringBuilder.Append("попадание\r\n");
            
            var dmgByHit = 0;
            
            dmgByHit += Random.Shared.Next(character1.DiceType) + 1;
            
            var damageModifiers = character1.Weapon + character1.DamageModifier;
            
            stringBuilder.Append($"выбрасывает и наносит удар равный {dmgByHit}(+{damageModifiers})\r\n");

            if (random == 20)
            {
                stringBuilder.Append($"{character2.Name} получает удар на {(dmgByHit + damageModifiers) * 2} хп, осталось {character2.HitPoints}\r\n");
            }
            else
            {
                stringBuilder.Append($"{character2.Name} получает удар на {(dmgByHit + damageModifiers) * 1} хп, осталось {character2.HitPoints}\r\n");
            }
            
            if (CheckHealthPoints(character1, character2, stringBuilder))
            {
                return true;
            }
        }
        return false;
    }

    
}