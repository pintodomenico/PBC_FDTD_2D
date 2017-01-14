using System.Collections.Generic;

namespace PBC_FDTD_2D.Interfaces
{
    public interface IFDTDPropagator
    {
        ComplexField EField { get; }
        ComplexField HField { get; }
        Structure Structure { get; }

        void Propagate(int numberOfTimeSteps, double Deltat, Source source, List<Detector> detectors);
    }
}