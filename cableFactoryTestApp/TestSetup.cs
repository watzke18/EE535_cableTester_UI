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
            numericUpDownForce.Value = m_testParameters.force_applied;
            numericUpDownTestLoops.Value = m_testParameters.loops;
            numericUpDownTest.Value = m_testParameters.test_duration;
            numericUpDownRest.Value = m_testParameters.rest_duration;

            if(m_testParameters.stop_on_break)
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
            m_testParameters.cable_description = textBoxCableType.Text;
            m_testParameters.force_applied = (int)numericUpDownForce.Value;
            m_testParameters.loops = (int)numericUpDownTestLoops.Value;
            m_testParameters.test_duration = (int)numericUpDownTest.Value;
            m_testParameters.rest_duration = (int)numericUpDownRest.Value;

            if(comboBoxContinuity.Text == "Yes")
            {
                m_testParameters.stop_on_break = true;
            }
            else
            {
                m_testParameters.stop_on_break = false;
            }
        }

        private void testSetupCancelBtn_Click(object sender, EventArgs e)
        {

        }

        public bool ParamCheck()
        {
            return false;
        }

      
    }
}
