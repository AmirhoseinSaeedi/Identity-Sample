using BookStore.Application.Dtos.Users;
using BookStore.Utility.ValidationErrors;

namespace BookStore.Application.Contracts
{
    public interface IUserService
    {
        Task<List<ValidationError?>?> CreateAsync(CreateUserDto user);
        Task<(List<GetAllUserDto?>?, List<ValidationError?>?)> GetAllAsync();
        Task<List<ValidationError?>?> RemoveAsync1(RemoveUserDto removeUserDto);
        Task<(GetUserDto, List<ValidationError?>?)> GetUserByIdAsync1(string id);
        Task<List<ValidationError?>?> EditAsync1(EditUserDto editUserDto);
    }
}