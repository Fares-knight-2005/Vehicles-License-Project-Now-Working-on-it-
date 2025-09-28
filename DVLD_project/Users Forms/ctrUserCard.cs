using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersBusnesLayer;

namespace DVLD_project.UsersForms
{
    public partial class ctrUserCard : UserControl
    {
        User user;
        public ctrUserCard()
        {
            InitializeComponent();
        }

        public void Work(int UserID)
        {
            user = User.Find(UserID);
            if (user == null) { return; }
            personCardControl1.Work(user.PersonId);
            lblIsActive.Text = (user.IsActive ? "yes" : "NO");
            lblUserId.Text = user.Id.ToString();
            lblUserName.Text = user.UserName;
        }

        public User getUser()
        {
            return user;
        }
    }
}
