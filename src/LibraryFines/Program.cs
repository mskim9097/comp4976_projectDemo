using LibraryFines;

// A small fine report for three returned books.
var loans = new List<(string Title, DateOnly Due, DateOnly Returned)>
{
    ("Clean Code",      new DateOnly(2026, 11, 10), new DateOnly(2026, 11, 7)),
    ("C# in Depth",     new DateOnly(2026, 11, 10), new DateOnly(2026, 11, 14)),
    ("Design Patterns", new DateOnly(2026, 9, 1),   new DateOnly(2026, 10, 31)),
};

Console.WriteLine("=== Library fine report ===");
Console.WriteLine();

foreach (var loan in loans)
{
    int daysLate = FineCalculator.DaysLate(loan.Due, loan.Returned);
    decimal fine = FineCalculator.CalculateFine(daysLate);

    Console.WriteLine($"{loan.Title,-16} days late: {daysLate,3}  fine: ${fine,5:F2}");
}

decimal total = FineCalculator.TotalFines(loans.Select(l => (l.Due, l.Returned)));
Console.WriteLine();
Console.WriteLine($"Total fines: ${total:F2}");
