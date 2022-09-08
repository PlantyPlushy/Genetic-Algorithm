using Microsoft.VisualStudio.TestTools.UnitTesting;
using PianoSimulator;

namespace PianoSimulationTests
{
    [TestClass]
    public class PianoWireTests{
        [TestMethod]
        public void testNoteFrequency(){
            PianoWire pw = new PianoWire(1.5,1);
            Assert.AreEqual(1.5, pw.NoteFrequency);
        }
        [TestMethod]
        public void testSampleRate(){
            PianoWire pw = new PianoWire(1.5,1);
            Assert.AreEqual(1, pw.NumberOfSamples);
        }
        [TestMethod]
        public void testSampler(){
            PianoWire pw = new PianoWire(2.0,4);
            pw.Strike();
            double testnum = pw.Sample();
            Assert.AreEqual(true, (testnum > -0.5 && testnum < 0.5));
        }
    }   
}