// See https://aka.ms/new-console-template for more information
using MextFullStack.Domain;
using MextFullStack.Domain.Entities;

Console.WriteLine("Hello, World!");


var customer = new Customer();
var franciseRep = new FranchiseRepresented();
customer.Id= "1234";
franciseRep.Id= 1;
var francihise = new Franchise();
francihise.Id= Guid.NewGuid();

Console.WriteLine(customer.Id.ToString());



Console.WriteLine(customer.CreatedOn.ToLongDateString());
Console.WriteLine(customer.Id.ToString());

Console.ReadLine();
