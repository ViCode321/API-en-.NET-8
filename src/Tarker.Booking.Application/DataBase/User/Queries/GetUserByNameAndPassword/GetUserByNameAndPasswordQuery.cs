using System;
using System.Runtime.CompilerServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.User.Queries.GetUserByNameAndPassword;

public class GetUserByNameAndPasswordQuery: IGetUserByNameAndPasswordQuery
{
    private readonly IDataBaseService _dataBaseService;
    private readonly IMapper _mapper;

    public GetUserByNameAndPasswordQuery(IDataBaseService dataBaseService, IMapper mapper)
    {
        _dataBaseService = dataBaseService;
        _mapper = mapper;
    }

    public async Task<GetUserByNameAndPasswordModel> Execute(string userName, string password)
    {
        var entity = await _dataBaseService.User
        .FirstOrDefaultAsync(x => x.UserName == userName && x.Password == password);

        return _mapper.Map<GetUserByNameAndPasswordModel>(entity);
    }
}
