using System;
using Microwave.Classes.Boundary;
using Microwave.Classes.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Microwave.Test.Unit
{
    public class BuzzerTest
    {
        private Buzzer uut;
        private IOutput output;


        [SetUp]
        public void Setup()
        {
            output = Substitute.For<IOutput>();
            uut = new Buzzer(output);
        }

        [Test]
        [TestCase(3)]
        [TestCase(1)]
        [TestCase(0)]

        public void BuzzerCalledWithAmount(int param)
        {
            uut.Buzz(param, 3);

            output.Received(param).OutputLine(Arg.Is<string>(str => str.Contains("Buzzing for " + 3 + " ms")));

        }

        [Test]
        [TestCase(-1)]
        public void BuzzerCalledWithIllegalAmount(int param)
        {
            Assert.That(() => uut.Buzz(param, 3), Throws.TypeOf<ArgumentException>());

        }

    }
}

