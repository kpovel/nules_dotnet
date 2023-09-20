namespace lab3;

public class Form1 : Form
{
    List<RightPentagon> pentagons = new List<RightPentagon>();

    public Form1()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        _buttonCreatePentagon = new Button();
        SuspendLayout();
        _buttonCreatePentagon.Location = new Point(12, 12);
        _buttonCreatePentagon.Name = "_buttonCreatePentagon";
        _buttonCreatePentagon.Size = new Size(180, 60);
        _buttonCreatePentagon.TabIndex = 0;
        _buttonCreatePentagon.Text = "Create Pentagon";
        _buttonCreatePentagon.UseVisualStyleBackColor = true;
        _buttonCreatePentagon.Click += buttonCreatePentagon_Click;
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(_buttonCreatePentagon);
        Name = "Form1";
        Text = "Pentagon App";
        ResumeLayout(false);
    }

    private Button _buttonCreatePentagon;


    private void buttonCreatePentagon_Click(object sender, EventArgs e)
    {
        Color randomColor = Color.FromArgb(new Random().Next(257), new Random().Next(256), new Random().Next(256));
        RightPentagon pentagon = new RightPentagon(30 + 10 * RightPentagon.InstanceCount, randomColor,
            new Point(50 + 100 * RightPentagon.InstanceCount, 100 + 50 * RightPentagon.InstanceCount)
        );
        pentagons.Add(pentagon);
        Invalidate(); // This will trigger the OnPaint event
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        foreach (var pentagon in pentagons)
        {
            using (SolidBrush brush = new SolidBrush(pentagon.ShapeColor))
            {
                // Define the points of the pentagon
                PointF[] points = new PointF[5];
                float angle = (float)(Math.PI / 2); // Start at 90 degrees for the bottom left vertex
                for (int i = 0; i < 5; i++)
                {
                    points[i] = new PointF(
                        pentagon.Location.X + pentagon.SideLength * (float)Math.Cos(angle),
                        pentagon.Location.Y + pentagon.SideLength * (float)Math.Sin(angle)
                    );
                    angle -= (float)(2 * Math.PI / 5); 
                }

                e.Graphics.FillPolygon(brush, points);
            }
        }
    }


    private class RightPentagon
    {
        public static int InstanceCount;

        public float SideLength { get; }
        public Color ShapeColor { get; }
        public Point Location { get; }

        public RightPentagon(float sideLength, Color color, Point location)
        {
            SideLength = sideLength;
            ShapeColor = color;
            Location = location;
            InstanceCount++;
        }
    }
}