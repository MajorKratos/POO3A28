using POO3A28.BLL;
using POO3A28.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO3A28
{
    public partial class Form1 : Form
    {
        private DTO.MusicaDTO MusicaDTO = new MusicaDTO();
        private tbl_MusicaBLL tbl_MusicaBLL = new tbl_MusicaBLL();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GridMusica.DataSource = tbl_MusicaBLL.PesquisarMusica();
        }

        private void button4_Click(object sender, EventArgs e) { Close(); }

        bool inserting = false;

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (inserting)
            {
                try
                {
                    MusicaDTO.Nome = txtTitulo.Text.ToString();
                    MusicaDTO.NomeAutor = txtAutor.Text.ToString();
                    MusicaDTO.IdCD = int.Parse(txtCDID.Text);
                    MusicaDTO.IdGravadora = int.Parse(txtGravadora.Text.ToString());

                    tbl_MusicaBLL.InserirMusica(MusicaDTO);
                    MessageBox.Show("Inserção Realizada com Sucesso. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GridMusica.DataSource = tbl_MusicaBLL.PesquisarMusica();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txtTitulo.Enabled = false;
                txtAutor.Enabled = false;
                txtCDID.Enabled = false;
                txtGravadora.Enabled = false;
                inserting = false;
                btnInsert.Text = "Inserir";
            }
            else
            {
                txtTitulo.Enabled = true;
                txtAutor.Enabled = true;
                txtCDID.Enabled = true;
                txtGravadora.Enabled = true;

                txtTitulo.Text = "";
                txtAutor.Text = "";
                txtCDID.Text = "";
                txtGravadora.Text = "";

                inserting = true;
                btnInsert.Text = "Confirmar";
            }
        }
        bool confirmDelete = false;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                MusicaDTO.Nome = txtTitulo.Text.ToString();
                MusicaDTO.NomeAutor = txtAutor.Text.ToString();
                MusicaDTO.IdCD = int.Parse(txtCDID.Text);
                MusicaDTO.IdGravadora = int.Parse(txtGravadora.Text.ToString());
                MusicaDTO.IdMusica = int.Parse(lblID.Text.ToString());

                tbl_MusicaBLL.AlterarMusica(MusicaDTO);
                MessageBox.Show("Alteração Realizada com Sucesso. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GridMusica.DataSource = tbl_MusicaBLL.PesquisarMusica();

                txtTitulo.Enabled = false;
                txtAutor.Enabled = false;
                txtCDID.Enabled = false;
                txtGravadora.Enabled = false;
                btnEdit.Text = "Editar";
                editing = false;
            }
            else
            {
                txtTitulo.Enabled = true;
                txtAutor.Enabled = true;
                txtCDID.Enabled = true;
                txtGravadora.Enabled = true;
                btnEdit.Text = "Confirmar";
                editing = true;
            }
           
        }
        bool editing = false;
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (confirmDelete)
            {
                MusicaDTO.IdMusica = int.Parse(lblID.Text.ToString());

                tbl_MusicaBLL.ExcluirMusica(MusicaDTO);
                MessageBox.Show("Remoção Realizada com Sucesso. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GridMusica.DataSource = tbl_MusicaBLL.PesquisarMusica();

                btnRemove.Text = "Remover";
                btnRemove.BackColor = Color.White;
                confirmDelete = false;
            }
            else
            {
                btnRemove.Text = "Certeza?";
                btnRemove.BackColor = Color.Red;
                confirmDelete = true;
            }
        }

        //Negar qualquer input não-numérico
        private void txtCDID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtGravadora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        

        private void GridMusica_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text = GridMusica.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTitulo.Text = GridMusica.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtAutor.Text = GridMusica.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtGravadora.Text = GridMusica.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtCDID.Text = GridMusica.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        
    }
}
