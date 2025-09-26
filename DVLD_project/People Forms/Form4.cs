using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeopleBusnisLayer;

namespace DVLD_project
{
    public partial class Form4 : Form
    {
        public delegate void dDataBack(object sender, int id);
        public event dDataBack DataBack;
        public Form4()
        {
            InitializeComponent();
            UserControl1 uc = new UserControl1();
            uc.DataBack += ReturnDelegate;
            this.Controls.Add(uc); 
            AcceptButton = uc.GetSaveButton();    
            CancelButton = uc.GetCancelButton();
        }

        public Form4(int ID)
        {
            InitializeComponent();
            UserControl1 uc = new UserControl1(ID);
            uc.DataBack += ReturnDelegate;
            this.Controls.Add(uc); 
            AcceptButton = uc.GetSaveButton();
            CancelButton = uc.GetCancelButton();
        }

        public void ReturnDelegate(object sender , int id)
        {
            DataBack?.Invoke(sender, id);
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
