--Drop Database bookstore;

CREATE DATABASE bookstore;

USE bookstore;

CREATE TABLE _Institution (
 _institution_id INT IDENTITY(1,1) PRIMARY KEY,
_institution_name VARCHAR(255) NOT NULL,
);

Create table GroupTable (
_user_group_id INT IDENTITY(1,1) PRIMARY KEY,
_Group_description VARCHAR(255)
);

CREATE TABLE _User (
_user_id INT IDENTITY(1,1) PRIMARY KEY,
_institution_id INT FOREIGN KEY REFERENCES _Institution(_institution_id), --FK Can be NULL for highest level Admin.
_first_name VARCHAR(255) NOT NULL,
_last_name VARCHAR(255) NOT NULL,
_email_address VARCHAR(255) NOT NULL UNIQUE,
_user_group_id INT FOREIGN KEY REFERENCES GroupTable(_user_group_id),
_estimated_year_of_graduation VARCHAR(5),
_hash VARCHAR(255) NOT NULL,
_salt VARCHAR(255) NOT NULL
);

Create table Action_Table(
_action_id INT IDENTITY(1,1) PRIMARY KEY,
_action_description VARCHAR(255)
);

Create table Group_Actions(
_group_actions_id INT IDENTITY(1,1) PRIMARY KEY,
_user_group_id INT FOREIGN KEY REFERENCES GroupTable(_user_group_id),
_action_id INT FOREIGN KEY REFERENCES Action_Table(_action_id),
);

CREATE TABLE _Course(
_course_id INT IDENTITY(1,1) PRIMARY KEY,
_institution_id INT NOT NULL FOREIGN KEY REFERENCES _Institution(_institution_id),
_course_semester INT NOT NULL,
_course_name VARCHAR(255) NOT NULL,
_course_description VARCHAR(255),
 CONSTRAINT UC_Course UNIQUE (_institution_id, _course_name, _course_semester)
);

CREATE TABLE _Book (
_book_id INT IDENTITY(1,1) PRIMARY KEY,
_book_title VARCHAR(255) NOT NULL,
_book_author VARCHAR(255) NOT NULL,
_book_edition INT NOT NULL,
_book_publisher VARCHAR(255) NOT NULL,
_book_isbn VARCHAR(255) NOT NULL UNIQUE,
CONSTRAINT UC_Book UNIQUE (_book_title, _book_author, _book_edition)
);

CREATE TABLE _Course_Materials(
_materials_id INT IDENTITY(1,1) PRIMARY KEY,
_course_id INT NOT NULL FOREIGN KEY REFERENCES _Course(_course_id),
_book_id INT NOT NULL FOREIGN KEY REFERENCES _Book(_book_id),
CONSTRAINT UC_Course_Materials UNIQUE (_course_id, _book_id)
);

CREATE TABLE _Post(
_post_id INT IDENTITY(1,1) PRIMARY KEY, --because PK it is NOT NULL and UNIQUE
_user_id INT NOT NULL FOREIGN KEY REFERENCES _User(_user_id), --foreign key
_book_id INT  NOT NULL FOREIGN KEY REFERENCES _Book(_book_id), --foreign key
_post_date DATETIME Not null,
_post_expire DATETIME NOT NULL,
_price float
);

CREATE TABLE _Course(
_course_id INT IDENTITY(1,1) PRIMARY KEY,
_institution_id INT NOT NULL FOREIGN KEY REFERENCES _Institution(_institution_id),
_course_semester INT NOT NULL,
_course_name VARCHAR(255) NOT NULL,
_course_description VARCHAR(255),
 CONSTRAINT UC_Course UNIQUE (_institution_id, _course_name, _course_semester)
);

INSERT INTO _Institution(_institution_name) VALUES ('Conestoga College'), ('Waterloo University'), ('Wilfred Laurier University');

INSERT INTO _Book (_book_title, _book_author, _book_edition, _book_isbn,_book_publisher)
VALUES
('Math Text 1000', 'F. Kafka', 1, 'ISBN 978-0-7334-2609-1','Hark'),
('Math Text 2000', 'D. Adams', 1, 'ISBN 978-0-7334-2609-2','Neilson'),
('Physics Text 1000', 'S. King', 3, 'ISBN 978-0-7334-2609-3','Pengu'),
('Physics Text 2000', 'J.k. Rowling', 2, 'ISBN 978-0-7334-2609-4','Penguin'),
('Chemistry Text 1000', 'J. Tolkien', 1, 'ISBN 978-0-7334-2609-5','Bonnier'),
('Chemistry Text 2000', 'J Austen', 4, 'ISBN 978-0-7334-2609-6','Harper Collins'),
('English Text 1000', 'W. Shakespeare', 3, 'ISBN 978-0-7334-2609-7','Little Brow'),
('English Text 2000', 'C. Dickens', 2, 'ISBN 978-0-7334-2609-8','Grey Sky'),
('C++ Text 1000', 'E. Brante', 1, 'ISBN 978-0-7334-2609-9','Walker Books'),
('C++ Text 2000', 'A. Senna', 4, 'ISBN 978-0-7334-2609-10','Ultra Books');

Insert into GroupTable(_Group_description)
values
('System admin'),
('Institution admin'),
('Student');

insert into Action_Table(_action_description)
values
('add/remove/update system admin'),
('add/remove/update institute admin'),
('add/remove/update student');

Insert into Group_Actions(_user_group_id,_action_id)
values
(1,1),
(1,2),
(1,3),
(2,3),
(1,3);

INSERT INTO _Course(_institution_id, _course_semester, _course_name, _course_description) 
VALUES 
(1, 1, 'C Programming', 'Introduction to Programming Principles'), 
(1, 2, 'N.A.D.', 'Network Application Development'), 
(1, 1, 'S.O.A.', 'Service Oriented Architecture'),
(1, 3, 'Business Intelligence', 'Exploring Big Data'),
(1, 1, 'User Interface Design', 'How to become metally stable'), 
(2, 2, 'Computer Security', 'Creeps Everywhere'), 
(2, 2, 'O.O.P.', 'Object Oriented Programming'),
(2, 1, 'Awakening The SPiral', 'Introduction to first Nations Culture'), 
(2, 2, 'Math-1001', 'intro to Math'),
(2, 3, 'M.A.D.', 'MObile app Development'),
(3, 2, 'Oceans', 'Marine Biology'), 
(3, 1, 'Intro to Astronomy', 'Exploring Space'),
(3, 3, 'Evil in Humanity', 'Exploring human empathy and contempt'), 
(3, 1, 'G.A.S.', 'Graphics Animation and Sound'),
(3, 2, 'World Religions', 'Intro to world Religions');

Insert INTO _Course_Materials(_course_id,_book_id)
Values
(1,1),(1,2),(1,3),(2,4),(3,5);

UPDATE _User
SET _user_group_id = 1
WHERE
_user_id = 5;

UPDATE _User
SET _institution_id = null
WHERE
_user_id = 5;

UPDATE _User
SET _user_group_id = 2
WHERE
_user_id = 6;

select * from _User;