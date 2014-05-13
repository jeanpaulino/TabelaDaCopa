using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Threading.Tasks;
using Microsoft.Phone.Net.NetworkInformation;
using TabelaDaCopa.Controllers;

namespace TabelaDaCopa.Views
{
    public partial class Groups : PhoneApplicationPage
    {
        ProgressIndicator pi = new ProgressIndicator() { IsVisible = false, IsIndeterminate = true, Text = "Aguarde, carregando os dados..." };

        public Groups()
        {
            InitializeComponent();

            SystemTray.SetProgressIndicator(this, pi);

            pi.IsVisible = false;

        }

        public async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            await carregarGrupos();
        }

        public async Task carregarGrupos()
        {
            if (DeviceNetworkInformation.IsWiFiEnabled || DeviceNetworkInformation.IsCellularDataEnabled || System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    pi.IsVisible = true;

                    var grupos = await RequestHttp.GetGrupos(App.WebServiceBaseAddress, App.WebServiceToken);

                    listaGrupos.ItemsSource = grupos;

                    pi.IsVisible = false;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                MessageBox.Show("Parece que você não está conectado!\nPor favor, conecte-se usando a rede de dados do celular ou uma rede wi-fi...", "Oooops...", MessageBoxButton.OK);
            }
        }

        private void listaGrupos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}