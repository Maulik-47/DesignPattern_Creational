namespace DesignPattern_Creational.Services.FactoryMethod;

public static class PaymentFactory
{
    public static IPayment Create(string? type)
    {
        switch (type?.ToLowerInvariant())
        {
            case "paypal":
                return new PayPalPayment();
            case "creditcard":
            case "card":
            case null:
            case "":
                return new CreditCardPayment();
            default:
                throw new NotSupportedException($"Payment type '{type}' is not supported.");
        }
    }
}
