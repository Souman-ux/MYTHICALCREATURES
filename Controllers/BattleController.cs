using Microsoft.AspNetCore.Mvc;
using MythicalCreatures.Models;
using System.IO;
using System.Text.Json;

namespace MythicalCreatures.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleController : ControllerBase
    {
        private readonly string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "battlelog.json");

        // POST api/battle
        [HttpPost]
        public IActionResult Battle([FromBody] BattleRequest battleRequest)
        {
            // Perform the battle logic between the two creatures
            var creature1 = battleRequest.Creature1;
            var creature2 = battleRequest.Creature2;

            // Simulate the battle and get the result
            var result = SimulateBattle(creature1, creature2);

            // Log the battle process to battlelog.json
            LogBattleToFile(result);

            // Return the BattleResult including both creatures and the result
            return Ok(result);
        }

        private BattleResult SimulateBattle(Creature creature1, Creature creature2)
        {
            BattleResult battleResult = new BattleResult
            {
                // Determine the winner based on some logic
                Winner = creature1.Strength > creature2.Strength ? creature1.Name : creature2.Name,
                Message = $"The battle took place between {creature1.Name} and {creature2.Name}."
            };

            // You can add more logic here for determining the winner, like comparing other attributes
            if (creature1.Strength > creature2.Strength)
            {
                battleResult.Winner = creature1.Name;
                battleResult.Message = $"{creature1.Name} wins with higher strength!";
            }
            else if (creature1.Strength < creature2.Strength)
            {
                battleResult.Winner = creature2.Name;
                battleResult.Message = $"{creature2.Name} wins with higher strength!";
            }
            else
            {
                battleResult.Winner = "None";
                battleResult.Message = "It's a tie!";
            }

            return battleResult;
        }

        private void LogBattleToFile(BattleResult battleResult)
        {
            try
            {
                // Check if the log file exists, if not, create it
                if (!System.IO.File.Exists(logFilePath))
                {
                    System.IO.File.WriteAllText(logFilePath, "[]"); // Initialize with empty array
                }

                // Read the existing logs from the battlelog.json
                var currentLogs = System.IO.File.ReadAllText(logFilePath);
                var logList = JsonSerializer.Deserialize<List<BattleResult>>(currentLogs) ?? new List<BattleResult>();

                // Add the current battle result to the list
                logList.Add(battleResult);

                // Write the updated list back to the battlelog.json file
                var updatedLog = JsonSerializer.Serialize(logList, new JsonSerializerOptions { WriteIndented = true });
                System.IO.File.WriteAllText(logFilePath, updatedLog);
            }
            catch (Exception ex)
            {
                // Log the error (optional, can also log to a different error log)
                Console.WriteLine($"Error logging battle: {ex.Message}");
            }
        }
    }
}
