using System;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using Lab_IV.ViewModels;
using NetCoreAudio;

namespace Lab_IV.Views;

public partial class MainWindow : Window
{
    private Image PlayerImage;
    private int playerFrame = 1;
    private MainWindowViewModel mainViewlModel;
    public MainWindow()
    {
        InitializeComponent();
        CreatePlayer();
        mainViewlModel.playerMovement += PlayerHitHandler;
    }

    private void CreatePlayer()
    {

        PlayerShip player = new PlayerShip(175, 175, "./Assets/Frames/player.png");

        Canvas screen = this.FindControl<Canvas>("Foguetinho");

        screen.Children.Add(player.PlayerImage);

        Canvas.SetLeft(player.PlayerImage, player.PlayerLeft);
        Canvas.SetTop(player.PlayerImage, player.PlayerTop);

        mainViewlModel = new MainWindowViewModel();

        mainViewlModel.SetImage(player.PlayerImage);
        KeyDown += mainViewlModel.MainWindow_KeyDown;
        KeyUp += mainViewlModel.MainWindow_KeyUp;
        var timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromMilliseconds(100); 
        timer.Tick += (sender, e) => {
            mainViewlModel.MovePlayer(); 
            Canvas.SetLeft(player.PlayerImage,mainViewlModel.PlayerLeft); 
            Canvas.SetTop(player.PlayerImage, mainViewlModel.PlayerTop); 
            player.PlayerImage.RenderTransform = new RotateTransform(mainViewlModel.RotationAngle); 
        };
        timer.Start();
    }

    private void Sound()
    {
        var sound = new Player();
        sound.Play("./Assets/Sounds/move.wav");
    }

    private async void PlayerHitHandler(Image player)
    {
        player.Source = UpdateFrame();
        Sound();
    }
    
    private Bitmap UpdateFrame()
    {
        switch (playerFrame)
        {
            case 1:
                playerFrame = 2;
                return new Bitmap("./Assets/Frames/player.png");
            case 2:
                playerFrame = 1;
                return new Bitmap("./Assets/Frames/player2.png");
            default:
                return new Bitmap("./Assets/Frames/player.png");
        }
    }
}