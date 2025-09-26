using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project.People_Forms
{
    
    public partial class FindPerson : Form
    {
        public delegate void dDataBack(object sender, int ID);
        public event dDataBack DataBack;

        public FindPerson()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack.Invoke(this , ctrUserIfoWithFilter1.getPerson().ID);
            this.Close();
        }
    }
}
