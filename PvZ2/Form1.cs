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

        }

        public class Plant
        {
            public int Health { get; set; }
            public int AttackPower { get; set; }
            public int SunPrice { get; set; }

            public Plant(int health, int attackPower, int sunPrice)
            {
                Health = health;
                AttackPower = attackPower;
                SunPrice = sunPrice;
            }
        }


        Plant Peashooter = new Plant(5, 2, 100);
        List<Point> plantLocations = new List<Point>();
        Image plantImage = Image.FromFile("C:\\Users\\ENDERWIS\\Desktop\\PvZ Курсовая\\Peashooter.png");

        int fieldX = 0;
        int fieldY = 0;
        int fieldWidth = 765;
        int fieldHeight = 425;
        int cellWidth = 85;
        int cellHeight = 85;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Рисуем игровое поле
            g.DrawRectangle(Pens.Black, fieldX, fieldY, fieldWidth, fieldHeight);
            for (int i = 1; i < 9; i++)
            {
                g.DrawLine(Pens.Black, fieldX + i * cellWidth, fieldY, fieldX + i * cellWidth, fieldY + fieldHeight);
            }
            for (int i = 1; i < 5; i++)
            {
                g.DrawLine(Pens.Black, fieldX, fieldY + i * cellHeight, fieldX + fieldWidth, fieldY + i * cellHeight);
            }

            // Рисуем растения
            Image plantImage = Image.FromFile("C:\\Users\\ENDERWIS\\Desktop\\PvZ Курсовая\\Peashooter.png");
            foreach (Point location in plantLocations)
            {
                g.DrawImage(plantImage, location);
            }
        }
        private void Form1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.X >= fieldX && e.X <= fieldX + fieldWidth && e.Y >= fieldY && e.Y <= fieldY + fieldHeight)
            {
                int cellX = (e.X - fieldX) / cellWidth;
                int cellY = (e.Y - fieldY) / cellHeight;
                int plantX = fieldX + cellX * cellWidth + cellWidth / 2 - plantImage.Width / 2;
                int plantY = fieldY + cellY * cellHeight + cellHeight / 2 - plantImage.Height / 2;
                plantLocations.Add(new Point(plantX, plantY));
                this.Invalidate();
            }
        }
    }
}