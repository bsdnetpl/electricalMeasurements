namespace electricalMeasurements.Service
    {
    public class InsulationResistanceService : IInsulationResistanceService
        {
        public object ValidateMeasurement(double resistance)
            {
            bool isValid = resistance >= 1.0;
            return new
                {
                MeasurementType = "Insulation Resistance",
                Resistance = resistance,
                Status = isValid ? "Pass" : "Fail",
                Message = isValid ? "Measurement meets safety standards." : "Insulation resistance too low, risk of leakage."
                };
            }
        }
    }
