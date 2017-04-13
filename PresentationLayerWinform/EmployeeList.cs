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


//using BusinessLogicLayer;
//using Shared.Entities;



namespace PresentationLayerWinform
{
    public partial class EmployeeList : Form
    {
        public EmployeeList()
        {
            InitializeComponent();

            //Abro el cliente
            ServiceEmployeesClient cliente = new ServiceEmployeesClient();
            
            List<Employee> aux1 = cliente.GetAllEmployees().ToList();
            
            foreach (var e in aux1)
            {
                if(e is FullTimeEmployee)
                {
                    var aux = (FullTimeEmployee)e;
                    
                     lstEmp.Items.Add(new ListViewItem(new string[] { Convert.ToString(aux.Id), Convert.ToString(aux.Name), Convert.ToString(aux.StartDate), "Full Time Employee" }));


                }
                else
                {
                    var aux = (PartTimeEmployee)e;
                    
                    lstEmp.Items.Add(new ListViewItem(new string[] { Convert.ToString(aux.Id), Convert.ToString(aux.Name), Convert.ToString(aux.StartDate), "Part Time Employee" }));
                    
                }


            }

 
        }

        private void EmployeeList_Load(object sender, EventArgs e)
        {
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstEmp.SelectedItems.Count > 0)
            {
                ServiceEmployeesClient client = new ServiceEmployeesClient();
                client.DeleteEmployee(Convert.ToInt16(lstEmp.SelectedItems[0].Text));
                lstEmp.Items.RemoveAt(lstEmp.SelectedIndices[0]);

            }
;
        }

        private void lstEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EmployeeAddEdit form2 = new EmployeeAddEdit();
            if (lstEmp.SelectedItems.Count > 0)
            {
               
                
                    form2.txtId.Text = lstEmp.SelectedItems[0].Text;
                    form2.txtName.Text = lstEmp.SelectedItems[0].SubItems[1].Text;
                    form2.txtDate.Text = lstEmp.SelectedItems[0].SubItems[2].Text;
                    form2.txtType.Text = lstEmp.SelectedItems[0].SubItems[3].Text;
                    form2.txtId.Enabled = false;
                    form2.btnAdd.Enabled = false;
                    this.Hide();
                    form2.ShowDialog();
                
            }                  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeAddEdit form2 = new EmployeeAddEdit();
            form2.btnEdit.Enabled = false;
            form2.ShowDialog();

        }
    }
}
