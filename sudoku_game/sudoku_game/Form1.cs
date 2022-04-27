namespace sudoku_game
{
    using System.IO;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox t= new TextBox();
                    t.Multiline = true;
                    t.TextAlign = HorizontalAlignment.Center;
                    t.Font = new Font("Tahoma", 25);
                    t.Anchor = AnchorStyles.Left | AnchorStyles.Right |
                                AnchorStyles.Bottom | AnchorStyles.Top;
                    tableLayoutPanel1.Controls.Add(t,i,j);
                }
            }
        }
        private void button_new_game_Click(object sender, EventArgs e)
        {
            OpenFileDialog x = new OpenFileDialog();
            if(x.ShowDialog() == DialogResult.OK)
            {
                string File_path = x.FileName;
                StreamReader my_file_reader = new StreamReader(File_path);
                string big_text = my_file_reader.ReadToEnd();
                MessageBox.Show(big_text);
                char[] my_seperators = {' ','\n' };
                string[] numbers = big_text.Split(my_seperators);
            }
        }
    }
}