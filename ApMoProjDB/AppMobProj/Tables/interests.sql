﻿CREATE TABLE interests
(
	ID INT IDENTITY (1,1) PRIMARY KEY,
	name VARCHAR (255) NOT NULL,
	UNIQUE(name)
)
