namespace LibraryFines;

/// <summary>
/// Works out late fines for library books.
/// </summary>
public static class FineCalculator
{
    /// <summary>
    /// Returns how many days late a book was returned.
    /// A book returned on or before the due date is 0 days late.
    /// </summary>
    public static int DaysLate(DateOnly dueDate, DateOnly returnedDate)
    {
        return returnedDate.DayNumber - dueDate.DayNumber;
    }

    /// <summary>
    /// The fine is $0.25 for each day late.
    /// The fine for one book is never more than $10.00.
    /// </summary>
    public static decimal CalculateFine(int daysLate)
    {
        if (daysLate <= 0)
        {
            return 0m;
        }

        return daysLate * 0.25m;
    }

    /// <summary>
    /// Adds up the fines for all the loans.
    /// </summary>
    public static decimal TotalFines(IEnumerable<(DateOnly Due, DateOnly Returned)> loans)
    {
        decimal total = 0m;
        foreach (var loan in loans)
        {
            total += CalculateFine(DaysLate(loan.Due, loan.Returned));
        }
        return total;
    }
}
