using System;
using System.Drawing;
using System.Windows.Forms;

namespace ControlAnimation
{
    public partial class WaitBox : Form
    {
        public event EventHandler Canceled;

        internal WaitBox(int value, int innerValue, string status, string innerStatus, string caption, bool clockwise)
        {
            InitializeComponent();
            Shown += WaitBox_Shown;

            Value = value;
            InnerValue = innerValue;
            Status = status;
            InnerStatus = innerStatus;
            Caption = caption;
            Clockwise = clockwise;
        }

        public int Value
        {            
            set
            {
                if (value > progressBar1.Maximum)
                {
                    value = 100;
                }
                progressBar1.Value = value;                
            }
        }

        public int InnerValue
        {
            set
            {
                if (value > progressBar2.Maximum)
                {
                    value = 100;
                }
                progressBar2.Value = value;
            }
        }

        public string Caption
        {
            set
            {
                Text = value;
            }
        }

        public string Status
        {           
            set
            {
                label1.Text = value;
            }
        }

        public string InnerStatus
        {
            set
            {
                label2.Text = value;
            }
        }
        private bool _clockwise;
        public bool Clockwise
        {
            set
            {
                _clockwise = value;
            }
        }

        void WaitBox_Shown(object sender, EventArgs e)
        {
            ControlAnimator.StartAnimating(panel1, ControlAnimator.DrawMode.Lines, Color.CornflowerBlue, _clockwise);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Vorgang wirklich abbrechen?", "Abbrechen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Canceled(this, new EventArgs());
            }
        }

        /// <summary>
        /// Close the WaitBox
        /// </summary>
        public new void Close()
        {
            ControlAnimator.StopAnimating(panel1);
            base.Close();
        }
        

    }
}
