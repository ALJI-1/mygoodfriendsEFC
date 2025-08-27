# Exercises: Loosely Coupled Friend and CreditCard Models, Service, and Controller

## Purpose
These exercises will guide you through creating a loosely coupled model of a `Friend` containing `firstname`, `lastname`, and credit card info, with `CreditCard` as a separate model. You will also create a service to provide a list of friends with creditcard information and a controller (`FriendsController`) with two endpoints: one returning credit card info in clear text, and one with encrypted credit card info.

---

## Exercise 1: Define the Models

1. **Create interfaces for loose coupling**
   - Create an `ICreditCard` interface with properties: `CardNumber`, `ExpiryMonth`, `ExpiryYear` (all as strings).
   - Create an `IFriend` interface with properties: `FirstName`, `LastName` (strings), and a `CreditCard` property (of type `ICreditCard`).
2. **Create a `CreditCard` model**
   - Properties: `CardNumber`, `ExpiryMonth`, `ExpiryYear` (all as strings).
   - Implement the `ICreditCard` interface.
3. **Create a `Friend` model**
   - Properties: `FirstName`, `LastName` (strings), and a `CreditCard` property (of type `ICreditCard`).
   - Implement the `IFriend` interface.
   - Ensure the models are in the Models project.

---

## Exercise 2: Create a Service

1. **Define an interface `IFriendService`**
   - Method: `List<Friend> GetFriends(int nrItems)`
2. **Implement the service as `FriendService`**
   - Return a randomly seeded list of nrItems amount of friends, each with credit card info.
   - Register the service for dependency injection.

   - hint: to generate CreditCard info
        
        Given an enum type CardIssuer (you can put this type in the same file as you have ICreditCard)
        public enum CardIssuer {AmericanExpress, Visa, MasterCard, DinersClub}

        Issuer = seeder.FromEnum<CardIssuer>();

        Number = $"{seeder.Next(2222, 9999)}-{seeder.Next(2222, 9999)}-{seeder.Next(2222, 9999)}-{seeder.Next(2222, 9999)}";
        ExpirationYear = $"{seeder.Next(25, 32)}";
        ExpirationMonth = $"{seeder.Next(01, 13):D2}";


---

## Exercise 3: Create the Controller

1. **Create a `FriendsController`**
   - Inject `IFriendService` via constructor.
2. **Add endpoint `/api/friends/clear`**
   - Returns the list of friends with credit card info in clear text.
3. **Add endpoint `/api/friends/encrypted`**
   - Returns the list of friends, but with credit card info encrypted, use Encryptions AesEncryptToBase64 to encrypt the credit card class.

---

## Test Your Endpoints
- Use Swagger or Postman to verify both endpoints return the expected data.
- Discuss the importance of not exposing sensitive data in clear text in real applications.

---

**Tip:** Focus on keeping models, services, and controllers loosely coupled, in separate projects, by using interfaces and dependency injection.
