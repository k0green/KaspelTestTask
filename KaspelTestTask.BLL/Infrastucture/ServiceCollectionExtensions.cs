using KaspelTestTask.DAL.Data;
using KaspelTestTask.DAL.Data.Entities;
using KaspelTestTask.DAL.Repositories.Implementations;
using KaspelTestTask.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KaspelTestTask.BLL.Infrastucture;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Dependency injection for repositories.
    /// </summary>
    public static void AddTest(this IServiceCollection services)
    {
        services.AddTransient<IBookRepository, BookRepository>();
        services.AddTransient<IOrderBookRepository, OrderBookRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
    }
}