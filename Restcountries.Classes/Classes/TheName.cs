namespace dot_net_restcountries_api.Classes
{
    public class TheName
    {
        public string? Official { get; set; }
        public string? Common { get; set; }
        public IDictionary<string, NativeNameObject>? NativeName { get; set; }

        public class NativeNameObject
        {
            public string? Official { get; set; }
            public string? Common { get; set; }
        }
    }
}
