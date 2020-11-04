using Practica1.EF.Entity;
using Practica1.EF.Logic;
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

namespace frmEmployees
{
    public partial class Form1 : Form
    {
        private EmployeesLogic employees;
        Employees DeleReg;

        public Form1()
        {
            InitializeComponent();

            showEmployees();
        }

        protected void showEmployees()
        {
            this.employees = new EmployeesLogic();
            dataGridView1.DataSource = employees.GetAll();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            frmNuevo frmNuevo = new frmNuevo();
            frmNuevo.ShowDialog();

            showEmployees();
        }

        private int? GetId()
        {
            try
            {
               return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //int? permite nulos
            int? id = GetId();

            if(id != null)
            {
                frmNuevo frmNuevo = new frmNuevo(id);
                frmNuevo.ShowDialog();

                showEmployees();
            }
        }

        public void EliminarRegistro()
        {
            this.employees = new EmployeesLogic();

            int? id = GetId();

            if (id != null)

            DeleReg = new Employees();

            int i = 0;
            i = Convert.ToInt32(id);

            DeleReg.EmployeeID = i;

            employees.Delete(DeleReg);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           MessageBox.Show("Se procede a Eliminar el registro seleccionado");
        
            EliminarRegistro();
              showEmployees();
        }

    }
}
