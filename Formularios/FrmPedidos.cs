using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPeca.Formularios
{
    public partial class FrmPedidos : Form
    {
        private VO.Pedidos vo;
        private BE.PedidosBE be;

        public FrmPedidos()
        {
            InitializeComponent();
            InicializarVeiculos();
            liberarEdicao(false);
            carregar();
            carregarCliente();
            carregarPeça();
        }

        private void carregarCliente()
        {
            BE.ClientesBE vo = new BE.ClientesBE(new VO.Clientes());
            cmbCodCliente.DataSource = null;
            cmbCodCliente.DataSource = vo.listar();
            cmbCodCliente.ValueMember = "codigo";
            cmbCodCliente.DisplayMember = "nome";
            cmbCodCliente.Refresh();
        }

        private void carregarPeça()
        {
            BE.PecasBE vo = new BE.PecasBE(new VO.Pecas());
            cmbCodPeça.DataSource = null;
            cmbCodPeça.DataSource = vo.listar();
            cmbCodPeça.ValueMember = "codigo";
            cmbCodPeça.DisplayMember = "nome";
            cmbCodPeça.Refresh();
        }

        private void InicializarVeiculos()
        {
            vo = new VO.Pedidos();
        }

        private void InteractToObject()
        {
            if (!string.IsNullOrEmpty(txtcod.Text))
            {
                vo.codigo = int.Parse(txtcod.Text);
            }
            vo.dataPedido =  DateTime.Parse(txtdata.Text);
            vo.pecas = (VO.Pecas)cmbCodPeça.SelectedItem;
            vo.clientes = (VO.Clientes)cmbCodCliente.SelectedItem;
        }

        private void objecttoInterface()
        {
            txtcod.Text = vo.codigo.ToString();
            txtdata.Text = vo.dataPedido.ToString();
            int index = 0;
            foreach (VO.Pecas item in cmbCodPeça.Items)
            {
                if (item.codigo.Equals(vo.pecas.codigo))
                {
                    cmbCodPeça.SelectedIndex = index;
                    return;
                }
                index++;
            }
            foreach (VO.Clientes item in cmbCodCliente.Items)
            {
                if (item.codigo.Equals(vo.clientes.codigo))
                {
                    cmbCodCliente.SelectedIndex = index;
                    return;
                }
                index++;
            }
        }

        private void limpar()
        {
            txtcod.Text = "";
            txtdata.Text = "";
            cmbCodCliente.SelectedIndex = -1;
            cmbCodPeça.SelectedIndex = -1;
        }

        private void carregar()
        {
            be = new BE.PedidosBE(this.vo);
            lstPedidos.DataSource = null;
            lstPedidos.DataSource = be.listar();
            lstPedidos.ValueMember = "codigo";
            lstPedidos.DisplayMember = "nome";
            lstPedidos.Refresh();
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
                vo = new VO.Pedidos();
                InteractToObject();
                be = new BE.PedidosBE(this.vo);
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
            be = new BE.PedidosBE(this.vo);
            vo = be.carregar(int.Parse(lstPedidos.SelectedValue.ToString()));
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
            be = new BE.PedidosBE(this.vo);
            be.alterar();
            carregar();
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            be = new BE.PedidosBE(this.vo);
            vo = (VO.Pedidos)lstPedidos.SelectedItem;
            be.remover(vo.codigo);
            carregar();
        }

        private void txtcod_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
