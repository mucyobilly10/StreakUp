using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using StreakUp.Models;

namespace StreakUp.Controllers;

public class HabitController
{
    private readonly HabitRepository _habitRepository;

    public HabitController(HabitRepository habitRepository)
    {
        _habitRepository = habitRepository;
    }

    // FR-07, FR-10: add habit
    public void AddHabit(int userId, string name, string? description, string? category, TimeSpan? reminderTime)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Habit name is required.");

        // FR-10: check duplicate name for this user
        if (_habitRepository.NameExists(userId, name.Trim()))
            throw new ArgumentException("You already have a habit with this name.");

        var habit = new Habit
        {
            UserId = userId,
            Name = name.Trim(),
            Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim(),
            Category = string.IsNullOrWhiteSpace(category) ? null : category.Trim(),
            ReminderTime = reminderTime,
            IsArchived = false
        };
        _habitRepository.Insert(habit);
    }

    // FR-08: edit habit
    public void EditHabit(Habit habit)
    {
        if (habit.HabitId <= 0 || habit.UserId <= 0)
            throw new ArgumentException("Invalid habit.");
        if (string.IsNullOrWhiteSpace(habit.Name))
            throw new ArgumentException("Habit name is required.");

        _habitRepository.Update(habit);
    }

    // FR-09: delete habit
    public void DeleteHabit(int userId, int habitId)
    {
        if (userId <= 0 || habitId <= 0)
            throw new ArgumentException("Invalid habit.");
        _habitRepository.Delete(userId, habitId);
    }

    // FR-11: archive/restore
    public void ArchiveHabit(int userId, int habitId, bool archive)
    {
        if (userId <= 0 || habitId <= 0)
            throw new ArgumentException("Invalid habit.");
        _habitRepository.SetArchived(userId, habitId, archive);
    }

    // FR-12: get all habits for user
    public List<Habit> GetUserHabits(int userId)
    {
        return _habitRepository.GetAllByUser(userId);
    }

    // FR-25: search active habits by name
    public List<Habit> SearchHabits(int userId, string keyword)
    {
        return _habitRepository.SearchHabits(userId, keyword);
    }

    // FR-26: filter active or archived habits
    public List<Habit> FilterByStatus(int userId, bool? isArchived)
    {
        return isArchived == true
            ? _habitRepository.GetArchivedHabits(userId)
            : _habitRepository.GetAllByUser(userId);
    }

    // FR-13: Get today's dashboard data (NEW METHOD)
    public DataTable GetTodayDashboard(int userId)
    {
        return _habitRepository.GetTodayDashboard(userId);
    }
}