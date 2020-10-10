using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserApp
{
    public class MoodAnalyser
    {
        public string AnalyseMood(string message)
        {
            string mood = message == "I am in a Sad mood" ? "Sad" : "Happy";
            return mood;
        }
    }
}
