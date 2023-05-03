﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoPeca.Formularios
{
    public partial class Principal : Form
    {
        private int childFormNumber = 0;

        public Principal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            FrmVeiculo veiculos = new FrmVeiculo();
            veiculos.MdiParent = this;
            veiculos.Text = "Janela " + childFormNumber++;
            veiculos.Show();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPeças veiculos = new FrmPeças();
            veiculos.MdiParent = this;
            veiculos.Text = "Janela " + childFormNumber++;
            veiculos.Show();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes veiculos = new FrmClientes();
            veiculos.MdiParent = this;
            veiculos.Text = "Janela " + childFormNumber++;
            veiculos.Show();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPedidos veiculos = new FrmPedidos();
            veiculos.MdiParent = this;
            veiculos.Text = "Janela " + childFormNumber++;
            veiculos.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFabricante veiculos = new FrmFabricante();
            veiculos.MdiParent = this;
            veiculos.Text = "Janela " + childFormNumber++;
            veiculos.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }


    }
}
