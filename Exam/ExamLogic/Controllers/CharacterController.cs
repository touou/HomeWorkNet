
using ExamLogic.MainLogic;
using ExamLogic.MainLogic;
using ExamLogic.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamLogic.Controllers;

[ApiController]
[Route("[action]")]
public class CharacterController
{
    [HttpPost]
    public IActionResult FinalaizeCharacter(Character character) => 
        new JsonResult(CharacterFinalaizer.Finalaize(character));
}