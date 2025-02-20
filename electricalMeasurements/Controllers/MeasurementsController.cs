using electricalMeasurements.Models;
using electricalMeasurements.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace electricalMeasurements.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
        {
        private readonly ContinuityTestService _continuityService;
        private readonly InsulationResistanceService _insulationService;
        private readonly PolarityCheckService _polarityService;
        private readonly RCDTestService _rcdService;
        private readonly LoopImpedanceService _loopImpedanceService;
        private readonly GroundResistanceService _groundResistanceService;

        public MeasurementsController(ContinuityTestService continuityService, InsulationResistanceService insulationService,
            PolarityCheckService polarityService, RCDTestService rcdService, LoopImpedanceService loopImpedanceService,
            GroundResistanceService groundResistanceService)
            {
            _continuityService = continuityService;
            _insulationService = insulationService;
            _polarityService = polarityService;
            _rcdService = rcdService;
            _loopImpedanceService = loopImpedanceService;
            _groundResistanceService = groundResistanceService;
            }
        [HttpPost("continuity")]
        public IActionResult CheckContinuity([FromBody] double resistance)
            {
            return Ok(_continuityService.ValidateMeasurement(resistance));
            }

        [HttpPost("insulation")]
        public IActionResult CheckInsulation([FromBody] double resistance)
            {
            return Ok(_insulationService.ValidateMeasurement(resistance));
            }

        [HttpPost("polarity")]
        public IActionResult CheckPolarity([FromBody] PolarityCheckRequest request)
            {
            return Ok(_polarityService.ValidateMeasurement(request.L_N, request.L_PE, request.N_PE));
            }

        [HttpPost("rcd")]
        public IActionResult CheckRCD([FromBody] double tripTime)
            {
            return Ok(_rcdService.ValidateMeasurement(tripTime));
            }

        [HttpPost("loop-impedance")]
        public IActionResult CheckLoopImpedance([FromBody] double impedance)
            {
            return Ok(_loopImpedanceService.ValidateMeasurement(impedance));
            }

        [HttpPost("ground-resistance")]
        public IActionResult CheckGroundResistance([FromBody] double resistance)
            {
            return Ok(_groundResistanceService.ValidateMeasurement(resistance));
            }
        }
    }
    
