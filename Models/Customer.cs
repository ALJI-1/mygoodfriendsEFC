namespace Models;

public class Customer : ICustomer
{
    public ICreditCard CreditCard { get; set; } 
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Token { get; set; }
    

}