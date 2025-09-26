using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeopleBusnisLayer;
namespace DVLD_project
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            dataGridView1.DataSource = PeopleBusnisLayer.Person.GetPeople();
            dataGridView1.Columns["ImagePath"].Visible = false;
            dataGridView1.Columns["Address"].Visible = false;
            dataGridView1.Columns["NationalityCountryID"].Visible = false;
            dataGridView1.Columns["NationalNo"].Visible = false;
            dataGridView1.Columns["Email"].Visible = false;
            dataGridView1.Columns["Gendor"].Visible = false;
            Records.Text = dataGridView1.Rows.Count.ToString();
            comboBox1.SelectedIndex = 0;
            textBox1.Enabled = false;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                dataGridView1.DataSource = PeopleBusnisLayer.Person.GetPeople();
                textBox1.Enabled = false;
            }
            else
            {
                textBox1.Enabled = true;
            }

            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = PeopleBusnisLayer.Person.GetPeople();
            DataView dv = new DataView(dt);

            try
            {
                dv.RowFilter = comboBox1.Text + " = \'" + textBox1.Text + "\'";
                dataGridView1.DataSource = dv;
            }
            catch (Exception ex) { }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != ((char)Keys.Back))
                {
                    MessageBox.Show("yes");
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.ShowDialog();
            comboBox1.SelectedIndex = 1;
            comboBox1.SelectedIndex = 0;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns["PersonID"].HeaderText = "Person ID";
                dataGridView1.Columns["FirstName"].HeaderText = "First Name";
                dataGridView1.Columns["SecondName"].HeaderText = "Second Name";
                dataGridView1.Columns["ThirdName"].HeaderText = "Third Name";
                dataGridView1.Columns["DateOfBirth"].HeaderText = "Birth Date";
                dataGridView1.Columns["CountryName"].HeaderText = "Country";
                dataGridView1.Columns["LastName"].HeaderText = "Last Name";
                dataGridView1.Columns["GendorName"].HeaderText = "Gendor";
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                ContextMenuStrip c = new ContextMenuStrip();
                c.Items.Add(toolStripMenuItem1);
                c.Show(dataGridView1 , e.Location);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.ShowDialog();
            comboBox1.SelectedIndex=1;
            comboBox1.SelectedIndex=0;
        }

        private void showDeatelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow != null)
            {
               int id = (int)dataGridView1.CurrentRow.Cells["PersonID"].Value;  
               ShowPersonDetails frm = new ShowPersonDetails(id);
               frm.ShowDialog();
                comboBox1.SelectedIndex = 1;
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No Person Was Selected" , "Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void updatePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["PersonID"].Value;
                Form4 frm = new Form4(id);
                frm.ShowDialog();
                comboBox1.SelectedIndex = 1;
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No Person Was Selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Person p = Person.Find((int)dataGridView1.CurrentRow.Cells["PersonID"].Value);
            if(MessageBox.Show("Are You Sure To Delete: " + p.FullName + " With ID = " + p.ID , "Delete" , MessageBoxButtons.YesNo , MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (Person.DeletePerson(p.ID))
                {
                    MessageBox.Show("Deleted Successfuly :)", "Dleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBox1 .SelectedIndex = 1;
                    comboBox1.SelectedIndex = 0;
                }
                else
                    MessageBox.Show("Person Wasn't Deleted \"There are other things related to it\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}