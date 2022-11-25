// Forked from https://github.com/TeamSWTFrabj/MicrowaveOven

using System;
using Microwave.Classes.Boundary;
using Microwave.Classes.Controllers;

namespace Microwave.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Button startCancelButton = new Button();
            Button powerButton = new Button();
            Button timeButton = new Button();

            Door door = new Door();

            Output output = new Output();

            Display display = new Display(output);

            PowerTube powerTube = new PowerTube(output, 700);

            Light light = new Light(output);

            Microwave.Classes.Boundary.Timer timer = new Timer();

            CookController cooker = new CookController(timer, display, powerTube);

            Buzzer buzzer = new Buzzer(output);

            UserInterface ui = new UserInterface(powerButton, timeButton, startCancelButton, door, display, light, cooker, buzzer);

            // Finish the double association
            cooker.UI = ui;

            // Simulate a simple sequence
            powerButton.Press();

            timeButton.Press();

            timeButton.Press();

            timeButton.Press();

            timeButton.Press();

            startCancelButton.Press();


            timeButton.Press();
            // The simple sequence should now run

            Console.WriteLine("When you press enter, the program will stop");
            // Wait for input

            Console.ReadLine();
        }
    }
}
