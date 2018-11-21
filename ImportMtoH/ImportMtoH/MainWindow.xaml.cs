using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ImportMtoH.classes;
using System.Threading;

namespace ImportMtoH
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnImport_Click_1(object sender, RoutedEventArgs e)
        {
            ButtonProgressAssist.SetIsIndeterminate(btnImport, true);

            BancoInfo info = new BancoInfo();
            info.Instancia1 = lblInstancia.Text;
            info.NomeServidor1 = lblNomeServe.Text;

            Conexao conec = new Conexao(info);

            ImportacaoEnti inserirEnti = new ImportacaoEnti(conec);
            ImportacaoProd inserirProd = new ImportacaoProd(conec);
            ImportacaoDoc inserirDoc = new ImportacaoDoc(conec);
            ImportacaoFilial inserirFil = new ImportacaoFilial(conec);
            ImportacaoEmp inserirEmp = new ImportacaoEmp(conec);

            checkEntidade.IsChecked = inserirEnti.ChecarEntidade();

            try
            {
                inserirEmp.InsertCME();
                MessageBox.Show("Empresa Cadastrada");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (checkFilial.IsChecked == true)
            {
                try
                {
                    inserirFil.InserFilial();
                    MessageBox.Show("Filial Importada");
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (checkEntidade.IsChecked == true)
            {
                try
                {
                    inserirEnti.ImportPerf();
                    MessageBox.Show("Clientes e Fornecedores Importado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (checkProd.IsChecked == true)
            {
                try
                {
                    inserirProd.InserEnderec();
                    MessageBox.Show("Produtos Importado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
           
            if (checkDoc.IsChecked == true)
            {
                try
                {
                    inserirDoc.DocumentoDuplicado();
                    MessageBox.Show("Documentos a Pagar/Receber Importado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            ButtonProgressAssist.SetIsIndeterminate(btnImport, false);
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
           
        }
    }
}
