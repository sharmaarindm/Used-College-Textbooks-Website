Use bookstore;
GO

CREATE PROCEDURE BrowseTextbooksbyTitle
	@param varchar(50)
AS	
	SELECT b._book_title, b._book_author,p._post_expire,p._post_id
	FROM _Book b
	INNER JOIN _Post p ON b._book_id = p._book_id
	WHERE b._book_title = @param
GO

CREATE PROCEDURE BrowseTxtbooksbyTitleAndInstitution
	@book_title varchar(50),
	@institute varchar(50)
AS
BEGIN
	DECLARE @instituteID int
	DECLARE @bookID int

	SELECT @instituteID = _Institution._institution_id FROM _Institution
	WHERE _Institution._institution_name = @institute

	SELECT @bookID = _Book._book_id FROM _Book
	WHERE _Book._book_title = @book_title

	SELECT b._book_title, b._book_author,p._post_expire,p._post_id
	FROM _Book b 
	INNER JOIN _Post p ON b._book_id = p._book_id
	INNER JOIN _User u ON u._user_id = p._user_id
	INNER JOIN _Institution i ON i._institution_id = u._institution_id
	WHERE b._book_title = @book_title AND i._institution_id = @instituteID
END
GO

CREATE PROCEDURE BrowseTextbooksbyAuthor
	@param varchar(50)
AS	
	SELECT b._book_title, b._book_author,p._post_expire, p._post_id
	FROM _Book b
	INNER JOIN _Post p ON b._book_id = p._book_id
	WHERE b._book_author = @param
GO

CREATE PROCEDURE BrowseTxtbooksbyAuthorAndInstitution
	@author varchar(50),
	@institute varchar(50)
AS
BEGIN
	DECLARE @instituteID int
	DECLARE @bookID int

	SELECT @instituteID = _Institution._institution_id FROM _Institution
	WHERE _Institution._institution_name = @institute

	SELECT @bookID = _Book._book_id FROM _Book
	WHERE _Book._book_author = @author

	SELECT b._book_title, b._book_author,p._post_expire,p._post_id
	FROM _Book b 
	INNER JOIN _Post p ON b._book_id = p._book_id
	INNER JOIN _User u ON u._user_id = p._user_id
	INNER JOIN _Institution i ON i._institution_id = u._institution_id
	WHERE b._book_author = @author AND i._institution_id = @instituteID
END
GO

CREATE PROCEDURE BrowseTextbooksbyISBN
	@param varchar(50)
AS	
	SELECT b._book_title, b._book_author,p._post_expire, p._post_id
	FROM _Book b
	INNER JOIN _Post p ON b._book_id = p._book_id
	WHERE b._book_isbn = @param
GO

CREATE PROCEDURE BrowseTxtbooksbyISBNAndInstitution
	@ISBN varchar(50),
	@institute varchar(50)
AS
BEGIN
	DECLARE @instituteID int
	DECLARE @bookID int

	SELECT @instituteID = _Institution._institution_id FROM _Institution
	WHERE _Institution._institution_name = @institute

	SELECT @bookID = _Book._book_id FROM _Book
	WHERE _Book._book_isbn = @ISBN

	SELECT b._book_title, b._book_author,p._post_expire,p._post_id
	FROM _Book b 
	INNER JOIN _Post p ON b._book_id = p._book_id
	INNER JOIN _User u ON u._user_id = p._user_id
	INNER JOIN _Institution i ON i._institution_id = u._institution_id
	WHERE b._book_isbn = @ISBN AND i._institution_id = @instituteID
END
GO

CREATE PROCEDURE getpostbypostid
	@param int
AS 
	SELECT u._first_name,u._last_name,p._price,b._book_title,b._book_author,b._book_isbn,b._book_edition,b._book_publisher,u._email_address
	FROM _Post p
	INNER JOIN _User u ON p._user_id = u._user_id
	INNER JOIN _Book b ON p._book_id = b._book_id
	WHERE p._post_id = @param
go

