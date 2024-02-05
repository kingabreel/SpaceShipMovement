using Avalonia.Input;
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


    private bool isMovingLeft;
    private bool isMovingRight;
    private bool isMovingUp;
    private bool isMovingDown;
    private int playerSpeed = 10;

    public MainWindowViewModel()
    {
        PlayerLeft = 175; 
        PlayerTop = 175; 

    }
    

        public void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    isMovingLeft = true;
                    break;
                case Key.Right:
                    isMovingRight = true;
                    break;
                case Key.Up:
                    isMovingUp = true;
                    break;
                case Key.Down:
                    isMovingDown = true;
                    break;

            }
        }

        public void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
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

    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

        #endregion
}
