insert into Lojamix.dbo.perfil_usuario select nome,NULL from Hiper.dbo.perfil_usuario where id_perfil_usuario <> 1


SET IDENTITY_INSERT LOJAMIX.DBO.USUARIO ON
INSERT INTO Lojamix.dbo.usuario(id_usuario,login,nome,ativo,senha,id_ultimo_correio_eletronico_lido,id_perfil_usuario,id_filial_trabalho,vendedor,email,id_entidade,tecnico,Id_Vendedor_Umovme
) select id_usuario, login, nome, ativo, senha, id_ultimo_correio_eletronico_lido, id_perfil_usuario, id_filial_trabalho,
vendedor, email, NULL, tecnico, 0 from Hiper.dbo.usuario where id_usuario <> 1
SET IDENTITY_INSERT LOJAMIX.DBO.USUARIO OFF

Alter Table Lojamix.dbo.entidade
    NOCHECK Constraint All
SET IDENTITY_INSERT Lojamix.dbo.entidade ON
Insert into Lojamix.dbo.entidade(id_entidade,tipo_entidade,nome,id_usuario_cadastro,data_hora_cadastro,id_usuario_alteracao,data_hora_alteracao,logradouro,numero_endereco,bairro,complemento,
cep,id_cidade,site,observacao,id_potencial,flag_fornecedor,flag_guia,flag_transportadora, flag_funcionario,situacao_replicacao_multiloja,limite_credito,flag_contador, num_insc_crc,fone1_ddd,
fone1_numero,email_principal,Ativo,codigo_importacao, receber_email_promocao,celular_ddd,celular_numero,saldo_valor_pontuacao,saldo_pontuacao,pontuacao_acumulada,imagem,horario_atendimento_inicio,
horario_atendimento_fim,tempo_atendimento_profissional,fone_comercial_ddd,fone_comercial_numero,celular_whatsapp,cadastro_incompleto,funcao_funcionario,flag_cliente,id_loja_virtual,flag_profissional,
exibir_agenda,senha_app,id_forca_vendas,id_vendedor_padrao,valor_pontuacao,quantidade_pontos,valor_faixa_pontuacao,valor_sobra_acumulado) 
select id_entidade,tipo_entidade,nome, id_usuario_cadastro, data_hora_cadastro, id_usuario_alteracao,
data_hora_alteracao, logradouro, numero_endereco, bairro, complemento, cep, id_cidade, site, observacao, 1, flag_fornecedor, flag_guia,
flag_transportadora, flag_funcionario, situacao_replicacao_multiloja, limite_credito, 0, '', fone_primario_ddd, fone_primario_numero,
email, inativo, '', 0, '','', 0.00, 0.00, 0.00, NULL, '00:00:00.0000000', '00:00:00.0000000', 0, '', '', 0, 0, NULL, flag_cliente, 0,
0, 0, NULL,0, NULL, 0.00, 0.00, 0.00, 0.00 from Hiper.dbo.entidade
UPDATE Lojamix.dbo.entidade SET Ativo = 1 where Ativo=0
SET IDENTITY_INSERT Lojamix.dbo.entidade OFF
Alter Table Lojamix.dbo.entidade
    CHECK Constraint All
    
INSERT INTO Lojamix.dbo.usuario_filial SELECT * FROM Hiper.dbo.usuario_filial WHERE id_usuario <> 1

Alter Table Lojamix.dbo.pessoa_fisica
    NOCHECK Constraint All
INSERT INTO Lojamix.dbo.pessoa_fisica(id_entidade,cpf,rg,data_nascimento,sexo,ie,indicador_ie) select id_entidade, cpf, rg, '2000-01-01 00:00:00.00', sexo, ie, '' from Hiper.dbo.pessoa_fisica
Alter Table Lojamix.dbo.pessoa_fisica
    CHECK Constraint All

Alter Table Lojamix.dbo.pessoa_juridica
    NOCHECK Constraint All
INSERT INTO Lojamix.dbo.pessoa_juridica(id_entidade, cnpj, ie, nome_fantasia, suframa,indicador_ie,codigo_regime_tributario) select id_entidade, cnpj, ie, nome_fantasia, suframa, 0,NULL FROM Hiper.dbo.pessoa_juridica
Alter Table Lojamix.dbo.pessoa_juridica
    CHECK Constraint All
    
