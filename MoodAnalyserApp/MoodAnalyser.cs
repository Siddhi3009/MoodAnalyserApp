using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserApp
{
    public class MoodAnalyser
    {
        public string message;
        public MoodAnalyser() { }
        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        public string AnalyseMood()
        {
            string mood = "";
            try
            {
                if (message == "I am in a Happy mood")
                    mood = "Happy";
                if (message == "I am in a Sad mood")
                    mood = "Sad";
            }
            catch (Exception e)
            {
                mood = "Happy";
            }
            return mood;
        }
    }
}
