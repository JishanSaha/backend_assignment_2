using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2Controller : ControllerBase
    {
        [HttpGet(template: "ChiliPepper={pepperList}")]
        public int CalculateTotalSpiciness(string pepperList)
        {
            string[] pepperArray = pepperList.Split(',');
            int cumulativeSpiciness = 0;

            // Loop through each pepper and determine SHU using switch
            foreach (var pepper in pepperArray)
            {
                switch (pepper.Trim())
                {
                    case "Poblano":
                        cumulativeSpiciness += 1500;
                        break;
                    case "Mirasol":
                        cumulativeSpiciness += 6000;
                        break;
                    case "Serrano":
                        cumulativeSpiciness += 15500;
                        break;
                    case "Cayenne":
                        cumulativeSpiciness += 40000;
                        break;
                    case "Thai":
                        cumulativeSpiciness += 75000;
                        break;
                    case "Habanero":
                        cumulativeSpiciness += 125000;
                        break;
                }
            }

            return cumulativeSpiciness;
        }

        [HttpPost("Epidemiology")]
        [Consumes("application/x-www-form-urlencoded")]
        public int ComputeDaysToThreshold([FromForm] int infectionThreshold, [FromForm] int startingInfections, [FromForm] int infectionMultiplier)
        {
            int totalInfections = startingInfections; 
            int dailyInfections = startingInfections; 
            int dayCount = 0; 

            while (totalInfections <= infectionThreshold)
            {
                dayCount++; 
                dailyInfections *= infectionMultiplier; 
                totalInfections += dailyInfections; 
            }

            return dayCount;
        }
    }
}