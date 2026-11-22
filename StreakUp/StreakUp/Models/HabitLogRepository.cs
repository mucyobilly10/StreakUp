using System;
using System.Collections.Generic;
using MySqlConnector;
using StreakUp.Models;

namespace StreakUp.Models;

public class HabitLogRepository
{
    private readonly string _connectionString;

    public HabitLogRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    // FR-14/16: mark habit done for a date (insert if not exists)
    public void MarkDone(int habitId, DateTime logDate)
    {
        const string sql = @"INSERT INTO habit_logs (habit_id, log_date, is_done) 
                             VALUES (@habitId, @logDate, 1)
                             ON DUPLICATE KEY UPDATE is_done = 1";
        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@habitId", MySqlDbType.Int32).Value = habitId;
        cmd.Parameters.Add("@logDate", MySqlDbType.Date).Value = logDate.Date;
        con.Open();
        cmd.ExecuteNonQuery();
    }

    // FR-15: undo (set is_done = 0)
    public void MarkUndone(int habitId, DateTime logDate)
    {
        const string sql = @"INSERT INTO habit_logs (habit_id, log_date, is_done) 
                             VALUES (@habitId, @logDate, 0)
                             ON DUPLICATE KEY UPDATE is_done = 0";
        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@habitId", MySqlDbType.Int32).Value = habitId;
        cmd.Parameters.Add("@logDate", MySqlDbType.Date).Value = logDate.Date;
        con.Open();
        cmd.ExecuteNonQuery();
    }

    // Check if a habit is done on a specific date
    public bool IsDoneOnDate(int habitId, DateTime logDate)
    {
        const string sql = "SELECT is_done FROM habit_logs WHERE habit_id = @habitId AND log_date = @logDate";
        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@habitId", MySqlDbType.Int32).Value = habitId;
        cmd.Parameters.Add("@logDate", MySqlDbType.Date).Value = logDate.Date;
        con.Open();
        var result = cmd.ExecuteScalar();
        return result != null && Convert.ToBoolean(result);
    }

    // FR-19/20: get all logs for a habit (for streak calculation)
    public List<HabitLog> GetLogsByHabit(int habitId)
    {
        const string sql = "SELECT * FROM habit_logs WHERE habit_id = @habitId ORDER BY log_date DESC";
        var logs = new List<HabitLog>();
        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@habitId", MySqlDbType.Int32).Value = habitId;
        con.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            logs.Add(new HabitLog
            {
                LogId = Convert.ToInt32(reader["log_id"]),
                HabitId = Convert.ToInt32(reader["habit_id"]),
                LogDate = Convert.ToDateTime(reader["log_date"]).Date,
                IsDone = Convert.ToBoolean(reader["is_done"])
            });
        }
        return logs;
    }

    // FR-22: get logs for a date range (for weekly progress)
    public List<HabitLog> GetLogsByDateRange(int habitId, DateTime startDate, DateTime endDate)
    {
        const string sql = "SELECT * FROM habit_logs WHERE habit_id = @habitId AND log_date BETWEEN @start AND @end";
        var logs = new List<HabitLog>();
        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@habitId", MySqlDbType.Int32).Value = habitId;
        cmd.Parameters.Add("@start", MySqlDbType.Date).Value = startDate.Date;
        cmd.Parameters.Add("@end", MySqlDbType.Date).Value = endDate.Date;
        con.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            logs.Add(new HabitLog
            {
                LogId = Convert.ToInt32(reader["log_id"]),
                HabitId = Convert.ToInt32(reader["habit_id"]),
                LogDate = Convert.ToDateTime(reader["log_date"]).Date,
                IsDone = Convert.ToBoolean(reader["is_done"])
            });
        }
        return logs;
    }
}