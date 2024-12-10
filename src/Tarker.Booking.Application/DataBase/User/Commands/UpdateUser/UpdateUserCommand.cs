using System;
using AutoMapper;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;

public class UpdateUserCommand: IUpdateUserCommand
{
    /* SERVICIO DE BASE DE DATOS */
    private readonly IDataBaseService _databaseService;
    /* SERVICIO DE MAPEO DE ENTIDADES */
    private readonly IMapper _mapper;

    /* MÉTODO PARA ACTUALIZAR */
    public UpdateUserCommand(IDataBaseService dataBaseService, IMapper mapper)
    {
        _databaseService = dataBaseService;
        _mapper = mapper;
    }

    /* MÉTODO ASÍNCRONO UpdateUser */
    public async Task<UpdateUserModel> Execute(UpdateUserModel model)
    {
        var entity = _mapper.Map<UserEntity>(model);
        /* UPDATE NO ES UN MÉTODO ASINCRONÓ, POR LO TANTO NO SE NECESITA USAR await*/
        _databaseService.User.Update(entity);
        await _databaseService.SaveAsync();
        return model;

    }

}
