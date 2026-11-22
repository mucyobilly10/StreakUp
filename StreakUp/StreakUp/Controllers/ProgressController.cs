using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using StreakUp.Models;

namespace StreakUp.Controllers;

public class ProgressController
{
    private readonly HabitLogRepository _logRepository;
    private readonly HabitRepository _habitRepository;

    public ProgressController(HabitLogRepository logRepository, HabitRepository habitRepository)
    {
        _logRepository = logRepository;
        _habitRepository = habitRepository;
    }

    public int GetCurrentStreak(int habitId)
    {
        ValidateHabitId(habitId);
        var completedDates = _logRepository.GetLogsByHabit(habitId)
            .Where(log => log.IsDone)
            .Select(log => log.LogDate.Date)
            .ToHashSet();

        DateTime checkDate = completedDates.Contains(DateTime.Today)
            ? DateTime.Today
            : DateTime.Today.AddDays(-1);
        int streak = 0;

        while (completedDates.Contains(checkDate))
        {
            streak++;
            checkDate = checkDate.AddDays(-1);
        }

        return streak;
    }

    public int GetLongestStreak(int habitId)
    {
        ValidateHabitId(habitId);
        var completedDates = _logRepository.GetLogsByHabit(habitId)
            .Where(log => log.IsDone)
            .Select(log => log.LogDate.Date)
            .Distinct()
            .OrderBy(date => date)
            .ToList();

        int longest = 0;
        int current = 0;
        DateTime? previousDate = null;

        foreach (DateTime date in completedDates)
        {
            current = previousDate.HasValue && date == previousDate.Value.AddDays(1)
                ? current + 1
                : 1;
            longest = Math.Max(longest, current);
            previousDate = date;
        }

        return longest;
    }

    public (int completedDays, int totalDays, double percentage) GetWeeklyProgress(int habitId)
    {
        DataTable weeklyDays = GetWeeklyProgressByDay(habitId);
        int completedDays = weeklyDays.Rows.Cast<DataRow>()
            .Count(row => row.Field<bool>("Completed"));
        int totalDays = weeklyDays.Rows.Cast<DataRow>()
            .Count(row => row.Field<bool>("CountsTowardProgress"));
        double percentage = totalDays == 0 ? 0 : completedDays * 100.0 / totalDays;
        return (completedDays, totalDays, percentage);
    }

    public List<HabitLog> GetHistory(int habitId)
    {
        ValidateHabitId(habitId);
        return _logRepository.GetLogsByHabit(habitId)
            .Where(log => log.IsDone)
            .OrderByDescending(log => log.LogDate.Date)
            .ToList();
    }

    public DataTable GetWeeklyProgressByDay(int habitId)
    {
        ValidateHabitId(habitId);
        Habit habit = _habitRepository.GetHabitById(habitId)
            ?? throw new KeyNotFoundException($"Habit {habitId} was not found.");

        DateTime today = DateTime.Today;
        DateTime monday = today.AddDays(-(((int)today.DayOfWeek + 6) % 7));
        DateTime sunday = monday.AddDays(6);
        DateTime observedEnd = today < sunday ? today : sunday;
        var logs = _logRepository.GetLogsByDateRange(habitId, monday, sunday)
            .Where(log => log.IsDone)
            .Select(log => log.LogDate.Date)
            .ToHashSet();

        var table = new DataTable();
        table.Columns.Add("Day", typeof(string));
        table.Columns.Add("Date", typeof(DateTime));
        table.Columns.Add("Status", typeof(string));
        table.Columns.Add("Completed", typeof(bool));
        table.Columns.Add("CountsTowardProgress", typeof(bool));

        for (int dayOffset = 0; dayOffset < 7; dayOffset++)
        {
            DateTime date = monday.AddDays(dayOffset);
            bool countsTowardProgress = date >= habit.CreatedAt.Date && date <= observedEnd;
            bool completed = countsTowardProgress && logs.Contains(date);
            string status = date < habit.CreatedAt.Date
                ? "Not started"
                : date > observedEnd
                    ? "Upcoming"
                    : completed ? "Completed" : "Not completed";

            table.Rows.Add(date.ToString("ddd"), date, status, completed, countsTowardProgress);
        }

        return table;
    }

    public double GetTodayCompletionPercentage(int userId)
    {
        var habits = _habitRepository.GetAllByUser(userId)
            .Where(habit => !habit.IsArchived)
            .ToList();

        if (habits.Count == 0)
        {
            return 0;
        }

        int doneCount = habits.Count(habit => _logRepository.IsDoneOnDate(habit.HabitId, DateTime.Today));
        return doneCount * 100.0 / habits.Count;
    }

    private static void ValidateHabitId(int habitId)
    {
        if (habitId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(habitId), "Habit ID must be positive.");
        }
    }
}