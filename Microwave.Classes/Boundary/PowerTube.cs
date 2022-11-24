using System;
using Microwave.Classes.Interfaces;

namespace Microwave.Classes.Boundary
{
    public class PowerTube : IPowerTube
    {
        private IOutput myOutput;
        // Default value of maxValue for the powertube
        public int MaxValue
        {
            get
            {
                return _maxValue;
            }
            private set { _maxValue = value; }
        }


        private int _maxValue = 700;

        private bool IsOn = false;


        public PowerTube(IOutput output, int maxValue) : this(output)
        {
            if (maxValue <= 0 || 1000 < maxValue)
                throw new ArgumentOutOfRangeException("Max Value", maxValue, "Must be between 1 and 1000 (incl.)");

            MaxValue = maxValue;
        }
        public PowerTube(IOutput output)
        {
            myOutput = output;
        }


        public void TurnOn(int power)
        {
            if (power < 1 || MaxValue < power)
            {
                throw new ArgumentOutOfRangeException("power", power, $"Must be between 1 and {_maxValue} (incl.)");
            }

            if (IsOn)
            {
                throw new ApplicationException("PowerTube.TurnOn: is already on");
            }

            myOutput.OutputLine($"PowerTube works with {power}");
            IsOn = true;
        }

        public void TurnOff()
        {
            if (IsOn)
            {
                myOutput.OutputLine($"PowerTube turned off");
            }

            IsOn = false;
        }
    }
}