namespace Entities.Concrete
{
    public class LorenzRequest
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Sigma { get; set; }
        public double Beta { get; set; }
        public double Rho { get; set; }
        public double Dt { get; set; }
        public int Steps { get; set; }
    }

}
