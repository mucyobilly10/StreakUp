-- StreakUp: Personal Habit Tracker
-- Database script (MariaDB / XAMPP)  -- Mucyo Billy, 26853

CREATE DATABASE streakup_db CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE streakup_db;

CREATE TABLE users (
    user_id       INT NOT NULL AUTO_INCREMENT,
    name          VARCHAR(100) NOT NULL,
    email         VARCHAR(150) NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    created_at    DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (user_id),
    UNIQUE KEY uq_users_email (email)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE habits (
    habit_id      INT NOT NULL AUTO_INCREMENT,
    user_id       INT NOT NULL,
    name          VARCHAR(100) NOT NULL,
    description   VARCHAR(255) NULL,
    category      VARCHAR(50)  NULL,
    reminder_time TIME NULL,
    is_archived   TINYINT(1) NOT NULL DEFAULT 0,
    created_at    DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (habit_id),
    UNIQUE KEY uq_habits_user_name (user_id, name),
    CONSTRAINT fk_habits_user FOREIGN KEY (user_id)
        REFERENCES users (user_id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE habit_logs (
    log_id   INT NOT NULL AUTO_INCREMENT,
    habit_id INT NOT NULL,
    log_date DATE NOT NULL,
    is_done  TINYINT(1) NOT NULL DEFAULT 1,
    PRIMARY KEY (log_id),
    UNIQUE KEY uq_logs_habit_date (habit_id, log_date),
    CONSTRAINT fk_logs_habit FOREIGN KEY (habit_id)
        REFERENCES habits (habit_id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;