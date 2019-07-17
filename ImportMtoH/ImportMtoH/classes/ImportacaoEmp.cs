using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportMtoH.classes
{
    class ImportacaoEmp
    {
        private Conexao ObjConexao;
        public ImportacaoEmp(Conexao conexao)
        {
            ObjConexao = conexao;
        }
        public void InsertCME()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ObjConexao.ObjetoConexao;

            cmd.CommandText = "ALTER TABLE LOJAMIX.DBO.CME " +
                "NOCHECK CONSTRAINT ALL " +
                "INSERT INTO Lojamix.dbo.cme select id_cme,nome,operacao,id_cme_contrapartida,tipo_valoracao, permite_manipulacao_valor,tipo_agrupamento_itens_impressao FROM Hiper.dbo.cme " +
"where Hiper.dbo.cme.id_cme not in(select id_cme FROM Lojamix.dbo.cme) " +
"ALTER TABLE LOJAMIX.DBO.CME " +
"CHECK CONSTRAINT ALL";

            ObjConexao.Conectar();
            cmd.ExecuteScalar();
            ObjConexao.Desconectar();
            UpdateEmp();
        }
        private void UpdateEmp()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ObjConexao.ObjetoConexao;

            cmd.CommandText = "UPDATE Lojamix.dbo.empresa SET nome = emp.nome from Hiper.dbo.empresa AS emp where emp.id_empresa = 1  ";

            ObjConexao.Conectar();
            cmd.ExecuteScalar();
            ObjConexao.Desconectar();
            UpdateFilial();
        }
       /* private void UpdateConfEmp()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ObjConexao.ObjetoConexao;

            cmd.CommandText = "alter table lojamix.dbo.configuracao_empresa " +
                "nocheck constraint all " +
                "UPDATE Lojamix.dbo.configuracao_empresa SET id_empresa=confemp.id_empresa, id_cme_venda=confemp.id_cme_venda,id_cme_devolucao=confemp.id_cme_devolucao, " +
"qtd_maxima_movim_estoque = confemp.qtd_maxima_movim_estoque,id_nop_faturamento_icms_normal = 3, id_nop_faturamento_icms_st = 7," +
"id_nop_faturamento_pdv_icms_normal = confemp.id_nop_faturamento_pdv_icms_normal, id_nop_faturamento_pdv_icms_st = confemp.id_nop_faturamento_pdv_icms_st, " +
"id_tipo_documento_financeiro_faturamento_pedido_venda = confemp.id_tipo_documento_financeiro_faturamento_pedido_venda, id_tipo_documento_financeiro_cheque = confemp.id_tipo_documento_financeiro_cheque, " +
"id_tipo_documento_financeiro_pendencia = confemp.id_tipo_documento_financeiro_pendencia,ip_host_unife = confemp.ip_host_unife, database_unife = confemp.database_unife,usuario_unife = confemp.usuario_unife, " +
"porta_unife = confemp.porta_unife, id_tipo_documento_financeiro_comissao = confemp.id_tipo_documento_financeiro_comissao, id_nop_devolucao_venda = confemp.id_nop_devolucao_venda, " +
"id_potencial_entidade_padrao = confemp.id_potencial_entidade_padrao, percentual_juros_receber = confemp.percentual_juros_receber, percentual_multa_receber = confemp.percentual_multa_receber, " +
"considerar_sabado_encargos_receber = confemp.considerar_sabado_encargos_receber, considerar_domingo_encargos_receber = confemp.considerar_domingo_encargos_receber, " +
"considerar_feriado_encargos_receber = confemp.considerar_feriado_encargos_receber,registrar_contas_pagar_compromisso = confemp.registrar_contas_pagar_compromisso, " +
"registrar_contas_pagar_autorizado = confemp.registrar_contas_pagar_autorizado, id_nop_venda_ecf = confemp.id_nop_venda_ecf,id_tipo_lancamento_juro = NULL, id_tipo_lancamento_multa = NULL, " +
"id_cfop_faturamento_pdv_icms_st = 5405, id_cfop_faturamento_pdv_icms_normal = 5102, id_nop_ordem_servico_dentro_uf = 3, id_nop_ordem_servico_fora_uf = 5, id_cme_entrada_reserva = NULL, " +
"id_cme_saida_reserva = NULL, id_nop_consignacao_entrada = 28, id_nop_consignacao_saida = 24, id_conta_contabil_pendencia = NULL, id_conta_contabil_cheque = NULL, " +
"usar_ean_padrao = 0, cod_pais_ean_padrao = NULL, cod_empresa_ean_padrao = NULL, id_nop_devolucao_compra = 17, id_conta_contabil_cartao_credito = NULL, " +
"id_tipo_documento_financeiro_cartao_credito = 3 , integrar_cartao_credito_pdv_no_financeiro = 0 FROM Hiper.dbo.configuracao_empresa AS confemp " +
"alter table lojamix.dbo.configuracao_empresa " +
"check constraint all";

            ObjConexao.Conectar();
            cmd.ExecuteScalar();
            ObjConexao.Desconectar();
            UpdateFilial();
        }*/
        private void UpdateFilial()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ObjConexao.ObjetoConexao;

            cmd.CommandText = "UPDATE Lojamix.dbo.filial SET id_empresa=filia.id_empresa, codigo_filial=filia.codigo_filial,razao_social=filia.razao_social,nome_fantasia=filia.nome_fantasia, apelido=filia.apelido, " +
