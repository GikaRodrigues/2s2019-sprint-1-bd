Use M_OpFlix

Select * From Categorias Order By IdCategoria Asc;

Select * From Tipos;

Select * From Usuarios;

Select * From Lancamentos;

Select * From Plataformas Order By IdPlataforma Asc;

--/////   Favoritos   /////
Select * From Favoritos;

Select U.*, P.*
From Usuarios U
Join Permissoes P
On U.IdPermissao = P.IdPermissao;

Select L.*, C.*
From Lancamentos L
Join Categorias C
On L.IdCategoria = C.IdCategoria;

Select L.*, T.*
From Lancamentos L
Join Tipos T
On L.IdTipo = T.IdTipo;

Select L.*, C.*, T.*
From Lancamentos L
Join Categorias C
On L.IdCategoria = C.IdCategoria
Join Tipos T
On L.IdTipo = T.IdTipo;

--/////   Selecionar os Filme de Acao   /////

Select * 
From Lancamentos
Where IdCategoria = 3

--/////   Contar quantiadade de filmes   /////

Select Count(IdLancamento)
From Lancamentos


--/////   Mostrar as categorias vinculadas aos lancamentos   /////
Select L.*, C.*
From Lancamentos L
Full Join Categorias C
On L.IdCategoria = C.IdCategoria;

--/////   Plataformas com os Lancamentos   /////
Select L.*, P.*
From Lancamentos L
Full Join Plataformas P
On L.IdPlataforma = P.IdPlataforma;