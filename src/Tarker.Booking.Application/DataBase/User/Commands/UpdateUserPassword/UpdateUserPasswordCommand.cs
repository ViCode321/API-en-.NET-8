using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword;

public class UpdateUserPasswordCommand: IUpdateUserPasswordCommand
{
    private readonly IDataBaseService _dataBaseService;
    public UpdateUserPasswordCommand(IDataBaseService dataBaseService)
    {
        _dataBaseService = dataBaseService;
    }

    public async Task<bool> Execute(UpdateUserPasswordModel model)
    {
        var entity = await _dataBaseService.User.FirstOrDefaultAsync(x => x.UserId == model.UserId);
        if(entity == null)
            return false;
        entity.Password = model.Password;
        return await _dataBaseService.SaveAsync();
    }
}
