using AutoMapper;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.DataBase.User.Commands.CreateUser;

/* CLASE DE IMPLEMENTACIÓN */
public class CreateUserCommand: ICreateUserCommand
{
    /* SERVICIO DE BASE DE DATOS */
    private readonly IDataBaseService _databaseService;

    /* SERVICIO DE MAPEO DE ENTIDADES */
    private readonly IMapper _mapper;

    /* MÉTODO CONSTRUCTOR */
    public CreateUserCommand(IDataBaseService dataBaseService, IMapper mapper)
    {
        /* INYECCIÓN DE DEPENDENCIAS */
        _databaseService = dataBaseService;
        _mapper = mapper;
    }

    /* MÉTODO ASINCRÓNO CreateUser */
    public async Task<CreateUserModel> Execute(CreateUserModel model)
    {
        /* INVOCAR SERVICIO DE BASE DE DATOS PARA CREAR O GUARDAR UN USUARIO */
        var entity = _mapper.Map<UserEntity>(model);
        await _databaseService.User.AddAsync(entity);
        await _databaseService.SaveAsync();
        return model;
    }
}
