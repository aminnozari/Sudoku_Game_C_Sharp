namespace sudoku_game
{
    using System.IO;
    public partial class Form1 : Form
    {
        TextBox[,] cells;
        public Form1()
        {
            InitializeComponent();
            cells = new TextBox[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    cells[i, j] = new TextBox();
                    cells[i, j].Multiline = true;
                    cells[i, j].TextAlign = HorizontalAlignment.Center;
                    cells[i, j].Font = new Font("Tahoma", 25);
                    cells[i, j].Anchor = AnchorStyles.Left | AnchorStyles.Right |
                                AnchorStyles.Bottom | AnchorStyles.Top;
                    cells[i, j].BackColor = Color.MediumBlue;
                    tableLayoutPanel1.Controls.Add(cells[i, j], i, j);
                    cells[i, j].TextChanged += new System.EventHandler(this.cells_Change);
                }
            }
        }
        private void cells_Change(object sender, EventArgs e)
        {
            string Spil = this.ActiveControl.Text.ToString();
            if (Spil != "Open" &&
                Spil != "1" && Spil != "2" && Spil != "3" &&
                Spil != "4" && Spil != "5" && Spil != "6" &&
                Spil != "7" && Spil != "8" && Spil != "9" &&
                Spil != string.Empty)
            {
                this.ActiveControl.Text = string.Empty;
                MessageBox.Show("JUST 1 --- 9 ", "Enter One - Nine"
                    , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl.Text = string.Empty;
            }
        }
        //MenuHighlight
        private void button_new_game_Click(object sender, EventArgs e)
        {
            OpenFileDialog x = new OpenFileDialog();
            if (x.ShowDialog() == DialogResult.OK)
            {
                reset();//baraye reset kardan hengame
                string File_path = x.FileName;
                StreamReader my_file_reader = new StreamReader(File_path);
                string big_text = my_file_reader.ReadToEnd();
                //MessageBox.Show(big_text);
                char[] my_seperators = { ' ', '\r' };
                big_text = big_text.Replace("\n", "");
                string[] numbers = big_text.Split(my_seperators);
                int index = 0;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (numbers[index] != "0")
                        {
                            cells[j, i].ReadOnly = true;
                            cells[j, i].Text = numbers[index];
                            cells[j, i].BorderStyle = BorderStyle.FixedSingle;
                        }
                        index++;
                    }
                }
            }
        }
        private void reset()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    cells[j, i].ReadOnly = false;
                    cells[j, i].Text = "";
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int list;
            int[] row;
            int[] colom;
            int[] sq;
            for (int i = 0; i < 9; i++)
            {
                row = new int[9];
                colom = new int[9];
                for (int j = 0; j < 9; j++)
                {
                    if (cells[i, j].Text != "" && cells[i, j].Text != "")
                    {
                        int cellrow = Convert.ToInt16(cells[j, i].Text);
                        int cellcolom = Convert.ToInt16(cells[i, j].Text);
                        if (0 < cellrow && cellrow < 10 && !row.Contains(cellrow) &&
                             0 < cellcolom && cellcolom < 10 && !colom.Contains(cellcolom))
                        {
                            row[j] = cellrow;
                            colom[i] = cellcolom;
                            continue;
                        }
                    }
                    MessageBox.Show("Try harder");
                    return;
                }
            }
            for (int k = 1, b1 = 0, d1 = 3, b2 = 0, d2 = 3; k <= 9; k++, b2 += 3, d2 += 3)

            {
                if ((k - 1) % 3 == 0)

                {
                    b2 = 0;
                    d2 = 3;
                }
                sq = new int[9];
                list = 0;
                for (int i = b1; i < d1; i++)

                {
                    for (int j = b2; j < d2; j++)

                    {
                        int cell = Convert.ToInt16(cells[j, i].Text);
                        if (!sq.Contains(cell))
                        {
                            sq[list++] = cell;
                            continue;
                        }
                        MessageBox.Show("Try More...");
                        return;
                    }
                }
                if (k % 3 == 0)
                {
                    b1 += 3;
                    d1 += 3;
                }
            }
            MessageBox.Show("YOU WIN");
        }
    }
}
