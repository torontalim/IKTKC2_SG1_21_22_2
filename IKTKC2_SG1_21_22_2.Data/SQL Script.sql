CREATE TABLE Players
(
  PlayerId INT PRIMARY KEY IDENTITY (1,1),
  [Name] NVARCHAR(200) NOT NULL,
  Email NVARCHAR(255) NOT NULL,
  PhoneNumber NVARCHAR(50),
  DateOfBirth DATE,
  Active BIT
);

INSERT INTO Players ([Name], Email, PhoneNumber, DateOfBirth, Active) VALUES ('Apró Elek', 'aproelek@gmail.com', '06-1-234-5678', '1992.03.04', 1);
INSERT INTO Players ([Name], Email, PhoneNumber, DateOfBirth, Active) VALUES ('Kicsi Elek', 'kicsielek@gmail.com', '06-1-345-6789', '1993.04.05', 1);
INSERT INTO Players ([Name], Email, PhoneNumber, DateOfBirth, Active) VALUES ('Közepes Elek', 'kozepeselek@gmail.com', '06-1-456-7899', '1994.05.06', 0);
INSERT INTO Players ([Name], Email, PhoneNumber, DateOfBirth, Active) VALUES ('Nagy Elek', 'nagyelek@gmail.com', '06-1-567-8999', '1995.06.07', 0);
INSERT INTO Players ([Name], Email, PhoneNumber, DateOfBirth, Active) VALUES ('Óriás Elek', 'oriaselek@gmail.com', '06-1-678-9999', '1996.07.08', 1);
INSERT INTO Players ([Name], Email, PhoneNumber, DateOfBirth, Active) VALUES ('Gigantikus Elek', 'gigantikuselek@gmail.com', '06-1-789-9999', '1997.08.09', 1);
