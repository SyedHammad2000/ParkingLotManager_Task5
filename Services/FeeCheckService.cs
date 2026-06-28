public class FeeCheckService : IFeeCheckService
{
    public IFeeService GetFeeService(string feetype)
    {
        return  feetype.ToLower() switch
        {
            "hourly" =>  new HourlyFeeService(),
            "daily" => new DailyFeeService(),
            "flat" => new FlatFeeService(),
            _ => throw new Exception("fee method not given"),
        };
    }
}