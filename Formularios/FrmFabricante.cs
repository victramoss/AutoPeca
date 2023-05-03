using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPeca.Formularios
{
    public partial class FrmFabricante : Form
    {
        private VO.Fabricante fab;
        private BE.FabricanteBE be;

        public FrmFabricante()
        {
            InitializeComponent();
            InicializarVeiculos();
            liberarEdicao(false);
            carregar();
        }

        private void InicializarVeiculos()
        {
            fab = new VO.Fabricante();
        }

        private void InteractToObject()
        {
            if (!string.IsNullOrEmpty(txtcod.Text))
            {
                fab.codigo = int.Parse(txtcod.Text);
            }
            fab.nome = txtnome.Text;
            fab.descricao = txtdesc.Text;
        }

        private void objecttoInterface()
        {
            txtcod.Text = fab.codigo.ToString();
            txtdesc.Text = fab.descricao.ToString();
            txtnome.Text = fab.nome.ToString();
        }

        private void limpar()
        {
            txtcod.Text = "";
            txtnome.Text = "";
            txtdesc.Text = "";
        }

        private void carregar()
        {
            be = new BE.FabricanteBE(this.fab);
            lstfabricante.DataSource = null;
            lstfabricante.DataSource = be.listar();
            lstfabricante.ValueMember = "codigo";
            lstfabricante.DisplayMember = "nome";
            lstfabricante.Refresh();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpar();
            liberarEdicao(false);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                fab = new VO.Fabricante();
                InteractToObject();
                be = new BE.FabricanteBE(this.fab);
                be.incluir();
                carregar();
                limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro No Aplicativo");

            }
        }

        private void btnselecionar_Click(object sender, EventArgs e)
        {
            be = new BE.FabricanteBE(this.fab);
            fab = be.carregar(int.Parse(lstfabricante.SelectedValue.ToString()));
            objecttoInterface();
            liberarEdicao(true);
        }

        private void liberarEdicao(bool habilita)
        {
            btnGravar.Enabled = !habilita;
            btnEditar.Enabled = habilita;
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            InteractToObject();
            be = new BE.FabricanteBE(this.fab);
            be.alterar();
            carregar();
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            be = new BE.FabricanteBE(this.fab);
            fab = (VO.Fabricante)lstfabricante.SelectedItem;
            be.remover(fab.codigo);
            carregar();
        }
    }
}

