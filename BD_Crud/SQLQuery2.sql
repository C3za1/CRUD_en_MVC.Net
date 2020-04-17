CREATE DATABASE Crud

use Crud

CREATE TABLE [dbo].[tabla]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[correo] [varchar](50) NOT NULL,
	[fecha_nacimiento] [datetime] NOT NULL,
 CONSTRAINT [PK_tabla] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
ON [PRIMARY]

GO

insert into tabla values ('Cesar','C3za1.97@gmail.com',170397);
insert into tabla values ('Alan','C3za1.97@gmail.com',170397);

select*from tabla