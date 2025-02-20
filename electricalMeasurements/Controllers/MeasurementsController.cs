using electricalMeasurements.Models;
using electricalMeasurements.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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

        public MeasurementsController(
            ContinuityTestService continuityService,
            InsulationResistanceService insulationService,
            PolarityCheckService polarityService,
            RCDTestService rcdService,
            LoopImpedanceService loopImpedanceService,
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
            var result = _continuityService.ValidateMeasurement(resistance);
            return Ok(FormatResult(result));
            }

        [HttpPost("insulation")]
        public IActionResult CheckInsulation([FromBody] double resistance)
            {
            var result = _insulationService.ValidateMeasurement(resistance);
            return Ok(FormatResult(result));
            }

        [HttpPost("polarity")]
        public IActionResult CheckPolarity([FromBody] PolarityCheckRequest request)
            {
            var result = _polarityService.ValidateMeasurement(request.L_N, request.L_PE, request.N_PE);
            return Ok(result);
            }

        [HttpPost("rcd")]
        public IActionResult CheckRCD([FromBody] double tripTime)
            {
            var result = _rcdService.ValidateMeasurement(tripTime);
            return Ok(FormatResult(result));
            }

        [HttpPost("loop-impedance")]
        public IActionResult CheckLoopImpedance([FromBody] LoopImpedanceRequest request)
            {
            var result = _loopImpedanceService.ValidateMeasurement(request.Impedance, request.Voltage, request.MCB, request.Type);
            return Ok(FormatResult(result));
            }

        [HttpPost("ground-resistance")]
        public IActionResult CheckGroundResistance([FromBody] double resistance)
            {
            var result = _groundResistanceService.ValidateMeasurement(resistance);
            return Ok(FormatResult(result));
            }

        /// <summary>
        /// Formatuje wynik tak, aby wszystkie liczby były w formacie z kropką dziesiętną.
        /// </summary>
        private object FormatResult(object result)
            {
            if (result is Dictionary<string, object> dictResult)
                {
                var formattedResult = new Dictionary<string, object>();
                foreach (var item in dictResult)
                    {
                    if (item.Value is double dValue)
                        {
                        formattedResult[item.Key] = dValue.ToString(CultureInfo.InvariantCulture);
                        }
                    else
                        {
                        formattedResult[item.Key] = item.Value;
                        }
                    }
                return formattedResult;
                }
            return result;
            }
        }
    }
    
