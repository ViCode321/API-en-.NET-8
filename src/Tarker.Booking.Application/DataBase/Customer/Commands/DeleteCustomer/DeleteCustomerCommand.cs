using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.Customer.Commands.DeleteCustomer;

public class DeleteCustomerCommand: IDeleteCustomerCommand
{
    private readonly IDataBaseService _dataBaseService;
    public DeleteCustomerCommand(IDataBaseService dataBaseService)
    {
        _dataBaseService = dataBaseService;
    }

    public async Task<bool> Execute(int customerId)
    {
        var entity = await _dataBaseService.Customer.FirstOrDefaultAsync(x => x.CustomerId ==  customerId);
        if (entity == null)
            return false;
        _dataBaseService.Customer.Remove(entity);
        return await _dataBaseService.SaveAsync();
    }
}

