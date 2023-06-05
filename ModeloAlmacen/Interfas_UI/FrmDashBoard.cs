using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Interfas_UI
{
    public partial class FrmDashBoard : Form
    {
        public FrmDashBoard()
        {
            InitializeComponent();
        }
        private Form Activeform = null;
        private void MostrarFormulario(Form FrmHijo)
        {
            if (Activeform != null)
                Activeform.Close();
            Activeform = FrmHijo;
            FrmHijo.TopLevel = false;
            FrmHijo.FormBorderStyle = FormBorderStyle.None;
            FrmHijo.Dock = DockStyle.Fill;
            Contenedor.Controls.Add(FrmHijo);
            Contenedor.Tag = FrmHijo;
            FrmHijo.BringToFront();
            FrmHijo.Show();
        }
        private void BtnMaximizar_Click(object sender, EventArgs e)
        {
            
            int ancho = Screen.PrimaryScreen.WorkingArea.Width;
            int alto = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = new Size(ancho, alto);
            this.WindowState = FormWindowState.Maximized;
            BtnMaximizar.Visible = false;
            BtnRestablecer.Visible = true;
        }

        private void BtnRestablecer_Click(object sender, EventArgs e)
        {
            this.Size = new Size(978, 567);
            this.WindowState = FormWindowState.Normal;
            BtnRestablecer.Visible = false;
            BtnMaximizar.Visible = true;
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            
            int ancho = Screen.PrimaryScreen.WorkingArea.Width;
            int alto = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = new Size(ancho, alto);
            this.WindowState = FormWindowState.Maximized;
            Cache.alto = Contenedor.Width;
            Cache.ancho = Contenedor.Height;
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            MostrarFormulario(new FrmListaUsuarios());
        }
    }
}
