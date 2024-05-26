using System.Text;
using MextFullStack.Domain;
using MextFullStack.Domain.Entities;
using MextFullStack.Domain.Enums;

var filePath = "/Users/fatos/Downloads/AccessControlLogs.txt";

var accesControlLogsText = File.ReadAllText(filePath);

var accesControlLogLines = accesControlLogsText.Split("\n", StringSplitOptions.RemoveEmptyEntries);

List<AccessControlLog> accessControlLogs = new();

foreach (var logLine in accesControlLogLines)
{
    var accesControlLogData = logLine.Split("---", StringSplitOptions.RemoveEmptyEntries);
    var accesControlLog = new AccessControlLog()
    {
        Id = Guid.NewGuid(),
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

// Farklı bir değişken adı kullanarak filtrelenmiş kayıtları saklıyoruz
var cardAccessControlLogs = accessControlLogs
    .Where(x => x.AccessType == AccessType.CARD || x.AccessType == AccessType.FP)
    .ToList();

var random = new Random();
var stringBuilder = new StringBuilder();
foreach (var accessControlLog in cardAccessControlLogs)
{
    // Rastgele bir sayı elde et
    var randomNumber = random.Next(1, 100);

    // Sayının çift mi tek mi olduğunu kontrol et
    if (randomNumber % 2 == 0)
    {
        accessControlLog.IsApproved = false;
    }
    else
    {
        accessControlLog.IsApproved = true;
    }
    accessControlLog.ApprovedDate = DateTime.Now;

    // Eğer sayı çiftse, sayıya 1 ekle
    // Eğer sayı tekse, sayıdan 1 çıkar
    Console.WriteLine($"Writing -> {accessControlLog.UserId}---{accessControlLog.DeviceSerialNumber}---{accessControlLog.AccessType}");

    stringBuilder.AppendLine($"Writing -> {accessControlLog.UserId}");
}
Console.ReadLine();
