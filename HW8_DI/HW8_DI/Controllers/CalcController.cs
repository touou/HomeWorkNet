using System;
using HW8_DI.Interfaces;
using HW8_DI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace HW8_DI.Controllers
{
    
    
    public class CalcController : Controller
    {
        [Route("calc")]
        [HttpGet]
        public IActionResult Calc([FromServices]ICalc calculator, CalcArguments args)
        {
            try
            {
                return Ok(calculator.Calc(args));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
                return new ObjectResult(e.Message)
                {
                    StatusCode = 450
                };
            }
        }
        
    }

}