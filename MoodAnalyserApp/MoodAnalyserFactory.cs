using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyserApp
{
    public class MoodAnalyserFactory
    {
        public static object MoodAnalyseObjectCreation(string className, string constructorName)
        {
            string name = @".*" + constructorName + "$";
            bool result = Regex.IsMatch(className, name);
            if (result)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "No such class found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
            }
        }
    }
}
