# ConsoleAppDependencyInjection
A Simple console app showing how to use Microsoft's Dependency Injection feature.

In this project i'll try explain how Microsoft's Dependency Injection works.
Why use it?
First of all, What actually is dependency injection?
Roughly, it mean that an object supplies the dependencies of another, for an exemple:
Consider the following Interface
```csharp
public interface IFooService 
{
  void SomeAction();
}
```
And the following class that implements the IFooService interface: 
```csharp
public class FooService : IFooService 
{
  public void SomeAction () 
  {
    Console.WriteLine("Hello world!");
  }
}
```
Everything's normal here, right? That's the fun part.
Let's inject this dependency as a service:
```csharp
  services.AddScoped<IFooService, FooService>();
```
In that code, i'm saying that i want inject the service of type IFooService, and the class that implements that service is FooService,
It means, that whenever you need to use this service, you just have to tell the class to inject it to you.
To use the service, just grab it in the construtor, No needs to creating tons of instances around the application
```csharp
public class AnotherClass 
{
  public IFooService FooService { get; set; }
  
  public AnotherClass(IFooService fooService)
  {
    FooService = fooService;
  }
}
```