CREATE PROCEDURE getuserbyuserName
	@param VARCHAR(255)
AS 
	SELECT u._hash,u._salt,u._first_name,u._last_name,u._estimated_year_of_graduation,u._user_group_id,u._user_id
	FROM _User u
	WHERE u._email_address = @param
go

CREATE PROCEDURE CreatePosting
	@bookTitle VARCHAR(255),
	@bookAuthor VARCHAR(255),
	@bookISBN VARCHAR(255),
	@bookEdition INT,
	@bookPublisher VARCHAR(255),
	@price FLOAT,
	@postExpire Datetime,
	@UserID int,
	@postdate Datetime
AS	
Begin
DECLARE @bID int
if not exists (Select _book_id from _Book where _book_isbn = @bookISBN)
    Begin
           INSERT INTO _Book(_book_title, _book_author, _book_edition, _book_publisher,_book_isbn)
			VALUES (@bookTitle, @bookAuthor, @bookEdition, @bookPublisher,@bookISBN); 

			Select @bID = _book_id from _Book where _book_isbn = @bookISBN

			INSERT INTO _Post(_user_id, _book_id, _post_expire, _price,_post_date)
			VALUES (@UserID, @bID, @postExpire, @price, @postdate); 
    End
Else
    Begin
	      Select @bID = _book_id from _Book where _book_isbn = @bookISBN

		  INSERT INTO _Post(_user_id, _book_id, _post_expire, _price,_post_date)
			VALUES (@UserID, @bID, @postExpire, @price, @postdate); 
    End   
End
GO


CREATE PROCEDURE CreateStudentUser
	@UserName VARCHAR(255),
	@hashpass VARCHAR(255),
	@fname VARCHAR(255),
	@lname VARCHAR(255),
	@institute VARCHAR(255),
	@yearOfGraduation VARCHAR(5),
	@salt VARCHAR(255)

AS	
Begin
DECLARE @instID int
if not exists (Select * from _User where _email_address = @UserName) --if does not exist then create the user
    Begin
			if exists (Select * from _Institution where _institution_name = @institute)
			BEGIN
				Select @instID = _institution_id from _Institution where _institution_name = @institute;

				INSERT INTO _User(_institution_id, _first_name, _last_name,_email_address,_user_group_id,_estimated_year_of_graduation,_hash,_salt)
				VALUES (@instID,@fname,@lname,@UserName,3,@yearOfGraduation,@hashpass,@salt); 
			END
			ELSE
			BEGIN
			    return -2; -- institute doesnt exist.
			END

			
    End
Else -- if already exist return error code.
    Begin
	      return -1;
    End   
End
GO

CREATE PROCEDURE ViewPostByUserID
	@param int
AS	
	SELECT p._post_id, b._book_title,p._post_expire
	FROM _Post p
	INNER JOIN _Book b ON b._book_id = p._book_id
	WHERE p._user_id = @param
GO

CREATE PROCEDURE ViewPostByPostID
	@param int
AS	
	SELECT u._first_name,u._last_name,p._price,b._book_title,b._book_author,b._book_isbn,b._book_edition,b._book_publisher
	FROM _Post p
	INNER JOIN _Book b ON b._book_id = p._book_id
	INNER JOIN _User u ON u._user_id = p._user_id
	WHERE p._post_id = @param
GO

CREATE PROCEDURE GetInstitutes
	
AS	
	SELECT _institution_name from _Institution;
GO


CREATE PROCEDURE AddInstitute
	@param VARCHAR(255)

AS	
Begin
if not exists (Select * from _Institution where _institution_name = @param) --if does not exist then create the user
    Begin

		INSERT INTO _Institution(_institution_name)
		VALUES (@param); 
		
    End
Else -- if already exist return error code.
    Begin
	      return -1;
    End   
End
GO

CREATE PROCEDURE EditInstitute
	@oldValue VARCHAR(255),
	@newValue VARCHAR(255)

AS	
Begin
UPDATE 
		_Institution
	SET 
		_institution_name = @newValue
	WHERE
		_institution_name = @oldValue  
