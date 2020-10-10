using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserApp;
namespace MoodAnalyserTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MoodAnalyser_Should_Return_Sad()
        {
            //Arrange
            MoodAnalyser analyser = new MoodAnalyser();
            string message = "I am in a Sad mood";
            //Act
            string mood = analyser.AnalyseMood(message);
            //Assert
            Assert.AreEqual("Sad", mood);
        }
    }
}
