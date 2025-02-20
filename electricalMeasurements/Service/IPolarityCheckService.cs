namespace electricalMeasurements.Service
    {
    public interface IPolarityCheckService
        {
        object ValidateMeasurement(string L_N, string L_PE, string N_PE);
        }
    }