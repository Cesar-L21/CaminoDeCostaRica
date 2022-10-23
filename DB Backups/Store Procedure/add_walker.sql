use [CaminoCR]

CREATE PROCEDURE Add_Walker
	@id int,
	@firstName varchar(50),
	@lastName varchar(50),
	@email varchar(50),
	@phone int,
	@password varchar(50),
	@result varchar(10) OUTPUT

AS
BEGIN
	insert into [user] 
	values (@id, @firstName, @lastName, @email, @phone, 0, ENCRYPTBYPASSPHRASE('12345', @password))

	--- Query for check new walker
	if exists (select @id from [user] where id = @id)
	select @result = 'true' else select @result = 'false' return
END
