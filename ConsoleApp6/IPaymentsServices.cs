namespace KATA
{
    public interface IPaymentsServices
    {
        public (double,string) getCurrency();
        public string getDescription();
        public double Cost();
    }
}