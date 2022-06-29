--
-- 由SQLiteStudio v3.3.3 产生的文件 周四 3月 24 21:51:57 2022
--
-- 文本编码：System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- 表：Students
CREATE TABLE Students (Id INT (10) UNIQUE NOT NULL DEFAULT (1) PRIMARY KEY, Name STRING NOT NULL, Age INT (100) NOT NULL) WITHOUT ROWID;
INSERT INTO Students (Id, Name, Age) VALUES (1, 'Tim', 29);
INSERT INTO Students (Id, Name, Age) VALUES (2, 'Tom', 28);
INSERT INTO Students (Id, Name, Age) VALUES (3, 'Tony', 27);
INSERT INTO Students (Id, Name, Age) VALUES (4, 'Kyle', 26);
INSERT INTO Students (Id, Name, Age) VALUES (5, 'Vina', 25);
INSERT INTO Students (Id, Name, Age) VALUES (6, 'Emily', 24);

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
