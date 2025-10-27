using Timer = System.Windows.Forms.Timer;

namespace _10_14;

public partial class Form1 : Form
{
    private int _hour;
    private int _minute;
    private int _second;
    private int _point;
    private Button _timerButton;
    private Button _stopButton;
    private Label _timeLabel;
    private readonly Timer _stopWatchTimer;
    private readonly Timer _timer;

    // private int _state;
    private bool _state;

    public Form1()
    {
        InitializeComponent();

        _stopWatchTimer = new Timer();
        _stopWatchTimer.Tick += StopWatchTimer_Tick!;
        _stopWatchTimer.Interval = 10;
        _timer = new Timer();
        _timer.Tick += Timer_Tick!;
        _timer.Interval = 10;
        _state = true;

        TimeReset();
        InitializeUI();
    }

    public void InitializeUI()
    {
        this.ClientSize = new Size(500, 300);
        this.BackColor = Color.Black;

        Label timeLabel = new Label();
        timeLabel.Size = new Size(200, 100);
        timeLabel.Location = new Point(190, 25);
        timeLabel.Name = "timeLabel";
        timeLabel.Text = "0:0:0.0";
        timeLabel.TextAlign = ContentAlignment.MiddleLeft;
        timeLabel.BackColor = Color.Black;
        timeLabel.ForeColor = Color.White;
        timeLabel.Font = new Font("맑은 고딕", 24f, FontStyle.Bold);
        _timeLabel = timeLabel;
        this.Controls.Add(timeLabel);

        Button timerButton = new Button();
        timerButton.Size = new Size(100, 50);
        timerButton.Location = new Point(300, 150);
        timerButton.Name = "startButton";
        timerButton.Text = "시작";
        timerButton.BackColor = Color.SkyBlue;
        timerButton.ForeColor = Color.White;
        timerButton.FlatStyle = FlatStyle.Flat;
        timerButton.Font = new Font("맑은 고딕", 14f, FontStyle.Bold);
        timerButton.Click += StartStopButton_Click!;
        _timerButton = timerButton;
        this.Controls.Add(timerButton);

        Button stopButton = new Button();
        stopButton.Size = new Size(100, 50);
        stopButton.Location = new Point(100, 150);
        stopButton.Name = "stopButton";
        stopButton.Text = "초기화";
        stopButton.BackColor = Color.DarkGray;
        stopButton.ForeColor = Color.White;
        stopButton.FlatStyle = FlatStyle.Flat;
        stopButton.Font = new Font("맑은 고딕", 14f, FontStyle.Bold);
        stopButton.Click += StopButton_Click!;
        stopButton.Visible = false;
        _stopButton = stopButton;
        this.Controls.Add(stopButton);

        Button stopWatchLabel = new Button();
        stopWatchLabel.Size = new Size(100, 50);
        stopWatchLabel.Location = new Point(145, 230);
        stopWatchLabel.Name = "stopWatchLabel";
        stopWatchLabel.Text = "스톱워치";
        stopWatchLabel.BackColor = Color.Black;
        stopWatchLabel.ForeColor = Color.White;
        stopWatchLabel.Font = new Font("맑은 고딕", 14f, FontStyle.Bold);
        stopWatchLabel.Tag = 1;
        stopWatchLabel.FlatStyle = FlatStyle.Flat;
        stopWatchLabel.Click += TabButtons_Click!;
        this.Controls.Add(stopWatchLabel);

        Button timerLabel = new Button();
        timerLabel.Size = new Size(100, 50);
        timerLabel.Location = new Point(255, 230);
        timerLabel.Name = "timerLabel";
        timerLabel.Text = "타이머";
        timerLabel.BackColor = Color.Black;
        timerLabel.ForeColor = Color.White;
        timerLabel.Font = new Font("맑은 고딕", 14f, FontStyle.Bold);
        timerLabel.Tag = 2;
        timerLabel.FlatStyle = FlatStyle.Flat;
        timerLabel.Click += TabButtons_Click!;
        this.Controls.Add(timerLabel);

        TextBox timerTextBox = new TextBox();
        timerTextBox.Size = new Size(50, 30);
        timerTextBox.Location = new Point(250, 50);
        timerTextBox.Name = "timerTextBox";
        timerTextBox.Text = "";
        // timerTextBox.BackColor = Color.Black;
        // timerTextBox.ForeColor = Color.White;
        timerTextBox.PlaceholderText = "asdfasdf";
        timerTextBox.Tag = 3;
        // timerTextBox.Visible = false;
        this.Controls.Add(timerTextBox);
    }

    public void TimeReset()
    {
        _point = 0;
        _minute = 0;
        _second = 0;
        _hour = 0;
    }

    public void ViewStopWatchUI()
    {
        _timeLabel.Text = "0:0:0.0";
        _timerButton.Text = "시작";
        _stopButton.Visible = false;
    }

    public void ViewTimerUI()
    {
        _timeLabel.Text = "";
        _timerButton.Text = "시작";
        _stopButton.Visible = false;

        Control textBox = this.Controls["timerTextBox"]!;
        textBox.Visible = true;
    }

    public void StopWatchTimer_Tick(object sender, EventArgs e)
    {
        _point++;

        if (_point >= 60)
        {
            _point = 0;
            _second++;
        }

        if (_second >= 60)
        {
            _second = 0;
            _minute++;
        }

        if (_minute >= 60)
        {
            _minute = 0;
            _hour++;
        }

        _timeLabel.Text = $"{_hour}:{_minute}:{_second}.{_point}";
    }

    public void Timer_Tick(object sender, EventArgs e)
    {
        _point--;

        if (_point < 0)
        {
            _point = 59;
            _second--;
        }

        if (_second < 0)
        {
            _second = 59;
            _minute--;
        }

        if (_minute < 0)
        {
            _minute = 59;
            _hour--;
        }

        _timeLabel.Text = $"{_hour}:{_minute}:{_second}:{_point}";
    }

    public void StartStopButton_Click(object sender, EventArgs e)
    {
        if (_stopWatchTimer.Enabled || _timer.Enabled)
        {
            Pause();
        }
        else
        {
            Start();
        }
    }

    public void Pause()
    {
        if (_state)
        {
            _stopWatchTimer.Stop();
        }
        else
        {
            _timer.Stop();
        }

        _timerButton.BackColor = Color.SkyBlue;
        _timerButton.Text = "계속";
    }

    public void Start()
    {
        if (_state)
        {
            _stopWatchTimer.Start();
        }
        else
        {
            _timer.Start();
        }

        _timerButton.BackColor = Color.Red;
        _timerButton.Text = "중지";
        _stopButton.Visible = true;
    }

    public void StopButton_Click(object sender, EventArgs e)
    {
        _stopWatchTimer.Stop();
        TimeReset();
        _stopButton.Visible = false;
        _timerButton.BackColor = Color.SkyBlue;
        _timerButton.Text = "시작";
        _timeLabel.Text = $"{_hour}:{_minute}:{_second}.{_point}";
    }

    public void TabButtons_Click(object sender, EventArgs e)
    {
        _stopWatchTimer.Stop();
        _timer.Stop();
        Control control;

        if (sender is Control)
        {
            control = sender as Control;
        }
        else
        {
            return;
        }

        if (control == null)
        {
            return;
        }

        switch (control.Tag)
        {
            default:
                MessageBox.Show("line 159 'control' not found");
                return;
            case 1:
                _state = true;
                ViewStopWatchUI();
                break;
            case 2:
                _state = false;
                ViewTimerUI();
                break;
        }
    }
}