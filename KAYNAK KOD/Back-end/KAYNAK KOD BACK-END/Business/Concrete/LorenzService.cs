using Autofac.Features.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LorenzService
    {
        public double Sigma { get; set; } = 10.0;
        public double Beta { get; set; } = 8.0 / 3.0;
        public double Rho { get; set; } = 28.0;
        public double StepSize { get; set; } = 0.007;
        public double[] ComputeNextState(double[] state)
        {
            double x = state[0];
            double y = state[1];
            double z = state[2];

            double dx(double x, double y, double z) => Sigma * (y - x);
            double dy(double x, double y, double z) => x * (Rho - z) - y;
            double dz(double x, double y, double z) => x * y - Beta * z;

            var k1x = dx(x, y, z);
            var k1y = dy(x, y, z);
            var k1z = dz(x, y, z);

            var k2x = dx(x + k1x * StepSize / 2, y + k1y * StepSize / 2, z + k1z * StepSize / 2);
            var k2y = dy(x + k1x * StepSize / 2, y + k1y * StepSize / 2, z + k1z * StepSize / 2);
            var k2z = dz(x + k1x * StepSize / 2, y + k1y * StepSize / 2, z + k1z * StepSize / 2);

            var k3x = dx(x + k2x * StepSize / 2, y + k2y * StepSize / 2, z + k2z * StepSize / 2);
            var k3y = dy(x + k2x * StepSize / 2, y + k2y * StepSize / 2, z + k2z * StepSize / 2);
            var k3z = dz(x + k2x * StepSize / 2, y + k2y * StepSize / 2, z + k2z * StepSize / 2);

            var k4x = dx(x + k3x * StepSize, y + k3y * StepSize, z + k3z * StepSize);
            var k4y = dy(x + k3x * StepSize, y + k3y * StepSize, z + k3z * StepSize);
            var k4z = dz(x + k3x * StepSize, y + k3y * StepSize, z + k3z * StepSize);

            return new double[]
            {
                x + (k1x + 2 * k2x + 2 * k3x + k4x) * StepSize / 6,
                y + (k1y + 2 * k2y + 2 * k3y + k4y) * StepSize / 6,
                z + (k1z + 2 * k2z + 2 * k3z + k4z) * StepSize / 6
            };
        }
    }
}
