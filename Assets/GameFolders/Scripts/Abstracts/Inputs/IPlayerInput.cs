namespace UdemyProject2.Abstracts.Inputs
{
    public interface IPlayerInput
    {
        float Horizontal { get;}
        float Vertical { get; }
        bool IsJump { get;}
    }
}