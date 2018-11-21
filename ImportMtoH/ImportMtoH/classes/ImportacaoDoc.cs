using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportMtoH.classes
{
    class ImportacaoDoc
    {
        private Conexao ObjConexao;
        public ImportacaoDoc(Conexao conexao)
        {
            ObjConexao = conexao;
        }
        public void DocumentoDuplicado()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ObjConexao.ObjetoConexao;

            cmd.CommandText = "UPDATE DOCUMENTO_PAGAR SET NUMERO_DOCUMENTO_PAGAR = ID_DOCUMENTO_PAGAR WHERE NUMERO_DOCUMENTO_PAGAR "+
"IN(select numero_documento_pagar from documento_pagar group by numero_documento_pagar having COUNT(numero_documento_pagar) > 1)";

            ObjConexao.Conectar();
            cmd.ExecuteScalar();
            ObjConexao.Desconectar();
            ImportTiDoFi();

        }
        public void ImportTiDoFi()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ObjConexao.ObjetoConexao;

            cmd.CommandText = "SET IDENTITY_INSERT Lojamix.dbo.tipo_documento_financeiro ON "+
"INSERT INTO Lojamix.dbo.tipo_documento_financeiro( "+
"id_tipo_documento_financeiro, nome, inativo, id_tipo_lancamento_financeiro_abertura, id_tipo_lancamento_financeiro_quitacao, tipo_titulo_credito, "+
"permite_recebimento_pdv, id_tipo_lancamento_financeiro_acrescimo, id_tipo_lancamento_financeiro_desconto) "+
"SELECT id_tipo_documento_financeiro, nome, inativo, id_tipo_lancamento_financeiro_abertura, id_tipo_lancamento_financeiro_quitacao, "+
"tipo_titulo_credito, permite_recebimento_pdv, id_tipo_lancamento_financeiro_acrescimo, 2 "+
"FROM Hiper.dbo.tipo_documento_financeiro where id_tipo_documento_financeiro > 4 "+
"SET IDENTITY_INSERT Lojamix.dbo.tipo_documento_financeiro OFF";
            ObjConexao.Conectar();
            cmd.ExecuteScalar();
            ObjConexao.Desconectar();
            ImportDocRec();
        }
        public void ImportDocRec()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ObjConexao.ObjetoConexao;

            cmd.CommandText = "SET IDENTITY_INSERT Lojamix.dbo.documento_receber ON "+
                "Alter Table Lojamix.dbo.documento_receber "+
    "NOCHECK Constraint All "+
"Insert into Lojamix.dbo.documento_receber( "+
"id_documento_receber, id_tipo_documento_financeiro, id_entidade, id_filial_geracao, id_usuario_cadastro, "+
"data_hora_cadastro, data_emissao, data_vencimento, data_vencimento_original, id_usuario_alteracao, data_hora_alteracao, id_usuario_quitacao, data_quitacao, "+
"id_usuario_estorno, data_hora_estorno, valor, saldo, situacao, numero_documento_receber, id_carne, codbarra_carne, tem_boleto, id_conta, id_ordem_servico, "+
"Observacao, codigo_importacao, nosso_numero, id_comanda, situacao_boleto, id_comanda_forma_pagamento, quitacao_automatica, id_lote_comissao, id_pacote_entidade_forma_pgto, "+
"id_lancamento_documento_receber_origem, id_lancamento_vale_credito) "+
"SELECT id_documento_receber, id_tipo_documento_financeiro, id_entidade, id_filial_geracao, id_usuario_cadastro, "+
"data_hora_cadastro, data_emissao, data_vencimento, data_vencimento_original, id_usuario_alteracao, data_hora_alteracao, id_usuario_quitacao, data_quitacao, "+
"id_usuario_estorno, data_hora_estorno, valor, saldo, situacao, numero_documento_receber, null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null "+
"FROM Hiper.dbo.documento_receber "+
"Alter Table Lojamix.dbo.documento_receber "+
    "CHECK Constraint All "+
"SET IDENTITY_INSERT Lojamix.dbo.documento_receber OFF";
            ObjConexao.Conectar();
            cmd.ExecuteScalar();
            ObjConexao.Desconectar();
            ImportDocPag();
        }
        public void ImportDocPag()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ObjConexao.ObjetoConexao;

            cmd.CommandText = "SET IDENTITY_INSERT Lojamix.dbo.documento_pagar ON "+
"Alter Table Lojamix.dbo.documento_pagar "+
    "NOCHECK Constraint All "+
"INSERT INTO Lojamix.dbo.documento_pagar(id_documento_pagar, id_tipo_documento_financeiro, id_entidade, id_filial_geracao, id_usuario_cadastro, "+
"data_hora_cadastro, data_emissao, data_vencimento, data_vencimento_original, id_usuario_quitacao, data_quitacao, id_usuario_estorno, data_hora_estorno, "+
"valor, saldo, situacao, autorizado, id_usuario_autorizacao, data_hora_autorizacao, compromisso, id_usuario_compromisso, data_hora_compromisso, "+
"id_usuario_alteracao, data_hora_alteracao, numero_documento_pagar, id_centro_custo, id_conta, id_importacao, Observacao) "+
"Select distinct id_documento_pagar,id_tipo_documento_financeiro,id_entidade, id_filial_geracao, id_usuario_cadastro, "+
"data_hora_cadastro, data_emissao, data_vencimento, data_vencimento_original, id_usuario_quitacao, data_quitacao, id_usuario_estorno,data_hora_estorno, "+
"valor, saldo, situacao, autorizado, id_usuario_autorizacao, data_hora_autorizacao, compromisso, id_usuario_compromisso, data_hora_compromisso, "+
"id_usuario_alteracao, data_hora_alteracao, numero_documento_pagar, id_centro_custo, NULL, NULL, descricao "+
"FROM Hiper.dbo.documento_pagar "+
"Alter Table Lojamix.dbo.documento_pagar "+
    "CHECK Constraint All "+
"SET IDENTITY_INSERT Lojamix.dbo.documento_pagar OFF";
            ObjConexao.Conectar();
            cmd.ExecuteScalar();
            ObjConexao.Desconectar();
            UpdateCentro();
        }
        public void UpdateCentro()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ObjConexao.ObjetoConexao;

            cmd.CommandText = "UPDATE Lojamix.dbo.centro_custo "+
"SET id_centro_custo = custo.id_centro_custo,nome = custo.nome,id_centro_custo_pai = custo.id_centro_custo_pai,sequencia = custo.sequencia "+
"FROM Hiper.dbo.centro_custo AS custo "+
"WHERE custo.id_centro_custo = '1'";

            ObjConexao.Conectar();
            cmd.ExecuteScalar();
            ObjConexao.Desconectar();
            ImportCentro();
        }
        public void ImportCentro()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ObjConexao.ObjetoConexao;

            cmd.CommandText = "INSERT INTO Lojamix.dbo.centro_custo SELECT id_centro_custo,nome,id_centro_custo_pai,sequencia FROM Hiper.dbo.centro_custo AS custo where custo.id_centro_custo <> '1'";

            ObjConexao.Conectar();
            cmd.ExecuteScalar();
            ObjConexao.Desconectar();
        }
    }
}