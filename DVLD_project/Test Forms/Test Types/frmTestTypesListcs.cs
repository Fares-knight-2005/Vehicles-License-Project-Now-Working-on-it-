using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestTypesBusnesLayer;

namespace DVLD_project.Test_Forms.Test_Types
{
    public partial class frmTestTypesListcs : Form
    {
        public frmTestTypesListcs()
        {
            InitializeComponent();
        }

        private void frmTestTypesListcs_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsTestTypes.GetAll();

            dataGridView1.Columns["TestTypeID"].HeaderText = "Test Type ID";
            dataGridView1.Columns["TestTypeFees"].HeaderText = "Test Type Fees";
            dataGridView1.Columns["TestTypeTitle"].HeaderText = "Test Type Title";
            dataGridView1.Columns["TestTypeDescription"].HeaderText = "Test Type Description";
            dataGridView1.Columns["TestTypeDescription"].Width = 300;
            dataGridView1.Columns["TestTypeTitle"].Width = 150;
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex , e.RowIndex];

                var position = dataGridView1.PointToClient(Cursor.Position);
                contextMenuStrip1.Show(dataGridView1 , position );
            }
        }

        private void updateTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestTypecs frm = new frmEditTestTypecs((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmTestTypesListcs_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
