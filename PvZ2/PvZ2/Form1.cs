namespace PvZ2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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

            // создание TableLayoutPanel
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.ColumnCount = 9;
            tableLayoutPanel.RowCount = 5;
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            // загрузка изображений
            Image plantImage = Image.FromFile("C:\\Users\\ENDERWIS\\Desktop\\PvZ Курсовая\\Peashooter.png");
            Image peaImage = Image.FromFile("C:\\Users\\ENDERWIS\\Desktop\\PvZ Курсовая\\Pea.png");

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
                        int column = tableLayoutPanel.GetColumn(pictureBox);
                        int row = tableLayoutPanel.GetRow(pictureBox);

                        // изменение значения в массиве и обновление изображения
                        if (board[column, row] == 0)
                        {
                            board[column, row] = 1;
                            pictureBox.Image = plantImage;
                        }
                    };

                    tableLayoutPanel.Controls.Add(pictureBox, i, j);
                }
            }

            // добавление TableLayoutPanel на форму
            this.Controls.Add(tableLayoutPanel);
        }

        public class Plant
        {
            public int Health { get; set; }
            public int AttackPower { get; set; }
            public int SunPrice { get; set; }
            public int NameBoard { get; set; }

            public Plant(int health, int attackPower, int sunPrice, int nameBoard)
            {
                Health = health;
                AttackPower = attackPower;
                SunPrice = sunPrice;
                NameBoard = nameBoard;
            }
        }
        public class Peashooter : Plant
        {
            public Peashooter() : base(5, 2, 100, 1)
            {
                // инициализация свойств Peashooter
            }
            public void Shoot()
            {

            }
        }

        public class Pea
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Pea(int x, int y)
            {
                X = x;
                Y = y;
            }

            public void Move()
            {
                X += 1;
            }
        }

        Image plantImage = Image.FromFile("C:\\Users\\ENDERWIS\\Desktop\\PvZ Курсовая\\Peashooter.png");


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
        }
        private void Form1_MouseDown_1(object sender, MouseEventArgs e)
        {

        }
    }
}