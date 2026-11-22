using System;
using StreakUp.Models;

namespace StreakUp.Controllers;

public class HabitLogController
{
    private readonly HabitLogRepository _logRepository;

    public HabitLogController(HabitLogRepository logRepository)
    {
        _logRepository = logRepository;
    }

    // FR-14, FR-16, FR-17, FR-18: mark done
    public void MarkDone(int habitId, DateTime logDate)
    {
        // FR-17: no future dates
        if (logDate.Date > DateTime.Today)
            throw new ArgumentException("Cannot mark a habit for a future date.");

        // FR-16: up to 7 days back
        if (logDate.Date < DateTime.Today.AddDays(-7))
            throw new ArgumentException("Cannot mark more than 7 days in the past.");

        _logRepository.MarkDone(habitId, logDate);
    }

    // FR-15: undo
    public void MarkUndone(int habitId, DateTime logDate)
    {
        if (logDate.Date > DateTime.Today)
            throw new ArgumentException("Cannot undo a future date.");

        _logRepository.MarkUndone(habitId, logDate);
    }

    // Check if done on a date
    public bool IsDoneOnDate(int habitId, DateTime logDate)
    {
        return _logRepository.IsDoneOnDate(habitId, logDate);
    }
}