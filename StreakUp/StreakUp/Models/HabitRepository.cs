using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using StreakUp.Models;

namespace StreakUp.Models;

public class HabitRepository
{
    private readonly string _connectionString;

    public HabitRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    // FR-12: get all active habits for a user
    public List<Habit> GetAllByUser(int userId)
    {
        const string sql = "SELECT * FROM habits WHERE user_id = @userId AND is_archived = 0 ORDER BY created_at DESC";
        var habits = new List<Habit>();
        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@userId", MySqlDbType.Int32).Value = userId;
        con.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            habits.Add(ReadHabit(reader));
        }
        return habits;
    }

    public Habit? GetHabitById(int habitId)
    {
        const string sql = "SELECT * FROM habits WHERE habit_id = @habitId LIMIT 1";
        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@habitId", MySqlDbType.Int32).Value = habitId;
        con.Open();
        using var reader = cmd.ExecuteReader();
        return reader.Read() ? ReadHabit(reader) : null;
    }

    public List<Habit> SearchHabits(int userId, string keyword)
    {
        const string sql = @"SELECT * FROM habits
                             WHERE user_id = @userId AND is_archived = 0
                               AND name LIKE @keyword
                             ORDER BY created_at DESC";
        var habits = new List<Habit>();
        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@userId", MySqlDbType.Int32).Value = userId;
        cmd.Parameters.Add("@keyword", MySqlDbType.VarChar, 100).Value = $"%{keyword.Trim()}%";
        con.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            habits.Add(ReadHabit(reader));
        }
        return habits;
    }

    public List<Habit> GetArchivedHabits(int userId)
    {
        const string sql = "SELECT * FROM habits WHERE user_id = @userId AND is_archived = 1 ORDER BY created_at DESC";
        var habits = new List<Habit>();
        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@userId", MySqlDbType.Int32).Value = userId;
        con.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            habits.Add(ReadHabit(reader));
        }
        return habits;
    }

    // FR-10: check if habit name already exists for this user
    public bool NameExists(int userId, string habitName)
    {
        const string sql = "SELECT COUNT(*) FROM habits WHERE user_id = @userId AND name = @name";
        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@userId", MySqlDbType.Int32).Value = userId;
        cmd.Parameters.Add("@name", MySqlDbType.VarChar, 100).Value = habitName;
        con.Open();
        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
    }

    // FR-07: add a new habit
    public void Insert(Habit habit)
    {
        const string sql = @"INSERT INTO habits (user_id, name, description, category, reminder_time) 
                             VALUES (@userId, @name, @description, @category, @reminderTime)";
        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@userId", MySqlDbType.Int32).Value = habit.UserId;
        cmd.Parameters.Add("@name", MySqlDbType.VarChar, 100).Value = habit.Name;
        cmd.Parameters.Add("@description", MySqlDbType.VarChar, 255).Value = (object?)habit.Description ?? DBNull.Value;
        cmd.Parameters.Add("@category", MySqlDbType.VarChar, 50).Value = (object?)habit.Category ?? DBNull.Value;
        cmd.Parameters.Add("@reminderTime", MySqlDbType.Time).Value = (object?)habit.ReminderTime ?? DBNull.Value;
        con.Open();
        cmd.ExecuteNonQuery();
    }

    // FR-08: edit habit details
    public void Update(Habit habit)
    {
        const string sql = @"UPDATE habits SET name = @name, description = @description, 
                             category = @category, reminder_time = @reminderTime 
                             WHERE habit_id = @id AND user_id = @userId";
        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@name", MySqlDbType.VarChar, 100).Value = habit.Name;
        cmd.Parameters.Add("@description", MySqlDbType.VarChar, 255).Value = (object?)habit.Description ?? DBNull.Value;
        cmd.Parameters.Add("@category", MySqlDbType.VarChar, 50).Value = (object?)habit.Category ?? DBNull.Value;
        cmd.Parameters.Add("@reminderTime", MySqlDbType.Time).Value = (object?)habit.ReminderTime ?? DBNull.Value;
        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = habit.HabitId;
        cmd.Parameters.Add("@userId", MySqlDbType.Int32).Value = habit.UserId;
        con.Open();
        cmd.ExecuteNonQuery();
    }

    // FR-09: delete habit (cascade deletes logs automatically)
    public void Delete(int userId, int habitId)
    {
        const string sql = "DELETE FROM habits WHERE habit_id = @id AND user_id = @userId";
        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = habitId;
        cmd.Parameters.Add("@userId", MySqlDbType.Int32).Value = userId;
        con.Open();
        cmd.ExecuteNonQuery();
    }

    // FR-11: archive or restore
    public void SetArchived(int userId, int habitId, bool isArchived)
    {
        const string sql = "UPDATE habits SET is_archived = @archived WHERE habit_id = @id AND user_id = @userId";
        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@archived", MySqlDbType.Int16).Value = isArchived ? 1 : 0;
        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = habitId;
        cmd.Parameters.Add("@userId", MySqlDbType.Int32).Value = userId;
        con.Open();
        cmd.ExecuteNonQuery();
    }

    // FR-13: Get today's dashboard data (NEW METHOD)
    public DataTable GetTodayDashboard(int userId)
    {
        const string sql = @"SELECT h.habit_id AS HabitId, h.name AS HabitName, h.description AS Description,
                            h.category AS Category, h.reminder_time AS ReminderTime, h.is_archived AS IsArchived,
                            CASE WHEN h.is_archived = 1 THEN 'Archived'
                                 WHEN hl.is_done = 1 THEN 'Done'
                                 ELSE 'Not Done' END AS Status
                            FROM habits h 
                            LEFT JOIN habit_logs hl ON h.habit_id = hl.habit_id AND hl.log_date = CURDATE() 
                            WHERE h.user_id = @userId
                            ORDER BY h.is_archived ASC, h.created_at DESC";

        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@userId", MySqlDbType.Int32).Value = userId;
        con.Open();
        using var reader = cmd.ExecuteReader();
        var table = new DataTable();
        table.Load(reader);
        return table;
    }

    // Helper: read one Habit from the reader
    private Habit ReadHabit(MySqlDataReader reader)
    {
        return new Habit
        {
            HabitId = Convert.ToInt32(reader["habit_id"]),
            UserId = Convert.ToInt32(reader["user_id"]),
            Name = reader["name"].ToString() ?? "",
            Description = reader["description"] == DBNull.Value ? null : reader["description"].ToString(),
            Category = reader["category"] == DBNull.Value ? null : reader["category"].ToString(),
            ReminderTime = reader["reminder_time"] == DBNull.Value ? null : (TimeSpan?)reader["reminder_time"],
            IsArchived = Convert.ToBoolean(reader["is_archived"]),
            CreatedAt = Convert.ToDateTime(reader["created_at"])
        };
    }
}