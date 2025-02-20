namespace electricalMeasurements.Models
    {
    public class LoopImpedanceRequest
        {
        public double Impedance { get; set; } // Ω
        public double Voltage { get; set; } = 230; // V (domyślnie 230V)
        public int MCB { get; set; } = 16; // A (domyślnie 16A)
        public string Type { get; set; } = "B"; // Typ zabezpieczenia (B, C, D)
        }
    }
