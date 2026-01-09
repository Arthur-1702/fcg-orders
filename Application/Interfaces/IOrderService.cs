using Application.DTO.Order;

namespace Application.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponse>> GetAllOrdersAsync();
        OrderResponse GetOrderById(int id);
        Task<OrderResponse> AddOrder(AddOrderRequest game);
        OrderResponse UpdateOrder(UpdateOrderRequest game);
        bool DeleteOrder(int id);
    }
}
