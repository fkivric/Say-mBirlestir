using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SayimBirlestir
{
    public static class CustomMessageBox
    {
        public static System.Windows.Forms.DialogResult ShowMessage(string message,string detay , Form owner, string caption, System.Windows.Forms.MessageBoxButtons buttons, System.Windows.Forms.MessageBoxIcon ıcon)
        {
            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;
            switch (buttons)
            {
                case System.Windows.Forms.MessageBoxButtons.OK:
                    using (frmMessageBox msgOK = new frmMessageBox())
                    {
                        msgOK.Text = caption;
                        msgOK.Message = message;
                        msgOK.detay = detay;
                        msgOK.StartPosition = FormStartPosition.Manual;
                        msgOK.Location = new Point(owner.Location.X + (owner.Width - msgOK.Width) / 2, owner.Location.Y + (owner.Height - msgOK.Height) / 2);                    
                        switch (ıcon)
                        {
                            case System.Windows.Forms.MessageBoxIcon.Information:
                                msgOK.MessageIcon = Properties.Resources.Entegref__1_;
                                break;
                            case System.Windows.Forms.MessageBoxIcon.Question:
                                msgOK.MessageIcon = Properties.Resources.question_32x32;
                                break;
                            case System.Windows.Forms.MessageBoxIcon.Warning:
                                msgOK.MessageIcon = Properties.Resources.bodetails_32x32;
                                break;
                        }
                        result = msgOK.ShowDialog(owner);
                    }
                    break;
                case System.Windows.Forms.MessageBoxButtons.OKCancel:
                    break;
                case System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore:
                    break;
                case System.Windows.Forms.MessageBoxButtons.YesNoCancel:
                    break;
                case System.Windows.Forms.MessageBoxButtons.YesNo:
                    break;
                case System.Windows.Forms.MessageBoxButtons.RetryCancel:
                    break;
                default:
                    break;
            }
            return result;
        }

    }
}
