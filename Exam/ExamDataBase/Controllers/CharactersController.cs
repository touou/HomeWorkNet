using ExamDataBase;
using ExamDataBase.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamDataBase.Controllers;

[ApiController]
[Route("[action]")]
public class CharactersController
{
    [HttpGet]
    public async Task<IActionResult> ShowCharacters([FromServices] GameDataContext dataContext)
    {
        if (!dataContext.Characters.Any())
        {
            dataContext.Characters.Add(new Character
            {
                Name = "Ember Spirit",
                HitPoints = 120,
                AttackModifier = 4,
                AttackPerRound = 2,
                Damage = 2,
                DiceType = 6,
                DamageModifier = 1,
                Weapon = 0,
                Ac = 12
            });
            dataContext.Characters.Add(new Character
            {
                Name = "Anti-Mage",
                HitPoints = 152,
                AttackModifier = 4,
                AttackPerRound = 1,
                Damage = 3,
                DiceType = 8,
                DamageModifier = 3,
                Weapon = 0,
                Ac = 14
            });
            dataContext.Characters.Add(new Character
            {
                Name = "Phantom Lancer",
                HitPoints = 220,
                AttackModifier = 8,
                AttackPerRound = 1,
                Damage = 3,
                DiceType = 7,
                DamageModifier = 0,
                Weapon = 0,
                Ac = 15
            });
            dataContext.SaveChanges();
        }
        
        return new JsonResult(dataContext.Characters.ToList());
    }

    [HttpGet]
    public async Task<IActionResult> GetCharacterById([FromQuery] int id, [FromServices] GameDataContext dataContext) =>
        new JsonResult(dataContext.Characters.FirstOrDefault(i => i.Id == id));
}