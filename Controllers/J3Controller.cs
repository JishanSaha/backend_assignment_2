using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J3Controller : ControllerBase
    {
        [HttpPost("InstructionsHandler")]
        [Consumes("application/x-www-form-urlencoded")]
        public string HandleSpecialInstructions([FromForm] string rawInstructions)
        {
            // Split the raw input instructions into an array using comma as a delimiter
            string[] instructionList = rawInstructions.Split(',');
            string result = "";
            string lastDirection = "";

            foreach (var instruction in instructionList)
            {
                // Stop processing if the special instruction '99999' is encountered
                if (instruction == "99999")
                {
                    break;
                }

                // Extract prefix and suffix from the instruction
                string currentDirection;
                int prefix = int.Parse(instruction.Substring(0, 2));
                int suffix = int.Parse(instruction.Substring(2, 3));
                int sumOfDigits = (prefix / 10) + (prefix % 10);

                // Determine the direction: use the last direction if the sum is zero
                if (sumOfDigits == 0)
                {
                    currentDirection = lastDirection;
                }
                else if (sumOfDigits % 2 == 0)
                {
                    currentDirection = "right";
                }
                else
                {
                    currentDirection = "left";
                }

                // Update last known direction for future instructions
                lastDirection = currentDirection;
                result += $"{currentDirection} {suffix}\n";
            }

            return result.TrimEnd('\n');
        }
    }
}