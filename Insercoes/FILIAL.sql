UPDATE Lojamix.dbo.filial SET id_empresa=filia.id_empresa, codigo_filial=filia.codigo_filial,razao_social=filia.razao_social,nome_fantasia=filia.nome_fantasia, apelido=filia.apelido,
cnpj=filia.cnpj,ie=filia.ie,logradouro=filia.logradouro, endereco_numero=filia.endereco_numero,complemento=filia.complemento,bairro=filia.bairro, cep=filia.cep, id_cidade=filia.id_cidade,
fone1_ddd=filia.fone1_ddd,fone1_numero=filia.fone1_numero,fone2_ddd=filia.fone2_ddd,fone2_numero=filia.fone2_numero,site=filia.site, email=filia.email,im=filia.im,suframa=filia.suframa,
id_perfil_sped = filial.id_perfil_sped,tipo_atividade=filia.tipo_atividade,cnpj_portal=1,nome_certificado=NULL,id_csc=Unife.identificacao_contribuinte_numero,csc=identificacao_contribuinte_token,
horario_atendimento_inicio= '08:00:00.0000000',horario_atendimento_fim = '21:00:00.0000000',imagem_logo= NULL,id_entidade = NULL 
FROM Hiper.dbo.filial AS filia Inner join Unife.dbo.emissor_nfe As Unife ON Unife.cnpj_emissor = cnpj where lojamix.dbo.filial.id_filial = 1


Alter table Lojamix.dbo.filial
	NOCHECK Constraint ALL
set IDENTITY_INSERT lojamix.dbo.filial ON
INSERT INTO Lojamix.dbo.filial(id_filial,id_empresa, codigo_filial, razao_social, nome_fantasia, apelido,cnpj,ie, logradouro, endereco_numero,complemento, bairro, cep, id_cidade, fone1_ddd,
fone1_numero, fone2_ddd, fone2_numero, site, email, im, suframa, id_perfil_sped,tipo_atividade, cnpj_portal,nome_certificado, id_csc,csc, horario_atendimento_inicio,horario_atendimento_fim,imagem_logo,id_entidade) 
SELECT id_filial, id_empresa, codigo_filial,razao_social,nome_fantasia, apelido,cnpj, ie, logradouro, endereco_numero,complemento, bairro, cep, id_cidade,
fone1_ddd,fone1_numero,fone2_ddd,fone2_numero, site, email,im,suframa, id_perfil_sped,tipo_atividade,1,'',Unife.identificacao_contribuinte_numero, identificacao_contribuinte_token,'08:00:00.0000000',
'21:00:00.0000000',NULL,NULL FROM Hiper.dbo.filial Inner join Unife.dbo.emissor_nfe As Unife ON Unife.cnpj_emissor = cnpj where id_filial <> 1
set IDENTITY_INSERT lojamix.dbo.filial OFF
Alter table Lojamix.dbo.filial
	CHECK Constraint ALL
	
INSERT INTO Lojamix.dbo.cme select id_cme,nome,operacao,id_cme_contrapartida,tipo_valoracao, permite_manipulacao_valor,tipo_agrupamento_itens_impressao FROM Hiper.dbo.cme 
where Hiper.dbo.cme.id_cme not in(select id_cme FROM Lojamix.dbo.cme)

UPDATE Lojamix.dbo.empresa SET nome = emp.nome from Hiper.dbo.empresa AS emp where emp.id_empresa = 1  

UPDATE Lojamix.dbo.configuracao_filial SET id_filial = confilial.id_filial, id_endereco_estoque_vendas = confilial.id_endereco_estoque_vendas, tipo_preco_venda = 1,
codigo_regime_tributario = confilial.codigo_regime_tributario, situacao_tributaria_pis = confilial.situacao_tributaria_pis, aliquota_pis = confilial.aliquota_pis,
situacao_tributaria_cofins = confilial.situacao_tributaria_cofins,aliquota_cofins=confilial.aliquota_cofins, alterna_preco_varejo_atacado = 0,
horario_verao_ativado = 0, mensagem_cupom_fiscal = '',id_regra_tributacao = confilial.id_regra_tributacao, id_situacao_tributaria_simples_nacional = confilial.id_situacao_tributaria_simples_nacional,
aliquota_icms_simples_nacional = confilial.aliquota_icms_simples_nacional,tipo_tef=confilial.tipo_tef, cupom_mania_ativo = 0, forcar_identificacao_cliente_pdv=confilial.forcar_identificacao_cliente_pdv,
minas_legal_ativo = 0, cod_regra_inc_tributaria = NULL,cod_metodo_apropr_credito = NULL, cod_tipo_contrib_apurada = NULL, cod_criterio_escrituracao = NULL, usar_campo_observacao = NULL, texto_campo_observacao = '', 
tipo_mensagem_promocional = '',ConcessaoCreditoDF = NULL, formato_impressao = NULL, ambiente = NULL, imagem_logo=NULL, arquivo_certificado_digital=NULL, senha_certificado_digital=NULL, versao = 4, email_nfe_automatico = 1,
texto_padrao_email_nfe = NULL, texto_observacao_item_icms_st = NULL, ambiente_servico = NULL, id_modelo_documento_servico = NULL, consultar_num_serie_pdv = 0, enquadramento_simples_nacional = 1,
id_local_estoque_consignacao =NULL, id_local_estoque_loja_virtual=NULL, id_local_estoque_pedido_venda=NULL, id_local_ordem_servico = NULL,url_n49 = null,merchant_id = null, aliquota_servico = NULL,
url_loja_virtual = NULL, consumer_key = NULL, consumer_secret = NULL, integrar_loja_virtual = 0, ultimo_nsu_nfe_destinada = NULL, id_tabela_preco_loja_virtual = NULL, token = NULL,
usuario_loja_virtual = NULL, senha_loja_virtual = NULL, url_api_umovme = NULL, token_api_umovme = NULL, integrar_forca_vendas = 0, controlar_estoque_pdv = 0, login_inicial= 0, habilitar_controle_mesas=0
FROM Hiper.dbo.configuracao_filial AS confilial
WHERE Lojamix.dbo.configuracao_filial.id_filial = 1


Alter table Lojamix.dbo.configuracao_filial
	Nocheck Constraint ALL
Insert into Lojamix.dbo.configuracao_filial SELECT confilial.id_filial, confilial.id_endereco_estoque_vendas, 1,
confilial.codigo_regime_tributario, confilial.situacao_tributaria_pis, confilial.aliquota_pis,
confilial.situacao_tributaria_cofins,confilial.aliquota_cofins,0,
0, '',confilial.id_regra_tributacao,confilial.id_situacao_tributaria_simples_nacional,confilial.aliquota_icms_simples_nacional,
confilial.tipo_tef,  0, confilial.forcar_identificacao_cliente_pdv, 0, NULL,
NULL,  NULL,  NULL,  NULL, '', '',
NULL, NULL, NULL, NULL, NULL, NULL,4, 1,
 NULL, NULL, NULL,  NULL, 0,  1,
NULL, NULL, NULL, NULL,null, null, NULL,
NULL, NULL, NULL,0, NULL, NULL, NULL,
NULL, NULL,  NULL, NULL,  0,  0,  0,0
FROM Hiper.dbo.configuracao_filial AS confilial
where confilial.id_filial <> 1
Alter table Lojamix.dbo.configuracao_filial
	Check Constraint ALL