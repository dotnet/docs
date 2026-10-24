using Orleans;

namespace SerializationLifecycleHooks;

// <ValidationHookType>
[GenerateSerializer]
[SerializationCallbacks(typeof(PaymentRequestHooks))]
public class PaymentRequest
{
    [Id(0)]
    public string Currency { get; set; } = "USD";

    [Id(1)]
    public decimal Amount { get; set; }

    [Id(2)]
    public string Recipient { get; set; } = string.Empty;
}
// </ValidationHookType>

// <ValidationHookClass>
public class PaymentRequestHooks
{
    private static readonly HashSet<string> s_supportedCurrencies =
        ["USD", "EUR", "GBP", "JPY", "CAD"];

    public void OnDeserialized(PaymentRequest value)
    {
        if (value.Amount <= 0)
        {
            throw new InvalidOperationException(
                $"Payment amount must be positive. Got: {value.Amount}");
        }

        if (!s_supportedCurrencies.Contains(value.Currency))
        {
            throw new InvalidOperationException(
                $"Unsupported currency: {value.Currency}");
        }
    }

    public void OnSerializing(PaymentRequest value)
    {
        if (string.IsNullOrWhiteSpace(value.Recipient))
        {
            throw new InvalidOperationException(
                "Recipient must be specified before serializing a payment request.");
        }
    }
}
// </ValidationHookClass>
