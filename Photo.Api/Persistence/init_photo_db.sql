create table Photo (
	Id                        INT				NOT NULL IDENTITY,
	Location		 VARCHAR(100)	    NOT NULL,
	Country			VARCHAR(100)		NOT NULL,

	CONSTRAINT PK_Photo_Id PRIMARY KEY (Id),
)

INSERT INTO Photo (Location, Country)
VALUES ('Ha Long Bay', 'Vietnam'),
('Kandy', 'Sri Lanka'),
('Grand Canyon', 'USA');

create table PrintPrice (
	Id			INT NOT NULL IDENTITY,
	PhotoId				INT NOT NULL,
	Price		INT NOT NULL,

	CONSTRAINT PK_PrintPrice_Id PRIMARY KEY (Id),
	CONSTRAINT FK_PrintPrice_PhotoId_Photo_Id FOREIGN KEY (PhotoId) REFERENCES Photo(Id)
	)

INSERT INTO PrintPrice (PhotoId, Price)
VALUES (1, 325),
(2, 300),
(3, 350)

create table PaintingPrice (
	Id			INT NOT NULL IDENTITY,
	PhotoId				INT NOT NULL,
	BasePrice		INT NOT NULL,
	DurationInHour	INT NOT NULL,
	PricePerHour		INT NOT NULL,

	CONSTRAINT PK_PaintingPrice_Id PRIMARY KEY (Id),
	CONSTRAINT FK_PaintingPrice_PhotoId_Photo_Id FOREIGN KEY (PhotoId) REFERENCES Photo(Id)
	)
INSERT INTO PaintingPrice (PhotoId, BasePrice, DurationInHour, PricePerHour)
VALUES (1, 200, 4, 40),
(2, 210, 5, 35),
(3, 150, 3, 30)
