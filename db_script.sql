CREATE DATABASE Taina
go

USE Taina
GO

-----------------

CREATE TABLE [dbo].[Person](
	[PersonId] [bigint] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](30) NOT NULL,
	[Surname] [nvarchar](40) NOT NULL,
	[Gender] [nvarchar](6) NOT NULL,
	[EmailAddress] [nvarchar](200) NOT NULL,
	[PhoneNumber] [nvarchar](30) NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-----------------

CREATE PROCEDURE dbo.UpdatePerson 
	@PersonId bigint,
	@Firstname nvarchar(30),
	@Surname nvarchar(40),
	@Gender nvarchar(6),
	@EmailAddress nvarchar(200),
	@PhoneNumber nvarchar(30)
AS
BEGIN

	update dbo.Person
	set	   Firstname = @Firstname,
		   Surname = @Surname,
		   Gender = @Gender,
		   EmailAddress = @EmailAddress,
		   PhoneNumber = isnull(@PhoneNumber, PhoneNumber)
	where  PersonId = @PersonId
END
GO

-----------------

CREATE PROCEDURE [dbo].[GetPeople]
AS
BEGIN
	SELECT PersonId,
		   Firstname,
		   Surname,
		   Gender,
		   EmailAddress,
		   PhoneNumber
	FROM   dbo.Person
END
GO

-----------------

CREATE PROCEDURE [dbo].[InsertPerson] 
	@Firstname nvarchar(30),
	@Surname nvarchar(40),
	@Gender nvarchar(6),
	@EmailAddress nvarchar(200),
	@PhoneNumber nvarchar(30)
AS
BEGIN
	insert into dbo.Person (Firstname, Surname, Gender, EmailAddress, PhoneNumber)
	values (@Firstname, @Surname, @Gender, @EmailAddress, @PhoneNumber);
END
GO

-----------------

insert into dbo.Person (Firstname, Surname, Gender, EmailAddress, PhoneNumber)
values ('Leonard', 'Hofstadter', 'Male', 'leinardhof@gmail.com', '+1-541-754-3010'),
	   ('Sheldon', 'Cooper', 'Male', 'sheldoncooper@gmail.com', '+1-541-754-3011'),
	   ('Howard', 'Wolowitz', 'Male', 'howardwol@gmail.com', '+1-541-754-3012'),
	   ('Amy Farrah', 'Fowler', 'Female', 'amyff@gmail.com', '+1-541-754-3013'),
	   ('Bernadette', 'Rostenkowsk', 'Female', 'bernadetter@gmail.com', '+1-541-754-3014'),
	   ('Sherlock', 'Holmes', 'Male', 'sherlockholmes@gmail.com', '+44 12 3456 7890'),
	   ('John', 'Watson', 'Male', 'johnwatson@gmail.com', '+44 12 3456 7891')