using AutoMapper;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class OrderManager : IOrderService
{

     private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public OrderManager(IRepositoryManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public IQueryable<Order> Orders => _manager.Order.Orders;

    public int NumberOfInProcess => _manager.Order.NumberOfInProcess;

    public void Complete(int id)
    {
        _manager.Order.Complete(id);
        _manager.Save();
    }

    public Order? GetOneOrder(int id) => _manager.Order.GetOneOrder(id);
    public void SaveOrder(Order order)
    {
        _manager.Order.SaveOrder(order);
        _manager.Save();
    }
}