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
        public static object CreateObjectOfMoodAnalyserUsingParameterizedConstructor(string className, string constructorName, string message = "")
        {
            Type type = typeof(MoodAnalyser);
            if (type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo info = type.GetConstructor(new[] { typeof(string) });
                    object instance = info.Invoke(new object[] { (message) });
                    return instance;
                }
                else
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
            }
            else
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "No such class found");
        }
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyserApp.MoodAnalyser");
                object moodAnalyserObject = CreateObjectOfMoodAnalyserUsingParameterizedConstructor("MoodAnalyserApp.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo method = type.GetMethod(methodName);
                object mood = method.Invoke(moodAnalyserObject, null);
                return mood.ToString();
            }
            catch (NullReferenceException e)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "No such method found");
            }
        }
    }
}
