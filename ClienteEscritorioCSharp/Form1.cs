using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteEscritorioCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Llamar al servicio
        private static ServiceReference1.WebService3SoapClient servicio;

        private void Form1_Load(object sender, EventArgs e)
        {
            servicio = new ServiceReference1.WebService3SoapClient();
            dgvAlumno.DataSource = servicio.Listar().Tables[0];
        }

        private void bttnAgregar_Click(object sender, EventArgs e)
        {
            // Leer las cajas de texto
            string codAlumno = txtCodAlumno.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string nombres = txtNombres.Text.Trim();
            string lugNacimiento = txtLugNacimiento.Text.Trim();
            DateTime fechaNacimiento = dtpFechaNacimiento.Value;
            string codEscuela = txtCodEscuela.Text.Trim();

            // Inicializamos el servicio
            servicio = new ServiceReference1.WebService3SoapClient();
            string[] rpta = servicio.Agregar(codAlumno, apellidos, nombres, lugNacimiento, fechaNacimiento, codEscuela).ToArray();

            //Evaluamos
            if (rpta[0] == "0")
            {
                dgvAlumno.DataSource = servicio.Listar().Tables[0];
                MessageBox.Show(rpta[1], "BIEN");
            }
            else
                MessageBox.Show(rpta[1], "ERROR");
        }

        private void bttnEliminar_Click(object sender, EventArgs e)
        {
            // Leer las cajas de texto
            string codAlumno = txtCodAlumno.Text.Trim();

            // Inicializamos el servicio
            servicio = new ServiceReference1.WebService3SoapClient();
            string[] rpta = servicio.Eliminar(codAlumno).ToArray();

            //Evaluamos
            if (rpta[0] == "0")
            {
                dgvAlumno.DataSource = servicio.Listar().Tables[0];
                MessageBox.Show(rpta[1], "BIEN");
            }
            else
                MessageBox.Show(rpta[1], "ERROR");
        }

        private void bttnActualizar_Click(object sender, EventArgs e)
        {
            // Leer las cajas de texto
            string codAlumno = txtCodAlumno.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string nombres = txtNombres.Text.Trim();
            string lugNacimiento = txtLugNacimiento.Text.Trim();
            DateTime fechaNacimiento = dtpFechaNacimiento.Value;
            string codEscuela = txtCodEscuela.Text.Trim();

            // Inicializamos el servicio
            servicio = new ServiceReference1.WebService3SoapClient();
            string[] rpta = servicio.Actualizar(codAlumno, apellidos, nombres, lugNacimiento, fechaNacimiento, codEscuela).ToArray();

            //Evaluamos
            if (rpta[0] == "0")
            {
                dgvAlumno.DataSource = servicio.Listar().Tables[0];
                MessageBox.Show(rpta[1], "BIEN");
            }
            else
                MessageBox.Show(rpta[1], "ERROR");
        }

        private void bttnBuscar_Click(object sender, EventArgs e)
        {
            // Leer las cajas de texto
            string buscar = txtBuscar.Text.Trim();

            // Inicializamos el servicio
            servicio = new ServiceReference1.WebService3SoapClient();
            dgvAlumno.DataSource = servicio.Buscar(buscar).Tables[1];
        }
    }
}
