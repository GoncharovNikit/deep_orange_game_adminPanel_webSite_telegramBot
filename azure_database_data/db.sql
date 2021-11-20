USE game
GO

create table Users
(
	id int identity primary key,
	email nvarchar(50) not null,
	passw nvarchar(50) not null,

	constraint UK_User_Email UNIQUE(email),
	constraint CK_User_Email check(len(email) > 0),
	constraint CK_User_Passw check(len(passw) > 0)
)
GO

INSERT Users(score, email, passw) values
(default, 'test0@gmail.com', 'qwerty'),
(default, 'test1@gmail.com', 'qwerty'),
(default, 'test2@gmail.com', 'qwerty')
GO
select * from Users


create table Languages
(
	id int identity primary key,
	lang_code nchar(5) not null,
	lang_title nvarchar(50) not null,

	constraint CK_Lang_Code check(len(lang_code) > 0),
	constraint CK_Lang_Title check(len(lang_title) > 0)
)
GO

INSERT Languages(lang_code, lang_title) values
('en', 'English'),
('uk', 'Ukrainian'),
('ru', 'Russian')
GO
select * from Languages



create table WordSet
(
	id int identity primary key,
	creator_id int not null,
	lang_id int not null,
	title nvarchar(40) not null,

	constraint FK_Set_Creator foreign key(creator_id) references Users(id),
	constraint FK_Set_Lang foreign key(lang_id) references Languages(id),
	constraint CK_Set_Title check(len(title) > 0)
)
GO

INSERT WordSet(creator_id, lang_id, title) values
(1, 1, 'Great food'),
(2, 1, 'Green'),
(3, 2, 'Українські міста')
GO
select * from WordSet



create table Phrases
(
	id int identity primary key,
	wordSet_id int not null,
	[text] nvarchar(120) not null,

	constraint CK_Phrases_Expression check(len([text]) > 0),
	constraint FK_Phrase_WordSet foreign key(wordSet_id) references WordSet(id)
)
GO

INSERT Phrases(wordSet_id, [text]) values
(1, 'I want to eat a ___'),
(1, 'I want to make a ___'),
(1, 'I am ___ now'),
(2, 'There ___ a many ___ near my house'),
(2, 'These apples are ___ my ___')
GO
select * from Phrases


create table Options
(
	id int identity primary key,
	phrase_id int not null,
	[version] nvarchar(40) not null,
	is_right bit not null,

	constraint FK_Option_Phrase foreign key(phrase_id) references Phrases(id),
	constraint CK_Option_Version check(len([version]) > 0)
)
GO

INSERT Options(phrase_id, [version], is_right) values
(1, 'fishing', 0), (1, 'fish', 1), (1, 'finished', 0), (1, 'fished', 0),
(2, 'cake', 1), (2, 'ckake', 0), (2, 'cacked', 0), (2, 'caked', 0),
(3, 'grass', 0), (3, 'smoke', 0), (3, 'bottle', 0), (3, 'walking', 1),
(4, 'are | trees', 1), (4, 'you | go', 0), (4, 'is | TV', 0), (4, 'too | cakes', 0),
(5, 'about | look', 0), (5, 'from | tree', 1), (5, 'is | TV', 0), (5, 'too | cakes', 0)
GO
select * from Options;

create table Rating
(
	id int identity primary key,
	username nvarchar(70) not null,
	score int not null default 0,

	constraint CK_Rating_Username check(len(username) > 0)
)
GO

INSERT Rating(username, score) values
('ghost_writer', 14),
('dima_', 20),
('andrey', 54)
GO
select * from Rating