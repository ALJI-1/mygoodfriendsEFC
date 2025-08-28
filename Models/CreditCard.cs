namespace Models;

public class CreditCard : ICreditCard
{
    public CardIssuer Issuer { get; set; }
    public string IssuerString => Issuer.ToString();
    
    public string CardNumber { get; set; }
    public string ExpiryMonth { get; set; }
    public virtual string ExpiryYear { get; set; }

}