"cnpj = filia.cnpj,ie = filia.ie,logradouro = filia.logradouro, endereco_numero = filia.endereco_numero,complemento = filia.complemento,bairro = filia.bairro, cep = filia.cep, id_cidade = filia.id_cidade, " +
"fone1_ddd = filia.fone1_ddd,fone1_numero = filia.fone1_numero,fone2_ddd = filia.fone2_ddd,fone2_numero = filia.fone2_numero,site = filia.site, email = filia.email,im = filia.im,suframa = filia.suframa, " +
"id_perfil_sped = filial.id_perfil_sped,tipo_atividade = filia.tipo_atividade,cnpj_portal = 1,nome_certificado = NULL,id_csc = Unife.identificacao_contribuinte_numero,csc = identificacao_contribuinte_token, " +
"horario_atendimento_inicio = '08:00:00.0000000',horario_atendimento_fim = '21:00:00.0000000',imagem_logo = NULL,id_entidade = NULL " +
"FROM Hiper.dbo.filial AS filia Inner join Unife.dbo.emissor_nfe As Unife ON Unife.cnpj_emissor = cnpj where lojamix.dbo.filial.id_filial = 1";

            ObjConexao.Conectar();
            cmd.ExecuteScalar();
            ObjConexao.Desconectar();
            UpdateConfFilial();
        }
        private void UpdateConfFilial()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ObjConexao.ObjetoConexao;

            cmd.CommandText = "UPDATE Lojamix.dbo.configuracao_filial SET id_filial = confilial.id_filial, id_endereco_estoque_vendas = confilial.id_endereco_estoque_vendas, tipo_preco_venda = 1, " +
"codigo_regime_tributario = confilial.codigo_regime_tributario, situacao_tributaria_pis = confilial.situacao_tributaria_pis, aliquota_pis = confilial.aliquota_pis, " +
"situacao_tributaria_cofins = confilial.situacao_tributaria_cofins,aliquota_cofins = confilial.aliquota_cofins, alterna_preco_varejo_atacado = 0, " +
"horario_verao_ativado = 0, mensagem_cupom_fiscal = '',id_regra_tributacao = confilial.id_regra_tributacao, id_situacao_tributaria_simples_nacional = confilial.id_situacao_tributaria_simples_nacional, " +
"aliquota_icms_simples_nacional = confilial.aliquota_icms_simples_nacional,tipo_tef = confilial.tipo_tef, cupom_mania_ativo = 0, forcar_identificacao_cliente_pdv = confilial.forcar_identificacao_cliente_pdv, " +
"minas_legal_ativo = 0, cod_regra_inc_tributaria = NULL,cod_metodo_apropr_credito = NULL, cod_tipo_contrib_apurada = NULL, cod_criterio_escrituracao = NULL, usar_campo_observacao = NULL, texto_campo_observacao = '', " +
"tipo_mensagem_promocional = '',ConcessaoCreditoDF = NULL, formato_impressao = NULL, ambiente = NULL, imagem_logo = NULL, arquivo_certificado_digital = NULL, senha_certificado_digital = NULL, versao = 4, email_nfe_automatico = 1, " +
"texto_padrao_email_nfe = NULL, texto_observacao_item_icms_st = NULL, ambiente_servico = NULL, id_modelo_documento_servico = NULL, consultar_num_serie_pdv = 0, enquadramento_simples_nacional = 1, " +
"id_local_estoque_consignacao = NULL, id_local_estoque_loja_virtual = NULL, id_local_estoque_pedido_venda = NULL, id_local_ordem_servico = NULL,url_n49 = null,merchant_id = null, aliquota_servico = NULL, " +
"url_loja_virtual = NULL, consumer_key = NULL, consumer_secret = NULL, integrar_loja_virtual = 0, ultimo_nsu_nfe_destinada = NULL, id_tabela_preco_loja_virtual = NULL, token = NULL, " +
"usuario_loja_virtual = NULL, senha_loja_virtual = NULL, url_api_umovme = NULL, token_api_umovme = NULL, integrar_forca_vendas = 0, controlar_estoque_pdv = 0, login_inicial = 0, habilitar_controle_mesas = 0 " +
"FROM Hiper.dbo.configuracao_filial AS confilial " +
"WHERE Lojamix.dbo.configuracao_filial.id_filial = 1";

            ObjConexao.Conectar();
            cmd.ExecuteScalar();
            ObjConexao.Desconectar();   
        }
    }
}
