namespace electricalMeasurements.Service
    {
    public class GroundResistanceService : IGroundResistanceService
        {
        public object ValidateMeasurement(double resistance)
            {
            bool isValid = resistance <= 10.0;
            return new
                {
                MeasurementType = "Ground Resistance",
                Resistance = resistance,
                Status = isValid ? "Pass" : "Fail",
                Message = isValid ? "Ground resistance meets requirements." : "Resistance too high, check grounding system."
                };
            }
        }
    }
