using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calculadora_rest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            decimal n1;
            decimal n2;
            if(IsNumeric(firstNumber,out n1)&&IsNumeric(secondNumber,out n2))
            {
                return Ok((n1 + n2).ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("Subtract/{firstNumber}/{secondNumber}")]
        public IActionResult Subtract(string firstNumber, string secondNumber)
        {
            decimal n1;
            decimal n2;
            if (IsNumeric(firstNumber, out n1) && IsNumeric(secondNumber, out n2))
            {
                return Ok((n1 - n2).ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("Multiply/{firstNumber}/{secondNumber}")]
        public IActionResult Multiply(string firstNumber, string secondNumber)
        {
            decimal n1;
            decimal n2;
            if (IsNumeric(firstNumber, out n1) && IsNumeric(secondNumber, out n2))
            {
                return Ok((n1 * n2).ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("Divide/{firstNumber}/{secondNumber}")]
        public IActionResult Divide(string firstNumber, string secondNumber)
        {
            decimal n1;
            decimal n2;
            if (IsNumeric(firstNumber, out n1) && IsNumeric(secondNumber, out n2))
            {
                try
                {
                    return Ok((n1 / n2).ToString());
                }
                catch (DivideByZeroException)
                {
                    return BadRequest("Quer explodir o universo?");
                }
            }
            return BadRequest("Invalid input");
        }


        [HttpGet("Mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            decimal n1;
            decimal n2;
            if (IsNumeric(firstNumber, out n1) && IsNumeric(secondNumber, out n2))
            {
                return Ok(((n1 + n2)/2).ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("Sqrt/{firstNumber}/{secondNumber}")]
        public IActionResult Sqrt(string firstNumber, string secondNumber)
        {
            decimal n1;
            decimal n2;
            if (IsNumeric(firstNumber, out n1) && IsNumeric(secondNumber, out n2))
            {
                return Ok(Math.Pow((double)n1, (double)n2).ToString());
            }
            return BadRequest("Invalid input");
        }

        private bool IsNumeric(string number, out decimal decNumber) {

            return decimal.TryParse(number,System.Globalization.NumberStyles.Any,System.Globalization.NumberFormatInfo.InvariantInfo,out decNumber);
        }
    }
}
