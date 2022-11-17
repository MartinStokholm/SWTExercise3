using System;
using Microwave.Classes.Interfaces;


namespace Microwave.Classes.Boundary
{
	public class Buzzer: IBuzzer
	{
        private IOutput myOutput;

        public Buzzer(IOutput output)
		{
			myOutput = output;
		}

		public void Buzz(int amount, int duration)
		{
			if (amount < 0)
			{
				throw new ArgumentException($"{amount} out of range");
			}

            for (int i = 0; i < amount; i++)
            {
                myOutput.OutputLine($"Buzzing for {duration} ms");
            }

          
        }
	}
}

