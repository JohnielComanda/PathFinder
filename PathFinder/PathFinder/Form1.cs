using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PathFinder
{
    public partial class PathFinder : Form
    {
        private List<Button> buttons;
        private Button _start;
        private Button _goal;

        public PathFinder()
        {
            InitializeComponent();
        }

        private void CreateObstacle(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                var button = (Button)sender;
                button.Text = " ";
                button.Enabled = false;
                button.BackColor = Color.AliceBlue;
            }
        }

        private void FindPath(object sender, EventArgs e)
        {
            buttons = LoadButtons();

            Stack<Button> visited = new Stack<Button>();
            Stack<Button> stack = new Stack<Button>();
            
            var start = Int32.Parse(textBox1.Text) - 1;
            var goal = Int32.Parse(textBox2.Text) - 1;
            var curr = start;     

            // render start button
            _start = buttons[start];
            _start.Text = "S";
            _start.BackColor = Color.Green;
            _start.Enabled = false;
            // render goal button
            _goal = buttons[goal];
            _goal.Text = "G";
            _goal.BackColor = Color.Red;
            _goal.Enabled = false;

            visited.Push(buttons[start]);

            int ctr = 0;
            while(curr != goal)
            {
                ctr++;
                if(curr >= 0 && curr <= 79) 
                {
                    buttons[curr].BackColor = Color.CornflowerBlue;

                    // up
                    if (curr > 9)
                    {
                        if ((!visited.Contains(buttons[curr - 10])) && buttons[curr - 10].Enabled == true)
                        {
                            stack.Push(buttons[curr - 10]);
                        }
                    }
                    // down
                    if (curr < 70)
                    {
                        if ((!visited.Contains(buttons[curr + 10])) && buttons[curr + 10].Enabled == true)
                        {
                            stack.Push(buttons[curr + 10]);
                        }
                    }
                    // left
                    if (!(curr % 10 == 0))
                    {
                        if ((!visited.Contains(buttons[curr - 1])) && buttons[curr - 1].Enabled == true)
                        {
                            stack.Push(buttons[curr - 1]);
                        }
                    }
                    // right
                    if (!((curr + 1) % 10 == 0))
                    {
                        if ((!visited.Contains(buttons[curr + 1])) && buttons[curr + 1].Enabled == true)
                        {
                            stack.Push(buttons[curr + 1]);
                        }
                    }
                }            
                if (stack.Count > 0)
                {
                    Button temp = stack.Pop();
                    visited.Push(temp);
                }               
                // update value of curr
                curr = (Int32.Parse(visited.Peek().Text));         
            }
            label3.Text += ctr;
        }

        private List<Button> LoadButtons()
        {
            var listButtons = new List<Button>()
            {
                button1, button2, button3, button4, button5, button6, button7, button8, button9, button10,
                button11, button12, button13, button14, button15, button16, button17, button18, button19, button20,
                button21, button22, button23, button24, button25, button26, button27, button28, button29, button30,
                button31, button32, button33, button34, button35, button36, button37, button38, button39, button40,
                button41, button42, button43, button44, button45, button46, button47, button48, button49, button50,
                button51, button52, button53, button54, button55, button56, button57, button58, button59, button60,
                button61, button62, button63, button64, button65, button66, button67, button68, button69, button70,
                button71, button72, button73, button74, button75, button76, button77, button78, button79, button80
            };
            return listButtons;
        }
    }
}
