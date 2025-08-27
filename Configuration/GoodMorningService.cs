using System;

namespace Configuration
{
    public interface IGreeter
    {
        string Greeting();
    }

    public class GoodMorning : IGreeter
    {
        public string Greeting() => "Good Morning";
    }
    public class GoodEvening : IGreeter
    {
        public string Greeting() => "Good Evening";
    }

}
