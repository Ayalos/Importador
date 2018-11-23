using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportMtoH.classes
{
    class ImportacaoFilial
    {
        private Conexao ObjConexao;
        public ImportacaoFilial(Conexao conexao) {
            ObjConexao = conexao;
        }
        public void InserFilial()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ObjConexao.ObjetoConexao;

            cmd.CommandText = "Alter table Lojamix.dbo.filial "+
    "NOCHECK Constraint ALL "+
"set IDENTITY_INSERT lojamix.dbo.filial ON "+
"INSERT INTO Lojamix.dbo.filial(id_filial, id_empresa, codigo_filial, razao_social, nome_fantasia, apelido, cnpj, ie, logradouro, endereco_numero, complemento, bairro, cep, id_cidade, fone1_ddd, "+
"fone1_numero, fone2_ddd, fone2_numero, site, email, im, suframa, id_perfil_sped, tipo_atividade, cnpj_portal, nome_certificado, id_csc, csc, horario_atendimento_inicio, horario_atendimento_fim, imagem_logo, id_entidade) "+
"SELECT id_filial, id_empresa, codigo_filial, razao_social, nome_fantasia, apelido, cnpj, ie, logradouro, endereco_numero, complemento, bairro, cep, id_cidade, "+
"fone1_ddd, fone1_numero, fone2_ddd, fone2_numero, site, email, im, suframa, id_perfil_sped, tipo_atividade,1,'',Unife.identificacao_contribuinte_numero, identificacao_contribuinte_token,'08:00:00.0000000', "+
"'21:00:00.0000000',NULL,NULL FROM Hiper.dbo.filial Inner join Unife.dbo.emissor_nfe As Unife ON Unife.cnpj_emissor = cnpj where id_filial <> 1 "+
"set IDENTITY_INSERT lojamix.dbo.filial OFF "+
"Alter table Lojamix.dbo.filial "+
"    CHECK Constraint ALL";

            ObjConexao.Conectar();
            cmd.ExecuteScalar();
            ObjConexao.Desconectar();
            InserConfFilial();
        }
        private void InserConfFilial()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ObjConexao.ObjetoConexao;

            cmd.CommandText = "Alter table Lojamix.dbo.configuracao_filial "+
    "Nocheck Constraint ALL "+
"Insert into Lojamix.dbo.configuracao_filial SELECT confilial.id_filial, confilial.id_endereco_estoque_vendas, 1, "+
"confilial.codigo_regime_tributario, confilial.situacao_tributaria_pis, confilial.aliquota_pis, "+
"confilial.situacao_tributaria_cofins,confilial.aliquota_cofins,0, "+ 
"0, '',confilial.id_regra_tributacao,confilial.id_situacao_tributaria_simples_nacional,confilial.aliquota_icms_simples_nacional, "+
"confilial.tipo_tef,  0, confilial.forcar_identificacao_cliente_pdv, 0, NULL, "+
"NULL,  NULL,  NULL,  NULL, '', '', "+
"NULL, NULL, NULL, NULL, NULL, NULL,4, 1, "+
"NULL, NULL, NULL,  NULL, 0,  1, "+
"NULL, NULL, NULL, NULL,NULL, NULL, NULL, "+
"NULL, NULL, NULL,0, NULL, NULL, NULL, "+
"NULL, NULL,  NULL, NULL,  0,  0,  0, 0 "+
"FROM Hiper.dbo.configuracao_filial AS confilial "+
"where confilial.id_filial <> 1 "+
"Alter table Lojamix.dbo.configuracao_filial "+
    "Check Constraint ALL";

            ObjConexao.Conectar();
            cmd.ExecuteScalar();
            ObjConexao.Desconectar();
        }

    }
}
