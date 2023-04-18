using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using Negocio;
namespace DemoADONET2023
{
    public partial class Form1 : Form
    {

        DataTable table = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {

            BProduct negocio = new BProduct();
            dgvDemo.DataSource = negocio.Listar(txtDescription.Text);
            //BRegion negocio= new BRegion();
            //dgvDemo.DataSource = negocio.Listar(txtDescription.Text);

        }

        private void btnListar2_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            
        }

         

    
    }
}
