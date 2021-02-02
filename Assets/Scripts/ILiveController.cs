public interface ILiveController
{
    int Damage { get; }

    void GetHit(int incomeDamage);
    void SetCurrentLives(int lives);
    int GetCurrentLives();
    void ResetLives();
}