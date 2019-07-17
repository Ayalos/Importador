SET IDENTITY_INSERT lojamix.dbo.nop ON
insert into lojamix.dbo.nop(id_nop,id_cfop,codigo_nop,nome,ativa,tipo_valoracao,id_cme,id_situacao_tributaria_icms,incide_pis,incide_cofins,incide_ipi,id_regra_tributacao,tipo_nop,id_nop_contrapartida_externa,operacao_nop,id_conta,id_situacao_tributaria_pis,id_situacao_tributaria_cofins,id_situacao_tributaria_ipi,aliquota_pis,aliquota_cofins,aliquota_ipi,cod_nat_receita_pis,cod_nat_receita_cofins,movimenta_estoque)
values(31,5102,510203,'VENDA MERCADORIA ADQUIRIDA ISENTO ICMS',1,NULL,501,NULL,0,0,0,3,0,NULL,5,NULL,NULL,NULL,99,0.00,0.00,0.00,'','',1)
SET IDENTITY_INSERT lojamix.dbo.nop OFF

SET IDENTITY_INSERT lojamix.dbo.nop ON
insert into lojamix.dbo.nop(
id_nop,id_cfop,codigo_nop,nome,ativa,tipo_valoracao,id_cme,id_situacao_tributaria_icms,incide_pis,incide_cofins,incide_ipi,id_regra_tributacao,tipo_nop,id_nop_contrapartida_externa,operacao_nop,id_conta,id_situacao_tributaria_pis,id_situacao_tributaria_cofins,id_situacao_tributaria_ipi,aliquota_pis,aliquota_cofins,aliquota_ipi,cod_nat_receita_pis,cod_nat_receita_cofins,movimenta_estoque)
values(32,5102,510204,'VENDA MERCADORIA ADQUIRIDA NÃO TRIBUTADA',1,NULL,501,NULL,0,0,0,4,0,NULL,5,NULL,NULL,NULL,99,0.00,0.00,0.00,'','',1)
SET IDENTITY_INSERT lojamix.dbo.nop OFF

DECLARE @ISENTO INT
SET @ISENTO = (SELECT ID_NOP FROM lojamix.dbo.NOP WHERE CODIGO_NOP = 510203)
UPDATE lojamix.dbo.produto SET id_nop_venda = @isento where id_produto in (
select prod.id_produto from hiper.dbo.regra_tributacao_produto as prod
inner join hiper.dbo.regra_tributacao as regra ON prod.id_regra_tributacao = regra.id_regra_tributacao WHERE LEFT(REGRA.nome,2) = 40)

DECLARE @NAOTRIBU INT
SET @NAOTRIBU = (SELECT ID_NOP FROM lojamix.dbo.NOP WHERE CODIGO_NOP = 510204)
UPDATE lojamix.dbo.produto SET id_nop_venda = @NAOTRIBU where id_produto in (
select prod.id_produto from hiper.dbo.regra_tributacao_produto as prod
inner join hiper.dbo.regra_tributacao as regra ON prod.id_regra_tributacao = regra.id_regra_tributacao WHERE LEFT(REGRA.nome,2) = 41)

DECLARE @ST INT
SET @ST = (SELECT ID_NOP FROM lojamix.dbo.NOP WHERE CODIGO_NOP = 540501)
UPDATE lojamix.dbo.produto SET id_nop_venda = @ST where id_produto in (
select prod.id_produto from hiper.dbo.regra_tributacao_produto as prod
inner join hiper.dbo.regra_tributacao as regra ON prod.id_regra_tributacao = regra.id_regra_tributacao WHERE LEFT(REGRA.nome,2) = 60)

DECLARE @TRIBUT INT
SET @TRIBUT = (SELECT ID_NOP FROM lojamix.dbo.NOP WHERE CODIGO_NOP = 510201)
UPDATE lojamix.dbo.produto SET id_nop_venda = @TRIBUT where id_produto in (
select prod.id_produto from hiper.dbo.regra_tributacao_produto as prod
inner join hiper.dbo.regra_tributacao as regra ON prod.id_regra_tributacao = regra.id_regra_tributacao WHERE LEFT(REGRA.nome,2) = 00)