End
GO

CREATE PROCEDURE DeleteInstitute
	@InstituteName VARCHAR(255)
AS	
Begin
	DELETE FROM _Institution
		WHERE _institution_name = @InstituteName 
End
GO

CREATE PROCEDURE AddInstituteAdmin
	@institution_Name VARCHAR(255),
	@first_name VARCHAR(255),
	@last_name VARCHAR(255),
	@Username VARCHAR(255),
	@password VARCHAR(255),
	@salt VARCHAR(255)

AS	
Begin
	DECLARE @instID int
	if exists (Select * from _Institution where _institution_name = @institution_Name) --if does not exist then create the user
    Begin
		if not exists (Select * from _User where _email_address = @Username) --if does not exist then create the user
		Begin
			Select @instID = _institution_id from _Institution where _institution_name = @institution_Name;
			INSERT INTO _User(_first_name,_last_name,_email_address,_hash,_institution_id,_user_group_id,_salt)
			VALUES
			(@first_name,@last_name,@Username,@password,@instID,2,@salt);
		END
		ELSE
		BEGIN
			return -1 -- user already exists
		END
	END
	ELSE
	BEGIN
		return -2 -- college doesnt exist
	END
End
GO

CREATE PROCEDURE DeleteInstituteAdmin
	@Username VARCHAR(255)
AS	
Begin
	DELETE FROM _User
		WHERE _email_address = @Username 
End
GO


CREATE PROCEDURE UpdateInstituteAdmin
	@institution_Name VARCHAR(255),
	@first_name VARCHAR(255),
	@last_name VARCHAR(255),
	@Username VARCHAR(255),
	@password VARCHAR(255),
	@salt VARCHAR(255)
AS	
Begin
  DECLARE @instID int
	if exists (Select * from _Institution where _institution_name = @institution_Name) --if does not exist then create the user
    Begin
	Select @instID = _institution_id from _Institution where _institution_name = @institution_Name
		UPDATE
			_User
		SET 
			_first_name = @first_name,
			_last_name =@last_name,
			_hash = @password,
			_institution_id = @instID,
			_salt =@salt
		WHERE
			_email_address = @Username  
	END
End
GO

 CREATE PROCEDURE getInstituteAdmin
AS
BEGIN 
	SELECT _email_address,_first_name,_last_name,_institution_id from _User where _user_group_id = 2
END
GO
drop procedure UpdatePosting;
CREATE PROCEDURE UpdatePosting
	@bookTitle VARCHAR(255),
	@bookAuthor VARCHAR(255),
	@bookISBN VARCHAR(255),
	@bookEdition INT,
	@bookPublisher VARCHAR(255),
	@price FLOAT,
	@postID int
AS	
Begin
DECLARE @bID int
if not exists (Select _book_id from _Book where _book_isbn = @bookISBN)
    Begin
           INSERT INTO _Book(_book_title, _book_author, _book_edition, _book_publisher,_book_isbn)
			VALUES (@bookTitle, @bookAuthor, @bookEdition, @bookPublisher,@bookISBN); 

			Select @bID = _book_id from _Book where _book_isbn = @bookISBN

				UPDATE 
				_Post
			SET 
				_price = @price,
				_book_id = @bID
		

			WHERE
				_post_id = @postID  
    End
Else
    Begin
	Select @bID = _book_id from _Book where _book_isbn = @bookISBN
	UPDATE 
				_Book
			SET 
				_book_title = @bookTitle,
				_book_isbn = @bookISBN,
				_book_author = @bookAuthor,
				_book_edition = @bookEdition,
				_book_publisher = @bookPublisher

			WHERE	
				_book_id = @bID 
		UPDATE 
		_Post
	SET 
				_price = @price
				
	WHERE
		_post_id = @postID  
    End   
End
GO

CREATE PROCEDURE DeletePostByPostID
	@param int
AS	
Begin
	DELETE FROM _Post
		WHERE _post_id = @param 
End
GO

