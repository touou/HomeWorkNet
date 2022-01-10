using Dnd.Ui.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamUi.Controllers;

public class HomeController : Controller
{
    private static HttpClient _client = new();

    public async Task<IActionResult> Index()
    {
        //var zxc = await _client.GetAsync("https://localhost:7120/ShowCharacters");
        //var content = zxc.Content;
        //ViewBag.Heroes = (await content.ReadFromJsonAsync<List<Character>>())!;
        return View();
    }


    private record StartingModel(Character Player, Character Monster);
    public record FightLog(string Log, Character player);

    public record FightModel(FinalaizedCharacter Character, string Log, Character AfterFight);


    public async Task<IActionResult> FightForExistingChar(int characterId)
    {
        var responseMessage = await _client.GetAsync($"https://localhost:7156/GetCharacterById?id={characterId}");
        var character = await responseMessage.Content.ReadFromJsonAsync<Character>();
        
        var zxc = await _client.GetAsync("https://localhost:7120/GetRandomMonster");
        
        var monster = await zxc.Content.ReadFromJsonAsync<Character>();
        
        var qwe = await _client.PostAsync("https://localhost:7101/FinalaizeCharacter", JsonContent.Create(character));
        
        var calculated = await qwe.Content.ReadFromJsonAsync<FinalaizedCharacter>();

        var e = await _client.PostAsync("https://localhost:7101/Fight", JsonContent.Create(new StartingModel(character, monster!)));
        
        var fightResult = await e.Content.ReadFromJsonAsync<FightLog>();
        
        return View(new FightModel(calculated!, fightResult!.Log, fightResult.player));
    }
    
    public async Task<IActionResult> Fight(Character player)
    {
        if (player.Name == null)
        {
            player.Name = "Chel ti Clown";
        }
        
        
        
        Console.WriteLine(player.Name);
        
        var zxc = await _client.GetAsync("https://localhost:7120/GetRandomMonster");
        
        var monster = await zxc.Content.ReadFromJsonAsync<Character>();
        
        var qwe = await _client.PostAsync("https://localhost:7263/FinalaizeCharacter", JsonContent.Create(player));
        
        var calculated = await qwe.Content.ReadFromJsonAsync<FinalaizedCharacter>();

        var e = await _client.PostAsync("https://localhost:7263/Fight", JsonContent.Create(new StartingModel(player, monster!)));
        
        var fightResult = await e.Content.ReadFromJsonAsync<FightLog>();
        
        return View(new FightModel(calculated!, fightResult!.Log, fightResult.player));
    }
}