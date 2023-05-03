using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AutoPeca.Formularios
{
    public partial class FrmClientes : Form
    {
        private VO.Clientes vo;
        private BE.ClientesBE be;

        public FrmClientes()
        {
            InitializeComponent();
            InicializarVeiculos();
            liberarEdicao(false);
            carregar();
        }

        private void InicializarVeiculos()
        {
            vo = new VO.Clientes();
        }

        private void InteractToObject()
        {
            if (!string.IsNullOrEmpty(txtcod.Text))
            {
                vo.codigo = int.Parse(txtcod.Text);
            }
            vo.nome = txtnome.Text;
            vo.CPF = txtcpf.Text;
            vo.endereco = txtend.Text;
            vo.numero = txtnum.Text;
            vo.cidade = txtcid.Text;
            vo.estado = txtest.Text;
            vo.país = txtpaís.Text;
        }

        private void objecttoInterface()
        {
            txtcod.Text = vo.codigo.ToString();
            txtnome.Text = vo.nome.ToString();
            txtcpf.Text = vo.CPF.ToString();
            txtend.Text = vo.endereco.ToString();
            txtnum.Text = vo.numero.ToString();
            txtcid.Text = vo.cidade.ToString();
            txtest.Text = vo.estado.ToString();
            txtpaís.Text = vo.país.ToString();

        }

        private void limpar()
        {
            txtcod.Text = "";
            txtnome.Text = "";
            txtcpf.Text = "";
            txtend.Text = "";
            txtnum.Text = "";
            txtcid.Text = "";
            txtest.Text = "";
            txtpaís.Text = "";
        }

        private void carregar()
        {
            be = new BE.ClientesBE(this.vo);
            lstClientes.DataSource = null;
            lstClientes.DataSource = be.listar();
            lstClientes.ValueMember = "codigo";
            lstClientes.DisplayMember = "nome";
            lstClientes.Refresh();
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
                vo = new VO.Clientes();
                InteractToObject();
                be = new BE.ClientesBE(this.vo);
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
            be = new BE.ClientesBE(this.vo);
            vo = be.carregar(int.Parse(lstClientes.SelectedValue.ToString()));
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
            be = new BE.ClientesBE(this.vo);
            be.alterar();
            carregar();
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            be = new BE.ClientesBE(this.vo);
            vo = (VO.Clientes)lstClientes.SelectedItem;
            be.remover(vo.codigo);
            carregar();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {

        }
    }
}
