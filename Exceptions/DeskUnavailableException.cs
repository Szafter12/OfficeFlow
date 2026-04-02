namespace OfficeFlow.Exceptions
{
    public class DeskUnavailableException : Exception
    {
        public DeskUnavailableException()
            : base("Desk is already taken") { }

        public DeskUnavailableException(string message)
            : base(message) { }
    }
}
