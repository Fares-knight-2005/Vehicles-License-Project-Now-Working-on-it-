using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using TestTypesDataLayer;

namespace TestTypesBusnesLayer
{
    public class clsTestTypes
    {
        public enum enTestTypes { vision = 1, writin = 2, street = 3}
        public enTestTypes ID { get; set; }
        enum enMode { AddNew , Update}
        enMode mode = enMode.AddNew;

        public string Title { get; set; }
        public string Description { get; set; }
        public double Fees { get; set; }

        clsTestTypes()
        {
            this.mode = enMode.AddNew;
            this.Title = "";
            this.Fees = 0.0;
            this.Description = "";
            this.ID = enTestTypes.vision;
        }

        clsTestTypes(enTestTypes ID , string title, double fees , string description)
        {
            this.ID = ID;  
            this.Title = title;
            this.Fees = fees;
            this.Description = description;
            this.mode= enMode.Update;
        }

        private static int AddNew(clsTestTypes testType)
        {
            return TestTypesDataLayer.Class1.AddNewTestType(testType.Title, testType.Description, testType.Fees);
        }
        private static bool Update(clsTestTypes testType)
        {
            return TestTypesDataLayer.Class1.UpdateTestType((int)testType.ID, testType.Title, testType.Description, testType.Fees);
        }
        public bool save()
        {
            if(this.mode == enMode.AddNew)
            {
                if(AddNew(this) != -1)
                {
                    this.mode = enMode.Update;
                    return true;
                }
                return false;
            }
            else return Update(this);
        }

        public static DataTable GetAll()
        {
            return TestTypesDataLayer.Class1.GetAllTestTypes();
        }

        public static clsTestTypes Find(enTestTypes id)
        {
            string title = "";
            string discription = "";
            double fees = 0.0;

            if (TestTypesDataLayer.Class1.FindTestTypeByTestTypeID(ref title, ref discription, ref fees, (int)id))
                return new clsTestTypes((enTestTypes)id , title , fees , discription);

            return null;
        }
    }
}
