using Backend;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PianoSimulationTests
{
    [TestClass]
    public class DetermineKeyTests{
        [TestMethod]
        public void TestGeneratePattern(){
            string teststring = "qwertyuiop[]";
            DetermineKey dk = new DetermineKey(teststring.Length);
            Assert.AreEqual("wbwwbwbwwbwb", dk.Pattern);
        }

        [TestMethod]
        public void TestGeneratePattern2(){
            string teststring = "qwertyuiop[]wsed";
            DetermineKey dk = new DetermineKey(teststring.Length);
            Assert.AreEqual("wbwwbwbwwbwbwbww", dk.Pattern);
        }
    }
}