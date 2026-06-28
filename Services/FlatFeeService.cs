public class FlatFeeService : IFeeService
{
    public decimal CalculateFee(DateTime entrytime,DateTime exittime)
    {
        if (entrytime == null && exittime == null)
        {
            return 0;
        }
    

        return  200;
    }
}