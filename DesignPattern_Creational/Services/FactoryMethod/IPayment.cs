namespace DesignPattern_Creational.Services.FactoryMethod;

public interface IPayment
{
    string Name { get; }
    string Pay(decimal amount);
}

public class CreditCardPayment : IPayment
{
    public string Name => "Credit Card";
    public string Pay(decimal amount) => $"Paid {amount:C} with Credit Card.";
}

public class PayPalPayment : IPayment
{
    public string Name => "PayPal";
    public string Pay(decimal amount) => $"Paid {amount:C} with PayPal.";
}

public abstract class PaymentCreator
{
    public abstract IPayment Create();
}

public class CreditCardCreator : PaymentCreator
{
    public override IPayment Create() => new CreditCardPayment();
}

public class PayPalCreator : PaymentCreator
{
    public override IPayment Create() => new PayPalPayment();
}