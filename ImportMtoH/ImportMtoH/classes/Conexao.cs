using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ImportMtoH.classes
{
    class Conexao
    {

        
        // ATRIBUTO RESPONSÁVEL POR MANTER OS DADOS DA CONEXÃO

        private String _strConexao;

        // ATRIBUTO PARA EFETUAR CONEXÃO 

        private SqlConnection _conexao;

        

        // METODO PARA FAZER CONEXAO

        public Conexao(BancoInfo info)
        {

            this._conexao = new SqlConnection();
           
            this._strConexao = "Data Source="+info.NomeServidor1+"\\"+info.Instancia1+";Initial Catalog=Hiper;Integrated Security=True";

            this._conexao.ConnectionString = _strConexao;
            
        }



        // IMPLEMENTA O GET AND SET PARA RETORNA PARA METODO QUE FAZ A CONEXAO

        public String strConexao

        {

            get { return this._strConexao; }

            set { this._strConexao = value; }

        }



        // IMPLEMENTA O GET AND SET PARA RETORNA O OBJETO DA CONEXÃO

        public SqlConnection ObjetoConexao

        {

            get { return this._conexao; }

            set { this._conexao = value; }

        }

        // METODO PUBLICO PARA ABRIR CONEXÃO

        public void Conectar()

        {
            // ACESSANDO O METODO PRIVADO DE ABRIR CONEXÃO
                this._conexao.Open();
        }



        // METODO PUBLICO PARA FECHAR CONEXÃO

        public void Desconectar()

        {

            // ACESSANDO O METODO PRIVADO DE FECHAR CONEXÃO

            this._conexao.Close();

        }
    }
}
