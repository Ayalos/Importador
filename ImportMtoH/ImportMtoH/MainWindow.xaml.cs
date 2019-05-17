using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using ImportMtoH.classes;


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
            ImportConsignado inserirCon = new ImportConsignado(conec);

            checkEntidade.IsChecked = inserirEnti.ChecarEntidade();
            if (checkHiper.IsChecked == true)
            {
                try
                {
                    inserirEmp.InsertCME();
                    MessageBox.Show("Empresa Cadastrada");
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                if (checkFilial.IsChecked == true)
                {
                    try
                    {
                        inserirFil.InserFilial();
                    } catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                if (checkEntidade.IsChecked == true)
                {
                    try
                    {
                        inserirEnti.ImportPerf();
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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

                if(checkCon.IsChecked == true)
                {
                    try
                    {
                        inserirCon.ImportarConsignado();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

                MessageBox.Show("Importação do Hiper Legado concluída");
            }
            ImportMiniEnti InserMiniEnti = new ImportMiniEnti(conec);
            ImportMiniProd InserMiniProd = new ImportMiniProd(conec);
            if (checkHiperMini.IsChecked == true)
            {
                if (checkMiniEnt.IsChecked == true)
                {
                    try
                    {
                        InserMiniEnti.InsertPerf();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                if (checkMiniProd.IsChecked == true)
                {
                    try
                    {
                        InserMiniProd.InsertMarca();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                MessageBox.Show("Importação do Hiper Mini Concluída");
            }
            ButtonProgressAssist.SetIsIndeterminate(btnImport, false);
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
           
        }

        private void CheckHiper_Click(object sender, RoutedEventArgs e)
        {
            if (checkHiper.IsChecked==true) {
                checkFilial.Visibility = Visibility.Visible;
                checkEntidade.Visibility = Visibility.Visible;
                checkProd.Visibility = Visibility.Visible;
                checkDoc.Visibility = Visibility.Visible;
                checkCon.Visibility = Visibility.Visible;
                checkHiperMini.IsEnabled = false;
            }
            else
            {
                checkFilial.Visibility = Visibility.Hidden;
                checkEntidade.Visibility = Visibility.Hidden;
                checkProd.Visibility = Visibility.Hidden;
                checkDoc.Visibility = Visibility.Hidden;
                checkCon.Visibility = Visibility.Hidden;
                checkHiperMini.IsEnabled = true;
            }
        }

        private void CheckHiperMini_Click(object sender, RoutedEventArgs e)
        {
            if (checkHiperMini.IsChecked == true) {
                checkMiniEnt.Visibility = Visibility.Visible;
                checkMiniProd.Visibility = Visibility.Visible;

                checkHiper.IsEnabled = false;
            }
            else
            {
                checkMiniEnt.Visibility = Visibility.Hidden;
                checkMiniProd.Visibility = Visibility.Hidden;

                checkHiper.IsEnabled = true;

            }
        }

    }
}
