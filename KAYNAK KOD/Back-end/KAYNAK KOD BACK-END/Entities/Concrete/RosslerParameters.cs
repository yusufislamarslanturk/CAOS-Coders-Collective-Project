using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class RosslerParameters
    {
        public double[] InitialState { get; set; }
        public double Dt { get; set; }
        public double σ { get; set; }
        public double β { get; set; }
        public double ρ { get; set; }
    }
}
