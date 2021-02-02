public interface ILiveController
{
    int Damage { get; }

    void HitMe(int incomeDamage);
    void SetCurrentLives(int lives);
    int GetCurrentLives();
    void ResetLives();
}