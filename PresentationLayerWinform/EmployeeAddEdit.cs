//using BusinessLogicLayer;
//using DataAccessLayer;
using PresentationLayerWinform.ServiceEmployeesReferencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Shared.Entities;


namespace PresentationLayerWinform
{
    public partial class EmployeeAddEdit : Form
    {
        public EmployeeAddEdit()
        {
            InitializeComponent();
        }

        private void EmployeeAddEdit_Load(object sender, EventArgs e)
        {
            txtRate.Enabled = false;
            txtSalary.Enabled = false;
        }

        //no entiendo por que me pone button1 al nombre del metodo, si en las propiedades le puse que se llamara edit :S
        //PD: ESTE METODO QUE ES EL QUE CREARIA EL OBJETO PARA SETEARLO EN LA BD, Y EL CODIGO QUE ESTA COMENTADO EN EMPLOEYEE LIST, EL OTRO FORMULARIO, 
        //EVIDENTEMENTE ES TODO FRUTA, CREO QUE LA IDEA VIENE POR AHI PERO HAY QUE METERLE, EN ESPECIAL A TODO LO QUE TIENE QUE VER LEVANTAR DATOS DE LA BD 
        //Y LLAMAR A LOS METODOS, DE AHI EN ADELANTE CAGUE..
        //DE TODOS MODOS EL FUNCIONAMIENTO DE LOS FORMULARIOS QUEDO PRONTO, HACE LO QUE TIENE QUE HACER CON LOS DATOS DE PRUEBA.
        private void button1_Click(object sender, EventArgs e)
        {
            ServiceEmployeesClient cliente = new ServiceEmployeesClient();

            if ((Convert.ToInt32(this.txtType.Text)) == 1)
            {

                FullTimeEmployee fte = new FullTimeEmployee();
                fte.Id = Convert.ToInt32(this.txtId.Text);
                fte.Name = Convert.ToString(this.txtName.Text);
                fte.StartDate = Convert.ToDateTime(this.txtDate.Text);
                //fte.Salary = Convert.ToInt32(this.txtSalary);
                cliente.AddEmployee(fte);
            }
            else
            {
                PartTimeEmployee pte = new PartTimeEmployee();
                pte.Id = Convert.ToInt32(this.txtId.Text);
                pte.Name = Convert.ToString(this.txtName.Text);
                pte.StartDate = Convert.ToDateTime(this.txtDate.Text);
                //pte.HourlyRate = Convert.ToInt32(this.txtRate);
                cliente.AddEmployee(pte);
            }

            MessageBox.Show("Empleado creado con éxito cabrón, a tomar por culo!");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (this.txtType.Text != "")
                if (Convert.ToInt32(this.txtType.Text) == 1)
                {
                    txtSalary.Enabled = true;
                }
        }

        //Para que cierre la aplicacion luego de abrir el segundo formulario.
        private void EmployeeAddEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //Editamos los datos de un empleado ya existente (menos el ID)
            //Primero buscamos el empleado en la bd, lo traemos como shared entities (? (todavia no termine de entender :S)
            /*
            if (Convert.ToInt32(txtType) == 1) //si es full --ACA ME TIRA UNA EXCEPCION AL EDITAR POR UN PROBLEMA CON LA CONVERSION / COMPARACION (tal vez con int.tryparse)
            {
                Shared.Entities.FullTimeEmployee ftEmp = new FullTimeEmployee();
                DateTime txtToDate = DateTime.Parse(txtDate.Text);
                ftEmp.Name = Convert.ToString(txtName);
                ftEmp.StartDate = (txtToDate);
                //ftEmp.Salary tiene que mantener el valor que ya tenia, o se vuelve a calcular, ya que el empleado podria cambiar de tipo (?
            //Luego de setear los valores, tengo que guardar el nuevo empleado (shEmp) en la base
            //Como se hace esto? No se, no estudie maestra.
   
            }
            else
            {
                Shared.Entities.PartTimeEmployee ptEmp = new PartTimeEmployee();
                DateTime txtToDate = DateTime.Parse(txtDate.Text);
                ptEmp.Name = Convert.ToString(txtName);
                ptEmp.StartDate = (txtToDate);
                //Luego de setear los valores, tengo que guardar el nuevo empleado (shEmp) en la base
            }
            */

        }

        private void txtBox2_TextChanged(object sender, EventArgs e)
            {

            }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
