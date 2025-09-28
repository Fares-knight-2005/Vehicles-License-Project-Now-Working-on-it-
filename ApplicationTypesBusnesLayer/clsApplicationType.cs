using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ApplicationTypesDataLayer;

namespace ApplicationTypesBusnesLayer
{
    public class clsApplicationType
    {
        private enum enMode { AddNew , Update}
        enMode Mode = enMode.AddNew;
        public int ID { get; set; }
        public string Title { get; set; }
        public double Fees {  get; set; }

        clsApplicationType() 
        { 
            ID = -1;
            Title = string.Empty;
            Fees = 0;
            this.Mode = enMode.AddNew;
        }
        clsApplicationType(int id , string title , double fees)
        {
            this.ID = id;
            this.Title = title;
            this.Fees = fees;
            this.Mode = enMode.Update;
        }

        private static int AddNewApplicationType(clsApplicationType ap)
        {
            return ApplicationTypesDataLayer.ClsApplicationTypeData.AddNewApplicationType(ap.Title, ap.Fees);
        }
        private static bool UpdateApplicationType(clsApplicationType ap)
        {
            return ApplicationTypesDataLayer.ClsApplicationTypeData.UpdateApplicationType(ap.ID, ap.Title, ap.Fees);
        }

        public static clsApplicationType Find(int ID)
        {
            string title = "";
            double fees = 0;
            if(ApplicationTypesDataLayer.ClsApplicationTypeData.FindApplicationTypeByApplicationTypeID(ref title , ref fees , ref ID))
            {
                return new clsApplicationType(ID , title , fees);
            }
            return null;
        }

        public static DataTable getAllApplicationTypes()
        {
            return ApplicationTypesDataLayer.ClsApplicationTypeData.GetAllApplicationTypes();
        }

        public bool Save()
        {
            if (this.Mode == enMode.AddNew)
            {
                if (AddNewApplicationType(this) != -1)
                {
                    this.Mode = enMode.Update;
                    return true;
                }
                return false;
            }
            else { return UpdateApplicationType(this); }
        }
    }
}
