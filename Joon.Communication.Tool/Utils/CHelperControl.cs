using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joon.Communication.Tool.Utils
{
    public class CHelperControl
    {
        #region ComBoBox

        public static int CmbSetSelectedIndex(ComboBox cmb, string val)
        {
            foreach (var item in cmb.Items)
            {
                if (item.ToString() == val)
                {
                    return cmb.Items.IndexOf(item);
                }
            }
            return 0;
        }

        public static void CmbSetSelectedItem(ComboBox cmb, string val)
        {
            foreach (var item in cmb.Items)
            {
                if (item.ToString() == val)
                {
                    cmb.SelectedIndex = cmb.Items.IndexOf(item);
                    return;
                }
            }
            cmb.SelectedIndex = 0;
        }

        #endregion
    }
}
