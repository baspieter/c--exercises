using FsCheck;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    public static bool operator ==(CurrencyAmount left, CurrencyAmount right) => checkCurrencies(left, right) && left.amount == right.amount;

    public static bool operator !=(CurrencyAmount left, CurrencyAmount right) => checkCurrencies(left, right) && left.amount != right.amount;

    public static bool operator <(CurrencyAmount left, CurrencyAmount right) => checkCurrencies(left, right) && left.amount < right.amount;

        public static bool operator >(CurrencyAmount left, CurrencyAmount right) => checkCurrencies(left, right) && left.amount > right.amount;

    public static CurrencyAmount operator +(CurrencyAmount left, CurrencyAmount right)
    {
        checkCurrencies(left, right);
        return new CurrencyAmount(amount: left.amount + right.amount, currency: left.currency);
    }

    public static CurrencyAmount operator -(CurrencyAmount left, CurrencyAmount right)
    {
        checkCurrencies(left, right);
        return new CurrencyAmount(amount: left.amount - right.amount, currency: left.currency);
    }

    public static CurrencyAmount operator /(decimal left, CurrencyAmount right) => new CurrencyAmount(amount: left / right.amount, currency: right.currency);
    public static CurrencyAmount operator *(decimal left, CurrencyAmount right) => new CurrencyAmount(amount: left * right.amount, currency: right.currency);
    public static CurrencyAmount operator /(CurrencyAmount left, decimal right) => new CurrencyAmount(amount: left.amount / right, currency: left.currency);
    public static CurrencyAmount operator *(CurrencyAmount left, decimal right) => new CurrencyAmount(amount: left.amount * right, currency: left.currency);

    public static explicit operator double(CurrencyAmount record) => Convert.ToDouble(record.amount);
    public static implicit operator decimal(CurrencyAmount record) => record.amount;

    private static bool checkCurrencies(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency)
        {
            throw new ArgumentException("Currencies are not the same.");
        }

        return true;
    }
}
