# General
C# code used to explain how we can fix SRP issues during refactorization based on different limitations.

[Link to video in Polish](https://www.youtube.com/watch?v=MJ1h2f2VCtY)

# Phases 

There are 3 different phases. 
* Phase I - On master branch - code without changes. 
* Phase II - P2 branch - different responsibilities moved to static methods. 
* Phase II - P3 branch - different responsibilities delegated to separate classes. 


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


