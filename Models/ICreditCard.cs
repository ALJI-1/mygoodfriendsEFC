namespace Models;
public enum CardIssuer {AmericanExpress, Visa, MasterCard, DinersClub}
public interface ICreditCard
{
    CardIssuer Issuer { get; set; }
    
    public string CardNumber { get; set; }
    public string ExpiryMonth { get; set; }
    public string ExpiryYear { get; set; }
    
    
}

