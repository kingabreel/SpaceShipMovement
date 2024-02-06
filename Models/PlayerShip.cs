

using Avalonia.Controls;
using Avalonia.Media.Imaging;

public class PlayerShip
{
    private double playerLeft;
    public int Width {  get { return 120; } }
    public int Height { get { return 120; } }

    public double PlayerLeft
    {
        get { return playerLeft; }
        set
        {
            if (playerLeft != value)
            {
                playerLeft = value;
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
            }
        }
    }

    private Image playerImage;
    public Image PlayerImage
    {
        get { return playerImage; }
        set 
        {
            if (playerImage != value)
            {
                playerImage = value;
            }
        }
    }

    public PlayerShip(double left, double top, string image)
    {
        playerLeft = left;
        playerTop = top;
        playerImage = new Image
        { 
            Source = new Bitmap(image),
            Width = Width,
            Height = Height
        };
    }


}