namespace dot_net_restcountries_api.Classes
{
    public class TheName
    {
        public string? official { get; set; }
        public string? common { get; set; }
        public IDictionary<string, NativeNameObject>? nativeName { get; set; }

        public class NativeNameObject
        {
            public string? Official { get; set; }
            public string? Common { get; set; }
        }
    }
}
