# General 
C# code used to explain how tests can help you with modyfing existing source code. 

[Link to video in Polish](https://www.youtube.com/watch?v=MJ1h2f2VCtY)

# How to run

Go to SOLID.SRP directory and run: 

1. dotnet restore
2. dotnet build
3. dotnet run

You should see:

```
Discounts for old: 31%
Order Info: 1-MoneyTransfer-17,250
Order completed True
```

# How to add and run your first test

1. Create nunit test project. "SOLID.SRP.TEST" is name of project. You can change it into something else. 
```
dotnet new nunit -n "SOLID.SRP.Test"
```
2. You should add project to your solution. If you changed name of your project please also change name in below command. 
```
dotnet add SOLID.SRP.Test/SOLID.SRP.Test.csproj reference SOLID.SRP/SOLID.SRP.csproj
```
3. Run your test. By default there will be single test. You can run it using VS Code or from command line. 
```
dotnet test
```
4. You should add reference to your test project. Why? Because your tests are in different library than code that you are going to test. 
```
dotnet sln add SOLID.SRP.Test/SOLID.SRP.Test.csproj
```
Now you can create code like this in your tests:
```
    Person person = new Person
    {
        Id = 1, 
        FirstName = "",
        LastName = "",
        Age = 66,
        IsStudent = true,
        Money = 100
    };
    BookingService bookingService = new BookingService();
    PersonOder personOder = bookingService.CreateOrde(person, Product.MoneyTransfer);
```







