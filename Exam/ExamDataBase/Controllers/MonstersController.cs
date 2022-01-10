using ExamDataBase;
using ExamDataBase.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamDataBase.Controllers;

[ApiController]
[Route("[action]")]
public class MonstersController
{
    [HttpGet]
    public IActionResult GetRandomMonster([FromServices] GameDataContext dataContext)
    {
        if (!dataContext.Monsters.Any())
        {
            dataContext.Monsters.Add(new Monster
            {
                Id = 0,
                Name = "Lifestealer",
                HitPoints = 80,
                AttackModifier = 4,
                AttackPerRound = 2,
                Damage = 2,
                DiceType = 6,
                DamageModifier = 1,
                Weapon = 0,
                Ac = 12
            });
            dataContext.Monsters.Add(new Monster
            {
                Name = "Shadow Fiend",
                HitPoints = 111,
                AttackModifier = 4,
                AttackPerRound = 1,
                Damage = 3,
                DiceType = 8,
                DamageModifier = 3,
                Weapon = 0,
                Ac = 14
            });
            dataContext.Monsters.Add(new Monster
            {
                Name = "DoomBringer",
                HitPoints = 160,
                AttackModifier = 8,
                AttackPerRound = 1,
                Damage = 3,
                DiceType = 7,
                DamageModifier = 0,
                Weapon = 0,
                Ac = 15
            });
            dataContext.Monsters.Add(new Monster
            {
                Id = 0,
                Name = "Outworld devourer",
                HitPoints = 210,
                AttackModifier = 9,
                AttackPerRound = 1,
                Damage = 5,
                DiceType = 10,
                DamageModifier = 3,
                Weapon = 0,
                Ac = 18
            });
            dataContext.SaveChanges();
        }

        var random = Random.Shared.Next(dataContext.Monsters.Count());
        
        return new JsonResult((random > 0 ? dataContext.Monsters.Skip(random) : dataContext.Monsters).First());
    }
}