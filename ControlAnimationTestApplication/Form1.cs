using System;
using System.Threading;
using System.Windows.Forms;
using ControlAnimation;

namespace ControlAnimationTestApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            comboBox1.Items.Add(ControlAnimator.DrawMode.Circle);
            comboBox1.Items.Add(ControlAnimator.DrawMode.Dots);
            comboBox1.Items.Add(ControlAnimator.DrawMode.Lines);
            comboBox1.SelectedIndex = 0;

            treeView1.ExpandAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (object item in checkedListBox1.CheckedItems)
            {
                switch ((string)item)
                {
                    case "SampleButton":
                        if (!checkBox1.Checked)
                        {
                            ControlAnimator.StartAnimating(button4,
                                                (ControlAnimator.DrawMode)comboBox1.SelectedItem,
                                                (int)numericUpDown2.Value,
                                                (int)numericUpDown3.Value,
                                                (int)numericUpDown1.Value
                                                ,panel1.BackColor, cbClockwise.Checked);
                        }
                        else
                        {
                            ControlAnimator.StartAnimating(button4,
                                                (ControlAnimator.DrawMode)comboBox1.SelectedItem
                                                , panel1.BackColor, cbClockwise.Checked);
                        }
                        break;
                    case "SampleTextbox":
                        if (!checkBox1.Checked)
                        {
                            ControlAnimator.StartAnimating(textBox1,
                                                (ControlAnimator.DrawMode)comboBox1.SelectedItem,
                                                (int)numericUpDown2.Value,
                                                (int)numericUpDown3.Value,
                                                (int)numericUpDown1.Value
                                                , panel1.BackColor, cbClockwise.Checked); 
                        }
                        else
                        {
                            ControlAnimator.StartAnimating(textBox1,
                                                (ControlAnimator.DrawMode)comboBox1.SelectedItem
                                                , panel1.BackColor, cbClockwise.Checked);
                        }
                        break;
                    case "SamplePictureBox":
                        if (!checkBox1.Checked)
                        {
                            ControlAnimator.StartAnimating(pictureBox1,
                                                (ControlAnimator.DrawMode)comboBox1.SelectedItem,
                                                (int)numericUpDown2.Value,
                                                (int)numericUpDown3.Value,
                                                (int)numericUpDown1.Value
                                                , panel1.BackColor, cbClockwise.Checked); 
                        }
                        else
                        {
                            ControlAnimator.StartAnimating(pictureBox1,
                                                (ControlAnimator.DrawMode)comboBox1.SelectedItem
                                                , panel1.BackColor, cbClockwise.Checked);
                        }
                        break;
                    case "SampleTreeView":
                        if (!checkBox1.Checked)
                        {
                            ControlAnimator.StartAnimating(treeView1,
                                                (ControlAnimator.DrawMode)comboBox1.SelectedItem,
                                                (int)numericUpDown2.Value,
                                                (int)numericUpDown3.Value,
                                                (int)numericUpDown1.Value
                                                , panel1.BackColor, cbClockwise.Checked); 
                        }
                        else
                        {
                            ControlAnimator.StartAnimating(treeView1,
                                                (ControlAnimator.DrawMode)comboBox1.SelectedItem
                                                , panel1.BackColor, cbClockwise.Checked);
                        }
                        break;
                    case "SampleGroupBox":
                        if (!checkBox1.Checked)
                        {
                            ControlAnimator.StartAnimating(groupBox3,
                                                (ControlAnimator.DrawMode)comboBox1.SelectedItem,
                                                (int)numericUpDown2.Value,
                                                (int)numericUpDown3.Value,
                                                (int)numericUpDown1.Value
                                                , panel1.BackColor, cbClockwise.Checked);
                        }
                        else
                        {
                            ControlAnimator.StartAnimating(groupBox3,
                                                (ControlAnimator.DrawMode)comboBox1.SelectedItem
                                                , panel1.BackColor, cbClockwise.Checked);
                        }
                        break;
                    case "Display":

                        ControlAnimator.FullScreenLock((ControlAnimator.DrawMode)comboBox1.SelectedItem
                                            , panel1.BackColor, cbClockwise.Checked);
                            timer1.Start();

                        break;
                }
               
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread.Sleep(5000);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ControlAnimator.StopAnimating(button4);
            ControlAnimator.StopAnimating(textBox1);
            ControlAnimator.StopAnimating(pictureBox1);
            ControlAnimator.StopAnimating(treeView1);
            ControlAnimator.StopAnimating(groupBox3);
            ControlAnimator.StopAnimating(IntPtr.Zero);            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
            }
            else
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = colorDialog1.Color;
            }
        }

        //Cancel flag
        private bool _isCanceled = false;

        /// <summary>
        /// Buttonclick startet a demoprozess.
        /// </summary>       
        private void button6_Click(object sender, EventArgs e)
        {
            //Randomizer for timedelays
            //(Just for demo use, please du not use!)
            var rnd = new Random();

            //Get a new WaitBox
            var diag = ControlAnimator.CreateWaitBox(0,0, "Begin", "Begin", "DemoOperation", cbClockwise.Checked);

            //Register the cancel event
            diag.Canceled += diag_Canceled;

            //Make the WaitBox visible
            diag.Show();

            //Do somethink and set status and progress
            var anz = 1;
            while (anz != 21 && !_isCanceled)
            {
                //Set status and progress
                diag.Status = @"Aktion " + anz + " von 20";
                diag.Value = anz * 5;

                int innerAnz = 1;
                while (innerAnz != 21 && !_isCanceled)
                {
                    //Set status and progress
                    diag.InnerStatus = @"Unteraktion " + innerAnz + " von 20";
                    diag.InnerValue = innerAnz * 5;

                    //Timedelay
                    //(Just for demo use, please du not use!)
                    Thread.Sleep(rnd.Next(10, 100));
                    Application.DoEvents();

                    innerAnz++;
                }

                //Timedelay
                //(Just for demo use, please du not use!)
                Thread.Sleep(rnd.Next(10, 100));
                Application.DoEvents();

                anz++;
            }

            //Progress finished, close WaitBox
            diag.Close();
        }

        /// <summary>
        /// CancelEventMethod
        /// </summary>       
        void diag_Canceled(object sender, EventArgs e)
        {
            //Set cancel flag to true
            _isCanceled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ControlAnimator.ReleaseFullScreenLock();
            timer1.Stop();
        }

       
    }
}
