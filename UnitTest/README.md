# Unit Testing in .NET

## Introduction

Unit Testing is a software testing technique where individual components
(units) of an application are tested in isolation.

In .NET, unit testing is commonly done using frameworks like: - xUnit -
NUnit - MSTest

------------------------------------------------------------------------

## Why Unit Testing?

-   Improve code quality
-   Catch bugs early
-   Make refactoring safer
-   Ensure business logic works correctly

------------------------------------------------------------------------

## Popular Frameworks

### 1. xUnit

-   Most modern and widely used
-   Clean and flexible

### 2. NUnit

-   Rich feature set
-   Good for legacy and modern apps

### 3. MSTest

-   Official Microsoft testing framework

------------------------------------------------------------------------

## Setting Up a Test Project

``` bash
dotnet new xunit -n MyApp.Tests
dotnet add reference ../MyApp/MyApp.csproj
```

------------------------------------------------------------------------

## Writing Your First Test

``` csharp
public class Calculator
{
    public int Add(int a, int b) => a + b;
}

public class CalculatorTests
{
    [Fact]
    public void Add_ShouldReturnCorrectSum()
    {
        var calc = new Calculator();
        var result = calc.Add(2, 3);

        Assert.Equal(5, result);
    }
}
```

------------------------------------------------------------------------

## Test Structure (AAA Pattern)

-   Arrange → prepare data
-   Act → execute method
-   Assert → verify result

------------------------------------------------------------------------

## Mocking with Moq

``` csharp
var mock = new Mock<IUserService>();
mock.Setup(x => x.GetUser()).Returns(new User { Name = "Ali" });
```

------------------------------------------------------------------------

## Best Practices

-   Test one thing per test
-   Use meaningful names
-   Avoid dependencies (use mocks)
-   Keep tests fast

------------------------------------------------------------------------

## Running Tests

``` bash
dotnet test
```

------------------------------------------------------------------------

## Coverage Tools

-   coverlet
-   dotnet test with coverage
-   ReportGenerator

------------------------------------------------------------------------

## Conclusion

Unit Testing is essential for building reliable and maintainable .NET
applications. Start small, practice daily, and integrate testing into
your workflow.

------------------------------------------------------------------------

## Author

Created for learning purposes.