CREATE PROCEDURE GetBooksByCourseName
@param varchar(255)
AS
BEGIN
	SELECT cm._course_id, b._book_title, b._book_id
	FROM _Book b
	INNER JOIN _Course_Materials cm ON cm._book_id = b._book_id
	INNER JOIN _Course c ON c._course_id = cm._course_id
	WHERE c._course_name = @param
END
GO

CREATE PROCEDURE GetCourseIDByCourseName
@param varchar(255)
AS
BEGIN
	SELECT _course_id
	FROM _Course
	WHERE _course_name = @param
END
GO


CREATE PROCEDURE GetCoursesByInstitutionID
@param int
AS	
	Begin
		SELECT _course_name
		FROM _Course
		WHERE _institution_id = @param;
	End
GO

CREATE PROCEDURE GetAllBooks
AS
BEGIN
	SELECT _book_id,_book_title,_book_author, _book_edition,_book_isbn
	FROM _Book
END
GO

CREATE PROCEDURE GetInstitutionByUserID
@param int
AS
BEGIN
	SELECT i._institution_name
	FROM _Institution i
	INNER JOIN _User u ON u._institution_id = i._institution_id
	WHERE u._user_id = @param;
END
GO

CREATE PROCEDURE AddBookToCourseMaterials
	@param1 int,
	@param2 int
AS
BEGIN
	INSERT INTO _Course_Materials(_course_id,_book_id)
	VALUES (@param1, @param2); 		
END
GO

CREATE PROCEDURE DeleteBookFromCourseMaterials
	@param1 int,
	@param2 int
AS
BEGIN
	DELETE  
	FROM _Course_Materials
	WHERE _book_id = @param2 AND _course_id = @param1;
END
GO

CREATE PROCEDURE getUIDfromEmail
	@param Varchar(255)
AS	
Begin
	select _user_id from _User where _email_address = @param
End
GO

CREATE PROCEDURE checkifUserExists
	@param Varchar(255)
AS	
Begin
 select _email_address from _User where _email_address = @param
	
End
GO


CREATE PROCEDURE editSaltHash
	@hash Varchar(255),
	@salt Varchar(255),
	@email Varchar(255)
AS	
Begin
	UPDATE 
	_User
	SET 
		_hash = @hash,
		_salt = @salt
	WHERE
		_email_address = @email;
End
GO

CREATE PROCEDURE GetCourseIDsByBookTitle
	@book_title varchar(255)
AS
Begin
DECLARE @bID int
Select @bID = _book_id from _book where _book_title = @book_title
Select _course_id from _Course_Materials where _book_id = @bID
end
GO


CREATE PROCEDURE GetCourseDescriptionByCourseID
	@course_id int
AS
Begin
Select  _course_name,_course_description from _Course where _course_id = @course_id
end
GO

CREATE PROCEDURE GetAllCourse
	@institution_id int
AS
Begin
Select * From _Course WHERE _institution_id = @institution_id;
end
GO

CREATE PROCEDURE CreateCourse
	@institution_id int,
	@course_semester int,
	@course_name varchar(255),
	@course_description varchar(255)
AS
	INSERT INTO _Course(_institution_id, _course_semester, _course_name, _course_description)
	VALUES (@institution_id, @course_semester, @course_name, @course_description);
GO



GO
CREATE PROCEDURE DeleteCourse
@course_id int
AS
BEGIN
	DELETE FROM _Course 
	WHERE _course_id = @course_id;
END
GO

CREATE PROCEDURE EditCourse
@course_id int,
@institution_id int,
@course_semester int,
@course_name VARCHAR(255),
@course_description VARCHAR(255)
AS
UPDATE
	_Course
	SET
		_institution_id = @institution_id,
		_course_semester= @course_semester,
		_course_name = @course_name,
		_course_description = @course_description
	WHERE
		_course_id = @course_id;
GO

CREATE PROCEDURE GetInstituteIDByUserID
@userID int
AS
SELECT _institution_id FROM _User WHERE _user_id = @userID
GO

