using Practica1.EF.Entity;
using Practica1.EF.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Region = System.Drawing.Region;

namespace frmEmployees
{
    public partial class frmNuevo : Form
    {
        //globales
        private EmployeesLogic employees;
        private RegionLogic region;

        public int? id;
        Employees Empl = null;
        Employees NueReg;
        Employees ModReg;
        string SelectReg;
        bool validar;
        Region ModRegion;

        public frmNuevo(int? id=null)
        {
            InitializeComponent();


            ListaRegion();

            this.id = id;
            if (id != null)
                CargaDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(id!=null)
            ModificoRegistro();
            else
            {
                NuevoRegistro();
            }

            SelectionRegion();
        }

        public void NuevoRegistro()
        {
            try
            {
                this.employees = new EmployeesLogic();

                NueReg = new Employees();
                validar = true;

                NueReg.LastName = txtApe.Text;
                NueReg.FirstName = txtName.Text;
                NueReg.BirthDate = dtpFecNac.Value;

                SelectionRegion();
                NueReg.Region = SelectReg;


                employees.Insert(NueReg);
                Refrescar();
            }catch(Exception ex)
            {
                MessageBox.Show("Debe completar todos los campos");
                validar = false;
            }
                
        }

        public void ModificoRegistro()
        {
            try
            {
                this.employees = new EmployeesLogic();
                this.region = new RegionLogic();

                ModReg = new Employees();
                validar = true;
                int i = 0;
                i = Convert.ToInt32(id);

                ModReg.EmployeeID = i;
                ModReg.LastName = txtApe.Text;
                ModReg.FirstName = txtName.Text;
                ModReg.BirthDate = dtpFecNac.Value;

                SelectionRegion();
                ModReg.Region = SelectReg;

                employees.Update(ModReg);

                Refrescar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe completar todos los campos");
                validar = false;
            }
        }

        protected void Refrescar()
        {

            txtApe.Text = "";
            txtName.Text = "";
            dtpFecNac.Value = DateTime.Now; //Fecha actual
            cbTerritorio.SelectedIndex = 0;

        }

        private void CargaDatos()
        {
            this.employees = new EmployeesLogic();

            int i = 0;
            i = Convert.ToInt32(id);
            
            Empl = employees.GetOne(i, "");

            txtName.Text = Empl.FirstName;
            txtApe.Text = Empl.LastName;


            var FecNac = Convert.ToString(Empl.BirthDate); 

            dtpFecNac.Text = FecNac;

            int idR;
            idR = Convert.ToInt32(Empl.Region);
            cbTerritorio.SelectedIndex = idR - 1;

        }

        public void ListaRegion()
        {
            this.region = new RegionLogic();

            cbTerritorio.DataSource = region.GetAll();
            cbTerritorio.DisplayMember = "RegionDescription";
            cbTerritorio.ValueMember = "RegionID";
            if (cbTerritorio.Items.Count > 1)
                cbTerritorio.SelectedIndex = 0;

        }

        public void SelectionRegion()
        {
            if (validar == true)
                SelectReg = cbTerritorio.SelectedValue.ToString();

        }
    }
}
