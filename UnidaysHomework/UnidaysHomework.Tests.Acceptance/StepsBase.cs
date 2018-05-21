using TechTalk.SpecFlow;

namespace UnidaysHomework.Tests.Acceptance
{
    [Binding]
    public class StepsBase
    {
        public static T Get<T>(string key = null)
        {
            return key == null ? ScenarioContext.Current.Get<T>() : ScenarioContext.Current.Get<T>(key);
        }

        public static void Set<T>(T item, string key = null)
        {
            if(key == null)
            {
                ScenarioContext.Current.Set(item);
            }
            else
            {
                ScenarioContext.Current.Set(item, key);
            }
        }
    }
}