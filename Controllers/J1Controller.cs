using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1Controller : ControllerBase
    {
        [HttpPost("Deliveries")]
        [Consumes("application/x-www-form-urlencoded")]
        public int CalculateDeliveryScore([FromForm] int numberOfCollisions, [FromForm] int numberOfDeliveries)
        {
            // Calculate the initial score based on deliveries and collisions
            int score = (numberOfDeliveries * 50) - (numberOfCollisions * 10);

            // Bonus for having more deliveries than collisions
            if (numberOfDeliveries > numberOfCollisions)
            {
                score += 500;
            }

            return score;
        }

        [HttpPost("Cupcake")]
        [Consumes("application/x-www-form-urlencoded")]
        public int CalculateCupcakeSurplus([FromForm] int numLargeCupcakes, [FromForm] int numSmallCupcakes)
        {
            // Calculate total sales from large and small cupcakes
            int totalRevenue = (numLargeCupcakes * 8) + (numSmallCupcakes * 3);
            // Determine surplus after a set target
            int surplus = totalRevenue - 28;

            return surplus;
        }
    }
}