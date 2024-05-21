using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RosslerManager
    {
        public static void RosslerMethod(double[] s, double dt, double σ, double β, double ρ)
        {
            Func<double, double, double, double> dx = (x, y, z) => -y - z;
            Func<double, double, double, double> dy = (x, y, z) => x + σ * y;
            Func<double, double, double, double> dz = (x, y, z) => β + z * (x - ρ);

            double x = s[0];
            double y = s[1];
            double z = s[2];

            double k1dx = dx(x, y, z);
            double k1dy = dy(x, y, z);
            double k1dz = dz(x, y, z);

            double k2x = x + k1dx * dt / 2;
            double k2y = y + k1dy * dt / 2;
            double k2z = z + k1dz * dt / 2;

            double k2dx = dx(k2x, k2y, k2z);
            double k2dy = dy(k2x, k2y, k2z);
            double k2dz = dz(k2x, k2y, k2z);

            double k3x = x + k2dx * dt / 2;
            double k3y = y + k2dy * dt / 2;
            double k3z = z + k2dz * dt / 2;

            double k3dx = dx(k3x, k3y, k3z);
            double k3dy = dy(k3x, k3y, k3z);
            double k3dz = dz(k3x, k3y, k3z);

            double k4x = x + k3dx * dt;
            double k4y = y + k3dy * dt;
            double k4z = z + k3dz * dt;

            double k4dx = dx(k4x, k4y, k4z);
            double k4dy = dy(k4x, k4y, k4z);
            double k4dz = dz(k4x, k4y, k4z);

            s[0] = x + (k1dx + 2 * k2dx + 2 * k3dx + k4dx) * dt / 6;
            s[1] = y + (k1dy + 2 * k2dy + 2 * k3dy + k4dy) * dt / 6;
            s[2] = z + (k1dz + 2 * k2dz + 2 * k3dz + k4dz) * dt / 6;
        }
    }
}
