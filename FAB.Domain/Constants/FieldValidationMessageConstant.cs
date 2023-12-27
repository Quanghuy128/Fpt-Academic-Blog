namespace FAB.Domain.Constants
{
    public static class FieldValidationMessageConstant
    {
        static FieldValidationMessageConstant() { }

        public const string NotExceeded = "This field '{0}' cannot be exceeded {1} characters";

        public static class Account
        {
            public static string GmailNotExceeded(string value) => String.Format(NotExceeded, "gmail", value); 
        }
    }
}
