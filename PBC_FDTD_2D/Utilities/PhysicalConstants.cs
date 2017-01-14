using System;

namespace PBC_FDTD_2D.Utilities
{
    public static class PhysicalConstants
    {
        private static double mi0 = 1.256637061e-6;
        private static double eps0 = 8.8541878176e-12;
        private static double c0 = Math.Sqrt(1.0/(mi0*eps0));

        /// <summary>
        /// Vacuum permeability
        /// </summary>
        public static double Mi0 => mi0;

        /// <summary>
        /// Vacuum permittivity
        /// </summary>
        public static double Eps0 => eps0;

        /// <summary>
        /// Speed of light in vacuum
        /// </summary>
        public static double C0 => c0;
    }
}
