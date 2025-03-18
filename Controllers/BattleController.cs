using Microsoft.AspNetCore.Mvc;
using MythicalCreatures.Models; // Make sure this namespace is included for BattleResult

namespace MythicalCreatures.Controllers
{
    [Route("battle")]
    [ApiController]
    public class BattleController : ControllerBase
    {
        [HttpPost("battle")]
        public ActionResult<BattleResult> Battle([FromBody] BattleRequest request)
        {
            Creature result;

            if (request.Creature1.Strength > request.Creature2.Strength)
            {
                result = request.Creature1;
            }
            else
            {
                result = request.Creature2;
            }


            // var result = new BattleResult
            // {
            //     Winner = request.Creature1,
            //     Message = "Phoenix wins the battle!"
            // };

            return Ok(result);
        }

        [HttpGet("log")]
        public ActionResult<BattleResult> GetBattleResult()
        {
            var result = new BattleResult
            {
                Winner = new Creature() { Name = "Phoenix" },
                Message = "Phoenix wins the battle!"
            };

            return Ok(result);
        }
    }
}
