﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImportMtoH.classes
{
    class ImportacaoProd
    {
        private Conexao objConexao;



        // construtor

        public ImportacaoProd(Conexao conexao)
        {

            objConexao = conexao;

        }
        

        public void InserEnderec()
        {
            SqlCommand com = new SqlCommand();

            com.Connection = objConexao.ObjetoConexao;
            com.CommandText = "SET IDENTITY_INSERT Lojamix.dbo.endereco_estoque ON "+
"Alter table Lojamix.dbo.endereco_estoque "+
"NOCHECK Constraint ALL "+
"INSERT INTO Lojamix.dbo.endereco_estoque(id_endereco_estoque, id_filial, id_local_estoque, codigo_composto, nivel1, nivel2, nivel3, nivel4, nivel5, inativo, descricao) "+
"SELECT id_endereco_estoque, id_filial, id_local_estoque, codigo_composto, nivel1, nivel2, nivel3, nivel4, nivel5, inativo,'Endereco ' + Cast(id_filial AS varchar) "+
"FROM Hiper.dbo.endereco_estoque WHERE id_endereco_estoque <> 1 "+
"Alter table Lojamix.dbo.endereco_estoque "+
"CHECK Constraint ALL "+
"SET IDENTITY_INSERT Lojamix.dbo.endereco_estoque OFF";

            objConexao.Conectar();
            com.ExecuteScalar();
            objConexao.Desconectar();
            InserUnidade();
        }
        private void InserUnidade()
        {
            SqlCommand com = new SqlCommand();

            com.Connection = objConexao.ObjetoConexao;
            com.CommandText = "delete from lojamix.dbo.unidade_medida " +
                "SET IDENTITY_INSERT lojamix.dbo.unidade_medida ON "+
                "insert into lojamix.dbo.unidade_medida(id_unidade_medida, sigla, nome, casas_decimais, unidade_primaria) " +
                "select id_unidade_medida, sigla, nome, casas_decimais, 1 from hiper.dbo.unidade_medida "+
                "SET IDENTITY_INSERT lojamix.dbo.unidade_medida OFF";
            objConexao.Conectar();
            com.ExecuteScalar();
            objConexao.Desconectar();
            InserMarca();
        }

        private void InserMarca()
        {
            SqlCommand com = new SqlCommand();
            
            com.Connection = objConexao.ObjetoConexao;
            com.CommandText = "SET IDENTITY_INSERT lOJAMIX.DBO.MARCA_PRODUTO ON " +
                                "ALTER TABLE LOJAMIX.DBO.MARCA_PRODUTO " +
                                "NOCHECK Constraint ALL " +
                                "INSERT INTO Lojamix.dbo.marca_produto(id_marca_produto, nome, marca_propria, cod_marca, id_loja_virtual) " +
                                "SELECT id_marca_produto, nome, marca_propria, NULL, NULL " +
                                "FROM Hiper.dbo.marca_produto where id_marca_produto <> 1 " +
                                "SET IDENTITY_INSERT lOJAMIX.DBO.MARCA_PRODUTO OFF " +
                                "ALTER TABLE LOJAMIX.DBO.MARCA_PRODUTO " +
                                "CHECK Constraint ALL";
            objConexao.Conectar();
            com.ExecuteScalar();
            objConexao.Desconectar();
            InserHier();
           
        }
        private void InserHier()
        {
            SqlCommand com = new SqlCommand();

            com.Connection = objConexao.ObjetoConexao;
            com.CommandText = "ALTER TABLE LOJAMIX.DBO.HIERARQUIA_PRODUTO " +
                "NOCHECK CONSTRAINT ALL "+
                "INSERT INTO Lojamix.dbo.hierarquia_produto " +
                "SELECT id_hierarquia_produto, nome, id_hierarquia_produto_pai, sequencia, NULL, 1,NULL, NULL, NULL, 0, NULL, NULL,NULL " +
                "FROM Hiper.dbo.hierarquia_produto " +
                "WHERE id_hierarquia_produto <> '1' " +
                "ALTER TABLE LOJAMIX.DBO.HIERARQUIA_PRODUTO " +
                "CHECK CONSTRAINT ALL";
            objConexao.Conectar();
            com.ExecuteScalar();
            objConexao.Desconectar();
            InserTabelaVar();
        }
        private void InserTabelaVar()
        {
            SqlCommand com = new SqlCommand();

            com.Connection = objConexao.ObjetoConexao;

            com.CommandText = "SET IDENTITY_INSERT Lojamix.dbo.tabela_variacao ON " +
                                "ALTER TABLE LOJAMIX.DBO.TABELA_variacao " +
                                    "NOCHECK Constraint ALL " +
                                "INSERT INTO Lojamix.dbo.tabela_variacao(id_tabela_variacao, nome) " +
                                "(SELECT id_tabela_variacao, nome " +
                                "FROM Hiper.dbo.tabela_variacao " +
                                "where id_tabela_variacao != 1 and id_tabela_variacao != 2) " +
                                "SET IDENTITY_INSERT Lojamix.dbo.tabela_variacao OFF " +
                                "ALTER TABLE LOJAMIX.DBO.TABELA_variacao " +
                                    "CHECK Constraint ALL";
            objConexao.Conectar();
            com.ExecuteScalar();
            objConexao.Desconectar();
            InserProd();
        }
        private void InserProd()
        {
            SqlCommand com = new SqlCommand();

            com.Connection = objConexao.ObjetoConexao;

            com.CommandText = "SET IDENTITY_INSERT Lojamix.dbo.produto ON " +
                            "ALTER TABLE LOJAMIX.DBO.PRODUTO " +
                            "NOCHECK CONSTRAINT ALL " +
                            "INSERT INTO Lojamix.dbo.produto(id_produto, nome, situacao, id_entidade_fornecedor, id_marca_produto, id_unidade_medida, id_hierarquia_produto, id_usuario_cadastro, data_hora_cadastro," +
                            "id_usuario_alteracao, data_hora_alteracao, tipo_variacao, id_tabela_variacao_a, id_tabela_variacao_b, referencia_interna_produto, preco_custo, preco_aquisicao," +
                            "preco_venda, preco_venda_atacado, cod_mercadoria, id_ncm, tributacao_pis_diferenciada, id_situacao_tributaria_pis, aliquota_pis, tributacao_cofins_diferenciada," +
                            "id_situacao_tributaria_cofins, aliquota_cofins, id_situacao_tributaria_ipi, aliquota_ipi, origem_produto, tipo_item, descricao_porcao, valor_energetico," +
                            "valor_energetico_percentual, quantidade_carboidratos, quantidade_carboidratos_percentual, quantidade_proteinas, quantidade_proteinas_percentual, quantidade_gorduras_totais," +
                            "quantidade_gorduras_totais_percentual, quantidade_gorduras_saturadas, quantidade_gorduras_saturadas_percentual, quantidade_gorduras_trans, quantidade_gorduras_trans_percentual," +
                            "quantidade_fibra_alimentar, quantidade_fibra_alimentar_percentual, quantidade_sodio, quantidade_sodio_percentual, dias_validade, receita, informacao_adicional," +
                            "codigo_importacao, mva_interno, mva_externo, integrar_tablet, cest, id_loja_virtual, perc_red_bc_icms, codigo_anp, largura, altura, comprimento, volume, peso_volume," +
                            "tipo_dimensao, tipo_peso_volume, id_forca_vendas, descricao_loja_virtual, indicador_escala, cnpj_fabricante, codigo_beneficio_fiscal, descricao_anp) " +
                            "SELECT id_produto, nome, situacao, id_entidade_fornecedor, id_marca_produto,id_unidade_medida,id_hierarquia_produto,id_usuario_cadastro,data_hora_cadastro," +
                            "id_usuario_alteracao,data_hora_alteracao,tipo_variacao,id_tabela_variacao_a,id_tabela_variacao_b,referencia_interna_produto,preco_custo,preco_aquisicao," +
                            "preco_venda,0,null, id_ncm,tributacao_pis_diferenciada,id_situacao_tributaria_pis,aliquota_pis, tributacao_cofins_diferenciada,id_situacao_tributaria_cofins,aliquota_cofins," +
                            "id_situacao_tributaria_ipi,aliquota_ipi, origem_produto, tipo_item,descricao_porcao,valor_energetico,valor_energetico_percentual,quantidade_carboidratos, " +
                            "quantidade_carboidratos_percentual,quantidade_proteinas, quantidade_proteinas_percentual,quantidade_gorduras_totais,quantidade_gorduras_totais_percentual,quantidade_gorduras_saturadas," +
                            "quantidade_gorduras_saturadas_percentual,quantidade_gorduras_trans, quantidade_gorduras_trans_percentual, quantidade_fibra_alimentar,"+
                            "quantidade_fibra_alimentar_percentual,quantidade_sodio, quantidade_sodio_percentual, dias_validade,receita,informacao_adicional,NULL,0.00,"+
                            "0.00,1,'',NULL,0.00,'',0.00000,0.00000,0.00000,0.00000,0.00000,1,1,0,'',NULL,'','','' "+
                            "FROM Hiper.dbo.produto "+
                            "SET IDENTITY_INSERT Lojamix.dbo.produto OFF " +
                            "ALTER TABLE LOJAMIX.DBO.PRODUTO " +
                            "CHECK CONSTRAINT ALL";
            objConexao.Conectar();
            com.ExecuteScalar();
            objConexao.Desconectar();
            InserProdSin();
        }
        private void InserProdSin()
        {
            SqlCommand com = new SqlCommand();

            com.Connection = objConexao.ObjetoConexao;

            com.CommandText = "ALTER TABLE Lojamix.dbo.produto_sinonimo "+
                                "NOCHECK Constraint ALL "+
                            "INSERT INTO Lojamix.dbo.produto_sinonimo "+
                            "select id_produto, id_variacao, codigo_barras, sigla_unidade_logistica ,id_usuario_cadastro,data_hora_cadastro,id_usuario_alteracao, data_hora_alteracao "+
                            "FROM Hiper.dbo.produto_sinonimo "+
                            "ALTER TABLE Lojamix.dbo.produto_sinonimo "+
                                "CHECK Constraint ALL";
            objConexao.Conectar();
            com.ExecuteScalar();
            objConexao.Desconectar();
            InserProdForn();
        }
        private void InserProdForn()
        {
            SqlCommand com = new SqlCommand();

            com.Connection = objConexao.ObjetoConexao;

            com.CommandText = "SET IDENTITY_INSERT Lojamix.dbo.produto_fornecedor ON " +
                            "ALTER TABLE LOJAMIX.DBO.PRODUTO_FORNECEDOR " +
                            "NOCHECK CONSTRAINT ALL " +
                            "INSERT INTO Lojamix.dbo.produto_fornecedor(id_produto_fornecedor, id_entidade, id_produto, principal, ativo, observacao, ultimo_preco_aquisicao, data_alteracao_ultimo_preco, codigo_importacao) "+
                            "SELECT id_produto_fornecedor, id_entidade, id_produto,1,1,NULL,0.00, NULL, NULL "+
                            "FROM Hiper.dbo.produto_fornecedor "+
                            "SET IDENTITY_INSERT Lojamix.dbo.produto_fornecedor OFF " +
                            "ALTER TABLE LOJAMIX.DBO.PRODUTO_FORNECEDOR " +
                            "CHECK CONSTRAINT ALL";
            objConexao.Conectar();
            com.ExecuteScalar();
            objConexao.Desconectar();
            InserProdNumSer();
        }
        private void InserProdNumSer()
        {
            SqlCommand com = new SqlCommand();

            com.Connection = objConexao.ObjetoConexao;

            com.CommandText = "ALTER TABLE LOJAMIX.DBO.PRODUTO_NUMERO_SERIE " +
                                "NOCHECK CONSTRAINT ALL " +
                                "INSERT INTO Lojamix.dbo.produto_numero_serie(id_produto,id_variacao,numero_serie,id_endereco_estoque) " +
                                "select id_produto, id_variacao, numero_serie, id_endereco_estoque from Hiper.dbo.produto_numero_serie " +
                                "ALTER TABLE LOJAMIX.DBO.PRODUTO_NUMERO_SERIE " +
                                "CHECK CONSTRAINT ALL";
            objConexao.Conectar();
            com.ExecuteScalar();
            objConexao.Desconectar();
            InserItemTabVar();
        }
        private void InserItemTabVar()
        {
            SqlCommand com = new SqlCommand();

            com.Connection = objConexao.ObjetoConexao;
            com.CommandText = "DELETE FROM Lojamix.dbo.item_tabela_variacao where id_item_tabela_variacao >= 390 " +
                            "SET IDENTITY_INSERT Lojamix.dbo.item_tabela_variacao ON " +
                            "ALTER TABLE LOJAMIX.DBO.ITEM_TABELA_VARIACAO " +
                            "NOCHECK CONSTRAINT ALL "+
                            "INSERT INTO Lojamix.dbo.item_tabela_variacao(id_item_tabela_variacao, id_tabela_variacao, nome) "+
                            "SELECT id_item_tabela_variacao, id_tabela_variacao, nome FROM Hiper.dbo.item_tabela_variacao "+
                            "SET IDENTITY_INSERT Lojamix.dbo.item_tabela_variacao OFF " +
                            "ALTER TABLE LOJAMIX.DBO.ITEM_TABELA_VARIACAO " +
                            "CHECK CONSTRAINT ALL";
            objConexao.Conectar();
            com.ExecuteScalar();
            objConexao.Desconectar();
            InserProdVar();
        }
        private void InserProdVar()
        {
            SqlCommand com = new SqlCommand();

            com.Connection = objConexao.ObjetoConexao;

            com.CommandText = "ALTER TABLE LOJAMIX.DBO.PRODUTO_VARIACAO " +
                                "NOCHECK CONSTRAINT ALL " +
                                "INSERT INTO Lojamix.dbo.produto_variacao " +
                                "Select id_produto, id_variacao, nome, situacao, id_item_tabela_variacao_a, id_item_tabela_variacao_b, referencia_interna_variacao,"+
                                "nome_variacao_a, nome_variacao_b, NULL, NULL, NULL, NULL, NULL, NULL FROM Hiper.dbo.produto_variacao " +
                                "ALTER TABLE LOJAMIX.DBO.PRODUTO_VARIACAO " +
                                "CHECK CONSTRAINT ALL";

            objConexao.Conectar();
            com.ExecuteScalar();
            objConexao.Desconectar();
            InserSalEsto();
        }
        private void InserSalEsto()
        {
            SqlCommand com = new SqlCommand();

            com.Connection = objConexao.ObjetoConexao;
            com.CommandText = "ALTER TABLE LOJAMIX.DBO.SALDO_ESTOQUE " +
                "NOCHECK CONSTRAINT ALL " +
                "INSERT INTO Lojamix.dbo.saldo_estoque select id_produto, id_variacao,id_endereco_estoque,quantidade,hash_md5,0 FROM Hiper.dbo.saldo_estoque " +
                "ALTER TABLE LOJAMIX.DBO.SALDO_ESTOQUE " +
                "CHECK CONSTRAINT ALL";
            objConexao.Conectar();
            com.ExecuteScalar();
            objConexao.Desconectar();
            InserSalEstoqueDiar();
        }
        private void InserSalEstoqueDiar()
        {
            SqlCommand com = new SqlCommand();

            com.Connection = objConexao.ObjetoConexao;
            com.CommandText = "ALTER TABLE LOJAMIX.DBO.SALDO_ESTOQUE_DIARIO " +
                "NOCHECK CONSTRAINT ALL " +
                "INSERT INTO Lojamix.dbo.saldo_estoque_diario select id_produto, id_variacao,id_endereco_estoque, data, saldo_data FROM Hiper.dbo.saldo_estoque_diario " +
                "ALTER TABLE LOJAMIX.DBO.SALDO_ESTOQUE_DIARIO " +
                "CHECK CONSTRAINT ALL";

            objConexao.Conectar();
            com.ExecuteScalar();
            objConexao.Desconectar();
            InserCadastro();
        }
        private void InserCadastro()
        {
            SqlCommand com = new SqlCommand();
            com.Connection = objConexao.ObjetoConexao;
            com.CommandText = "ALTER TABLE LOJAMIX.DBO.CADASTRO_LOGISTICO_PRODUTO " +
                "NOCHECK CONSTRAINT ALL " +
                "INSERT INTO Lojamix.dbo.cadastro_logistico_produto SELECT sigla_unidade_logistica,id_produto,id_unidade_medida,multiplicador,0 FROM Hiper.dbo.cadastro_logistico_produto " +
                "ALTER TABLE LOJAMIX.DBO.CADASTRO_LOGISTICO_PRODUTO " +
                "CHECK CONSTRAINT ALL";
            objConexao.Conectar();
            com.ExecuteScalar();
            objConexao.Desconectar();
            InserHierar();
        }

        public void UpdateCFOP()
        {
            SqlCommand com = new SqlCommand();
            com.Connection = objConexao.ObjetoConexao;
            com.CommandText = "SET IDENTITY_INSERT lojamix.dbo.nop ON " +
"insert into lojamix.dbo.nop(id_nop, id_cfop, codigo_nop, nome, ativa, tipo_valoracao, id_cme, id_situacao_tributaria_icms, incide_pis, incide_cofins, incide_ipi, id_regra_tributacao, tipo_nop, id_nop_contrapartida_externa, operacao_nop, id_conta, id_situacao_tributaria_pis, id_situacao_tributaria_cofins, id_situacao_tributaria_ipi, aliquota_pis, aliquota_cofins, aliquota_ipi, cod_nat_receita_pis, cod_nat_receita_cofins, movimenta_estoque) " +
"values(31, 5102, 510203, 'VENDA MERCADORIA ADQUIRIDA ISENTO ICMS', 1, NULL, 501, NULL, 0, 0, 0, 3, 0, NULL, 5, NULL, NULL, NULL, 99, 0.00, 0.00, 0.00, '', '', 1) " +
"SET IDENTITY_INSERT lojamix.dbo.nop OFF ; " +

"SET IDENTITY_INSERT lojamix.dbo.nop ON " +
"insert into lojamix.dbo.nop( " +
"id_nop, id_cfop, codigo_nop, nome, ativa, tipo_valoracao, id_cme, id_situacao_tributaria_icms, incide_pis, incide_cofins, incide_ipi, id_regra_tributacao, tipo_nop, id_nop_contrapartida_externa, operacao_nop, id_conta, id_situacao_tributaria_pis, id_situacao_tributaria_cofins, id_situacao_tributaria_ipi, aliquota_pis, aliquota_cofins, aliquota_ipi, cod_nat_receita_pis, cod_nat_receita_cofins, movimenta_estoque) " +
"values(32, 5102, 510204, 'VENDA MERCADORIA ADQUIRIDA NÃO TRIBUTADA', 1, NULL, 501, NULL, 0, 0, 0, 4, 0, NULL, 5, NULL, NULL, NULL, 99, 0.00, 0.00, 0.00, '', '', 1) " +
"SET IDENTITY_INSERT lojamix.dbo.nop OFF ; ";
            objConexao.Conectar();
            com.ExecuteScalar();
            objConexao.Desconectar();
        }

        public void InserCFOP()
        {
            SqlCommand com = new SqlCommand();
            com.Connection = objConexao.ObjetoConexao;
            com.CommandText ="DECLARE @ISENTO INT "+
"SET @ISENTO = (SELECT ID_NOP FROM lojamix.dbo.NOP WHERE CODIGO_NOP = 510203) "+
"UPDATE lojamix.dbo.produto SET id_nop_venda = @isento where id_produto in ( "+
"select prod.id_produto from hiper.dbo.regra_tributacao_produto as prod "+
"inner join hiper.dbo.regra_tributacao as regra ON prod.id_regra_tributacao = regra.id_regra_tributacao WHERE LEFT(REGRA.nome,2) = 40) "+

"DECLARE @NAOTRIBU INT "+
"SET @NAOTRIBU = (SELECT ID_NOP FROM lojamix.dbo.NOP WHERE CODIGO_NOP = 510204) "+
"UPDATE lojamix.dbo.produto SET id_nop_venda = @NAOTRIBU where id_produto in ( "+
"select prod.id_produto from hiper.dbo.regra_tributacao_produto as prod "+
"inner join hiper.dbo.regra_tributacao as regra ON prod.id_regra_tributacao = regra.id_regra_tributacao WHERE LEFT(REGRA.nome,2) = 41) "+

"DECLARE @ST INT "+
"SET @ST = (SELECT ID_NOP FROM lojamix.dbo.NOP WHERE CODIGO_NOP = 540501) "+
"UPDATE lojamix.dbo.produto SET id_nop_venda = @ST where id_produto in ( "+
"select prod.id_produto from hiper.dbo.regra_tributacao_produto as prod "+
"inner join hiper.dbo.regra_tributacao as regra ON prod.id_regra_tributacao = regra.id_regra_tributacao WHERE LEFT(REGRA.nome,2) = 60) "+

"DECLARE @TRIBUT INT "+
"SET @TRIBUT = (SELECT ID_NOP FROM lojamix.dbo.NOP WHERE CODIGO_NOP = 510201) "+
"UPDATE lojamix.dbo.produto SET id_nop_venda = @TRIBUT where id_produto in ( "+
"select prod.id_produto from hiper.dbo.regra_tributacao_produto as prod "+
"inner join hiper.dbo.regra_tributacao as regra ON prod.id_regra_tributacao = regra.id_regra_tributacao WHERE LEFT(REGRA.nome,2) = 00) ";

            objConexao.Conectar();
            com.ExecuteScalar();
            objConexao.Desconectar();

        }
        private void InserHierar()
        {
            SqlCommand com = new SqlCommand();

            com.Connection = objConexao.ObjetoConexao;
            com.CommandText = "UPDATE Lojamix.dbo.hierarquia_produto SET nome = hierarquia.nome, id_hierarquia_produto_pai = hierarquia.id_hierarquia_produto_pai, sequencia=hierarquia.sequencia "+
 "FROM Hiper.dbo.hierarquia_produto AS hierarquia where Lojamix.dbo.hierarquia_produto.id_hierarquia_produto = 1";

            objConexao.Conectar();
            com.ExecuteScalar();
            objConexao.Desconectar();
        }
    }
}
