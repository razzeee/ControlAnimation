using System;
using System.Drawing;
using System.Windows.Forms;

namespace ControlAnimation
{
    public partial class WaitBox_SingleThread : Form
    {
        public event EventHandler Canceled;

        internal WaitBox_SingleThread(int value, String status, String caption, bool clockwise)
        {
            InitializeComponent();
            Shown += WaitBox_Shown;

            Value = value;
            Status = status;
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

        public string Caption
        {
            set
            {
                this.Text = value;
            }
        }

        public string Status
        {           
            set
            {
                label1.Text = value;
            }
        }

        private bool clockwise;
        public bool Clockwise
        {
            set
            {
                clockwise = value;
            }
        }

        void WaitBox_Shown(object sender, EventArgs e)
        {
            ControlAnimator.StartAnimating(panel1, ControlAnimator.DrawMode.Lines, Color.CornflowerBlue, clockwise);
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
