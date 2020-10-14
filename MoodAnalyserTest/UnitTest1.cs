using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserApp;
namespace MoodAnalyserTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenSadMood_ShouldReturn_SadMood()
        {
            //Arrange
            MoodAnalyser analyser = new MoodAnalyser("I am in a Sad mood");
            //Act
            string mood = analyser.AnalyseMood();
            //Assert
            Assert.AreEqual("Sad", mood);
        }
        [TestMethod]
        public void GivenAnyMood_ShouldReturn_HappyMood()
        {
            //Arrange
            MoodAnalyser analyser = new MoodAnalyser("I am in a Happy mood");
            //Act
            string mood = analyser.AnalyseMood();
            //Assert
            Assert.AreEqual("Happy", mood);
        }
        [TestMethod]
        public void GivenEmptyMood_ShouldThrow_MoodAnalysisExceptionIndicatingEmptyMood()
        {
            try
            {
                string message = string.Empty;
                MoodAnalyser mood = new MoodAnalyser(message);
                string moodStr = mood.AnalyseMood();
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("Mood should not be empty", e.Message);
            }
        }
        [TestMethod]
        public void GivenNULLMood_ShouldThrow_MoodAnalysisException()
        {
            try
            {
                string message = null;
                MoodAnalyser moodAnalyse = new MoodAnalyser(message);
                string mood = moodAnalyse.AnalyseMood();
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("Mood should not be null", e.Message);
            }
        }
        [TestMethod]
        public void GivenMoodAnalyserClassName_WhenAnalyse_ShouldReturnMoodAnalyserObject()
        {
            object expected = new MoodAnalyser();
            object actual = MoodAnalyserFactory.MoodAnalyseObjectCreation("MoodAnalyserApp.MoodAnalyser" , "MoodAnalyser");
            //expected.Equals(actual);
            Assert.AreEqual(expected.GetType(), actual.GetType());
        }
        [TestMethod]
        public void GivenImproperClassName_WhenAnalyse_ShouldThrowMoodAnalysisException()
        {
            try
            {
                object expected = new MoodAnalyser();
                object actual = MoodAnalyserFactory.MoodAnalyseObjectCreation("abc", "abc");
            }
            catch(MoodAnalyserCustomException e)
            {
                Assert.AreEqual("No such class found", e.Message);
            }
        }
        [TestMethod]
        public void GivenImproperConstructorName_WhenAnalyse_ShouldThrowMoodAnalysisException()
        {
            try
            {
                object expected = new MoodAnalyser();
                object actual = MoodAnalyserFactory.MoodAnalyseObjectCreation("Mood", "MoodAnalyser");
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("Constructor not found", e.Message);
            }
        }
    }
}
