using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiplomaPMS
{
    public partial class MemberDetails : UserControl
    {
        public MemberDetails()
        {
            InitializeComponent();
        }

        public void SwitchFieldsReadOnly(int val)
        {
            if (val == 0)
            {
                this.firstName.ReadOnly = false;
                this.lastName.ReadOnly = false;
                this.specialisation.ReadOnly = false;
                this.birthDate.ReadOnly = false;
                this.additionalInformation.ReadOnly = false;
                this.birthDate.Enter += StartDateInput_Enter;
            }
            else if (val == 1)
            {
                this.firstName.ReadOnly = true;
                this.lastName.ReadOnly = true;
                this.specialisation.ReadOnly = true;
                this.birthDate.ReadOnly = true;
                this.additionalInformation.ReadOnly = true;
                this.birthDate.Enter -= StartDateInput_Enter;
            }
        }

        private void StartDateInput_Enter(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void StartDateInput_Leave(object sender, EventArgs e)
        {
            if (!monthCalendar1.Focused)
            {
                monthCalendar1.Visible = false;
            }

        }

        private void calendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            var mcalendar = sender as MonthCalendar;
            birthDate.Text = mcalendar.SelectionStart.ToString();
        }

        private void calendar1_Leave(object sender, EventArgs e)
        {
            var mcalendar = sender as MonthCalendar;
            mcalendar.Visible = false;
        }
    }
}
