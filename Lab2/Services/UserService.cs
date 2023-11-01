using Lab2.DTO;
using Lab2.Models;

namespace Lab2.Services;

public class UserService
{
    private readonly List<User> _users = new()
    {
        new User
        {
            Id = 0,
            Name = "John",
            SecondName = "Doe",
            Email = "test@gmail.com",
        },
        new User
        {
            Id = 1,
            Name = "Jane",
            SecondName = "Doe",
            Email = "test1@gmail.com",
        },
    };

    public async void AddUser(UserDTO user)
    {
        _users.Add(new User
        {
            Id = _users.Count,
            Name = user.Name,
            SecondName = user.SecondName,
            Email = user.Email,
        });
    }

    public async Task<List<User>> GetUsers()
    {
        return _users;
    }

    public async Task<User> GetUser(int id)
    {
        User? user = _users.FirstOrDefault(user => user.Id == id);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        return user;
    }

    public async void DeleteUser(int id)
    {
        User user = await GetUser(id);
        _users.Remove(user);
    }
}