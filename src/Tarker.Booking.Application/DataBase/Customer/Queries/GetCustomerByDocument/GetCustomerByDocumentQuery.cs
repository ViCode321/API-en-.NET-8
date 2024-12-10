using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocument;

public class GetCustomerByDocumentQuery: IGetCustomerByDocumentQuery
{
    private readonly IDataBaseService _dataBaseService;
    private readonly IMapper _mapper;

    public GetCustomerByDocumentQuery(IDataBaseService dataBaseService, IMapper mapper)
    {
        _dataBaseService = dataBaseService;
        _mapper = mapper;
    }

    public async Task<GetCustomerByDocumentModel> Execute(string document)
    {
        var entity = await _dataBaseService.Customer.FirstOrDefaultAsync(x => x.DocumentNumber == document);
        return _mapper.Map<GetCustomerByDocumentModel>(entity);
    }
}
