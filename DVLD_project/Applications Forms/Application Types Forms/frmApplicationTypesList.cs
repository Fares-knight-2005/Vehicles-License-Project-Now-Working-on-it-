using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationTypesBusnesLayer;

namespace DVLD_project.Applications_Forms.Application_Types_Forms
{
    public partial class frmApplicationTypesList : Form
    {
        public frmApplicationTypesList()
        {
            InitializeComponent();
        }

        private void frmApplicationTypesList_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsApplicationType.getAllApplicationTypes();
            dataGridView1.Columns["ApplicationTypeTitle"].HeaderText = "Application Type Title";
            dataGridView1.Columns["ApplicationTypeTitle"].Width = 435;
            dataGridView1.Columns["ApplicationFees"].HeaderText = "Application Fees";
            dataGridView1.Columns["ApplicationTypeID"].HeaderText = "Application Type ID";
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
          
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex , e.RowIndex];

                var position = dataGridView1.PointToClient(Cursor.Position);
                contextMenuStrip1.Show(dataGridView1, position );
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void updateApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationYpes frm = new frmEditApplicationYpes((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmApplicationTypesList_Load(null, null);
        }
    }
}
