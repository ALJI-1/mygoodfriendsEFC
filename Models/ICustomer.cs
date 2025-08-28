namespace Models;

public interface ICustomer
{
    public ICreditCard CreditCard { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Token { get; set; }
}

