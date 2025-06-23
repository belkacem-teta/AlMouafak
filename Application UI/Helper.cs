using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Application_UI
{
    public struct CustomColors
    {
        public static Color Debt = Color.LightCoral;
        public static Color Paid = Color.LightSeaGreen;
    }
    internal class Helper
    {
        public static void ShowError()
        {
            MessageBox.Show("حصل خطأ في البرنامج", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static bool ShowDeleteConfirmation()
        {
            if (MessageBox.Show("هل تريد بالتأكيد حذف هذا؟", "إنتبه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                return true;
            return false;
        }
        public static bool ValidateEmptyTextBox(TextBox txtBox, ErrorProvider errorProvider)
        {
            if (string.IsNullOrWhiteSpace(txtBox.Text))
            {
                errorProvider.SetError(txtBox, "مطلوب ملئ هذا الحقل");
                return true;
            }
            errorProvider.SetError(txtBox, "");
            return false;
        }

        public static void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static string GetVersionNumber()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo versioninfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            return versioninfo.FileVersion;
        }

        public static string SaveExcelFile(string fileName)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "حفظ ملف";
                saveFileDialog.FileName = fileName;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return saveFileDialog.FileName;
                }
                return "";
            }
        }

    }
}
