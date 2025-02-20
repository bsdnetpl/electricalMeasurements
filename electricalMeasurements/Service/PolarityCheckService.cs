namespace electricalMeasurements.Service
    {
    public class PolarityCheckService : IPolarityCheckService
        {
        public object ValidateMeasurement(string L_N, string L_PE, string N_PE)
            {
            bool isValid = L_N == "230V" && L_PE == "230V" && N_PE == "0V";
            return new
                {
                MeasurementType = "Polarity Check",
                L_N = L_N,
                L_PE = L_PE,
                N_PE = N_PE,
                Status = isValid ? "Pass" : "Fail",
                Message = isValid ? "Correct polarity detected." : "Incorrect polarity, check wiring."
                };
            }
        }
    }
