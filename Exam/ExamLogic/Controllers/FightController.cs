using ExamLogic.MainLogic;
using ExamLogic.MainLogic;
using ExamLogic.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamLogic.Controllers;

[ApiController]
[Route("[action]")]
public class FightController
{
    public record FightInput(Character Player, Character Monster);
    public record FightLog(string Log, Character player);
    
    [HttpPost]
    public IActionResult Fight(FightInput input)
    {
        var (player, monster) = input;
        return new JsonResult(FightProcess.GetFightLog(player, monster));
    }
}