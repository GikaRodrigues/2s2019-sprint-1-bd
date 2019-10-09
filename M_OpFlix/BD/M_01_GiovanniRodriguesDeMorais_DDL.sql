Create Database M_OpFlix

Use M_OpFlix

Create Table Categorias
(
	IdCategoria Int Primary Key Identity
	,Categoria Varchar (250) Unique Not Null
);

Create Table Tipos
(
	IdTipo Int Primary Key Identity
	,Tipo Varchar (250) Unique Not Null
);

Create Table Usuarios
(
	IdUsuarios Int Primary Key Identity
	,Nome Varchar (250) Unique Not Null
	,CPF Int Unique Not Null
	,Email Varchar (250) Unique Not Null
	,Senha Varchar (250) Unique Not Null
	,DataCriacao Date Not Null
	,Permissao Varchar (250) Default ('Cliente')
);

Create Table Lancamentos
(
	IdLancamento Int Primary Key Identity
	,Titulo Varchar (250) Unique Not Null
	,Sinopse Text Not Null
	,IdCategoria Int Foreign Key References Categorias (IdCategoria)
	,TempoDeDuracao Time Unique Not Null
	,IdTipo Int Foreign Key References Tipos (IdTipo)
	,DataLancamento Date Not Null
);

Create Table Plataformas
(
	IdPlataforma Int Primary Key Identity
	,Plataforma Varchar (250) Unique Not Null
);

Create Table Favoritos
(
	IdFavorito Int Primary Key Identity
	,IdUsuario Int Foreign Key References Usuarios (IdUsuarios)
	,IdLacamentos Int Foreign Key References Lancamentos (IdLancamento)
);

Create Table PlataformaLancamentos
(
	IdPlataformaLancamentos Int Primary Key Identity
	,IdPlataforma Int Foreign Key References Plataformas (IdPlataforma)
	,IdLancamento Int Foreign Key References Lancamentos (IdLancamento)
);