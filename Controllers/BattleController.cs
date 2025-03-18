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
            var result = new BattleResult
            {
                Winner = "Phoenix",
                Message = "Phoenix wins the battle!"
            };

            return Ok(result);
        }

        [HttpGet("log")]
        public ActionResult<BattleResult> GetBattleResult()
        {
            var result = new BattleResult
            {
                Winner = "Phoenix",
                Message = "Phoenix wins the battle!"
            };

            return Ok(result);
        }
    }
}
