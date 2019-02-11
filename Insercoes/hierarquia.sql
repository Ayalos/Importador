Select * from Hiper.dbo.hierarquia_produto
Select * from Lojamix.dbo.hierarquia_produto


UPDATE Lojamix.dbo.hierarquia_produto SET nome = hierarquia.nome, id_hierarquia_produto_pai = hierarquia.id_hierarquia_produto_pai, sequencia=hierarquia.sequencia
 FROM Hiper.dbo.hierarquia_produto AS hierarquia where Lojamix.dbo.hierarquia_produto.id_hierarquia_produto = 1


Alter table Lojamix.dbo.hierarquia_produto
	NOCHECK Constraint ALL 
Insert into Lojamix.dbo.hierarquia_produto(id_hierarquia_produto,nome,id_hierarquia_produto_pai,sequencia,id_impressora,integrar,id_loja_virtual,cor_padrao_hierarquia,cor_padrao_texto_hierarquia,
situacao_loja_virtual,codigo_importacao,Id_UmovME,id_setor) select id_hierarquia_produto,nome,id_hierarquia_produto,sequencia,
null,1, null, null,null,0,null,null,null from Hiper.dbo.hierarquia_produto where id_hierarquia_produto <> 1
Alter table Lojamix.dbo.hierarquia_produto
	CHECK Constraint ALL