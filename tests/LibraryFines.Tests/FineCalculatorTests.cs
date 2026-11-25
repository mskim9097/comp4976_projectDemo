// These tests show how FineCalculator is supposed to work.
// If a test fails, fix the code in src/LibraryFines, not the test.

using LibraryFines;

namespace LibraryFines.Tests;

public class FineCalculatorTests
{
    // ---------- DaysLate ----------

    [Fact]
    public void DaysLate_ReturnedOnDueDate_IsZero()
    {
        int result = FineCalculator.DaysLate(new DateOnly(2026, 11, 10), new DateOnly(2026, 11, 10));

        Assert.Equal(0, result);
    }

    [Fact]
    public void DaysLate_ReturnedFourDaysLate_IsFour()
    {
        int result = FineCalculator.DaysLate(new DateOnly(2026, 11, 10), new DateOnly(2026, 11, 14));

        Assert.Equal(4, result);
    }

    [Fact]
    public void DaysLate_ReturnedEarly_IsZero()
    {
        int result = FineCalculator.DaysLate(new DateOnly(2026, 11, 10), new DateOnly(2026, 11, 7));

        Assert.Equal(0, result);
    }

    // ---------- CalculateFine ----------

    [Fact]
    public void CalculateFine_OnTime_IsZero()
    {
        Assert.Equal(0m, FineCalculator.CalculateFine(0));
    }

    [Fact]
    public void CalculateFine_FourDaysLate_IsOneDollar()
    {
        Assert.Equal(1.00m, FineCalculator.CalculateFine(4));
    }

    [Fact]
    public void CalculateFine_FortyDaysLate_IsExactlyTheMax()
    {
        Assert.Equal(10.00m, FineCalculator.CalculateFine(40));
    }

    [Fact]
    public void CalculateFine_SixtyDaysLate_IsCappedAtTenDollars()
    {
        Assert.Equal(10.00m, FineCalculator.CalculateFine(60));
    }

    // ---------- TotalFines ----------

    [Fact]
    public void TotalFines_AddsUpEachBook()
    {
        var loans = new List<(DateOnly, DateOnly)>
        {
            (new DateOnly(2026, 11, 10), new DateOnly(2026, 11, 14)), // 4 days late: $1.00
            (new DateOnly(2026, 11, 10), new DateOnly(2026, 11, 12)), // 2 days late: $0.50
        };

        Assert.Equal(1.50m, FineCalculator.TotalFines(loans));
    }
}
