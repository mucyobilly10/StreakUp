using System;
using BCrypt.Net;
using StreakUp.Models;

namespace StreakUp.Controllers;

public class AuthController
{
    private readonly UserRepository _userRepository;

    public AuthController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    // FR-01, FR-02, FR-03: register
    public void Register(string name, string email, string plainPassword)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.");
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required.");
        if (string.IsNullOrWhiteSpace(plainPassword))
            throw new ArgumentException("Password is required.");

        if (_userRepository.EmailExists(email))
            throw new ArgumentException("This email is already registered.");

        string passwordHash = BCrypt.Net.BCrypt.HashPassword(plainPassword);

        var user = new User
        {
            Name = name.Trim(),
            Email = email.Trim(),
            PasswordHash = passwordHash
        };
        _userRepository.Insert(user);
    }

    // FR-04: login — returns user if valid, null otherwise
    public User? Login(string email, string plainPassword)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(plainPassword))
            throw new ArgumentException("Email and password are required.");

        var user = _userRepository.GetByEmail(email.Trim());
        if (user == null)
            return null;

        if (!BCrypt.Net.BCrypt.Verify(plainPassword, user.PasswordHash))
            return null;

        return user;
    }

    // FR-06: update name
    public void UpdateName(int userId, string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("Name cannot be empty.");
        _userRepository.UpdateName(userId, newName.Trim());
    }

    // FR-06: update password
    public void UpdatePassword(int userId, string newPassword)
    {
        if (string.IsNullOrWhiteSpace(newPassword))
            throw new ArgumentException("Password cannot be empty.");
        if (newPassword.Length < 6)
            throw new ArgumentException("Password must be at least 6 characters.");

        string newHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
        _userRepository.UpdatePassword(userId, newHash);
    }
}