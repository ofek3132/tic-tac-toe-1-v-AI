using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        public int turns = 0; //the number of turns
        public int s1 = 0; //player wins
        public int s2 = 0; //AI wins
        public int sd = 0; //draws
        public bool onturn = true; //true - players turn /false - cpu trun

        public Form1()
        {
            InitializeComponent();
        }
        //CPU
        public Button CPU()
        {
            Button b = null;
            if (dumbAI.Checked)
            {
                b = CPUMoveRandom();
                return b;
            }
            else
            {
                b = tryToWinOrDefend("o");
                if (b != null)
                    return b;
                else
                {
                    b = tryToWinOrDefend("x");
                    if (b != null)
                        return b;
                    else
                    {
                        b = CPUMoveRandom();
                        return b;
                    }
                }
            }
            return null;

        }
        //CPU try to win or defend move
        public Button tryToWinOrDefend(String s)
        {
            //horizonal
            if (A00.Text == A01.Text && A00.Text == s && A02.Text == "")
                return A02;
            else if (A00.Text == A02.Text && A00.Text == s && A01.Text == "")
                return A01;
            else if (A01.Text == A02.Text && A01.Text == s && A00.Text == "")
                return A00;
            else if (A10.Text == A11.Text && A10.Text == s && A12.Text == "")
                return A12;
            else if (A10.Text == A12.Text && A10.Text == s && A11.Text == "")
                return A11;
            else if (A11.Text == A12.Text && A11.Text == s && A10.Text == "")
                return A10;
            else if (A20.Text == A21.Text && A20.Text == s && A22.Text == "")
                return A22;
            else if (A20.Text == A22.Text && A20.Text == s && A21.Text == "")
                return A21;
            else if (A21.Text == A22.Text && A21.Text == s && A20.Text == "")
                return A20;
            //vertical
            else if (A00.Text == A10.Text && A00.Text == s && A20.Text == "")
                return A20;
            else if (A00.Text == A20.Text && A00.Text == s && A10.Text == "")
                return A10;
            else if (A10.Text == A20.Text && A10.Text == s && A00.Text == "")
                return A00;
            else if (A01.Text == A11.Text && A01.Text == s && A21.Text == "")
                return A21;
            else if (A01.Text == A21.Text && A01.Text == s && A11.Text == "")
                return A11;
            else if (A11.Text == A21.Text && A11.Text == s && A01.Text == "")
                return A01;
            else if (A02.Text == A12.Text && A02.Text == s && A22.Text == "")
                return A22;
            else if (A02.Text == A22.Text && A02.Text == s && A12.Text == "")
                return A12;
            else if (A12.Text == A22.Text && A12.Text == s && A02.Text == "")
                return A02;
            //other
            else if (A00.Text == A11.Text && A00.Text == s && A22.Text == "")
                return A22;
            else if (A00.Text == A22.Text && A00.Text == s && A11.Text == "")
                return A11;
            else if (A11.Text == A22.Text && A11.Text == s && A00.Text == "")
                return A00;
            else if (A02.Text == A11.Text && A02.Text == s && A20.Text == "")
                return A20;
            else if (A02.Text == A20.Text && A02.Text == s && A11.Text == "")
                return A11;
            else if (A11.Text == A20.Text && A11.Text == s && A02.Text == "")
                return A02;

            else
                return null;
        }
        //CPU random move
        public Button CPUMoveRandom()
        {
            Button b = null;
            Random rnd = new Random();
            again:
            int num = rnd.Next(1, 10);
            switch (num)
            {
                case 1:
                    if (A00.Text == "")
                        return A00;
                    else
                        goto again;
                    break;
                case 2:
                    if (A01.Text == "")
                        return A01;
                    else
                        goto again;
                    break;
                case 3:
                    if (A02.Text == "")
                        return A02;
                    else
                        goto again;
                    break;
                case 4:
                    if (A10.Text == "")
                        return A10;
                    else
                        goto again;
                    break;
                case 5:
                    if (A11.Text == "")
                        return A11;
                    else
                        goto again;
                    break;
                case 6:
                    if (A12.Text == "")
                        return A12;
                    else
                        goto again;
                    break;
                case 7:
                    if (A20.Text == "")
                        return A20;
                    else
                        goto again;
                    break;
                case 8:
                    if (A21.Text == "")
                        return A21;
                    else
                        goto again;
                    break;
                case 9:
                    if (A22.Text == "")
                        return A22;
                    else
                        goto again;
                    break;
            }
            return null;

        }
        // setting the labels
        private void Form1_Load(object sender, EventArgs e)
        {
            scoreUpdate();
        }
        //score update
        public void scoreUpdate()
        {
            xWins.Text = "you: " + s1;
            oWins.Text = "CPU: " + s2;
            draws.Text = "draws: " + sd;
        }
        //exit button
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //o / x buttons
        private void buttonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "")
            {
                if (onturn)
                    button.Text = "x";
                else
                    button.Text = "o";
                onturn = !onturn;
                turns++;
                if (checkDraw() == true)
                {
                    MessageBox.Show("It's a tie!");
                    sd++;
                    scoreUpdate();
                    newGame();
                }
                if (checkWinner() == true)
                {
                    if (button.Text == "x")
                    {
                        MessageBox.Show("You win!");
                        s1++;
                        scoreUpdate();
                        newGame();
                    }
                    else
                    {
                        MessageBox.Show("CPU wins!");
                        s2++;
                        scoreUpdate();
                        newGame();
                    }
                }
                if (!onturn)
                {
                    CPU().PerformClick();
                }
            }
        }
        //new game
        public void newGame()
        {
            onturn = true;
            turns = 0;
            A00.Text = A01.Text = A02.Text = A10.Text = A11.Text = A12.Text = A20.Text = A21.Text = A22.Text = "";
        }
        //checks if a draw
        public bool checkDraw()
        {
            if (turns == 9 && checkWinner() == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //checks who is the winner
        public bool checkWinner()
        {
            if (A00.Text == A01.Text && A01.Text == A02.Text && A00.Text != "")
                return true;
            else if (A10.Text == A11.Text && A11.Text == A12.Text && A10.Text != "")
                return true;
            else if (A20.Text == A21.Text && A21.Text == A22.Text && A20.Text != "")
                return true;
            else if (A00.Text == A10.Text && A10.Text == A20.Text && A00.Text != "")
                return true;
            else if (A01.Text == A11.Text && A11.Text == A21.Text && A01.Text != "")
                return true;
            else if (A02.Text == A12.Text && A12.Text == A22.Text && A02.Text != "")
                return true;
            else if (A00.Text == A11.Text && A11.Text == A22.Text && A00.Text != "")
                return true;
            else if (A02.Text == A11.Text && A11.Text == A20.Text && A02.Text != "")
                return true;
            else
                return false;
        }
        //New game button click
        private void newGameButton_Click(object sender, EventArgs e)
        {
            newGame();
        }
        //Reset button clicked
        private void resetButton_Click(object sender, EventArgs e)
        {
            onturn = true;
            turns = 0;
            s1 = 0;
            s2 = 0;
            sd = 0;
            A00.Text = A01.Text = A02.Text = A10.Text = A11.Text = A12.Text = A20.Text = A21.Text = A22.Text = "";
            scoreUpdate();
        }
    }
}
