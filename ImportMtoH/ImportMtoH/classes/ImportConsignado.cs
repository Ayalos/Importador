using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ImportMtoH.classes
{
    class ImportConsignado
    {
        private Conexao ObjConexao;
        public ImportConsignado(Conexao conexao)
        {
            ObjConexao = conexao;
        }
        public void ImportarConsignado()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ObjConexao.ObjetoConexao;

            cmd.CommandText = "set identity_insert lojamix.dbo.consignacao_venda on " +
"insert into lojamix.dbo.consignacao_venda(id_consignacao_venda, id_entidade_cliente, id_filial, id_local_estoque, situacao, codigo_consignacao, data_hora_cadastro, id_usuario_cadastro, data_hora_alteracao, id_usuario_alteracao, data_hora_cancelamento, id_usuario_cancelamento, data_previsao_devolucao, data_hora_finalizacao, id_usuario_vendedor, id_documento_estoque, observacao, id_pedido_venda) "+
"select consi.id_consignacao,id_entidade,id_filial,1,situacao,consi.id_consignacao,data_hora_cadastro, "+
"id_usuario_cadastro,data_hora_alteracao,id_usuario_alteracao,null, null, CURRENT_TIMESTAMP,null,null,null,observacao,pedido.id_pedido_venda from hiper.dbo.consignacao as consi "+
"left join hiper.dbo.consignacao_pedido_venda as pedido ON pedido.id_consignacao = consi.id_consignacao "+
"set identity_insert lojamix.dbo.consignacao_venda off";

            ObjConexao.Conectar();
            cmd.ExecuteScalar();
            ObjConexao.Desconectar();
            ImportarConsignadoItem();

        }
        private void ImportarConsignadoItem()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ObjConexao.ObjetoConexao;

            cmd.CommandText = "set identity_insert lojamix.dbo.consignacao_venda_item on " +
"insert into lojamix.dbo.consignacao_venda_item(id_consignacao_venda_item, id_consignacao_venda, id_produto, id_variacao, sequencia_item, valor_unitario, valor_unitario_com_desconto, valor_total_bruto, valor_total_liquido, quantidade_original, quantidade_devolvida, quantidade_venda, observacao, id_nop_venda) " +
"select id_item_consignacao, id_consignacao, id_produto, id_variacao, ROW_NUMBER() OVER(PARTITION BY id_consignacao order by id_item_consignacao), " +
"valor_unitario,valor_unitario,valor_total,valor_total,quantidade,quantidade_retornada,quantidade_faturada,'',null from hiper.dbo.item_consignacao "+
"set identity_insert lojamix.dbo.consignacao_venda_item off";

            ObjConexao.Conectar();
            cmd.ExecuteScalar();
            ObjConexao.Desconectar();
        }
    }
}
