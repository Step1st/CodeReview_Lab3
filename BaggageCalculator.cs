namespace Refactoring;

public class BaggageCalculator
{
    double holidayTravelFeePercent = 0.1;

    public double HolidayTravelFeePercent
    {
        get { return holidayTravelFeePercent; }
        set { holidayTravelFeePercent = value; }
    }

    public double calculatePrice(int numChecked, int numCarryOn, int numPassengers, DateTime travelTime) 
    {
        double total = 0;

        // Calculate carry-On price
        if (numCarryOn > 0) {
            Console.WriteLine($"Carry-on price: {numCarryOn * 40}");
            total += numCarryOn * 40;
        }

        // Calculated checked-in price
        if (numChecked > 0) {
            if (numChecked <= numPassengers) {
                Console.WriteLine($"Checked bag price: {numChecked * 25}");
                total += numChecked * 25;
            } else {
                double CheckedFee = (numPassengers * 25) + ((numChecked - numPassengers) * 50);
                Console.WriteLine($"Checked bag price (including excess): {CheckedFee}");
                total += CheckedFee;
            }
        }

        // Calculate holiday fee
        if (travelTime.Month == 12 || travelTime.Month == 1 || travelTime.Month == 2) {
            Console.WriteLine($"Holiday travel fee: {total * HolidayTravelFeePercent}");
            total += total * HolidayTravelFeePercent;
        }

        return total;
    }
}