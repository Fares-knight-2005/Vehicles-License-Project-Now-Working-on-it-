using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersBusnesLayer;
namespace DVLD_project
{
    internal static class clsGlobal
    {
        public static User _user;

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {

            try
            {
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();
                string filePath = currentDirectory + "\\data.txt";

                if (Username == "" && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;

                }

                string dataToSave = Username + "#//#" + Password;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(dataToSave);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            try
            {
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                string filePath = currentDirectory + "\\data.txt";

                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line); 
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            Username = result[0];
                            Password = result[1];
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }

    }
}
