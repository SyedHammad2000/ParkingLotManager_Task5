public class HourlyFeeService : IFeeService
{
    public decimal CalculateFee(DateTime entrytime,DateTime exittime)
    {
        if (entrytime == null && exittime == null)
        {
            return 0;
        }
        var hours = Math.Ceiling((exittime-entrytime).TotalHours);

        return  (decimal)hours * 50;
    }
}