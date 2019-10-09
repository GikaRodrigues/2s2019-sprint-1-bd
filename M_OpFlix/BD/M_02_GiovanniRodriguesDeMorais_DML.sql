Use M_OpFlix

Insert Into Categorias	(Categoria)
	Values				('Terror')
						,('Aventura')
						,('Acao')
						,('Comedia')
						,('Guerra');

Insert Into Tipos	(Tipo)
	Values			('Filme')
					,('Serie');

Insert Into Usuarios	(Nome , CPF , Email , Senha , DataCriacao , Permissao)
	Values				('Administrador' , 275433708-32 , 'adm@gmail.com' , 'adm123' , '2019-08-10' , 'Administrador')
						,('Leo' , 441556358-95 , 'leo@gmail.com' , 'leo123' , '2019-08-11' , 'Cliente')
						,('Pieri' , 419244538-78 , 'pieri@gmail.com' , 'pieri123' , '2019-08-12' , 'Cliente')
						,('Murilo' , 424877388-04 , 'murilo@gmail.com' , 'murilo123' , '2019-08-14' , 'Cliente')
						,('Helena' , 449658148-51 , 'roads@gmail.com' , 'hroads123' , '2019-08-25' , 'Cliente');

Insert Into Lancamentos	(Titulo , Sinopse , IdCategoria , TempoDeDuracao , IdTipo , DataLancamento)
	Values				('Up' , 'Tem um veio e uma crianca com milhoes de baloes' , 2 , '01:43:12' , 1 , '2009-09-04')
						,('Vingadores Ultimato' , 'Após Thanos eliminar metade das criaturas vivas, os Vingadores têm de lidar com a perda de amigos e entes queridos.' , 3 , '03:03:12' , 1 , '2019-04-25')
						,('A Grande Familia' , 'Uma família muito louca! Uma família muito careta. Uma família chata, engraçada, alegre, triste.' , 4 , '00:30:45' , 2 , '2001-03-29')
						,('O Grinch' , 'Às vésperas do Natal, os moradores de Quemlândia preparam a grande festa anual em celebração à data. Grinch, o pequeno ser verde e mal-humorado, detesta a festividade. 
						Ao lado de seu cãozinho Max, ele cria um plano maléfico: invadir as casas da vizinhança e sumir com todos os itens de Natal.' , 2 , '01:22:00' , 1 , '2018-11-08');

--/////     EXTRAS     /////

Insert Into Lancamentos	(Titulo , Sinopse , IdCategoria , TempoDeDuracao , IdTipo , DataLancamento)
	Values				('Rei Leao' , 'Traído e exilado de seu reino, o leãozinho Simba precisa descobrir como crescer e retomar seu destino como herdeiro real.' , 2 , '02:00:12' , 1 , '2019-09-04')
						,('Deuses Americanos' , 'Centrado em uma guerra entre os velhos e os novos deuses. Os seres bíblicos e mitológicos estão perdendo cada vez mais fiéis para novos deuses.' , 7 , '01:00:12' , 2 , '2017-04-30')
						,('La Casa Papel 3ª Temporada' , 'Oito habilidosos ladrões se trancam na Casa da Moeda da Espanha com o ambicioso plano de realizar o maior roubo da história e levar com eles mais de 2 bilhões de euros.' , 7 , '00:50:45' , 2 , '2017-05-02')
						,('Velozes e Furiosos: Hobbs & Shaw' , 'Tem muita corrida' , 3 , '02:16:00' , 1 , '2019-08-01')
						,('Ana Belle 3: De volta para casa' , 'Annabelle, aproveitando que os investigadores paranormais estão fora de jogo, anima os letais e aterrorizantes objetos contidos na Sala dos Artefatos dos Warren.' , 1 , '01:46:00' , 1 , '2019-06-27')
						,('Homem Haranha: Longe de casa' , 'Tem muita pancadaria' , 3 , '02:10:00' , 1 , '2019-07-04');

--/////   Inserir novas categorias   ///////

Insert Into Categorias	(Categoria)
	Values				('Documentario')
						,('Drama')
						,('Ficcao Cientifica');


--/////   Deletar a Serie Deuses Americanos   ///////

Delete From Lancamentos Where IdLancamento = 6;

--/////   Coloca Helena com ADM   /////

Update Usuarios
Set Permissao = 'Administrador'
Where IdUsuarios = 5

--/////   Alterar a data do Rei Leao   /////

Update Lancamentos
Set DataLancamento = '1994-07-08'
Where IdLancamento = 5

--/////   Alterar nome de La Casa de Papel   /////

Update Lancamentos
Set Titulo = 'La Casa De Papel - 3º Temporada'
Where IdLancamento = 7


Insert Into Plataformas (Plataforma)
	Values				('Netflix')
						,('Amazon')
						,('Cinema')
						,('VHS');

Insert Into Favoritos (IdUsuario , IdLacamentos)
	Values				(1 , 9)
						,(2 , 10)
						,(3 , 2)
						,(4 , 4)
						,(5 , 1)
						,(3 , 2)
						,(5 , 5)
						,(2 , 9);

Insert Into PlataformaLancamentos (IdPlataforma , IdLancamento)
	Values				(1 , 2)
						,(2 , 2)
						,(3 , 1)
						,(4 , 5)
						,(2 , 3)
						,(3 , 8)
						,(4 , 8)
						,(2 , 9);