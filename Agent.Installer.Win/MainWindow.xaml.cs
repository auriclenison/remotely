using Remotely.Agent.Installer.Win.Utilities;
using Remotely.Agent.Installer.Win.ViewModels;
using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace Remotely.Agent.Installer.Win
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            if (CommandLineParser.CommandLineArgs.ContainsKey("quiet"))
            {
                Hide();
                ShowInTaskbar = false;
                _ = new MainWindowViewModel().Init();
            }
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await (DataContext as MainWindowViewModel).Init();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ShowServerUrlHelp(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Adicione Aqui a Url de Acesso Remoto do Servidor ex: https:\\acessoremotologicom.com.br","Site de Acesso Remoto", 
                MessageBoxButton.OK, 
                MessageBoxImage.Information);
        }

        private void ShowOrganizationIdHelp(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Adicione aqui a id da Organização Copie a informação do Site na opção Organização", 
                "Organização ID", 
                MessageBoxButton.OK, 
                MessageBoxImage.Information);
        }
        private void ShowSupportShortcutHelp(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Se selecionado, o instalador criará um atalho na área de trabalho para a página Obter suporte para este dispositivo.", 
                "Criar Atalho",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}
