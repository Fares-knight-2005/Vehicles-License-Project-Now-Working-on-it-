using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project
{
    internal class Handling
    {
        public static bool ValidatRecoaierdTextBoxes(TextBox toCheck , ErrorProvider errorProvider1)
        {
            if (string.IsNullOrEmpty(toCheck.Text))
            {
                errorProvider1.SetError(toCheck, "This fieled is required");
                return false;
            }
            return true;
        }

        public static bool ValidatingEmail(TextBox toCheck, ErrorProvider errorProvider1 , bool EmailRequaired = false)
        {

            if (!string.IsNullOrEmpty(toCheck.Text) || EmailRequaired)
            {
                if (!toCheck.Text.Contains("@gmail.com"))
                {
                    errorProvider1.SetError(toCheck, "Not Valied Email");
                    return false;
                }
            }
            return true;
        }

        public static bool ValidatOnlyNumbersAllawed(TextBox textBox, ErrorProvider errorProvider1)
        {
            if (!textBox.Text.All(char.IsDigit))
            {
                errorProvider1.SetError(textBox, "only numbers ");
                return false;
            }
            else
            {
                errorProvider1.SetError(textBox,null);
            }
            return true;
        }

        public static string GenerateGUID()
        {
            return Guid.NewGuid().ToString();
        }

        public static string ReplaceFileNameWithGUID(string FileName)
        {
            FileInfo file = new FileInfo(FileName);
            string extn = file.Extension;
            return GenerateGUID() + extn;
        }

        public static bool CopyImageToProjectImagesFolder(ref string path)
        {
            string ProjectPicFolder = @"D:\coding files\DVLD_project\PicsFolder\";
            string NewPath = ProjectPicFolder + ReplaceFileNameWithGUID(path);
            try { File.Copy(path, NewPath, true); }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message , "Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            path = NewPath;
            return true;
        }

    }
}