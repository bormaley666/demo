namespace Demo.Common.Exceptions;

public class SalePointException : Exception
{
    public SalePointException(string message)
        : base(message)
    {
    }
}