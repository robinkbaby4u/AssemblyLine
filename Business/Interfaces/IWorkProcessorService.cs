using Business.Domain;

namespace Business.Interfaces
{
    public interface IWorkProcessorService
    {
        string ProcessOrder(OrderDetail orderDetail, List<Employee> employees);
    }
}
