Console.WriteLine("\nDefault values...\n");
DateOnly date = DateOnly.MinValue;
Write(date, nameof(date));

TimeOnly time = TimeOnly.MinValue;
Write(time, nameof(time));

Console.WriteLine("\nSetup...\n");

TimeOnly startTime = TimeOnly.Parse("11:00 PM");
var hoursWorked = 2;
var endTime = startTime.AddHours(hoursWorked);

Write(startTime, nameof(startTime));
Write(endTime, nameof(endTime));
Console.WriteLine("\nTesting...\n");
Write(TimeOnly.Parse("12:00 AM").IsBetween(startTime, endTime));
