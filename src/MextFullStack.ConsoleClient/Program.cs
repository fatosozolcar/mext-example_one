using MextFullStack.Domain;
using MextFullStack.Domain.Entities;
using MextFullStack.Domain.Enums;

var filePath = "/Users/fatos/Downloads/AccessControlLogs.txt";

var accesControlLogsText = File.ReadAllText(filePath);

var accesControlLogLines = accesControlLogsText.Split("\n",StringSplitOptions.RemoveEmptyEntries);

List<AccessControlLog> accessControlLogs = new();

foreach(var logLine in accesControlLogLines){
    var accesControlLogData = logLine.Split("---",StringSplitOptions.RemoveEmptyEntries);
    var accesControlLog = new AccessControlLog(){
        Id =Guid.NewGuid(),
        UserId = Convert.ToInt32(accesControlLogData[0]),
        DeviceSerialNumber = accesControlLogData[1],
        AccessType = Enum.Parse<AccessType>(accesControlLogData[2]),
        Date = Convert.ToDateTime(accesControlLogData[3]),
        CreatedOn = DateTime.Now

    };

    accessControlLogs.Add(accesControlLog);

    Console.WriteLine($"Reading -> Access control log: {logLine}");

    Thread.Sleep(100);


}
var random = new Random();
foreach(var accesControlLog in accessControlLogs){

   //Get a random number
   var randomNumber = random.Next(1,100);
   
   //Chech whether this number is even or odd
   if(randomNumber % 2 == 0){
       accesControlLog.IsApproved = false;
       
   }
   else{
       accesControlLog.IsApproved = true;
       
   }
   accesControlLog.ApprovedDate = DateTime.Now; 
   //If it is even, then add 1 to the number
   //If it is odd, then subtract 1 from the number
  

}
Console.ReadLine();