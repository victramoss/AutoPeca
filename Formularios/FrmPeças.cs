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
    public partial class FrmPeças : Form
    {
        private VO.Pecas vo;
        private BE.PecasBE be;

        public FrmPeças()
        {
            InitializeComponent();
            InicializarVeiculos();
            liberarEdicao(false);
            carregar();
            carregarVeiculo();
        }

        private void carregarVeiculo()
        {
            BE.VeiculoBE vo = new BE.VeiculoBE(new VO.Veiculo());
            cmbCodVei.DataSource = null;
            cmbCodVei.DataSource = vo.listar();
            cmbCodVei.ValueMember = "codigo";
            cmbCodVei.DisplayMember = "nome";
            cmbCodVei.Refresh();
        }

        private void InicializarVeiculos()
        {
            vo = new VO.Pecas();
        }

        private void InteractToObject()
        {
            if (!string.IsNullOrEmpty(txtcod.Text))
            {
                vo.codigo = int.Parse(txtcod.Text);
            }
            vo.descricao = txtdesc.Text;
            vo.codigoBarras = txtcodbarras.Text;
            vo.veiculo = (VO.Veiculo)cmbCodVei.SelectedItem;
        }

        private void objecttoInterface()
        {
            txtcod.Text = vo.codigo.ToString();
            txtcodbarras.Text = vo.codigoBarras.ToString();
            txtdesc.Text = vo.descricao.ToString();
            int index = 0;
            foreach (VO.Veiculo item in cmbCodVei.Items)
            {
                if (item.codigo.Equals(vo.veiculo.codigo))
                {
                    cmbCodVei.SelectedIndex = index;
                    return;
                }
                index++;
            }
        }

        private void limpar()
        {
            txtcod.Text = "";
            txtdesc.Text = "";
            txtcodbarras.Text = "";
            cmbCodVei.SelectedIndex = -1;
        }

        private void carregar()
        {
            be = new BE.PecasBE(this.vo);
            lstPecas.DataSource = null;
            lstPecas.DataSource = be.listar();
            lstPecas.ValueMember = "codigo";
            lstPecas.DisplayMember = "descricao";
            lstPecas.Refresh();
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
                vo = new VO.Pecas();
                InteractToObject();
                be = new BE.PecasBE(this.vo);
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
            be = new BE.PecasBE(this.vo);
            vo = be.carregar(int.Parse(lstPecas.SelectedValue.ToString()));
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
            be = new BE.PecasBE(this.vo);
            be.alterar();
            carregar();
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            be = new BE.PecasBE(this.vo);
            vo = (VO.Pecas)lstPecas.SelectedItem;
            be.remover(vo.codigo);
            carregar();
        }
    }
}
