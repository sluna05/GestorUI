using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comun;
using Entidades;
using System.Runtime.InteropServices;

namespace Interfas_UI
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]//Libreria
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]//Libreria
        private extern static void SendMessage(System.IntPtr hwnd, int wnsg, int wparam, int lparam);
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private List<Modelo> CargarTiendas()
        {
            cTienda obj = new cTienda();
            var Datos = obj.GetTienda();
            var Reg = from x in Datos select x;
            return Reg.ToList();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            cmbTienda.DataSource = CargarTiendas();
            cmbTienda.ValueMember = "Id";
            cmbTienda.DisplayMember = "Nombre";
            txtUsuario.Text = "SLUNA";
            txtPassword.Text = "852456";
        }

        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            int t = Convert.ToInt32(cmbTienda.SelectedValue);
            cUsuarios Obj = new cUsuarios();
            var Resultado = Obj.cLogin(txtUsuario.Text, txtPassword.Text, t);
            if (Resultado == true)
            {
                this.Hide();
                FrmDashBoard frm = new FrmDashBoard();
                frm.ShowDialog();
            }else
            {
                MessageBox.Show("Usuario y/o Contraseña incorecta");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {

        }
    }
}
