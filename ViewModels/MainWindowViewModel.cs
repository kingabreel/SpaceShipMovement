using Avalonia.Controls;
using Avalonia.Input;
using System;
using System.ComponentModel;

namespace Lab_IV.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private double playerLeft;
    public double PlayerLeft
    {
        get { return playerLeft; }
        set
        {
            if (playerLeft != value)
            {
                playerLeft = value;
                OnPropertyChanged(nameof(PlayerLeft));
            }
        }
    }

    private double playerTop;
    public double PlayerTop
    {
        get { return playerTop; }
        set
        {
            if (playerTop != value)
            {
                playerTop = value;
                OnPropertyChanged(nameof(playerTop));
            }
        }
    }

        private double rotationAngle; 
        public double RotationAngle
        {
            get { return rotationAngle; }
            set
            {
                if (rotationAngle != value)
                {
                    rotationAngle = value;
                    OnPropertyChanged(nameof(RotationAngle));
                }
            }
        }


    private bool isMovingLeft;
    private bool isMovingRight;
    private bool isMovingUp;
    private bool isMovingDown;
    private int playerSpeed = 10;
    private Image player;
    public event Action<Image> playerMovement;

    public MainWindowViewModel()
    {
        PlayerLeft = 175; 
        PlayerTop = 175; 
    }

    public void SetImage(Image PlayerImage)
    {
        player = PlayerImage;
    }
    

        public void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            UpdateRotationAngle(e.Key);
            switch (e.Key)
            {
                case Key.Left:
                    isMovingLeft = true;
                    playerMovement?.Invoke(player);
                    break;
                case Key.Right:
                    isMovingRight = true;
                    playerMovement?.Invoke(player);
                    break;
                case Key.Up:
                    isMovingUp = true;
                    playerMovement?.Invoke(player);
                    break;
                case Key.Down:
                    isMovingDown = true;
                    playerMovement?.Invoke(player);
                    break;

            }
        }

        public void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateRotationAngle(e.Key); 
            switch (e.Key)
            {
                case Key.Left:
                    isMovingLeft = false;
                    break;
                case Key.Right:
                    isMovingRight = false;
                    break;
                case Key.Up:
                    isMovingUp = false;
                    break;
                case Key.Down:
                    isMovingDown = false;
                    break;
            }
        }

    public void MovePlayer()
    {   
        if (isMovingLeft && PlayerLeft - playerSpeed > 0)
        {
            PlayerLeft -= playerSpeed;
        }
        if (isMovingRight && PlayerLeft + playerSpeed < 350)
        {
            PlayerLeft += playerSpeed;
        }
        if (isMovingDown && PlayerTop + playerSpeed < 350)
        {
            PlayerTop += playerSpeed;
        }
        if (isMovingUp && PlayerTop - playerSpeed > 0)
        {
            PlayerTop -= playerSpeed;
        }
    }

        private void UpdateRotationAngle(Key key)
        {
            switch (key)
            {
                case Key.Left:
                    RotationAngle = 270; 
                    isMovingLeft = true;
                    break;
                case Key.Right:
                    RotationAngle = 90; 
                    isMovingRight = true;
                    break;
                case Key.Up:
                    RotationAngle = 0; 
                    isMovingUp = true;
                    break;
                case Key.Down:
                    RotationAngle = 180; 
                    isMovingDown = true;
                    break;
                default:
                    break;
            }
        }


    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

        #endregion
}
