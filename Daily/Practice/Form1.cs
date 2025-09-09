namespace Practice;

public partial class Form1 : Form
{
    private Random _rnd;
    private int _randomNum;
    
    public Form1()
    {
        InitializeComponent();
        _rnd = new Random();
        _randomNum = 0;
    }

    public void UIInitialize()
    {
        this.ClientSize = new Size(800, 800);
        Label numScreen = new Label();
        numScreen.Size = new Size(250, 100);
        numScreen.Location = new Point(525, 200);
        Button button1 = new Button();
        button1.Size = new Size(100, 50);
        button1.Location = new Point(275, 700);
        button1.Click += Button1_Click!;
    }

    public void SetRandom()
    {
        _randomNum = _rnd.Next(101); // 1 ~ 101 사이의 난수 할당
    }

    public void Button1_Click(object sender, EventArgs e)
    {
        
    }

    public void Button2_Click()
    {
        
    }
}