namespace TooGood.Model
{
    public class StandardAccount
    {
        public string AccountCode { get; set; }
        public string Name { get; set; }
        public AccountType Type { get; set; }
        public string Opened { get; set; }
        public string Currency { get; set; }
    }

    public enum AccountType
    {
        Trading = 1,
        RRSP = 2,
        RESP = 3,
        Fund = 4
    }
}