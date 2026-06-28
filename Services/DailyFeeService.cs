public class DailyFeeService : IFeeService
{
    public decimal CalculateFee(DateTime entrytime,DateTime exittime)
    {
        if (entrytime == null && exittime == null)
        {
            return 0;
        }
        var day = Math.Ceiling((exittime-entrytime).TotalDays);

        return  (decimal)day * 500;
    }
}