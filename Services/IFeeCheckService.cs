public interface IFeeCheckService
{
    IFeeService GetFeeService(string feeType);
}