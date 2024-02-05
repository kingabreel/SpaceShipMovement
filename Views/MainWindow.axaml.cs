using System;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using Lab_IV.ViewModels;

namespace Lab_IV.Views;

public partial class MainWindow : Window
{
    private Image PlayerImage;
    private MainWindowViewModel mainViewlModel;
    public MainWindow()
    {
        InitializeComponent();
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        PlayerImage = new Image {
            Source = new Bitmap("./Assets/Frames/player.png"),
            Width = 50,
            Height = 50,
        };

        Canvas screen = this.FindControl<Canvas>("Foguetinho");

        screen.Children.Add(PlayerImage);

        Canvas.SetLeft(PlayerImage, 175);
        Canvas.SetTop(PlayerImage, 175);

        mainViewlModel = new MainWindowViewModel();

        KeyDown += mainViewlModel.MainWindow_KeyDown;
        KeyUp += mainViewlModel.MainWindow_KeyUp;
        var timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromMilliseconds(100); 
        timer.Tick += (sender, e) => {mainViewlModel.MovePlayer(); Canvas.SetLeft(PlayerImage,mainViewlModel.PlayerLeft); Canvas.SetTop(PlayerImage, mainViewlModel.PlayerTop);};
        timer.Start();
    }
}