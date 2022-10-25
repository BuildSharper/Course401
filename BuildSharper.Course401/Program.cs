using BuildSharper.Course401.Services;
using BuildSharper.Course401.Services.Interfaces;

//TODO Populate the App.config with your own values.  To test email, use https://ethereal.email/
//TODO to test DbMessageService, install SqlExpress, SQL Management Studio, and run SqlScript.txt

//let's create our list of IMessageServices
List<IMessageService> services = new List<IMessageService>();
services.Add(new DbMessageService());
services.Add(new EmailMessageService());
services.Add(new SmsMessageService());

Console.WriteLine("****************************************");
Console.WriteLine("BuildSharper.com - Interface Demo");
Console.WriteLine("****************************************");
Console.WriteLine("");
Console.Write("Enter a message to be delivered: ");
var message = Console.ReadLine();

//let's iterated through the list of IMessageServices and blindly send the message, without having to know the specific implementations of each service
foreach (var service in services)
{
    Console.WriteLine($"Sending message via {service.Name}...");
    service.Send(message);
}

Console.WriteLine("Done!");
