using Microsoft.AspNetCore.Mvc;
using ProbabilityCalculatorAPI.Application.Commands;
using ProbabilityCalculatorAPI.Application.Handlers;
using ProbabilityCalculatorAPI.Infrastructure.Interfaces;

namespace ProbabilityCalculatorAPI.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class CalculationController : ControllerBase {
        private readonly CalculateCommandHandler _handler;
        private readonly GetCalculationLogsQueryHandler _queryHandler;

        public CalculationController(CalculateCommandHandler handler, GetCalculationLogsQueryHandler queryHandler) {
            _handler = handler;
            _queryHandler = queryHandler;
        }

        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody] CalculateCommand command) {
            try {
                var result = _handler.Handle(command);
                return Ok(new { Result = result.Result });
            }
            catch (ArgumentException ex) {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("logs")]
        public IActionResult GetCalculationLogs() {
            try {
                var logs = _queryHandler.Handle();
                return Ok(logs);
            }
            catch (Exception ex) {
                return StatusCode(500, $"Error retrieving logs: {ex.Message}");
            }
        }
    }
}
