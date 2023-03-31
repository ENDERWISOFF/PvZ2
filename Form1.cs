using System.Drawing;
using System.Windows.Forms;
using static WinFormsApp8.Form1;

namespace WinFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Plant> plants = new List<Plant>();
        public void Form1_Load(object sender, EventArgs e)
        {
            int[,] board = new int[9, 5];

            // заполнение доски пустыми клетками
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    board[i, j] = 0;
                }
            }

            // Создание таблетопе для игрового процесса
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                Parent = this,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            // добавление элементов управления в ячейки
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Dock = DockStyle.Fill;
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                    // установка изображения в зависимости от значения в массиве
                    if (board[i, j] == 0)
                    {

                    }
                    else if (board[i, j] == 1)
                    {
                        pictureBox.Image = plantImage;
                    }
                    else if (board[i, j] == 2)
                    {
                        pictureBox.Image = peaImage;
                    }

                    // добавление обработчика события Click
                    pictureBox.Click += (sender, e) =>
                    {

                        // определение координат клетки
                        int x = tableLayoutPanel.GetColumn(pictureBox);
                        int y = tableLayoutPanel.GetRow(pictureBox);

                        // изменение значения в массиве и обновление изображения

                        if (board[x, y] == 0)
                        {
                            pictureBox.Image = plantImage;

                            Plant plant = new Plant(5, 2, 100, x, y);

                            plants.Add(plant);
                        }
                    };

                    tableLayoutPanel.Controls.Add(pictureBox, i, j);
                }
            }
        }
        
        public List<Pea> peas = new List<Pea>();
        public class Pea
        {
            public int Speed { get; set; }
            public int X { get; set; }
            public int Y { get; set; }

            private System.Windows.Forms.Timer timer;
            public Pea(int speed, int x, int y)
            {
                Speed = speed;
                X = x + Speed;
                Y = y;

                timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000;
                timer.Tick += Move;
                timer.Start();
            }
            public void Move(object sender, EventArgs e)
            {
                X += Speed;

                if (X > 9)
                {
                    timer.Stop();
                    timer.Dispose();
                    peas.Remove(this);
                }

            }
        }

        public class Plant
        {
            public int Health { get; set; }
            public int AttackPower { get; set; }
            public int SunPrice { get; set; }
            public int X { get; set; }
            public int Y { get; set; }

            private System.Windows.Forms.Timer timer;
            public Plant(int health, int attackPower, int sunPrice, int x, int y)
            {
                Health = health;
                AttackPower = attackPower;
                SunPrice = sunPrice;
                X = x;
                Y = y;

                timer = new System.Windows.Forms.Timer();
                timer.Interval = 3000;
                timer.Tick += Shoot;
                timer.Start();
            }
            public void Shoot(object sender, EventArgs e)
            {
                Pea pea = new Pea(1, X + 1, Y);

                peas.Add(pea);
            }
        }

        // Импорт картиночек

        Image plantImage = Image.FromFile("C:\\Users\\ENDERWIS\\Desktop\\PvZ Курсовая\\Peashooter.png");
        Image peaImage = Image.FromFile("C:\\Users\\ENDERWIS\\Desktop\\PvZ Курсовая\\Pea.png");

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (Plant plant in plants)
            {
                listBox1.Items.Add(Convert.ToString(plant.X + 1) + ", " + Convert.ToString(plant.Y + 1));
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
