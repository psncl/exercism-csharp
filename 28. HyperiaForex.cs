// https://exercism.org/tracks/csharp/exercises/hyperia-forex
// Operator overloading

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    public static bool operator ==(CurrencyAmount left, CurrencyAmount right)
    {
        IsNotSameCurrency(left, right);
        return left.amount == right.amount;
    }

    public static bool operator !=(CurrencyAmount left, CurrencyAmount right) => !(left == right);

    public static bool operator >(CurrencyAmount left, CurrencyAmount right)
    {
        IsNotSameCurrency(left, right);
        return left.amount > right.amount;
    }

    public static bool operator <(CurrencyAmount left, CurrencyAmount right)
    {
        IsNotSameCurrency(left, right);
        return left.amount < right.amount;
    }

    public static CurrencyAmount operator +(CurrencyAmount left, CurrencyAmount right)
    {
        IsNotSameCurrency(left, right);
        return left with { amount = left.amount + right.amount };
    }

    public static CurrencyAmount operator -(CurrencyAmount left, CurrencyAmount right)
    {
        IsNotSameCurrency(left, right);
        return left with { amount = left.amount - right.amount };
    }

    public static CurrencyAmount operator *(CurrencyAmount currency, decimal factor)
    {
        return currency with { amount = currency.amount * factor };
    }

    public static CurrencyAmount operator *(decimal factor, CurrencyAmount currency)
    {
        return currency with { amount = factor * currency.amount };
    }

    public static CurrencyAmount operator /(CurrencyAmount currency, decimal divisor)
    {
        if (divisor == 0) throw new ArgumentException();
        return currency with { amount = currency.amount / divisor };
    }

    public static explicit operator double(CurrencyAmount currency) => (double)currency.amount;

    public static implicit operator decimal(CurrencyAmount currency) => currency.amount;

    private static void IsNotSameCurrency(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency) throw new ArgumentException();
    }

}