using System;
using System.Data;
using MySqlConnector;
using StreakUp.Models;

namespace StreakUp.Models;

public class UserRepository
{
    private readonly string _connectionString;

    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    // FR-02: check if email already exists
    public bool EmailExists(string email)
    {
        const string sql = "SELECT COUNT(*) FROM users WHERE email = @email";
        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@email", MySqlDbType.VarChar, 150).Value = email;
        con.Open();
        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
    }

    // FR-01: register a new user
    public void Insert(User user)
    {
        const string sql = @"INSERT INTO users (name, email, password_hash) 
                             VALUES (@name, @email, @password_hash)";
        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@name", MySqlDbType.VarChar, 100).Value = user.Name;
        cmd.Parameters.Add("@email", MySqlDbType.VarChar, 150).Value = user.Email;
        cmd.Parameters.Add("@password_hash", MySqlDbType.VarChar, 255).Value = user.PasswordHash;
        con.Open();
        cmd.ExecuteNonQuery();
    }

    // Get user by email (for login verification)
    public User? GetByEmail(string email)
    {
        const string sql = "SELECT * FROM users WHERE email = @email";
        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@email", MySqlDbType.VarChar, 150).Value = email;
        con.Open();
        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            return new User
            {
                UserId = Convert.ToInt32(reader["user_id"]),
                Name = reader["name"].ToString() ?? "",
                Email = reader["email"].ToString() ?? "",
                PasswordHash = reader["password_hash"].ToString() ?? "",
                CreatedAt = Convert.ToDateTime(reader["created_at"])
            };
        }
        return null;
    }

    // FR-06: update name
    public void UpdateName(int userId, string newName)
    {
        const string sql = "UPDATE users SET name = @name WHERE user_id = @id";
        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@name", MySqlDbType.VarChar, 100).Value = newName;
        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = userId;
        con.Open();
        cmd.ExecuteNonQuery();
    }

    // FR-06: update password
    public void UpdatePassword(int userId, string newPasswordHash)
    {
        const string sql = "UPDATE users SET password_hash = @password_hash WHERE user_id = @id";
        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@password_hash", MySqlDbType.VarChar, 255).Value = newPasswordHash;
        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = userId;
        con.Open();
        cmd.ExecuteNonQuery();
    }
}