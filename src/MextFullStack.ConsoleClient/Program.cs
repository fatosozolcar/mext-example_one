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
        UserId = int.Parse(accesControlLogData[0]),
        DeviceSerialNumber = accesControlLogData[1],
        AccessType = (AccessType)int.Parse(accesControlLogData[2]),
        Date = DateTime.Parse(accesControlLogData[3]),
        CreatedOn = DateTime.Now

    };

    accessControlLogs.Add(accesControlLog);

}