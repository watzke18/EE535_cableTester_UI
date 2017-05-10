using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cableFactoryTestApp
{
    public partial class TestSetup : Form
    {
        public TestParameters m_testParameters;

        public TestSetup()
        {
            InitializeComponent();
        }

        public void TestSetup_Load(object sender, EventArgs e)
        {
            textBoxCableType.Text = m_testParameters.cable_description;
            numericUpDownForce.Value = (decimal)m_testParameters.force_applied;
            numericUpDownTestLoops.Value = m_testParameters.total_loops;
            numericUpDownTest.Value = m_testParameters.test_duration;
            numericUpDownRest.Value = m_testParameters.rest_duration;
            numericUpDownMotorSpin.Value = m_testParameters.spin_degree;

            if(m_testParameters.stop_on_break == 1)
            {
                comboBoxContinuity.Text = "Yes";
            }
            else
            {
                comboBoxContinuity.Text = "No";
            }
        }

        private void testSetupOkBtn_Click(object sender, EventArgs e)
        {

           // if (!ParamCheck())
           // {
             //   this.DialogResult = DialogResult.None;
          //  }
          //  else
            {
                m_testParameters.cable_description = textBoxCableType.Text;
                m_testParameters.force_applied = (float)numericUpDownForce.Value;
                m_testParameters.total_loops = (int)numericUpDownTestLoops.Value;
                m_testParameters.test_duration = (int)numericUpDownTest.Value;
                m_testParameters.rest_duration = (int)numericUpDownRest.Value;
                m_testParameters.spin_degree = (int)numericUpDownMotorSpin.Value;

                if (comboBoxContinuity.Text == "Yes")
                {
                    m_testParameters.stop_on_break = 1;
                }
                else
                {
                    m_testParameters.stop_on_break = 0;
                }
            }
      

        }

        private void testSetupCancelBtn_Click(object sender, EventArgs e)
        {

        }

        public bool ParamCheck() //true if paramaters are valid, false if invalid.
        {
            bool reply = true;
            string str = "";

            if((int)numericUpDownTest.Value == 0)
            {
                str += "-Test duration cannot be 0 \n";
                reply = false;
            }

            if((int)numericUpDownTestLoops.Value != 0)
            {
                if ((int)numericUpDownRest.Value == 0)
                {
                    str += "-Rest duration between test repititions cannot be 0 \n";
                    reply = false;
                }
                else if (((double)numericUpDownTest.Value / (double)(int)numericUpDownRest.Value) > 1.67)
                {
                    str += "-There must be 3 minutes of rest for every 5 minutes that test is running (1.66:1 ratio). \n";
                    reply = false;
                }
            }

        

            if(reply == false)
            {
                MessageBox.Show(str, "Invalid Parameters", MessageBoxButtons.OK);
               
            }

            return reply;
        }

      
    }
}
