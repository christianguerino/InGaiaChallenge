using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsConsumoWepApi.Models;

namespace WinFormsConsumoWepApi
{
    public partial class Form1 : Form
    {
        #region metodos privados

        private void LoadData()
        {
            ClearForm();

            #region obtendo informacoes das Musicas

            TemperatureAndMusicList info = null;

            try
            {
                info = new WebApiClient.MusicApi().GetInformationByCity(txtCidade.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}.");
                return;
            }


            if (info != null && info.musicList != null && info.musicList.Count > 0)
            {
                dgMusicas.DataSource = info.musicList;
            }
            else
            {
                MessageBox.Show($"Não foram encontradas Músicas para a cidade de {txtCidade.Text}.");
            }

            tStripStatusInfo.Text = $"A temperatura agora em {txtCidade.Text} é de {info.temperature.ToString("N0")}º. Ouça músicas da categoria {info.musicCategory}.";

            #endregion

            #region obtendo estatisticas

            TemperatureStatistics stat = null;

            try
            {
                stat = new WebApiClient.MusicApi().GetStatisticsByCity(txtCidade.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}.");
                return;
            }

            if (stat != null)
            {
                lstboxEstatisticas.Items.Add($"Primeira Consulta: {stat.firstDate.ToString("dd/MM/yyyy")}");
                lstboxEstatisticas.Items.Add($"Última Consulta: {stat.lastDate.ToString("dd/MM/yyyy")}");
                lstboxEstatisticas.Items.Add($"Temperatura mais baixa registrada: {stat.minTemp.ToString("N0")}");
                lstboxEstatisticas.Items.Add($"Temperatura mais alta registrada: {stat.maxTemp.ToString("N0")}");
                lstboxEstatisticas.Items.Add($"Média de Temperatura: {stat.avgTemp.ToString("N0")}");
                lstboxEstatisticas.Items.Add($"Total de Consultas: {stat.total.ToString("N0")}");
            }
            else
            {
                lstboxEstatisticas.Items.Add("Sem Estatísticas para esta cidade.");
            }

            #endregion
        }

        private void ClearForm()
        {
            dgMusicas.DataSource = null;
            dgMusicas.AutoGenerateColumns = false;
            tStripStatusInfo.Text = string.Empty;
            lstboxEstatisticas.Items.Clear();
        }

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region eventos

        private void btnMostrarMusicas_Click(object sender, EventArgs e)
        {
            #region validacoes

            if (txtCidade.Text.Length <= 0)
            {
                MessageBox.Show("Por favor, preencha o campo Cidade.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtCidade.Text.Length <= 2)
            {
                MessageBox.Show("Campo Cidade é Inválido. Entre com mais de 3 letras.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            #endregion

            LoadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClearForm();
            txtCidade.Text = string.Empty;
        }

        #endregion
    }
}
